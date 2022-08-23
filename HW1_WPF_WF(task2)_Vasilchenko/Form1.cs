using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW1_WPF_WF_task2__Vasilchenko
{   
    public partial class Form1 : Form
    {
        Image[] images;
        int counter = 0;
        string folderPath;
        bool animation = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void _openf_Click(object sender, EventArgs e)
        {            
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.UserProfile;
            folderBrowserDialog1.ShowNewFolderButton = false;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                string search = "*.*";
                images = Directory.GetFiles(folderPath, search).Select(Image.FromFile).ToArray();
                pictureBox1.Image = images[0];
                label1.Text = $"{counter + 1} / {images.Length}";
            }
        }

        private void _next_Click(object sender, EventArgs e)
        {
            if (counter < images.Count() - 1)
            {
                counter++;
            }
            label1.Text = $"{counter + 1}/{images.Length}";
            pictureBox1.Image = images[counter];
        }

        private void _prev_Click(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                counter--;
            }
            label1.Text = $"{counter + 1} / {images.Length}";
            pictureBox1.Image = images[counter];
        }

        private void _start_Click(object sender, EventArgs e)
        {
            do
            {
                foreach (Image item in images)
                {
                    pictureBox1.Image = item;
                    Thread.Sleep(500);
                }
            } while (animation == true && counter > 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            animation = false;
        }
    }
}
