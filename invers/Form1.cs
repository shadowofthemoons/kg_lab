using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace invers
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Bitmap imagesave;
        public Form1()
        {
            InitializeComponent();
        }

        private void download_click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imagesave = new Bitmap(open_dialog.FileName);
                    image = new Bitmap(open_dialog.FileName);
                    pictureBox1.Image = image;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void save_click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".jpg";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                image.Save(saveFile.FileName);

            }
        }

        private void inversion_click(object sender, EventArgs e)
        {
            int i, j;
            Color pix1;
            for (i = 0; i < image.Height; i++)
            {
                for (j = 0; j < image.Width; j++)
                {
                    pix1 = image.GetPixel(j, i);
                    pix1 = Color.FromArgb(255 - pix1.R, 255 - pix1.G, 255 - pix1.B);
                    image.SetPixel(j, i, pix1);
                }
            }
            pictureBox1.Image = image;
        }

        private void grayscale_Click(object sender, EventArgs e)
        {
            int i, j;
            Color pix1;
            int g;
            for (i = 0; i < image.Height; i++)
            {
                for (j = 0; j < image.Width; j++)
                {
                    pix1 = image.GetPixel(j, i);
                    g = (int)(pix1.R * 0.2125 + pix1.G * 0.7154 + pix1.B * 0.0721);
                    pix1 = Color.FromArgb(g, g, g);
                    image.SetPixel(j, i, pix1);
                }
            }
            pictureBox1.Image = image;
        }

        private void return_Click(object sender, EventArgs e)
        {

            RectangleF cloneRect = new RectangleF(0, 0, imagesave.Width, imagesave.Height);
            image = imagesave.Clone(cloneRect, imagesave.PixelFormat);
            pictureBox1.Image = image;
        }

        private void average_binarization_Click(object sender, EventArgs e)
        {
            int i, j;
            ulong med = 0;
            Color pix1;

            for (i = 0; i < image.Height; i++)
            {
                for (j = 0; j < image.Width; j++)
                {
                    pix1 = image.GetPixel(j, i);
                    med += (ulong)(pix1.R * 0.2125 + pix1.G * 0.7154 + pix1.B * 0.0721);
                }
            }
            med = med / (ulong)(image.Height * image.Width);
            for (i = 0; i < image.Height; i++)
            {
                for (j = 0; j < image.Width; j++)
                {
                    pix1 = image.GetPixel(j, i);
                    if ((ulong)(pix1.R * 0.2125 + pix1.G * 0.7154 + pix1.B * 0.0721) > med)
                    {
                        pix1 = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        pix1 = Color.FromArgb(0, 0, 0);
                    }
                    image.SetPixel(j, i, pix1);
                }
            }
            pictureBox1.Image = image;
        }


        private void Bradley_Roth_algorithm_Click(object sender, EventArgs e)
        {
            int S = image.Width / 8;
            int s2 = S / 2;
            double t = 0.15;
            Color pix1;
            ulong[,] inti = new ulong[image.Width, image.Height];
            ulong sum = 0;
            int count = 0;
            int x1, y1, x2, y2;
            for (int i = 0; i < image.Width; i++)
            {
                sum = 0;
                for (int j = 0; j < image.Height; j++)
                {
                    pix1 = image.GetPixel(i, j);
                    sum += (ulong)(pix1.R * 0.2125 + pix1.G * 0.7154 + pix1.B * 0.0721);
                    if (i == 0)
                    {
                        inti[i, j] = sum;
                    }
                    else
                    {
                        inti[i, j] = inti[i - 1, j] + sum;
                    }
                }
            }
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    x1 = i - s2;
                    x2 = i + s2;
                    y1 = j - s2;
                    y2 = j + s2;
                    if (x1 < 0)
                        x1 = 0;
                    if (x2 >= image.Width)
                        x2 = image.Width - 1;
                    if (y1 < 0)
                        y1 = 0;
                    if (y2 >= image.Height)
                        y2 = image.Height - 1;
                    count = (x2 - x1) * (y2 - y1);
                    sum = inti[x2, y2] - inti[x2, y1] - inti[x1, y2] + inti[x1, y1];
                    pix1 = image.GetPixel(i, j);
                    if ((long)((pix1.R * 0.2125 + pix1.G * 0.7154 + pix1.B * 0.0721) * count) < (long)(sum * (1.0 - t)))
                    {
                        pix1 = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        pix1 = Color.FromArgb(255, 255, 255);
                    }
                    image.SetPixel(i, j, pix1);
                }
            }
            pictureBox1.Image = image;
        }

        private void med_Click(object sender, EventArgs e)
        {
            Bitmap image1;
            RectangleF cloneRect = new RectangleF(0, 0, imagesave.Width, imagesave.Height);
            image1 = image.Clone(cloneRect, imagesave.PixelFormat);
            Color pix;
            int arg = 3;
            int num;
            int r, g, b;
            int x1, x2, y1, y2;
            int[] rm = new int[arg * arg];
            int[] gm = new int[arg * arg];
            int[] bm = new int[arg * arg];
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    if (i - arg / 2 < 0)
                    {
                        x1 = 0;
                    }
                    else
                    {
                        x1 = i - arg / 2;
                    }
                    if (i + arg / 2 >= image.Width)
                    {
                        x2 = image.Width - 1;

                    }
                    else
                    {
                        x2 = i + arg / 2;
                    }
                    if (j - arg / 2 < 0)
                    {
                        y1 = 0;
                    }
                    else
                    {
                        y1 = j - arg / 2;
                    }
                    if (j + arg / 2 >= image.Height)
                    {
                        y2 = image.Height - 1;
                    }
                    else
                    {
                        y2 = j + arg / 2;
                    }
                    num = 0;
                    for (int k = x1; k <= x2; k++)
                    {
                        for (int h = y1; h <= y2; h++)
                        {
                            pix = image.GetPixel(k, h);
                            rm[num] = pix.R;
                            gm[num] = pix.G;
                            bm[num] = pix.B;
                            num++;
                        }
                    }
                    mergesort(rm, 0, num);
                    mergesort(gm, 0, num);
                    mergesort(bm, 0, num);
                    r = rm[num / 2];
                    g = gm[num / 2];
                    b = bm[num / 2];
                    pix = Color.FromArgb(r, g, b);
                    image1.SetPixel(i, j, pix);
                }
            }
            pictureBox1.Image = image = image1;
        }

        private void grayscale_noise_Click(object sender, EventArgs e)
        {
            Bitmap image1;
            RectangleF cloneRect = new RectangleF(0, 0, imagesave.Width, imagesave.Height);
            image1 = image.Clone(cloneRect, imagesave.PixelFormat);
            Color pix;
            int arg = 3;
            int num;
            int intens;
            int x1, x2, y1, y2;
            int[] intensity = new int[arg * arg];

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    if (i - arg / 2 < 0)
                    {
                        x1 = 0;
                    }
                    else
                    {
                        x1 = i - arg / 2;
                    }
                    if (i + arg / 2 >= image.Width)
                    {
                        x2 = image.Width - 1;

                    }
                    else
                    {
                        x2 = i + arg / 2;
                    }
                    if (j - arg / 2 < 0)
                    {
                        y1 = 0;
                    }
                    else
                    {
                        y1 = j - arg / 2;
                    }
                    if (j + arg / 2 >= image.Height)
                    {
                        y2 = image.Height - 1;
                    }
                    else
                    {
                        y2 = j + arg / 2;
                    }
                    num = 0;
                    for (int k = x1; k <= x2; k++)
                    {
                        for (int h = y1; h <= y2; h++)
                        {
                            pix = image.GetPixel(k, h);
                            intensity[num] = (int)(pix.R * 0.2125 + pix.G * 0.7154 + pix.B * 0.0721);
                            num++;
                        }
                    }
                    mergesort(intensity, 0, num);

                    intens = intensity[num / 2];

                    pix = Color.FromArgb(intens, intens, intens);
                    image1.SetPixel(i, j, pix);
                }
            }
            pictureBox1.Image = image = image1;
        }

        private void mergesort(int[] a, int left, int right)
        {
            if (left + 1 >= right)
            {
                return;
            }
            mergesort(a, left, (left + right) / 2);
            mergesort(a, ((left + right) / 2), right);
            merge(a, left, right);
        }
        private void merge(int[] a, int left, int right)
        {
            int[] b = new int[right - left];
            int i = left, j = ((left + right) / 2), t = 0;
            while ((i < ((left + right) / 2)) && (j < right))
            {
                if (a[i] < a[j])
                {
                    b[t] = a[i];
                    i++;
                }
                else
                {
                    b[t] = a[j];
                    j++;
                }
                t++;
            }
            while (i < ((left + right) / 2))
            {
                b[t] = a[i];
                i++;
                t++;
            }
            while (j < right)
            {
                b[t] = a[j];
                j++;
                t++;
            }
            for (i = 0; i < (right - left); i++)
            {
                a[left + i] = b[i];
            }
        }

        private void Sobel_Click(object sender, EventArgs e)
        {
            Bitmap image1;
            RectangleF cloneRect = new RectangleF(0, 0, imagesave.Width, imagesave.Height);
            image1 = image.Clone(cloneRect, imagesave.PixelFormat);
            int[,] masky = new int[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            int[,] maskx = new int[3, 3] { { -1, -0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            Color pix, pix1;
            double res;
            int sumy, sumx;

            for (int i = 1; i < image.Width - 1; i++)
            {
                for (int j = 1; j < image.Height - 1; j++)
                {
                    sumy = 0;
                    sumx = 0;
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int h = -1; h <= 1; h++)
                        {
                            pix = image.GetPixel(i + k, j + h);
                            sumy += (int)(pix.R * 0.2125 + pix.G * 0.7154 + pix.B * 0.0721) * masky[k + 1, h + 1];
                            sumx += (int)(pix.R * 0.2125 + pix.G * 0.7154 + pix.B * 0.0721) * maskx[k + 1, h + 1];

                        }
                    }
                    if (sumy < 0)
                    {
                        sumy *= -1;
                    }
                    if (sumx < 0)
                    {
                        sumx *= -1;
                    }
                    if (sumx > 255)
                    {
                        sumx = 255;
                    }
                    if (sumy > 255)
                    {
                        sumy = 255;
                    }
                    res = Math.Sqrt(sumy * sumy + sumx * sumx);

                    if (res > 255)
                    {
                        res = 255;
                    }
                    pix1 = Color.FromArgb((int)res, (int)res, (int)res);
                    image1.SetPixel(i, j, pix1);
                }
            }
            pictureBox1.Image = image = image1;
        }

        private void Sobel_color_Click(object sender, EventArgs e)
        {
            Bitmap image1;
            RectangleF cloneRect = new RectangleF(0, 0, imagesave.Width, imagesave.Height);
            image1 = image.Clone(cloneRect, imagesave.PixelFormat);
            int[,] masky = new int[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            int[,] maskx = new int[3, 3] { { -1, -0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            Color pix = Color.FromArgb(0, 0, 0), pix1;
            double res;
            int sumy, sumx;

            for (int i = 1; i < image.Width - 1; i++)
            {
                for (int j = 1; j < image.Height - 1; j++)
                {
                    sumy = 0;
                    sumx = 0;
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int h = -1; h <= 1; h++)
                        {
                            pix = image.GetPixel(i + k, j + h);
                            sumy += (int)(pix.R * 0.2125 + pix.G * 0.7154 + pix.B * 0.0721) * masky[k + 1, h + 1];
                            sumx += (int)(pix.R * 0.2125 + pix.G * 0.7154 + pix.B * 0.0721) * maskx[k + 1, h + 1];

                        }
                    }
                    if (sumy < 0)
                    {
                        sumy *= -1;
                    }
                    if (sumx < 0)
                    {
                        sumx *= -1;
                    }
                    if (sumx > 255)
                    {
                        sumx = 255;
                    }
                    if (sumy > 255)
                    {
                        sumy = 255;
                    }
                    res = Math.Sqrt(sumy * sumy + sumx * sumx);
                    if (res > 255)
                    {
                        res = 255;
                    }
                    pix1 = Color.FromArgb((int)res * pix.R / 255, (int)res * pix.G / 255, (int)res * pix.B / 255);

                    image1.SetPixel(i, j, pix1);
                }
            }
            pictureBox1.Image = image = image1;
        }
    }
}

