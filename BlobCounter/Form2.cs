using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlobCounter
{
    public partial class Form2 : Form
    {
        public Dictionary<string, string> imagesDict;
        
        public Form2(Dictionary<string, string> imagesDict)
        {
            InitializeComponent();
            this.imagesDict = imagesDict;
            var xFile = 20;
            var xMessage = 150;
            var yFile = 50;
            var yMessage = 50;
            var index = 0;
            foreach (var imageItem in this.imagesDict)
            {
                var fileLabel = new Label
                {
                    Text = Path.GetFileNameWithoutExtension(imageItem.Key),
                    Location = new Point(xFile,yFile)
                   //Width = 100
                };
                var messageLabel = new Label
                {
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleRight,
                    Name = index.ToString(),
                    Text = "Processing...",
                    Location = new Point(xMessage, yMessage)
                    //Width = 100
                };
                yFile += 40;
                yMessage += 40;
                processPanel.Controls.Add(fileLabel);
                processPanel.Controls.Add(messageLabel);
                index++;
            }

            RunImageProcessing();
        }

        private async Task<(string,string)> ProcessImage(string imagePath, string taskId)
        {
            var count = await Task.Run(() => Proxy.CallPython(imagePath));
            return (count, taskId);
        }

        private async void RunImageProcessing()
        {
            var tasks = new List<Task<(string, string)>>();
            var index = 0;
            foreach (var image in imagesDict)
            {
                tasks.Add(ProcessImage(image.Key, index.ToString()));
                index++;
            }

            foreach (var task in await Task.WhenAll(tasks))
            {
                if (!string.IsNullOrEmpty(task.Item1))
                {
                    var messageLabel = (Label)Controls.Find(task.Item2, true)[0];

                    messageLabel.Text = task.Item1;
                }
            }
            doneLabel.Visible = true;
            //string result = await ProcessImage(@"E:\BlobCounter\image2.jpg");
            //Console.WriteLine(result);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
