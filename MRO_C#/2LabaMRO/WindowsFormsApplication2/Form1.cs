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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int[] newPictureValues = new int[5];
        public Form1()
        {
            InitializeComponent();
            auto.Add(new Symbol("Water", 3, 2));
            auto.Add(new Symbol("Water", 4, 2));
            auto.Add(new Symbol("Water", 5, 2));
            auto.Add(new Symbol("Water", 6, 2));
            auto.Add(new Symbol("Water", 6, 2));

            auto.Add(new Symbol("Sky", 2, 1));
            auto.Add(new Symbol("Sky", 4, 1));
            auto.Add(new Symbol("Sky", 6, 1));
            auto.Add(new Symbol("Sky", 4, 1));
            auto.Add(new Symbol("Sky", 6, 1));
            auto.Add(new Symbol("Sky", 6, 1));

            auto.Add(new Symbol("Earth", 3, 3));
            auto.Add(new Symbol("Earth", 4, 3));
            auto.Add(new Symbol("Earth", 3, 3));
            auto.Add(new Symbol("Earth", 4, 3));
            auto.Add(new Symbol("Earth", 4, 3));
            auto.Add(new Symbol("Earth", 3, 3));
            auto.Add(new Symbol("Earth", 4, 3));

            auto.Add(new Symbol("Sun", 0, 2));
            auto.Add(new Symbol("Sun", 2, 2));
            auto.Add(new Symbol("Sun", 0, 3));

            auto.Add(new Symbol("Fire", 8, 4));

            auto.Add(new Symbol("Fire", 7, 4));



        }

        
       
        

        struct Letter {
            public double[] var;
            public string name;
        }

        List<Symbol> auto = new List<Symbol>();
        List<Symbol> arr1 = new List<Symbol>();
        List<Symbol> arr2 = new List<Symbol>();
        
        List<Point> arr4 = new List<Point>();

        int kt = 0, x_min = 1000, y_min = 1000, x_max = 0, y_max = 0, _gz = 0;
        string f = "";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label90_Click(object sender, EventArgs e)
        {

        }

        private void label110_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
 



            arr1.Clear();
            arr2.Clear();
            arr4.Clear();
            label2.Text = null;
            label1.Text = null;
            label7.Text = null;

            

            OpenFileDialog file = new OpenFileDialog();

            
          
            file.RestoreDirectory = true;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                f = file.FileName;
            }

            if (f != "")
            {
                bmp = new Bitmap(f);
                Graphics g = pictureBox1.CreateGraphics();
                Rectangle rect = new Rectangle(0, 0, 200, 200);
                kt = 0;
                int q = 0, w = 0;
                int z = 0, A = 0;

                Color color;
                string d = bmp.Height.ToString();




                for (int i = 0; i < bmp.Height; i++)
                {
                    for (int j = 0; j < bmp.Width; j++)
                    {
                        z = 0;
                        q = j; w = i;
                        color = bmp.GetPixel(i, j);
                        if (color.R < 255)
                        {

                            if (x_min > i) { x_min = i; }
                            if (y_min > j) { y_min = j; }
                            if (x_max < i) { x_max = i; }
                            if (y_max < j) { y_max = j; }

                            q = j; w = i;
                            for (int k = q - 1; k <= q + 1; k++)
                            {
                                for (int m = w - 1; m <= w + 1; m++)
                                {
                                    if (bmp.GetPixel(m, k).R < 255)
                                    {

                                        A++;
                                    }
                                }
                            }
                            q = j; w = i;

                            for (int k = w - 1; k <= w + 1; k += 2)
                            {
                                for (int m = q - 1; m <= q; m++)
                                {

                                    if (bmp.GetPixel(k, m).R < 255 && bmp.GetPixel(k, m + 1).R < 255)
                                    {
                                        z++;
                                    }
                                }
                            }


                            q = j; w = i;
                            for (int k = q - 1; k <= q + 1; k += 2)
                            {
                                for (int m = w - 1; m <= w; m++)
                                {

                                    if (bmp.GetPixel(m, k).R < 255 && bmp.GetPixel(m + 1, k).R < 255)
                                    {
                                        z++;
                                    }
                                }
                            }


                            if (A == 2)
                            {
                                arr4.Add(new Point(i, j));

                                kt++;
                            }
                            if (A == 3 && z == 1)
                            {
                                arr4.Add(new Point(i, j));

                                kt++;
                            }
                            A = 0;
                        }
                    }

                }

                int x = (x_max - x_min) / 2;
                int y = (y_max - y_min) / 2;









                int qwe = 0;
                _gz = 0;
                for (int i = 0; i <= bmp.Height - 1; i++)
                {
                    if (bmp.GetPixel(x_min + x, i).R < 255) { qwe++; }
                    if (bmp.GetPixel(x_min + x, i).R == 255 && qwe > 0) { _gz++; qwe = 0; }

                }



                for (int i = 0; i < arr4.Count; i++)
                {

                }

                arr4.Clear();
                g.DrawImage(bmp, rect);

                label1.Text = kt.ToString();
                label7.Text = _gz.ToString();








                double distanceWater1 = Convert.ToDouble(Math.Sqrt(Math.Pow((kt - 3), 2) + Math.Pow((_gz - 2), 2)));
                double distanceWater2 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 4, 2) + Math.Pow(_gz - 2, 2)));
                double distanceWater3 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 5, 2) + Math.Pow(_gz - 2, 2)));
                double distanceWater4 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 6, 2) + Math.Pow(_gz - 2, 2)));
                double distanceWater5 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 6, 2) + Math.Pow(_gz - 2, 2)));

                double distanceSky1 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 2, 2) + Math.Pow(_gz - 1, 2)));
                double distanceSky2 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 4, 2) + Math.Pow(_gz - 1, 2)));
                double distanceSky3 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 6, 2) + Math.Pow(_gz - 1, 2)));
                double distanceSky4 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 4, 2) + Math.Pow(_gz - 1, 2)));
                double distanceSky5 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 6, 2) + Math.Pow(_gz - 1, 2)));
                double distanceSky6 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 6, 2) + Math.Pow(_gz - 1, 2)));

                double distanceEarth1 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 3, 2) + Math.Pow(_gz - 3, 2)));
                double distanceEarth2 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 4, 2) + Math.Pow(_gz - 3, 2)));
                double distanceEarth3 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 3, 2) + Math.Pow(_gz - 3, 2)));
                double distanceEarth4 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 4, 2) + Math.Pow(_gz - 3, 2)));
                double distanceEarth5 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 4, 2) + Math.Pow(_gz - 3, 2)));
                double distanceEarth6 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 3, 2) + Math.Pow(_gz - 3, 2)));
                double distanceEarth7 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 4, 2) + Math.Pow(_gz - 3, 2)));

                double distanceSun1 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 0, 2) + Math.Pow(_gz - 2, 2)));
                double distanceSun2 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 2, 2) + Math.Pow(_gz - 2, 2)));
                double distanceSun3 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 8, 2) + Math.Pow(_gz - 3, 2)));

                double distanceFire1 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 8, 2) + Math.Pow(_gz - 4, 2)));
                double distanceFire2 = Convert.ToDouble(Math.Sqrt(Math.Pow(kt - 7, 2) + Math.Pow(_gz - 4, 2)));









                label16.Text = distanceWater1.ToString();
                label3.Text = distanceWater2.ToString();
                label36.Text = distanceWater3.ToString();
                label40.Text = distanceWater4.ToString();
                label44.Text = distanceWater5.ToString();

                label29.Text = distanceSky1.ToString();
                label48.Text = distanceSky2.ToString();
                label52.Text = distanceSky3.ToString();
                label56.Text = distanceSky4.ToString();
                label60.Text = distanceSky5.ToString();
                label64.Text = distanceSky6.ToString();

                label68.Text = distanceEarth1.ToString();
                label30.Text = distanceEarth2.ToString();
                label72.Text = distanceEarth3.ToString();
                label76.Text = distanceEarth4.ToString();
                label80.Text = distanceEarth5.ToString();
                label84.Text = distanceEarth6.ToString();
                label88.Text = distanceEarth7.ToString();

                label92.Text = distanceSun1.ToString();
                label96.Text = distanceSun2.ToString();
                label31.Text = distanceSun3.ToString();

                label32.Text = distanceFire1.ToString();
                label100.Text = distanceFire2.ToString();





                Double[] MassDist = new double[23];

                MassDist[0] = distanceWater1;
                MassDist[1] = distanceWater2;
                MassDist[2] = distanceWater3;
                MassDist[3] = distanceWater4;
                MassDist[4] = distanceWater5;

                MassDist[5] = distanceSky1;
                MassDist[6] = distanceSky2;
                MassDist[7] = distanceSky3;
                MassDist[8] = distanceSky4;
                MassDist[9] = distanceSky5;
                MassDist[10] = distanceSky6;

                MassDist[11] = distanceEarth1;
                MassDist[12] = distanceEarth2;
                MassDist[13] = distanceEarth3;
                MassDist[14] = distanceEarth4;
                MassDist[15] = distanceEarth5;
                MassDist[16] = distanceEarth6;
                MassDist[17] = distanceEarth7;

                MassDist[18] = distanceSun1;
                MassDist[19] = distanceSun2;
                MassDist[20] = distanceSun3;

                MassDist[21] = distanceFire1;
                MassDist[22] = distanceFire2;

                // foreach (Double  in MassDist)
                // Array.Sort(MassDist);
                double minDist1 = MassDist[0];
                double minDist2 = MassDist[0];
                double minDist3 = MassDist[0];

                for (int i = 0; i < MassDist.Length; i++)
                {
                    double curr = MassDist[i];
                    if (curr <= minDist1 && curr < minDist2 && curr < minDist3)
                    {
                        minDist3 = minDist2; minDist2 = minDist1; minDist1 = curr;

                    }

                    if (curr > minDist1 && curr <= minDist2 && curr < minDist3)
                    {

                        minDist2 = curr;
                    }

                    if (curr > minDist1 && curr > minDist2 && curr < minDist3)
                    {
                        minDist3 = curr;
                    }


                }


                int ind1 = Array.IndexOf(MassDist, minDist1);
                int ind2 = Array.IndexOf(MassDist, minDist2);
                int ind3 = Array.IndexOf(MassDist, minDist3);


                // Alert(Math.min.apply(Array, MassDist));





                label104.Text = minDist1.ToString();
                label105.Text = minDist2.ToString();
                label106.Text = minDist3.ToString();




                String[] MassName = new String[23];


                MassName[0] = label13.ToString();
                MassName[1] = label35.ToString();
                MassName[2] = label39.ToString();
                MassName[3] = label43.ToString();
                MassName[4] = label47.ToString();

                MassName[5] = label17.ToString();
                MassName[6] = label51.ToString();
                MassName[7] = label55.ToString();
                MassName[8] = label59.ToString();
                MassName[9] = label63.ToString();
                MassName[10] = label67.ToString();

                MassName[11] = label71.ToString();
                MassName[12] = label18.ToString();
                MassName[13] = label75.ToString();
                MassName[14] = label79.ToString();
                MassName[15] = label83.ToString();
                MassName[16] = label87.ToString();
                MassName[17] = label91.ToString();

                MassName[18] = label95.ToString();
                MassName[19] = label99.ToString();
                MassName[20] = label19.ToString();

                MassName[21] = label20.ToString();
                MassName[22] = label103.ToString();



                string k1 = MassName[ind1];
                string k2 = MassName[ind2];
                string k3 = MassName[ind3];



                



                string[] ResultName = new string[3] { k1, k2, k3 };
                if (k1 != k2 && k1 != k3 && k2 != k3)
                { label2.Text = "33.3% - " + k1 + "33.3% - " + k2 + "33.3% - " + k3; }
                if (k1 == k2 && k2 == k3 && k3 == k1)
                { label2.Text = k1; }
                if (k1 == k2 && k2 != k3)
                { label2.Text = k1; }
                if (k1 == k3 && k1 != k2)
                { label2.Text = k1; }
                if (k2 == k3 && k2 != k1)
                { label2.Text = k2; }



                label107.Text = "";
                label108.Text = "";
                label109.Text = "";

                label107.Text = k1;
                label108.Text = k2;
                label109.Text = k3;

            }
        }

        Bitmap bmp;

        private void button2_Click(object sender, EventArgs e)
        {
        //    for (int i = 0; i < auto.Count; i++)
        //    {
        //        if (auto[i].KT == kt) { arr1.Add(auto[i]); }
        //    }
        //    if (arr1.Count < 1 && arr1.Count != 0) { label2.Text = arr1[0].Name; label104.Text = arr1[0].Name; arr1.Clear(); return; } else if (arr1.Count == 0) { label2.Text = "Does not belong to our classes"; }


        //    for (int i = 0; i < arr1.Count; i++)
        //    {
        //        if (arr1[i].GZ == _gz) { arr2.Add(arr1[i]); }
        //    }

        //    if (arr2.Count != 0) { label2.Text = arr2[0].Name; label104.Text = arr1[0].Name; arr2.Clear(); arr1.Clear();  return;  } else { label2.Text = "Does not belong to our classes"; }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(228, 209, 209);
        }

      
           

    }

    public class Symbol
    {
        public string Name; //{ get; set; }
        public int KT { get; set; }
        
        public int GZ { get; set; }

        public Symbol(string _name, int _kt,  int _gz)
        {
            Name = _name;
            KT = _kt;
            
            GZ = _gz;
        }

       
    }


   
}
