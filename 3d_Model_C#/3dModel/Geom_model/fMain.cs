using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Geom_model
  
{
    public partial class fMain : Form
    {
  
    public fMain()
        {
            InitializeComponent();
            this.Text = "Shut";
        }

        private MyDraw md;

        int indproek = -1;

        private void fMain_Load(object sender, EventArgs e)
        {
            
           bDraw_Click(bDraw, new EventArgs());
            //cbPro.SelectedIndex = 0;
        }

        private void bDraw_Click(object sender, EventArgs e)
        {
          //  double parShir, parDl, parVys,dx,dy;
            double priH, priR;
            double konh, konr, dx,dy;
            int konn;

            priH = double.Parse(textBoxB.Text);
            priR = double.Parse(textBoxA.Text);
            konh = double.Parse(textBoxH.Text);
            konr = double.Parse(textBoxD.Text);
            konn = int.Parse(textBoxN.Text);

            md = new MyDraw(priH, priR, konh, konr, konn,
                pDraw.CreateGraphics(), 
                new PointF((float) (pDraw.Size.Width / 2 ),
                (float) (pDraw.Size.Height / 2 )));
            md.IsInvDel = isFill.Checked;
            md.IsColor = isColor.Checked;
            md.IsLight = cbLight.Checked;
            md.IsProj = false;
            md.SetLightPoint(int.Parse(tbLightX.Text),
                             -int.Parse(tbLightY.Text),
                             int.Parse(tbLightZ.Text));
            dx = double.Parse(textBoxDX.Text);
            dy = double.Parse(textBoxDY.Text);
            if (radioButton5.Checked)
            md.Draw(0,dx,dy);
            if (radioButton6.Checked)
                md.Draw(1, dx, dy);

            //cbPro.SelectedIndex = 0;
        }

        private void bRotate_Click(object sender, EventArgs e)
        {
            md.IsProj = false;
            md.RotateAll(
                int.Parse(tbRotX.Text),
                int.Parse(tbRotY.Text),
                int.Parse(tbRotZ.Text));


        }
        bool bLbLightChek;
        private void bMove_Click(object sender, EventArgs e)
        {
            md.IsProj = false;
            md.MoveAll(
                int.Parse(tbMoveX.Text),
                int.Parse(tbMoveY.Text),
                int.Parse(tbMoveZ.Text), indproek);
            if (bLbLightChek)
            {
                md.SetLightPoint(int.Parse(tbLightX.Text),
                             -int.Parse(tbLightY.Text),
                             int.Parse(tbLightZ.Text));
                md.DrawObjects();

            }

            vubr( indproek);
                
        }

        private void vubr(int ind)
        {
            switch (ind)
            {
                case -1:
                    md.DrawObjects();
                    break;
                case 0:
                    md.ProFrontAll();
                    break;
                case 1:
                    md.ProGorAll();
                    break;
                case 2:
                    md.ProProfAll();
                    break;
                case 3:
                    md.IsProj = true;
                    md.ProAksAll(double.Parse(textBoxFiAcs.Text), double.Parse(textBoxPsiAcs.Text));
                    break;
                case 4:
                    md.IsProj = true;
                    md.ProKosAll(double.Parse(textBoxLkos.Text), double.Parse(textBoxAlfakos.Text));
                    break;
                case 5:
                    md.IsProj = true;
                    md.ProPerAll(double.Parse(textBoxDPr.Text), double.Parse(textBoxTetaPr.Text), double.Parse(textBoxFiPr.Text), double.Parse(textBoxRPr.Text));
                    break;

            }
        }
         
        private void bScale_Click(object sender, EventArgs e)
        {
            md.IsProj = false;
            md.ScaleAll(
                (double)nudScaleX.Value,
                (double)nudScaleY.Value,
                (double)nudScaleZ.Value);

        }

        private void isFill_CheckedChanged(object sender, EventArgs e)
        {
            md.IsInvDel = isFill.Checked;
            md.DrawObjects();
            isColor.Enabled = isFill.Checked;
            cbLight.Enabled = isColor.Enabled && isColor.Checked;
        }

        private void isColor_CheckedChanged(object sender, EventArgs e)
        {
            md.IsColor = isColor.Checked;
            md.DrawObjects();
            cbLight.Enabled = isColor.Checked;
        }

        private void pDraw_Paint(object sender, PaintEventArgs e)
        {
            if (md != null) md.DrawObjects();
        }

        private void cbLight_CheckedChanged(object sender, EventArgs e)
        {
            md.IsLight = cbLight.Checked;
            gbLight.Visible = cbLight.Checked;
            //md.SetLightPoint(int.Parse(tbLightX.Text),
            //                 -int.Parse(tbLightY.Text),
            //                 int.Parse(tbLightZ.Text));
            md.DrawObjects();
        }

        private void bLight_Click(object sender, EventArgs e)
        {
            md.SetLightPoint(int.Parse(tbLightX.Text),
                             -int.Parse(tbLightY.Text),
                             int.Parse(tbLightZ.Text));
            md.DrawObjects();
            vubr(indproek);
            bLbLightChek = true;
        }
        //Фронтальная
        private void button9_Click(object sender, EventArgs e)
        {
            md.IsProj = true;
            md.ProFrontAll();
        }
        //профильная
        private void button10_Click(object sender, EventArgs e)
        {
            md.IsProj = true;           
            md.ProProfAll();
        }
       // горизонтальная
        private void button11_Click(object sender, EventArgs e)
        {
            md.IsProj = true;           
            md.ProGorAll();
        }
        //Аксонометрия
        private void button12_Click(object sender, EventArgs e)
        {
            md.IsProj = true;
            md.ProAksAll(double.Parse(textBoxFiAcs.Text), double.Parse(textBoxPsiAcs.Text));
        }
        //косоугольная
        private void button13_Click(object sender, EventArgs e)
        {
            md.IsProj = true;
            md.ProKosAll(double.Parse(textBoxLkos.Text), double.Parse(textBoxAlfakos.Text));
        }
        //перспектива
        private void button14_Click(object sender, EventArgs e)
        {
       
            md.IsProj = true;
            md.ProPerAll(double.Parse(textBoxDPr.Text), double.Parse(textBoxTetaPr.Text), double.Parse(textBoxFiPr.Text), double.Parse(textBoxRPr.Text));
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {

        }

        private void pOptions_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}