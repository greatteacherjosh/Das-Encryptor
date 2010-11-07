using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasEncryptor
{
    public partial class Form1 : Form
    {
        String saltAES = "y+(Y2!n&)G^or0uca-";
        Boolean firstEnter = true;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.UseSystemPasswordChar == false)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
            }
            else
            {
                Encrypt(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.UseSystemPasswordChar == false)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
            }
            else
            {
                Decrypt(false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void pasteTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
        }

       private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               /* Decrypt(true);
                if (label1.Visible == false && label2.Visible == false && label3.Visible == false)
                {*/
                    e.Handled = true;
                //}
            }
        } 
        private void textBox1_Entered(object sender, EventArgs e)
        {
            if (firstEnter == true)
            {
                if (textBox1.Text.Equals("Password..."))
                {
                    textBox1.Text = "";
                    textBox1.UseSystemPasswordChar = true;
                    textBox1.ForeColor = Color.Black;
                    firstEnter = false;
                }
            }
            else
            {
                textBox1.SelectAll();
            }
        }
        private void textBox1_Left(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Password...";
                textBox1.UseSystemPasswordChar = false;
                textBox1.ForeColor = Color.LightGray;
                firstEnter = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String name = "Das Encryptor";
            String author = "Joshua Gause && Daniel Zinni";
            String copyright = "Copyright GTJ Works 2010";
            String company = "GTJ Works is an independent contractor";
            String description = "Das Encryptor is a simple but extremely useful message encrypting program. It is constantly being updated with new features and better encryption algorithms. And as always, Das Encryptor is free and non-licensed.";
            AboutBox1 aboutBox = new AboutBox1(name, author, copyright, company, description);
            aboutBox.Show();
            
        }

        private void Encrypt(bool test)
        {
            if (textBox1.Text != "")
            {
                if (label1.Visible == true | label2.Visible == true)
                {
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                }
                String encrypt = AESEncryption.Encrypt(richTextBox1.Text, textBox1.Text, saltAES, "SHA1", 2, "r0#a1etooriuj4ek", 256);
                richTextBox1.Text = encrypt;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
            }
        }

        private void Decrypt(bool test)
        {
            if (textBox1.Text != "")
            {
                String decrypt = AESEncryption.Decrypt(richTextBox1.Text, textBox1.Text, saltAES, "SHA1", 2, "r0#a1etooriuj4ek", 256);
                if (decrypt.Equals("exception ce"))
                {
                    if (richTextBox1.Text.Length == 4)
                    {
                        label1.Visible = false;
                        label2.Visible = true;
                        label3.Visible = false;
                    }
                    else
                    {
                        label2.Visible = false;
                        label1.Visible = true;
                        label3.Visible = false;
                    }
                }
                else if (decrypt.Equals("exception fe"))
                {
                    if (test == true)
                    {
                        Encrypt(false);
                    }
                    else
                    {
                        label1.Visible = false;
                        label2.Visible = true;
                        label3.Visible = false;
                    }
                }
                else
                {
                    if (label1.Visible == true | label2.Visible == true)
                    {
                        label1.Visible = false;
                        label2.Visible = false;
                        label3.Visible = false;
                    }
                    richTextBox1.Text = decrypt;
                }
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
            }
        }




    }
}

