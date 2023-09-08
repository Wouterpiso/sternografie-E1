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
                try
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
                        //encoder

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
                catch(Exception exc) {
                    MessageBox.Show("error: " + exc);
                    throw;
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
