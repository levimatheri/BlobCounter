using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlobCounter
{
    public partial class Form1 : Form
    {
        private static string[] imageNames;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Select images";
            ofd.Multiselect = true;
            ofd.Filter = "(JPG,JPEG,PNG)|*.JPG;*.GIF;*.PNG";
            var result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                imageNames = ofd.FileNames;

                int x = 20;
                int y = 20;
                int maxHeight = -1;
                foreach (var image in imageNames)
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new System.Drawing.Size(100, 100);
                    pb.Image = Image.FromFile(image);
                    pb.Location = new Point(x, y);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    x += pb.Width + 10;
                    maxHeight = Math.Max(pb.Height, maxHeight);
                    if (x > this.ClientSize.Width - 100)
                    {
                        x = 20;
                        y += maxHeight + 10;
                    }
                    //pb.Load(image);
                    this.imageViewer.Controls.Add(pb);
                    //index++;
                    //x += 110;
                }
                nextButton1.Visible = true;
            }
        }

        private void NextButton1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2(imageNames);
            f2.ShowDialog();
        }
    }
}
