using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgFilter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap orgPic = new Bitmap(this.pictureBox.Image);
            Bitmap tmpPic = new Bitmap(this.pictureBox.Image);
            for (int y = 1; y < orgPic.Height - 1; y++)
            {
                for (int x = 1; x < orgPic.Width - 1; x++)
                {
                    List<int> list = new List<int>();
                    list.Add(orgPic.GetPixel(x - 1, y - 1).ToArgb());
                    list.Add(orgPic.GetPixel(x - 0, y - 1).ToArgb());
                    list.Add(orgPic.GetPixel(x + 1, y - 1).ToArgb());
                    list.Add(orgPic.GetPixel(x - 1, y - 0).ToArgb());
                    list.Add(orgPic.GetPixel(x - 0, y - 0).ToArgb());
                    list.Add(orgPic.GetPixel(x + 1, y - 0).ToArgb());
                    list.Add(orgPic.GetPixel(x - 1, y + 1).ToArgb());
                    list.Add(orgPic.GetPixel(x - 0, y + 1).ToArgb());
                    list.Add(orgPic.GetPixel(x + 1, y + 1).ToArgb());
                    list.Sort();
                    tmpPic.SetPixel(x, y, Color.FromArgb(list[5]));
                }
            }
            demoPictureBox.Image = tmpPic;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap orgPic = new Bitmap(this.pictureBox.Image);
            Bitmap tmpPic = new Bitmap(this.pictureBox.Image);
            for (int y = 1; y < orgPic.Height - 1; y++)
            {
                for (int x = 1; x < orgPic.Width - 1; x++)
                {
                    Point[] arrayP = new Point[] {  new Point(x - 1, y - 1),
                                                    new Point(x - 0, y - 1),
                                                    new Point(x + 1, y - 1),
                                                    new Point(x - 1, y - 0),
                                                    new Point(x - 0, y - 0),
                                                    new Point(x + 1, y - 0),
                                                    new Point(x - 1, y + 1),
                                                    new Point(x - 0, y + 1),
                                                    new Point(x + 1, y + 1)};

                    int sumA = 0 , sumR = 0, sumG = 0, sumB = 0;
                    foreach (Point item in arrayP)
                    {
                        sumA += orgPic.GetPixel(item.X, item.Y).A;
                        sumR += orgPic.GetPixel(item.X, item.Y).R;
                        sumG += orgPic.GetPixel(item.X, item.Y).G;
                        sumB += orgPic.GetPixel(item.X, item.Y).B;
                    }
                    int meanARGB = 0x01000000 * (sumA/9) +
                                   0x00010000 * (sumR/9) +
                                   0x00000100 * (sumG/9) +
                                   0x00000001 * (sumB/9) ;

                    tmpPic.SetPixel(x, y, Color.FromArgb(meanARGB));
                }
            }
            demoPictureBox.Image = tmpPic;
        }
    }
}
