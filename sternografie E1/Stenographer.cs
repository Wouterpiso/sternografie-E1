using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sternografie_E1
{
    public partial class Stenographer : Form
    {
        const int ONE_KB = 1024;

        public enum State
        {
            Hiding,
            Filling_With_Zeros
        };

        public static int reverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }

        public Stenographer()
        {
            InitializeComponent();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (secretTextTbx.Text == "Write your secret text here...")
            {
                secretTextTbx.Text = "";
                secretTextTbx.ForeColor = Color.Black;
            }
        }

        private void ImageUploadBtn_Click(object sender, EventArgs e)
        {
            //upload image from local file
            ofd.ShowDialog();
            string filePath = ofd.FileName;
            imageLoaderPb.ImageLocation = filePath;
        }

        private void encodeBtn_Click(object sender, EventArgs e)
        {
            if (imageLoaderPb.Image == null)
            {
                MessageBox.Show("please upload an image");
            }
            else if (secretTextTbx.Text == "" || secretTextTbx.Text == "Write your secret text here...")
            {
                MessageBox.Show("please write a secret text");
            }
            else
            {
                //size check (checks the size of the image against the size of the secret text)
                double textsize = (8 * ((imageLoaderPb.Height * (imageLoaderPb.Width / 3) * 3) / 3 - 1)) / 1024;
                string messageText = secretTextTbx.Text;
                double textlength = System.Text.ASCIIEncoding.ASCII.GetByteCount(messageText);
                double textlen = textlength / 1024;
                if (textsize < textlen)
                {
                    MessageBox.Show("Image cannot save text more than" + textsize + "KB");
                }
                else
                {
                    //encoder
                        
                    //all statements that are going to be used
                    State state = State.Hiding;
                    int charIndex = 0;
                    int charValue = 0;
                    long pixelElementIndex = 0;
                    int zeros = 0;
                    int R = 0, G = 0, B = 0;
                    Image img = null;

                    // make the Bitmap of the image
                    Bitmap bmp = new Bitmap(imageLoaderPb.Image);

                    // go through the rows of the image
                    for (int height = 0;  height < bmp.Height; height++)
                    {
                        //go through each pixel within the row
                        for (int width = 0; width < bmp.Width; width++)
                        {
                            //current pixel that is being worked on
                            Color pixel = bmp.GetPixel(width, height);

                            //for clearing the LSB
                            R = pixel.R - pixel.R % 2;
                            G = pixel.G - pixel.G % 2;
                            B = pixel.B - pixel.B % 2;

                            //goes through the R then G then B
                            for (int nmb = 0; nmb < 3; nmb++)
                            {
                                //check if the program has gone through all 8 bits
                                if (pixelElementIndex % 8 == 0)
                                {
                                    //check if the whole process has finished
                                    if (state == State.Filling_With_Zeros && zeros == 8)
                                    {
                                        //apply the last pixel on the image
                                        if ((pixelElementIndex - 1) % 3 < 2)
                                        {
                                            bmp.SetPixel(width, height, Color.FromArgb(R, G, B));

                                        }
                                        img = bmp;
                                    }
                                    //check if all characters are hidden
                                    if (charIndex >= messageText.Length)
                                    {
                                        //starts adding zero's at the end
                                        state = State.Filling_With_Zeros;
                                    }
                                    else
                                    {
                                        //move to the next character
                                        charValue = messageText[charIndex++];
                                    }
                                }

                                // check which pixel element has the turn to hide a bit in its LSB
                                switch (pixelElementIndex % 3)
                                {
                                    case 0:
                                        {
                                            if (state == State.Hiding)
                                            {
                                                R += charValue % 2;
                                                charValue /= 2;
                                            }
                                        } break; 
                                    case 1:
                                        {
                                            if (state == State.Hiding)
                                            {
                                                G += charValue % 2;
                                                charValue /= 2;
                                            }
                                        }
                                        break; 
                                    case 2:
                                        {
                                            if (state == State.Hiding)
                                            {
                                                B += charValue % 2;
                                                charValue /= 2;
                                            }
                                            bmp.SetPixel(width, height, Color.FromArgb(R, G, B));
                                        } break;
                                }
                                pixelElementIndex++;

                                if (state == State.Filling_With_Zeros)
                                {
                                    //increment the value untill its 8
                                    zeros++;
                                }
                            }
                        }
                    }
                    img = bmp;

                    //save the encoded image
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "Image Files (*.png) | *.png";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        imageLoaderPb.Text = saveFile.FileName.ToString();
                        imageLoaderPb.ImageLocation = imageLoaderPb.Text;
                        img.Save(imageLoaderPb.Text);

                    }
                    else
                    {
                        MessageBox.Show("Error: file path not valid or no file path.");
                    }
                }
            }
        }
        private void decodeBtn_Click(object sender, EventArgs e)
        {
            if (imageLoaderPb.Image == null)
            {
                MessageBox.Show("please upload an image");
            }
            else
            {
                //decoder

                //all statements that are going to be used
                int colorUnitIndex = 0;
                int charValue = 0;
                Bitmap bmp = new Bitmap(imageLoaderPb.Image);

                // holds the text that will be extracted from the image
                string extractedText = String.Empty;

                // go through the rows of the image
                for (int height = 0; height < bmp.Height; height++)
                {
                    //go through each pixel within the row
                    for (int width = 0; width < bmp.Width; width++)
                    {
                        //current pixel that is being worked on
                        Color pixel = bmp.GetPixel(width, height);

                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    charValue = charValue * 2 + pixel.R % 2;
                                }break;
                            case 1:
                                {
                                    charValue = charValue * 2 + pixel.G % 2;
                                }break;
                            case 2:
                                {
                                    charValue = charValue * 2 + pixel.B % 2;
                                }
                                break;
                        }

                        colorUnitIndex++;

                        //check if 8 bits have been added and if so then add a character.
                        if (colorUnitIndex % 8 == 0)
                        {

                            charValue = reverseBits(charValue);

                            // can only be 0 if it is the stop character (the 8 zeros)
                            if (charValue == 0)
                            {
                                outputLb.Text = extractedText;
                            }

                            // convert the character value from int to char
                            char c = (char)charValue;

                            // add the current character to the result text
                            extractedText += c.ToString();
                        }

                    }
                }
                outputLb.Text = extractedText;
            }
        }

        private void keyTbx_MouseClick(object sender, MouseEventArgs e)
        {
            if (secretTextTbx.Text == "Write the key here to decode...")
            {
                secretTextTbx.Text = "";
            }
        }
    }
}
