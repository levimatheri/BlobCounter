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
    public partial class Form2 : Form
    {
        public string[] imageNames;
        public Form2(string[] imageNames)
        {
            InitializeComponent();
            this.imageNames = imageNames;
            foreach (var image in this.imageNames)
            {
                var label = new Label()
                {
                    Text = "Processing..."
                };
                processPanel.Controls.Add(label);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private async Task<string> ProcessImage(string imagePath)
        {
            var count = await Task.Run(() => Proxy.CallPython(imagePath));
            return count;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            foreach (var image in imageNames)
            {
                await ProcessImage(image);
            }
            string result = await ProcessImage(@"E:\BlobCounter\image2.jpg");
            Console.WriteLine(result);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
