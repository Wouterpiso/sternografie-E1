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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sternografie_E1
{
    public partial class Stenographer : Form
    {
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
                double textsize = (8.0 * ((imageLoaderPb.Height * (imageLoaderPb.Width / 3) * 3) / 3 - 1)) / 1024;
                string messageText = secretTextTbx.Text;
                double textlength = System.Text.ASCIIEncoding.ASCII.GetByteCount(messageText);
                double textlen = textlength / 1024;

                if (textsize < textlen)
                {
                    MessageBox.Show("Image cannot save text more than" + textsize + "KB");
                }
                else
                {
                    Bitmap img = new Bitmap(imageLoaderPb.Image);
                    for (int width = 0; width < imageLoaderPb.Width; width++)
                    {
                        for (int height = 0; height < imageLoaderPb.Height; height++)
                        {
                            Color pixel = img.GetPixel(width, height);
                            if (width < 1 && height < secretTextTbx.TextLength)
                            {
                                Console.WriteLine("R= [" + width + "][" + height + "]=" + pixel.R);
                                Console.WriteLine("G= [" + width + "][" + height + "]=" + pixel.G);
                                Console.WriteLine("B= [" + width + "][" + height + "]=" + pixel.B);

                                char letter = Convert.ToChar(secretTextTbx.Text.Substring(height, 1));
                                int value = Convert.ToInt32(letter);
                                Console.WriteLine("letter :" + letter + " value :" + value);
                                img.SetPixel(width, height, Color.FromArgb(pixel.R, pixel.G, value));
                            }
                            if (width == img.Width - 1 && height == img.Height - 1)
                            {
                                img.SetPixel(width, height, Color.FromArgb(pixel.R, pixel.G, secretTextTbx.TextLength));
                            }
                        }
                    }
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
                Bitmap img = new Bitmap(imageLoaderPb.Image);
                String msg = "";
                Color lastpixel = img.GetPixel(img.Width - 1, img.Height - 1);
                int msgLength = lastpixel.B;

                for (int width = 0; width < img.Width; width++)
                {
                    for (int height = 0; height < img.Height; height++)
                    {
                        Color pixel = img.GetPixel(width, height);
                        if (width < 1 && height < msgLength)
                        {
                            int value = pixel.B;
                            char c = Convert.ToChar(value);

                            String letter = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                            Console.WriteLine("letter : " + letter + " value : " + value);
                            msg = msg + letter;
                        }   
                    }
                }
                outputLb.Text = msg;
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
