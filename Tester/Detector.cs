using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Tester
{
    class Detector
    {
        Image<Gray, byte> _image;
        Bitmap _colorImage;
        Detector(string imagePath, Bitmap colorImage)
        {
            _image = new Image<Gray, byte>(imagePath);
            _colorImage = colorImage;
        }

        private void IdentifyContours()
        {
            int counter = 0;
            Image<Bgr, byte> color = new Image<Bgr, byte>(_colorImage);
            using (MemStorage storage = new MemStorage())
            {
                for (Contour<Point> contours = _image.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, storage); contours != null; contours = contours.HNext)
                {
                    contours.ApproxPoly(contours.Perimeter * 0.05, storage);
                    CvInvoke.cvDrawContours(color, contours, new MCvScalar(255), new MCvScalar(255), -1, 1, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, new Point(0, 0));
                    counter++;
                }
            }

            using (MemStorage store = new MemStorage())
            {
                for (Contour<Point> contours1 = color.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE, store); contours1 != null; contours1 = contours1.HNext)
                {
                    Rectangle r = CvInvoke.cvBoundingRect(contours1, 1);
                    color.Draw(r, new Bgr(0, 255, 0), 1);
                }
            }
        }

        static void Main(string[] args)
        {
            Detector detector = new Detector()
        }
    }
}
