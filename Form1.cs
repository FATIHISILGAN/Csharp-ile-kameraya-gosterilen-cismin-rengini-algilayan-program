using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace color_reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int m, y, k;
     

        private void webCamCapture1_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            Bitmap resim = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < e.WebCamImage.Width; i++)
            {
                for (int j = 0; j < e.WebCamImage.Height; j++)
                {
                    if (resim.GetPixel(i, j).R <= 95 && resim.GetPixel(i, j).G <= 95 && resim.GetPixel(i, j).B >= 100)//mavi şartı
                    {
                        m++;
                    }
                    if (resim.GetPixel(i, j).R <= 95 && resim.GetPixel(i, j).G >= 100 && resim.GetPixel(i, j).B <= 95)//yeşil şartı
                    {
                        y++;
                    }
                    if (resim.GetPixel(i, j).R >= 105 && resim.GetPixel(i, j).G <= 95 && resim.GetPixel(i, j).B <= 95)//kırmızı şartı
                    {
                        k++;
                    }

                }
            }

            pictureBox1.Image = e.WebCamImage;
            if (k > m && k > y)
            {
                label1.Text = "kırmızı";
                k= 0;
                y = 0;

                m = 0;
            }
            if (y> m && y > k)
            {
                label1.Text ="yeşil";
                k = 0;
                y = 0;

                m = 0;

            }
            if (m > k && m > y)
            {
                label1.Text = "mavi";
                k = 0;
                y = 0;

                m = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m = 0;
            y = 0;
            k = 0;
            webCamCapture1.Start(0);

        }
    }
}
