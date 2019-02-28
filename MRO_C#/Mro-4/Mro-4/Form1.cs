using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mro_4
{
    public partial class Form1 : Form
    {


        const int Len = 50;
        const int Per = 5;
        int[,] MassImg;
        int[,] MassSoed;
        int[,] MassPer;
        int[,] rangedOptions;
        int[] lineY;
        int[] soed;
        int[] lym1;
        int[] lym2;
        int[] lym3;
        
        public Form1()
        {
            InitializeComponent();
            tabPage1.Text = "HomePage";
            
            tabPage2.Text = "ConnectionTable";
            tabPage3.Text = "ClassA";
            tabPage4.Text = "ClassB";
            tabPage5.Text = "ClassC"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("Image Files(*.BMP)|*.BMP");
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                    Bitmap Img = new Bitmap(pictureBox1.Image);
                    MassImg = new int[Img.Width,Img.Height];
                   // MassSoed = new int[2500, 500];
                    MassImg = ImgToMat(Img);
                    
                    griding(dataGridView1, MassImg);
                    soed = new int[(MassImg.GetLength(0)*MassImg.GetLength(1))/Per];
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private int[,] ImgToMat(Bitmap img)
        {
            int[,] mat = new int[Len, Len];
            for (int ik = 0; ik < Len; ik++)
                for (int jk = 0; jk < Len; jk++)
                {
                    Color c1 = img.GetPixel(jk, ik);
                    if (c1.R > 0)
                        mat[ik, jk] = 0;
                    else
                            mat[ik, jk] = 1;                   
                }
            return mat;
        }

        private void griding(DataGridView d, int[,] mat)
        {          
            d.ColumnCount = mat.GetLength(1)+1;
            for (int i = 0; i < mat.GetLength(1); i++)
                d.Columns[i].Width = 20;
                d.Columns[50].Width = 20;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                d.Rows.Add("x"+i);

               
            }
            for (int i = 0; i<mat.GetLength(0);i++)
                for (int j = 0; j<mat.GetLength(1);j++)
                {
                    d.Rows[i].Cells[j+1].Value = mat[i, j];
                   
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            lineY = new int[soed.Length];
            MassPer = new int[MassImg.GetLength(0) * MassImg.GetLength(1), soed.Length];

            for (int i = 0; i < 500; i++)
            {

                for (int j = 0; j < 500; j++)
                {
                    if (i == j)
                    {

                        MassPer[i, j] = 1;
                    }
                    else MassPer[i, j] = 0;
                }
            }
            for (int i = 1999; i < 2500; i++)
            {
                for (int j = 0; j < 500; j++)
                    if (i == j + 1999)
                    {

                        MassPer[i, j] = -1;
                    }
                    else MassPer[i, j] = 0;
            }
            int a;

            for (int i = 500; i < 1999; i++)
            {
                a = rand.Next(0, 500);


                for (int j = 0; j < 500; j++)



                    if (rand.Next(0, 2) == 0)
                        MassPer[i, a] = 1;
                    else
                        MassPer[i, a] = -1;

            }



            griding(dataGridView2, MassPer);


        }



       

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            lym1 = new int[lineY.Length];
            lym2 = new int[lineY.Length];
            lym3 = new int[lineY.Length];
            for (int i = 0; i < lym1.Length; i++)
                lym1[i] = 1;
            for (int i = 0; i < lym2.Length; i++)
                lym2[i] = 1;
            for (int i = 0; i < lym3.Length; i++)
                lym3[i] = 1;
            dataGridView3.ColumnCount = lym1.Length + 1;
            dataGridView4.ColumnCount = lym1.Length + 1;
            dataGridView5.ColumnCount = lym1.Length + 1;
            addLym();
        }

        private void addLym()
        {
            Random rand = new Random();
            int[] myValue = { -1, 0, 1 };

            dataGridView3.Rows.Add("lym ");
           
            for (int i = 0; i < lym1.Length; i++)
            {

                dataGridView3.Rows[0].Cells[i + 1].Value = myValue[rand.Next(myValue.GetLength(0))];
               
            }

            //for (int i = 0; i < dataGridView3.RowCount; i++)
            //{

            //    for (int j = 0; j < dataGridView3.ColumnCount; j++)
            //    {

            //        rangedOptions[i, j] = Convert.ToInt32(dataGridView3.Rows[i].Cells[j].Value);
                   
            //    }
            //}


            dataGridView4.Rows.Add("lym ");
        


            for (int i = 0; i < lym1.Length; i++)
            {

                dataGridView4.Rows[0].Cells[i + 1].Value = myValue[rand.Next(myValue.GetLength(0))];
               
            }





            dataGridView5.Rows.Add("lym ");
         

            for (int i = 0; i < lym1.Length; i++)
            {
                dataGridView5.Rows[0].Cells[i + 1].Value = myValue[rand.Next(myValue.GetLength(0))];
            }
            addY();
        }

        private void addY()
        {
            //int ost = 0;
            dataGridView3.Rows.Add("Y");
            dataGridView4.Rows.Add("Y");
            dataGridView5.Rows.Add("Y");
            ArrayList arrayImage = new ArrayList();
            ArrayList arrayConnectionTable = new ArrayList();
           // ArrayList y = new ArrayList();
            int  yy = 0;

            foreach (DataGridViewRow dr in dataGridView1.Columns)
          // for (int i = 0; i < dataGridView1.Columns.Count; i )

            {

             
                    for (int j = 0; j < 2500; j++)

                     arrayImage.Add(dr.Cells[j].Value);
                        

            }

             foreach (DataGridViewColumn dr in dataGridView2.Rows)
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                for (int j = 0; j < 500; j++)
                    arrayConnectionTable.Add(dataGridView2.Rows[j]);

                

            }
            for (int i = 0; i < arrayConnectionTable.Count; i++) {
                yy += Convert.ToInt32(arrayImage[i]) * Convert.ToInt32(arrayConnectionTable[i]);
            }

            for (int i = 0; i < 500; i++)
            {
                dataGridView3.Rows[1].Cells[i + 1].Value = yy;
                if (yy >= 0)
                {
                    yy = 1;
                }
                else

                    yy = 0;

            }


            //   y = arrayImage * arrayConnectionTable;

            //for (int j = 0; j < lineY.Length; j++)
            //{
            //    lineY[j] = 0;
            //    for (int i = 0; i < MassPer.GetLength(0); i++)
            //        lineY[j] += MassPer[i, j] * rangedOptions[i, j];
            //    dataGridView3.Rows[1].Cells[j + 1].Value = lineY[j];
            //    if (lineY[j] >= 0)
            //    {
            //        lineY[j] = 1;
            //    }
            //    else

            //        lineY[j] = 0;
            //}

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
