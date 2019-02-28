using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] mas = new int[225]; //тут хранятся пиксели изображения

        private void toolStripMenuItem2_Click(object sender, EventArgs e) //открытие изображения вручную
        {
            openFileDialog1.ShowDialog();
            string strFile;
            strFile = openFileDialog1.FileName.ToString();
            label1.Text = strFile;
            pictureBox1.ImageLocation = strFile;

            Bitmap img = new Bitmap(label1.Text);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (img.GetPixel(i, j).B == 0)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = "1"; //определение цвета пикселей
                    }
                    else
                        dataGridView1.Rows[j].Cells[i].Value = "0";
                }
            }

            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    dataGridView2.Rows[j + i * 15].HeaderCell.Value = 'x' + (j+1+i*15).ToString() + "=".ToString() + dataGridView1.Rows[i].Cells[j].Value.ToString();
                    mas[j + i * 15] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                }

            int sum;
            for (int i = 0; i < 100; i++) //иду по всем А-элементам, считаю что они насуммировали
            {
                sum = 0;
                for (int j = 0; j < 225; j++)
                    sum += Convert.ToInt32(dataGridView2.Rows[j].Cells[i].Value.ToString()) * mas[j];
                dataGridView2.Rows[229].Cells[i].Value = sum.ToString();
            }
            for (int i = 0; i < 100; i++)
                if (Convert.ToInt32(dataGridView2.Rows[229].Cells[i].Value.ToString()) >= 1) //больше порога 1
                    dataGridView2.Rows[230].Cells[i].Value = '1'; //т.е. элемент А активен
                else
                    dataGridView2.Rows[230].Cells[i].Value = '0';

            for (int i = 0; i < 100; i++) //считаю Y*лямбды
            {
                dataGridView2.Rows[231].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[230].Cells[i].Value.ToString()) * Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString());
                dataGridView2.Rows[232].Cells[i].Value =( Convert.ToInt32(dataGridView2.Rows[230].Cells[i].Value.ToString()) * Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString())).ToString();
                dataGridView2.Rows[233].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[230].Cells[i].Value.ToString()) * Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString());
                dataGridView2.Rows[234].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[230].Cells[i].Value.ToString()) * Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString());
            }

            int sigma1 = 0, sigma2 = 0, sigma3 = 0, sigma4 = 0;
            for (int i = 0; i < 100; i++) //считаю значения сумматоров
            {
                sigma1 += Convert.ToInt32(dataGridView2.Rows[231].Cells[i].Value.ToString());
                sigma2 += Convert.ToInt32(dataGridView2.Rows[232].Cells[i].Value.ToString());
                sigma3 += Convert.ToInt32(dataGridView2.Rows[233].Cells[i].Value.ToString());
                sigma4 += Convert.ToInt32(dataGridView2.Rows[234].Cells[i].Value.ToString());
            }
            dataGridView2.Rows[235].Cells[0].Value = sigma1;
            dataGridView2.Rows[236].Cells[0].Value = sigma2;
            dataGridView2.Rows[237].Cells[0].Value = sigma3;
            dataGridView2.Rows[238].Cells[0].Value = sigma4;

                for (int i = 0; i < 100; i++) //изменяю лямбды
                {
                    if (dataGridView2.Rows[230].Cells[i].Value.ToString() == "1") //если элемент активен
                    {
                        if (checkBox1.Checked == true)
                        {
                            dataGridView2.Rows[225].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString()) +  1;
                            dataGridView2.Rows[226].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[227].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[228].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString()) - 1;
                        }
                        if (checkBox2.Checked == true)
                        {
                            dataGridView2.Rows[225].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[226].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString()) + 1;
                            dataGridView2.Rows[227].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[228].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString()) - 1;
                        }
                        if (checkBox3.Checked == true)
                        {
                            dataGridView2.Rows[225].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[226].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[227].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString()) + 1;
                            dataGridView2.Rows[228].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString()) - 1;
                        }
                        if (checkBox4.Checked == true)
                        {
                            dataGridView2.Rows[225].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[226].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[227].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString()) - 1;
                            dataGridView2.Rows[228].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString()) + 1;
                        }
                        if (checkBox5.Checked == true)
                        {

                            if ( //распознавание
                                (Convert.ToInt32(dataGridView2.Rows[235].Cells[0].Value.ToString()) > Convert.ToInt32(dataGridView2.Rows[236].Cells[0].Value.ToString())) &
                                (Convert.ToInt32(dataGridView2.Rows[235].Cells[0].Value.ToString()) > Convert.ToInt32(dataGridView2.Rows[237].Cells[0].Value.ToString())) &
                                (Convert.ToInt32(dataGridView2.Rows[235].Cells[0].Value.ToString()) > Convert.ToInt32(dataGridView2.Rows[238].Cells[0].Value.ToString()))
                                )
                                label2.Text = "объект отнесен к классу 1";
                            else
                                if ( //распознавание
                                (Convert.ToInt32(dataGridView2.Rows[236].Cells[0].Value.ToString()) > Convert.ToInt32(dataGridView2.Rows[237].Cells[0].Value.ToString())) &
                                (Convert.ToInt32(dataGridView2.Rows[236].Cells[0].Value.ToString()) > Convert.ToInt32(dataGridView2.Rows[238].Cells[0].Value.ToString()))
                                )
                                    label2.Text = "объект отнесен к классу 2";
                                else
                                    if ( //распознавание
                               Convert.ToInt32(dataGridView2.Rows[237].Cells[0].Value.ToString()) > Convert.ToInt32(dataGridView2.Rows[238].Cells[0].Value.ToString()))
                                        label2.Text = "объект отнесен к классу 3";
                                    else
                                        label2.Text = "объект отнесен к классу 4";
                        }

                    }
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 15; i++)
            {
                DataGridViewRow row = new DataGridViewRow(); //добвляю строки
                row.HeaderCell.Value = i.ToString();
                dataGridView1.Rows.Add(row);
            }
            for (int i = 0; i < 15; i++)
            {
                dataGridView1.Rows[i].Height=15;
                dataGridView1.Columns[i].Width = 20;
            }

            for (int i = 1; i < 225+15; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = 'x'+i.ToString();
                dataGridView2.Rows.Add(row);        //добавляю строки в основную таблицу
            }
            for (int i = 1; i < 100; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = 'A'+ (i+1).ToString();
                dataGridView2.Columns.Add(col);     //добавляю столбцы в основную таблицу
            }
            for (int i = 0; i < 41; i++)
            {
                DataGridViewRow row = new DataGridViewRow(); //добвляю строки в таблицу автообучения L1
                row.HeaderCell.Value = i.ToString();
                dataGridViewL1.Rows.Add(row);
            }
            for (int i = 0; i < 41; i++)
            {
                DataGridViewRow row = new DataGridViewRow(); //добвляю строки в таблицу автообучения L2
                row.HeaderCell.Value = i.ToString();
                dataGridViewL2.Rows.Add(row);
            }
            for (int i = 0; i < 41; i++)
            {
                DataGridViewRow row = new DataGridViewRow(); //добвляю строки в таблицу автообучения L3
                row.HeaderCell.Value = i.ToString();
                dataGridViewL3.Rows.Add(row);
            }
            for (int i = 0; i < 41; i++)
            {
                DataGridViewRow row = new DataGridViewRow(); //добвляю строки в таблицу автообучения L4
                row.HeaderCell.Value = i.ToString();
                dataGridViewL4.Rows.Add(row);
            }
            for (int i = 1; i < 100; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = 'L' + (i+1).ToString();
                dataGridViewL1.Columns.Add(col);     //добавляю столбцы в таблицу автообучения L1
            }
            for (int i = 1; i < 100; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = 'L' + (i + 1).ToString();
                dataGridViewL2.Columns.Add(col);     //добавляю столбцы в таблицу автообучения L2
            }
            for (int i = 1; i < 100; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = 'L' + (i + 1).ToString();
                dataGridViewL3.Columns.Add(col);     //добавляю столбцы в таблицу автообучения L3
            }
            for (int i = 1; i < 100; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = 'L' + (i + 1).ToString();
                dataGridViewL4.Columns.Add(col);     //добавляю столбцы в таблицу автообучения L4
            }
            for (int i = 0; i < 225; i++)
            {
                dataGridView2.Rows[i].Height = 15;
            }
            for (int i = 0; i < 100; i++)
            {
                dataGridView2.Columns[i].Width = 25;
                dataGridViewL1.Columns[i].Width = 25;
                dataGridViewL2.Columns[i].Width = 25;
                dataGridViewL3.Columns[i].Width = 25;
                dataGridViewL4.Columns[i].Width = 25;
            }
            dataGridView1.Rows[14].HeaderCell.Value = "15";
            dataGridView2.Columns[0].Width = 35; //надо пошире, а то значения сумматоров не влазят
            dataGridView2.Rows[224].HeaderCell.Value = "x225";
            dataGridView2.Rows[225].HeaderCell.Value = "Lambda1";
            dataGridView2.Rows[226].HeaderCell.Value = "Lambda2";
            dataGridView2.Rows[227].HeaderCell.Value = "Lambda3";
            dataGridView2.Rows[228].HeaderCell.Value = "Lambda4";
            dataGridView2.Rows[229].HeaderCell.Value = "Sum";
            dataGridView2.Rows[230].HeaderCell.Value = "Y";
            dataGridView2.Rows[231].HeaderCell.Value = "Y*Lambd1";
            dataGridView2.Rows[232].HeaderCell.Value = "Y*Lambd2";
            dataGridView2.Rows[233].HeaderCell.Value = "Y*Lambd3";
            dataGridView2.Rows[234].HeaderCell.Value = "Y*Lambd4";
            dataGridView2.Rows[235].HeaderCell.Value = "sigma1";
            dataGridView2.Rows[236].HeaderCell.Value = "sigma2";
            dataGridView2.Rows[237].HeaderCell.Value = "sigma3";
            dataGridView2.Rows[238].HeaderCell.Value = "sigma4";

            for (int i = 0; i < 100; i++) //начальное заполнение
                for (int j = 0; j < 225; j++)
                    dataGridView2.Rows[j].Cells[i].Value = '0';
            for (int i = 0; i < 100; i++)
            {
                dataGridView2.Rows[225].Cells[i].Value = '1'; //начальные лямбды
                dataGridView2.Rows[226].Cells[i].Value = '1';
                dataGridView2.Rows[227].Cells[i].Value = '1';
                dataGridView2.Rows[228].Cells[i].Value = '1';
                dataGridViewL1.Rows[0].Cells[i].Value = '1';
                dataGridViewL2.Rows[0].Cells[i].Value = '1';
                dataGridViewL3.Rows[0].Cells[i].Value = '1';
                dataGridViewL4.Rows[0].Cells[i].Value = '1';
            }

            Random rnd = new Random();
            int nomer1,znak;
            for (int i = 0; i < 100; i++) //первые сто пикселей подключаю по порядку 
                //к А-элементам, чтобы у каждого А-элемента был хотя бы один икс
            {
                znak = rnd.Next(2); //как подключен:со знаком '+' или '-'
                if (znak ==0)
                    dataGridView2.Rows[i].Cells[i].Value = 1; //со знаком '+'
                else
                    dataGridView2.Rows[i].Cells[i].Value = -1;
            }
            for (int i = 100; i < 225; i++) //подключаю все оставшиеся пиксели
            {
                nomer1 = rnd.Next(100); //к какому А-элементу подключить
                znak = rnd.Next(2); //как подключен:со знаком '+' или '-'
                if (znak == 0)
                    dataGridView2.Rows[i].Cells[nomer1].Value = 1;
                else
                    dataGridView2.Rows[i].Cells[nomer1].Value = -1;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) //автообучение
        {
            string strFile;
            for (int i = 1; i < 41; i++) //обрабатывает по очереди 40 изображений
            {
                strFile = "pic" + i.ToString() + ".bmp";
                AvtoStep(strFile,i);
            }
        }

        private void AvtoStep(string str, int nomer) //эта процедура обрабатывает одно изображение при автоообучении
        {
            Bitmap img = new Bitmap(str);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (img.GetPixel(i, j).B == 0)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = "1"; //определение цвета пикселей
                    }
                    else
                        dataGridView1.Rows[j].Cells[i].Value = "0";
                }
            }

            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    dataGridView2.Rows[j + i * 15].HeaderCell.Value = 'x' + (j + 1 + i * 15).ToString() + "=".ToString() + dataGridView1.Rows[i].Cells[j].Value.ToString();
                    mas[j + i * 15] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                }

            int sum;
            for (int i = 0; i < 100; i++) //иду по всем А-элементам, считаю что они насуммировали
            {
                sum = 0;
                for (int j = 0; j < 225; j++)
                    sum += Convert.ToInt32(dataGridView2.Rows[j].Cells[i].Value.ToString()) * mas[j];
                dataGridView2.Rows[229].Cells[i].Value = sum.ToString();
            }
            for (int i = 0; i < 100; i++)
                if (Convert.ToInt32(dataGridView2.Rows[229].Cells[i].Value.ToString()) >= 1) //больше порога 1
                    dataGridView2.Rows[230].Cells[i].Value = '1'; //т.е. элемент А активен
                else
                    dataGridView2.Rows[230].Cells[i].Value = '0';

            for (int i = 0; i < 100; i++) //считаю Y*лямбды
            {
                dataGridView2.Rows[231].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[230].Cells[i].Value.ToString()) * Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString());
                dataGridView2.Rows[232].Cells[i].Value = (Convert.ToInt32(dataGridView2.Rows[230].Cells[i].Value.ToString()) * Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString())).ToString();
                dataGridView2.Rows[233].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[230].Cells[i].Value.ToString()) * Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString());
                dataGridView2.Rows[234].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[230].Cells[i].Value.ToString()) * Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString());
            }

            int sigma1 = 0, sigma2 = 0, sigma3 = 0, sigma4 = 0;
            for (int i = 0; i < 100; i++) //считаю значения сумматоров
            {
                sigma1 += Convert.ToInt32(dataGridView2.Rows[231].Cells[i].Value.ToString());
                sigma2 += Convert.ToInt32(dataGridView2.Rows[232].Cells[i].Value.ToString());
                sigma3 += Convert.ToInt32(dataGridView2.Rows[233].Cells[i].Value.ToString());
                sigma4 += Convert.ToInt32(dataGridView2.Rows[234].Cells[i].Value.ToString());
            }
            dataGridView2.Rows[235].Cells[0].Value = sigma1;
            dataGridView2.Rows[236].Cells[0].Value = sigma2;
            dataGridView2.Rows[237].Cells[0].Value = sigma3;
            dataGridView2.Rows[238].Cells[0].Value = sigma4;

            for (int i = 0; i < 100; i++) //изменяю лямбды
            {
                if (dataGridView2.Rows[230].Cells[i].Value.ToString() == "1") //если элемент активен
                {
                    if (nomer < 11) //первая ЦИФРА
                    {
                        dataGridView2.Rows[225].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString()) +1;
                        dataGridView2.Rows[226].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[227].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[228].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString()) - 1;
                    }
                    if ((nomer < 21) & (nomer > 10)) //вторая ЦИФРА
                    {
                        dataGridView2.Rows[225].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[226].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString()) + 1;
                        dataGridView2.Rows[227].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[228].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString()) - 1;
                    }
                    if ((nomer < 31) & (nomer > 20))
                    {
                        dataGridView2.Rows[225].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[226].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[227].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString()) + 1;
                        dataGridView2.Rows[228].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString()) - 1;
                    }
                    if (nomer > 30)
                    {
                        dataGridView2.Rows[225].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[225].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[226].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[226].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[227].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[227].Cells[i].Value.ToString()) - 1;
                        dataGridView2.Rows[228].Cells[i].Value = Convert.ToInt32(dataGridView2.Rows[228].Cells[i].Value.ToString()) + 1;
                    }

                }
            }
            for (int i = 0; i < 100; i++) //заполняю таблицы автообучения
            {
                dataGridViewL1.Rows[nomer].Cells[i].Value = dataGridView2.Rows[225].Cells[i].Value.ToString();
                dataGridViewL2.Rows[nomer].Cells[i].Value = dataGridView2.Rows[226].Cells[i].Value.ToString();
                dataGridViewL3.Rows[nomer].Cells[i].Value = dataGridView2.Rows[227].Cells[i].Value.ToString();
                dataGridViewL4.Rows[nomer].Cells[i].Value = dataGridView2.Rows[228].Cells[i].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
