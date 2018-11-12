using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace photo
{



    public partial class Form1 : Form
    {
        private string dosyayolu;
        Image zoomimg;
        Image File;
        Bitmap orj;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value=(0);
            pictureBox1.ImageLocation = dosyayolu;
            //845; 530
            pictureBox1.Height = 530;

            pictureBox1.Width = 845;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox1.Image);

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    img.SetPixel(j, i, Color.FromArgb(255, 255 - img.GetPixel(j, i).R, 255 - img.GetPixel(j, i).G, 255 - img.GetPixel(j, i).B));
                }

            }

            pictureBox1.Image = img;
            zoomimg = pictureBox1.Image;
            
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            /*openFileDialog1.FileName = "";
            openFileDialog1.Title = " Images";
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png; *.jpeg";
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName.ToString();
            dosyayolu = openFileDialog1.FileName.ToString();
          
            zoomimg = pictureBox1.Image;*/
            
            OpenFileDialog f = new OpenFileDialog();
            f.Filter= "All Images|*.jpg; *.bmp; *.png; *.jpeg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                File = Image.FromFile(f.FileName);
                pictureBox1.Image = File;
                zoomimg = pictureBox1.Image;
              dosyayolu = f.FileName.ToString();
            }

            pictureBox1.Height = 530;

            pictureBox1.Width = 845;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button8_Click(object sender, EventArgs e)
        {
          //  pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
           
            SaveFileDialog save = new SaveFileDialog();
             save.Filter = "All Images|*.jpg; *.bmp; *.png; *.jpeg";
             Size tam = new Size(pictureBox1.Width, pictureBox1.Height);
             Bitmap bmp = new Bitmap(pictureBox1.Image, tam);
             save.FileName = "";

             if (save.ShowDialog() == DialogResult.OK) { bmp.Save(save.FileName); }
             
             /*
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "All Images|*.jpg; *.bmp; *.png; *.jpeg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                File.Save(f.FileName);
               
               
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Bitmap img = new Bitmap(pictureBox1.Image);


            for (int i = 1; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    int gri = (int)(img.GetPixel(j, i).R * 0.3 + img.GetPixel(j, i).G * 0.59 + img.GetPixel(j, i).B * 0.11);
                    img.SetPixel(j, i, Color.FromArgb(gri, gri, gri));
                }

            }

            pictureBox1.Image = img;


            zoomimg = pictureBox1.Image;



        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*//pictureBox1.Image = pictureBox1.Image;
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Refresh();
            zoomimg = pictureBox1.Image;*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
           /* //pictureBox1.Image = pictureBox1.Image;
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Refresh();
            zoomimg = pictureBox1.Image;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            Bitmap img = new Bitmap(pictureBox1.Image,Width,Height);
            int genislik = img.Width;
            int uzunluk = img.Height;
            
           
            Bitmap img2 = new Bitmap(Width * 2, Height);
            for (int y = 0; y < uzunluk; y++)
            {
                for (int x = 0, rx = genislik * 2 - 1; x < genislik; x++, rx--)
                {
                    Color p = img.GetPixel(x, y);
                    img2.SetPixel(x, y, p);
                    img2.SetPixel(rx, y, p);



                }

            }

            pictureBox1.Image = img2;
            zoomimg = pictureBox1.Image;
        }

        private void button9_Click(object sender, EventArgs e)
        {
           pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
           // pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);



            Bitmap img = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Width, pictureBox1.Height));



            Bitmap img2 = new Bitmap(img, new Size(img.Height, img.Width));
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    img2.SetPixel(y, x, img.GetPixel(x, img.Height - y - 1));




                }

            }
            pictureBox1.Image = img2;
            img = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Width, pictureBox1.Height));
            img2 = new Bitmap(img, new Size(img.Height, img.Width));
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    img2.SetPixel(y, x, img.GetPixel(x, img.Height - y - 1));




                }

            }
            pictureBox1.Image = img2;






             img = new Bitmap(pictureBox1.Image, Width , Height);
            int genislik = img.Width;
            int uzunluk = img.Height;

            img2 = new Bitmap(Width * 2, Height);
            for (int y = 0; y < uzunluk; y++)
            {
                for (int x = 0, rx = genislik * 2 - 1; x < genislik; x++, rx--)
                {
                    Color p = img.GetPixel(x,y);
                    img2.SetPixel(x, y, p);
                    img2.SetPixel(rx, y, p);



                }

            }
          

            pictureBox1.Image = img2;
            img = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Width, pictureBox1.Height));



             img2 = new Bitmap(img, new Size(img.Height, img.Width));
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    img2.SetPixel(y, x, img.GetPixel(x, img.Height - y - 1));




                }

            }
            pictureBox1.Image = img2;
            img = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Width, pictureBox1.Height));
            img2 = new Bitmap(img, new Size(img.Height, img.Width));
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    img2.SetPixel(y, x, img.GetPixel(x, img.Height - y - 1));




                }

            }
            pictureBox1.Image = img2;
            zoomimg = pictureBox1.Image;

        }

        private void button10_Click(object sender, EventArgs e)
        {

            int[] HistogramRed = new int[256];
            int[] HistogramGreen = new int[256];
            int[] HistogramBlue = new int[256];
            int[] HistogramRedK = new int[256];
            int[] HistogramGreenK = new int[256];
            int[] HistogramBlueK = new int[256];
            int[] YüzdelikRed = new int[256];
            int[] YüzdelikGreen = new int[256];
            int[] YüzdelikBlue = new int[256];
            int Çözünürlük;

            String a = "";

            Image img = pictureBox1.Image;

            Bitmap renderedImage = new Bitmap(img);

            uint pixels = (uint)renderedImage.Height * (uint)renderedImage.Width;
            decimal Const = 255 / (decimal)pixels;

            int x, y, R, G, B;


            int[] HistogramRed2 = new int[256];
            int[] HistogramGreen2 = new int[256];
            int[] HistogramBlue2 = new int[256];

            StreamWriter dosya = new StreamWriter("C:\\Users\\Ahmet\\Desktop\\görüntü işleme\\histogram.txt");
            for (var i = 0; i < renderedImage.Width; i++)
            {
                for (var j = 0; j < renderedImage.Height; j++)
                {
                    var piksel = renderedImage.GetPixel(i, j);

                    HistogramRed2[(int)piksel.R]++;
                    HistogramGreen2[(int)piksel.G]++;
                    HistogramBlue2[(int)piksel.B]++;

                }
            }
    


               

                for (int i = 0; i < 256; i++)
                {
                dosya.WriteLine("" +HistogramRed2[i] +"|" +HistogramGreen2[i] + "| " +HistogramBlue2[i] + "n");
                }

                dosya.Close();
            



            int[] cdfR = HistogramRed2;
            int[] cdfG = HistogramGreen2;
            int[] cdfB = HistogramBlue2;

            for (int r = 1; r <= 255; r++)
            {
                cdfR[r] = cdfR[r] + cdfR[r - 1];
                cdfG[r] = cdfG[r] + cdfG[r - 1];
                cdfB[r] = cdfB[r] + cdfB[r - 1];
            }

            for (y = 0; y < renderedImage.Height; y++)
            {
                for (x = 0; x < renderedImage.Width; x++)
                {
                    Color pixelColor = renderedImage.GetPixel(x, y);

                    R = (int)((decimal)cdfR[pixelColor.R] * Const);
                    G = (int)((decimal)cdfG[pixelColor.G] * Const);
                    B = (int)((decimal)cdfB[pixelColor.B] * Const);

                    Color newColor = Color.FromArgb(R, G, B);
                    renderedImage.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = renderedImage;
            zoomimg = pictureBox1.Image;
        }

       
        

       
    
        private void Form1_FormClosing(object sender,FormClosedEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Dispose();
            }

        }

        
        

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            // pictureBox1.SizeMode = PictureBoxSizeMode.Normal;

            /*
            if (trackBar1.Value > 0)
            {   
                pictureBox1.Image = Zoom(zoomimg, new Size(trackBar1.Value, trackBar1.Value));
            }*/
            Bitmap img = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = img;
            // pictureBox1.Size = new Size(img.Width * (trackBar1.Value / 20), img.Height * (trackBar1.Value / 20));
            pictureBox1.Size = new Size(845-trackBar1.Value, 530-(trackBar1.Value/2));
            /*
            if (trackBar1.Value > 199)
            {
                 img = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = img;
                pictureBox1.Size = new Size(845, 530);
            }
            */

        }

        private void button12_Click(object sender, EventArgs e)
        {
            orj = new Bitmap(pictureBox1.Image);
            Bitmap kanallar = new Bitmap(pictureBox1.Image);
            int width1 = kanallar.Width;
            int height1 = kanallar.Height;
            Bitmap red = new Bitmap(kanallar);

            for (int y = 0; y < height1; y++)
            {
                for (int x = 0; x < width1; x++)
                {

                    Color p = kanallar.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;

                    red.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));

                }

                pictureBox1.Image = red;
            }

        }
        private void button13_Click(object sender, EventArgs e)
        {
            orj = new Bitmap(pictureBox1.Image);
            Bitmap kanallar = new Bitmap(pictureBox1.Image);
            int width1 = kanallar.Width;
            int height1 = kanallar.Height;
            Bitmap blue = new Bitmap(kanallar);

            for (int y = 0; y < height1; y++)
            {
                for (int x = 0; x < width1; x++)
                {

                    Color p = kanallar.GetPixel(x, y);
                    int a = p.A;
                    int b = p.B;

                    blue.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));

                }

                pictureBox1.Image = blue;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            orj = new Bitmap(pictureBox1.Image);
            Bitmap kanallar = new Bitmap(pictureBox1.Image);
            int width1 = kanallar.Width;
            int height1 = kanallar.Height;
            Bitmap green = new Bitmap(kanallar);

            for (int y = 0; y < height1; y++)
            {
                for (int x = 0; x < width1; x++)
                {

                    Color p = kanallar.GetPixel(x, y);
                    int a = p.A;
                    int g = p.G;

                    green.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));

                }

                pictureBox1.Image = green;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = orj;
        }

        private void button11_Click(object sender, EventArgs e)
        {//845; 530
           // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            Bitmap img = new Bitmap(pictureBox1.Image,new Size(pictureBox1.Width,pictureBox1.Height));
           


            Bitmap img2 = new Bitmap(img , new Size(img.Height,img.Width));
            for (int y = 0; y < img.Height; y++)
            {
                for (int x =  0 ; x < img.Width; x++)
                {
                    img2.SetPixel(y, x, img.GetPixel(x, img.Height - y - 1));
                    



                }

            }
          
            pictureBox1.Image = img2;
            zoomimg = pictureBox1.Image;
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Width, pictureBox1.Height));



            Bitmap img2 = new Bitmap(img, new Size(img.Height, img.Width));
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    img2.SetPixel(y, x, img.GetPixel(x, img.Height - y - 1));




                }

            }
            pictureBox1.Image = img2;
            img = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Width, pictureBox1.Height));
            img2 = new Bitmap(img, new Size(img.Height, img.Width));
            for ( int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    img2.SetPixel(y, x, img.GetPixel(x, img.Height - y - 1));




                }

            }
            pictureBox1.Image = img2;
            img = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Width, pictureBox1.Height));
            img2 = new Bitmap(img, new Size(img.Height, img.Width));
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    img2.SetPixel(y, x, img.GetPixel(x, img.Height - y - 1));




                }

            }


            pictureBox1.Image = img2;
            zoomimg = pictureBox1.Image;
        }


        





        
    }

    
}

