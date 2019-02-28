using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
    public partial class Form1 : Form
    {


        public void setEtalonPic(double[,,] ass, int k)
        {

            // (massiv4[i, a1, a2] ))
            double[,,] mat = new double[2, 500, 500];
            Random rand = new Random();
            double ran = 0;

            Color myRgbColor = new Color();
            Bitmap bmp = new Bitmap(50, 50);
          //  for(int i1 = 0; i1 < 5; i1++)
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb((int)(255 * ass[k, i, j]), 0, 0, 0)); // яркость
                }
            }
            if (k == 0)
            {
                pictureBox3.Image = bmp;
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }
            if (k == 1)
            {
                pictureBox2.Image = bmp;
        
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }
            if (k == 2)
          { 
                pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox8.Image = bmp;
        }
            if (k == 3)
            { 
                pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox10.Image = bmp;
            }
            if (k == 4)
      { 
                pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox9.Image = bmp;
        }

            if (k == 5)
            {
                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox4.Image = bmp;
            }
            if (k == 6)
            {
                pictureBox12.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox12.Image = bmp;
            }
            if (k == 7)
            {
                pictureBox18.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox18.Image = bmp;
            }
            if (k == 8)
            {
                pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox13.Image = bmp;
            }
            if (k == 9)
            {
                pictureBox19.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox19.Image = bmp;
            }
            if (k == 10)
            {
                pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox5.Image = bmp;
            }
            if (k == 11)
            {
                pictureBox17.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox17.Image = bmp;
            }
            if (k == 12)
            {
                pictureBox15.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox15.Image = bmp;
            }
            if (k == 13)
            {
                pictureBox14.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox14.Image = bmp;
            }
            if (k == 14)
            {
                pictureBox16.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox16.Image = bmp;
            }
            if (k == 15)
            {
                pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox6.Image = bmp;
            }
            if (k == 16)
            {
                pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox11.Image = bmp;
            }
            if (k == 17)
            {
                pictureBox23.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox23.Image = bmp;
            }
            if (k == 18)
            {
                pictureBox22.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox22.Image = bmp;
            }
            if (k == 19)
            {
                pictureBox21.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox21.Image = bmp;
            }
            if (k == 20)
            {
                pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox7.Image = bmp;
            }
            if (k == 21)
            {
                pictureBox24.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox24.Image = bmp;
            }
            if (k == 22)
            {
                pictureBox20.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox20.Image = bmp;
            }
            if (k == 23)
            {
                pictureBox25.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox25.Image = bmp;
            }
            if (k == 24)
            {
                pictureBox26.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox26.Image = bmp;
            }

        }
        int[] nums = new int[25];
        public Form1()
        {
            InitializeComponent();
        }
        string str;
       
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            double p = 0;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            int a, b;
            str = @"c:\bmp\";
            string str_TEXTKOD = @"c:\\bmp\text_kod\";

            int len = 0;
            ///////////////////////////////////////
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("Image Files(*.BMP)|*.BMP");
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = new Bitmap(ofd.FileName);
                Bitmap bmm2 = new Bitmap(pictureBox1.Image);
                int[,,] normik = new int[10, bmm2.Width + 100, bmm2.Height + 100];

                for (b = 1; b < bmm2.Height; b++)
                {

                    //     System.IO.File.AppendAllText(str_TEXTKOD + @"\" + "ffn", "\r\n");
                    for (a = 1; a < bmm2.Width; a++)
                    {
                        Color colr = bmm2.GetPixel(a, b);
                        if (colr.Name == "ffffffff")
                        {

                            normik[1, a, b] = 0;
                        }
                        else

                        {

                            normik[1, a, b] = 1;

                        }


                        //         massiv4[i, a, b] = massiv4[i, a, b] / len;
                        //    System.IO.File.AppendAllText(str_TEXTKOD + (i + 1) + @"\" + (j + 1), string.Join("", massiv[a, b]));

                        //    System.IO.File.AppendAllText(str_TEXTKOD +  @"\" + "ffn", string.Join("", normik[1, a, b]));
                    }

                }
                ///////////////////////////////////////
                ///
                double[] onvet2 = new double[100];
                // проходимся по 5 классам(i)
                for (int i = 0; i < 25; i++)
                {
                   // progressBar1.Value = progressBar1.Value + 1;
                    double[,,] massiv4 = new double[i + 1, 500, 500];
                    double[,,] massiv5 = new double[i + 1, 500, 500];// новая картинка 

                    Text = new DirectoryInfo(@"c:\bmp\" + (i + 1)).GetFiles().Length.ToString();

                    len = Convert.ToInt32(Text);
                    nums[i] = len;
                    // создаем массив картинок
                    for (int j = 0; j < nums[i]; j++)
                    {

                        Bitmap bmm = new Bitmap(str + (i + 1) + @"\" + (j + 1) + ".bmp");
                        int[,] massiv = new int[bmm.Width, bmm.Height];
                        int[,,] massiv3 = new int[j + 1, bmm.Width, bmm.Height];


                        for (b = 1; b < bmm.Height; b++)
                        {

                            //    System.IO.File.AppendAllText(str_TEXTKOD + (i + 1) + @"\" + (j + 1), "\r\n");
                            //      System.IO.File.AppendAllText(str_TEXTKOD + (i + 1) + @"\" + "ff", "\r\n");
                            for (a = 1; a < bmm.Width; a++)
                            {



                                Color colr = bmm.GetPixel(a, b);
                                if (colr.Name == "ffffffff")
                                {
                                    //  massiv[a, b] = 0;
                                    massiv3[j, a, b] = 0; // белый
                                }
                                else

                                {
                                   // massiv[a, b] = 1;
                                    massiv3[j, a, b] = 1;

                                }

                                massiv4[i, a, b] = massiv4[i, a, b] + massiv3[j, a, b];

                                // ВЫВОД МАТРИЦ 
                                //massiv4[i, a, b] = massiv4[i, a, b] / len;
                                //System.IO.File.AppendAllText(str_TEXTKOD + (i + 1) + @"\" + (j + 1), string.Join("", massiv[a, b]));

                                //System.IO.File.AppendAllText(str_TEXTKOD + (i + 1) + @"\" + "ff", string.Join("", massiv4[i, a, b]));
                            }

                        }


                    }

                   



                    double[] onvet = new double[i + 10];
                    for (int j2 = 0; j2 < nums[i]; j2++)
                    {
                        Bitmap bmm = new Bitmap(str + (i + 1) + @"\" + (j2 + 1) + ".bmp");
                        for (int a1 = 0; a1 < bmm.Height; a1++)
                        {
                           // System.IO.File.AppendAllText(str_TEXTKOD + (i + 1) + @"\" + "ff2", "\r\n");
                            for (int a2 = 0; a2 < bmm.Width; a2++)
                            {
                                massiv4[i, a1, a2] = massiv4[i, a1, a2] / len;
                                onvet[i] = onvet[i] + Math.Abs(normik[1, a1, a2] - (massiv4[i, a1, a2]));

                              
                            }
                        }
                    }
                    setEtalonPic(massiv4, i);



                    onvet2[i] = Math.Sqrt(onvet[i]);


                    

                }
                for (int i = 0; i < 25; i++)
                {
                    if (i == 0) p = onvet2[i];
                    else
                  if (p > onvet2[i])
                    {
                        p = onvet2[i];
                        n = i;
                        double k = n/5;
                        double f = (Math.Round(k) + 1);
 label3.Text = Convert.ToString(f);
                    }


                    label9.Text += "\r\n "+(i+1) + " "+ Convert.ToString(onvet2[i]);
                }

               

            }
           
        }


        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void OpenButton_Click(object sender, EventArgs e)//все по 0 кб!!!!
        {
            str = @"c:\bmp\";
            string str_TEXTKOD = @"d:\\bmp\text_kod\";
            string path2 = @"D:\N_klass2.txt";
            int len = 0;
           // ///
           //System.IO.File.WriteAllText(path2, "");
            string path = @"D:\N_klass.txt";
            //2
            //System.IO.File.WriteAllText(str_TEXTKOD + @"\" + "ffn", "");
            //System.IO.File.WriteAllText(str_TEXTKOD + @"\" + "ffOOOOHH", "");
            for (int i = 0; i < 5; i++)
            {

                Text = new DirectoryInfo(@"c:\bmp\" + (i + 1)).GetFiles().Length.ToString();
                len = Convert.ToInt32(Text);
                nums[i] = len;


                //for (int j = 0; j < nums[i]; j++)
                //{
                //    //System.IO.File.WriteAllText(str_TEXTKOD + (i + 1) + @"\" + (j + 1), "");
                //    //System.IO.File.WriteAllText(str_TEXTKOD + (i + 1) + @"\" + "ff", "");
                //    //System.IO.File.WriteAllText(str_TEXTKOD + (i + 1) + @"\" + "ff2", "");

                //}
            }
            //System.IO.File.WriteAllText(path, "");
            label3.Text = "";
            label9.Text = null;
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void qw11_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }
    }

}
        
