using System;
using System.Collections.Generic;
using System.Drawing;

namespace Geom_model
{
    struct Point3
    {
        public Point3(double inX, double inY, double inZ)
        {
            X = inX;
            Y = inY;
            Z = inZ;
        }

        public double X;
        public double Y;
        public double Z;
    }

    struct Rebro
    {
        public Point3 A;
        public Point3 B;
    }

    class Gran
    {
        public Gran(Color cf)
        {
            Points = new List<Point3>();
            ColorFill = cf;
        }
        public List<Point3> Points;
        public Color Color;
        public Color ColorFill;
    }

    
   
    class MyDraw
    {
        
        #region Fields
        private Point3[] pKon = new Point3[100], pPri = new Point3[10];
        private Rebro[] rKon = new Rebro[200], rPri = new Rebro[15];
        private Gran[] gKon = new Gran[101], gPri = new Gran[7];

        private Point3[] pPriBackup = new Point3[10], pKonBackup = new Point3[100];
        private Rebro[] rPriBackup = new Rebro[15], rKonBackup = new Rebro[200];

        PointF Zero = new PointF(250, 250);
        private Graphics gr;

        private double priC, priR;
        private double konC, konR;
        private int konN;

        private int curCrepl;
        private bool isInvDel;
        private bool isColor;
        private bool isLight;
        private Point3 lightPoint;
        private bool isProj;

        public void SetLightPoint(double X, double Y, double Z)
        {
            lightPoint.X = X;
            lightPoint.Y = Y;
            lightPoint.Z = Z;
        }

        #endregion

        public MyDraw(double inpriC, double inpriR, double inkonC, double inkonR, int inkonN, Graphics inGr, PointF inZero)
        {
            priC = inpriC;
            priR = inpriR;
            konC = inkonC;
            konR = inkonR;
            konN = inkonN;
            gr = inGr;
            Zero = inZero;

            pPri[0].X = 0; pPri[0].Y = 0; pPri[0].Z = priR;
            pPri[1].X = priR * Math.Sin(2 * Math.PI / 5); pPri[1].Y = 0; pPri[1].Z = priR * Math.Cos(2 * Math.PI / 5);
            pPri[2].X = priR * Math.Sin(2 * Math.PI /10); pPri[2].Y = 0; pPri[2].Z = -priR * Math.Cos(2 * Math.PI / 10);
            pPri[3].X = -priR * Math.Sin(2 * Math.PI / 10); pPri[3].Y = 0; pPri[3].Z = -priR * Math.Cos(2 * Math.PI / 10);
            pPri[4].X = -priR * Math.Sin(2 * Math.PI / 5); pPri[4].Y = 0; pPri[4].Z = priR * Math.Cos(2 * Math.PI / 5);

            pPri[5].X = 0; pPri[5].Y = inpriC; pPri[5].Z = priR;
            pPri[6].X = priR * Math.Sin(2 * Math.PI / 5); pPri[6].Y = inpriC; pPri[6].Z = priR * Math.Cos(2 * Math.PI / 5);
            pPri[7].X = priR * Math.Sin(2 * Math.PI / 10); pPri[7].Y = inpriC; pPri[7].Z = -priR * Math.Cos(2 * Math.PI / 10);
            pPri[8].X = -priR * Math.Sin(2 * Math.PI / 10); pPri[8].Y = inpriC; pPri[8].Z = -priR * Math.Cos(2 * Math.PI / 10);
            pPri[9].X = -priR * Math.Sin(2 * Math.PI / 5); pPri[9].Y = inpriC; pPri[9].Z = priR * Math.Cos(2 * Math.PI / 5);
            

           
            for (int i = 0; i < gPri.Length; i++)
                gPri[i] = new Gran(Color.BlueViolet);

            SetEdgesPri();

            for (int i = 0; i < konN; i++)
            {
                if ((i * Math.PI * 2 / konN) == 0)//0
                {
                    pKon[i].X = 0; pKon[i].Y = 0; pKon[i].Z = konR; 

                }
                if (((i * Math.PI * 2 / konN) < (Math.PI / 2)) & ((i * Math.PI * 2 / konN) > 0))//<90
                {
                    pKon[i].X = konR * Math.Sin((2 * Math.PI / konN) * i); pKon[i].Y = 0; pKon[i].Z =  konR * Math.Cos((2 * Math.PI / konN) * i);
                }
                if ((i * Math.PI * 2 / konN) == (Math.PI / 2))//90
                {
                    pKon[i].X = konR; pKon[i].Y = 0; pKon[i].Z = 0; 
                }
                if (((i * Math.PI * 2 / konN) > (Math.PI / 2)) & ((i * (Math.PI * 2 / konN)) < Math.PI))//90-180
                {
                    pKon[i].X = konR * Math.Cos(-(Math.PI / 2) + (2 * Math.PI / konN) * i); pKon[i].Y = 0; pKon[i].Z = -konR * Math.Sin(-(Math.PI / 2) + ((2 * Math.PI / konN) * i));
                }
                if ((i * Math.PI * 2 / konN) == Math.PI)//180
                {
                    pKon[i].X = 0; pKon[i].Y = 0; pKon[i].Z = - konR; 
                }
                if (((i * Math.PI * 2 / konN) > Math.PI) & ((i * Math.PI * 2 / konN) < (3 * Math.PI / 2)))//180-270
                {
                    pKon[i].X = -konR * Math.Sin(-Math.PI + (2 * Math.PI / konN) * i); pKon[i].Y = 0; pKon[i].Z = -konR * Math.Cos(-Math.PI + (2 * Math.PI / konN) * i);
                }
                if (((i * 2 * Math.PI) / konN) == (3 * Math.PI / 2))//270
                {
                    pKon[i].X = -konR; pKon[i].Y = 0; pKon[i].Z = 0; 
                }
                if (((i * Math.PI * 2 / konN) < (2 * Math.PI)) & ((i * Math.PI * 2 / konN) > (3 * Math.PI / 2)))//270-360
                {
                    pKon[i].X = -konR * Math.Cos(-3 * Math.PI / 2 + (2 * Math.PI / konN) * i); pKon[i].Y = 0; pKon[i].Z = konR* Math.Sin(-3 * Math.PI / 2 + (2 * Math.PI / konN) * i);
                }
            }

            pKon[konN].X = 0; pKon[konN].Y = konC; pKon[konN].Z = 0; 

           
            
            for (int i = 0; i < gKon.Length; i++)
                gKon[i] = new Gran(Color.Yellow);
      
            SetEdgesKon();
        }

        public bool IsInvDel
        {
            set { isInvDel = value; }
        }

        public bool IsColor
        {
            set { isColor = value; }
        }

        public bool IsLight
        {
            set { isLight = value; }
        }

        public bool IsProj
        {
            set { isProj = value; }
        }

        private void SetEdgesPri()
        {
            rPri[0].A = pPri[0]; rPri[0].B = pPri[1];
            rPri[1].A = pPri[1]; rPri[1].B = pPri[2];
            rPri[2].A = pPri[2]; rPri[2].B = pPri[3];
            rPri[3].A = pPri[3]; rPri[3].B = pPri[4];
            rPri[4].A = pPri[4]; rPri[4].B = pPri[0];

            rPri[5].A = pPri[5]; rPri[5].B = pPri[6];
            rPri[6].A = pPri[6]; rPri[6].B = pPri[7];
            rPri[7].A = pPri[7]; rPri[7].B = pPri[8];
            rPri[8].A = pPri[8]; rPri[8].B = pPri[9];
            rPri[9].A = pPri[9]; rPri[9].B = pPri[0];

            rPri[10].A = pPri[0]; rPri[10].B = pPri[5];
            rPri[11].A = pPri[1]; rPri[11].B = pPri[6];
            rPri[12].A = pPri[2]; rPri[12].B = pPri[7];
            rPri[13].A = pPri[3]; rPri[13].B = pPri[8];
            rPri[14].A = pPri[4]; rPri[14].B = pPri[9];


            for (int i = 0; i < gPri.Length; i++)
                gPri[i].Points.Clear(); 


            gPri[0].Points.Add(pPri[5]);  gPri[0].Points.Add(pPri[0]);
            gPri[0].Points.Add(pPri[1]); gPri[0].Points.Add(pPri[6]);
          

            gPri[1].Points.Add(pPri[6]);gPri[1].Points.Add(pPri[1]);
            gPri[1].Points.Add(pPri[2]); gPri[1].Points.Add(pPri[7]); 
            

           gPri[2].Points.Add(pPri[7]);  gPri[2].Points.Add(pPri[2]); 
           gPri[2].Points.Add(pPri[3]);gPri[2].Points.Add(pPri[8]); 
           

gPri[3].Points.Add(pPri[8]);  gPri[3].Points.Add(pPri[3]);
            gPri[3].Points.Add(pPri[4]); gPri[3].Points.Add(pPri[9]); 
          

 gPri[4].Points.Add(pPri[9]);  gPri[4].Points.Add(pPri[4]);
            gPri[4].Points.Add(pPri[0]);gPri[4].Points.Add(pPri[5]);
           


        gPri[5].Points.Add(pPri[4]);  gPri[5].Points.Add(pPri[3]) ; 
           gPri[5].Points.Add(pPri[2]); gPri[5].Points.Add(pPri[1]);  
            gPri[5].Points.Add(pPri[0]);  
 
          
          
          
         
           gPri[6].Points.Add(pPri[7]); gPri[6].Points.Add(pPri[8]);
           gPri[6].Points.Add(pPri[9]) ;   gPri[6].Points.Add(pPri[5]);  gPri[6].Points.Add(pPri[6]);

        }
        private void SetEdgesKon()
        {

            for (int i = 0; i < konN -1; i++)
            {
                rKon[i].A = pKon[i]; rKon[i].B = pKon[i + 1];
                              
            }
            rKon[konN - 1].A = pKon[konN - 1]; rKon[konN - 1].B = pKon[0];

            for (int i = konN; i < 2*konN - 1; i++)
            {
                rKon[i].A = pKon[i - konN]; rKon[i].B = pKon[konN];

            }
                     

            for (int i = 0; i < gKon.Length; i++)
                gKon[i].Points.Clear();

            for (int i = 0; i < konN - 1; i++)
            {
                gKon[i].Points.Add(pKon[konN]);gKon[i].Points.Add(pKon[i]);
                gKon[i].Points.Add(pKon[i+1]);
                
            }
                        
            gKon[konN - 1].Points.Add(pKon[konN]);
            gKon[konN - 1].Points.Add(pKon[konN-1]); 
            gKon[konN - 1].Points.Add(pKon[0]);
            
          for (int i = 1; i < konN+1 ; i++)
            {
              gKon[konN].Points.Add(pKon[konN-i]);

            }

        }

        public void Draw(int NomGr, double pirDX, double pirDY)
        {
            
            Point3[] newpKon = new Point3[8];
            switch (NomGr)
            {
                case 0: newpKon = RotateX(0, pKon); ;
                    pKon = MovePir(new Point3(+pirDX, priC, +pirDY), newpKon);
                    curCrepl = 6; break;
                case 1: newpKon = RotateX(180, pKon); ;
                    pKon = MovePir(new Point3(+pirDX, 0, +pirDY), newpKon);
                    curCrepl = 5; break;
            }
            SetEdgesKon();
            DrawObjects();
        }

        private void DrawObject(Gran[] obj)
        {
            foreach (Gran gran in obj)
            {
                if (isInvDel & (gran.Points.ToArray().Length != 0))
                {
                    gran.Color = isProj ? gran.Color : gran.ColorFill;
                    if (IsVisible(gran))
                    {
                        List<PointF> lP = new List<PointF>();
                        foreach (Point3 point3 in gran.Points)
                        {
                            lP.Add(new PointF(Zero.X + (float)point3.X,
                                              Zero.Y - (float)point3.Y));
                        }
                        PointF[] lp1 = lP.ToArray();
                        if (lp1.Length != 0)
                        {
                            if (isColor)
                            {
                                if (isLight)
                                    gr.FillPolygon(new SolidBrush(gran.Color), lp1);
                                else
                                    gr.FillPolygon(new SolidBrush(gran.ColorFill), lp1);
                            }
                            else
                            {  
                                
                                gr.FillPolygon(new SolidBrush(Color.White), lp1);
                           
                            }
                            if (!isColor || !isLight)
                                gr.DrawPolygon(new Pen(Color.Black, 1), lp1);                  
                        }
                    }
                }
                else
                { 
                    List<PointF> lP = new List<PointF>();
                    foreach (Point3 point3 in gran.Points)
                    {
                        lP.Add(new PointF(Zero.X + (float)point3.X,Zero.Y - (float)point3.Y));
                    }

                    PointF[] lp1 = lP.ToArray();
                    if (lp1.Length > 0)
                    {
                        gr.DrawPolygon(new Pen(Color.Black, 1), lp1);
                    }
                }
            }
        }

        public void DrawObjects()
        {
            Color col = Color.White;
            gr.Clear(col);
            if (IsVisible(gPri[curCrepl]))
            {
               DrawObject(gPri);
                if (gKon.Length != 0)
                {
                   DrawObject(gKon);
                }
                 
            }
            else
            {
                
                if (gKon.Length != 0)
                {
                    DrawObject(gKon);
                }
                DrawObject(gPri);
            }
           
        }

        private void SetBackup()
        {
            for (int i = 0; i < pPri.Length; i++)
                pPriBackup[i] = pPri[i];
            for (int i = 0; i < pKon.Length; i++)
                pKonBackup[i] = pKon[i];
            for (int i = 0; i < rPri.Length; i++)
                rPriBackup[i] = rPri[i];
            for (int i = 0; i < rKon.Length; i++)
                rKonBackup[i] = rKon[i];
        }

        private void GetBackup()
        {
            for (int i = 0; i < pPri.Length; i++)
                pPri[i] = pPriBackup[i];
            for (int i = 0; i < pKon.Length; i++)
                pKon[i] = pKonBackup[i];
            for (int i = 0; i < rPri.Length; i++)
                rPri[i] = rPriBackup[i];
            for (int i = 0; i < rKon.Length; i++)
                rKon[i] = rKonBackup[i];
        }

      
        #region Ïîâîðîò
        public void RotateAll(int angleX, int angleY, int angleZ)
        {
            Point3[] tmpP1, tmpP2;
            tmpP1 = RotateX(angleX, pKon);
            tmpP2 = RotateY(angleY, tmpP1);
            pKon = RotateZ(angleZ, tmpP2);
            SetEdgesKon();

            tmpP1 = RotateX(angleX, pPri);
            tmpP2 = RotateY(angleY, tmpP1);
            pPri = RotateZ(angleZ, tmpP2);
            SetEdgesPri();
            DrawObjects();
           
        }
        private Point3[] RotateX(int ang, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            double radians = Math.PI * ang / 180;
            Matrix R = new Matrix(4, 4);
            R[0, 0] = 1;
            R[0, 1] = 0;
            R[0, 2] = 0;
            R[0, 3] = 0;
            R[1, 0] = 0;
            R[1, 1] = Math.Cos(radians);
            R[1, 2] = Math.Sin(radians);
            R[1, 3] = 0;
            R[2, 0] = 0;
            R[2, 1] = -Math.Sin(radians);
            R[2, 2] = Math.Cos(radians);
            R[2, 3] = 0;
            R[3, 0] = 0;
            R[3, 1] = 0;
            R[3, 2] = 0;
            R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 2];
            }

            return outMas;
        }
        private Point3[] RotateY(int ang, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            double radians = Math.PI * ang / 180;
            Matrix R = new Matrix(4, 4);
            R[0, 0] = Math.Cos(radians);
            R[0, 1] = 0;
            R[0, 2] = -Math.Sin(radians);
            R[0, 3] = 0;
            R[1, 0] = 0;
            R[1, 1] = 1;
            R[1, 2] = 0;
            R[1, 3] = 0;
            R[2, 0] = Math.Sin(radians);
            R[2, 1] = 0;
            R[2, 2] = Math.Cos(radians);
            R[2, 3] = 0;
            R[3, 0] = 0;
            R[3, 1] = 0;
            R[3, 2] = 0;
            R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 2];
            }
            return outMas;
        }
        private Point3[] RotateZ(int ang, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            double radians = Math.PI * ang / 180;
            Matrix R = new Matrix(4, 4);
            R[0, 0] = Math.Cos(radians);
            R[0, 1] = Math.Sin(radians);
            R[0, 2] = 0;
            R[0, 3] = 0;
            R[1, 0] = -Math.Sin(radians);
            R[1, 1] = Math.Cos(radians);
            R[1, 2] = 0;
            R[1, 3] = 0;
            R[2, 0] = 0;
            R[2, 1] = 0;
            R[2, 2] = 1;
            R[2, 3] = 0;
            R[3, 0] = 0;
            R[3, 1] = 0;
            R[3, 2] = 0;
            R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 2];
            }

            return outMas;
        }
        #endregion

        #region Ïåðåìåùåíèå
        private Point3[] MovePir(Point3 p, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            for (int i = 0; i < point3s.Length; i++)
            {
                outMas[i].X = point3s[i].X + p.X;
                outMas[i].Y = point3s[i].Y + p.Y;
                outMas[i].Z = point3s[i].Z + p.Z;
            }

            return outMas;
        }
        public void MoveAll(int disX, int disY, int disZ,int ind)
        {
            Point3[] tmpP;
            tmpP = Move(disX, disY, disZ, pPri);
            for (int i = 0; i < 10; i++)
                pPri[i] = tmpP[i];
            SetEdgesPri();

            tmpP = Move(disX, disY, disZ, pKon);
            for (int i = 0; i < konN+1; i++)
                pKon[i] = tmpP[i];
            SetEdgesKon();

          
        }
        private Point3[] Move(int disX, int disY, int disZ, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            Matrix R = new Matrix(4, 4);
            R[0, 0] = 1; R[0, 1] = 0; R[0, 2] = 0; R[0, 3] = 0;
            R[1, 0] = 0; R[1, 1] = 1; R[1, 2] = 0; R[1, 3] = 0;
            R[2, 0] = 0; R[2, 1] = 0; R[2, 2] = 1; R[2, 3] = 0;
            R[3, 0] = disX; R[3, 1] = disY; R[3, 2] = disZ; R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 2];
            }
            return outMas;
        }
        #endregion

        #region Ìàñøòàá
        public void ScaleAll(double scX, double scY, double scZ)
        {
            Point3[] tmpP;
            tmpP = Scale(scX, scY, scZ, pKon);
            for (int i = 0; i < konN +1; i++)
                pKon[i] = tmpP[i];
            SetEdgesKon();

            tmpP = Scale(scX, scY, scZ, pPri);
            for (int i = 0; i < 10; i++)
                pPri[i] = tmpP[i];
            SetEdgesPri();

            DrawObjects();
        }
        private Point3[] Scale(double scX, double scY, double scZ, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            Matrix R = new Matrix(4, 4);
            R[0, 0] = scX; R[0, 1] = 0; R[0, 2] = 0; R[0, 3] = 0;
            R[1, 0] = 0; R[1, 1] = scY; R[1, 2] = 0; R[1, 3] = 0;
            R[2, 0] = 0; R[2, 1] = 0; R[2, 2] = scZ; R[2, 3] = 0;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = 0; R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 2];
            }
            return outMas;
        }
        #endregion

        #region Ïðîåêöèè
        public void ProFrontAll()
        {
            SetBackup();
            Point3[] tmpP;
            tmpP = ProFront(pKon);
            for (int i = 0; i < konN+1; i++)
                pKon[i] = tmpP[i];
            SetEdgesKon();

            tmpP = ProFront(pPri);
            for (int i = 0; i < 10; i++)
                pPri[i] = tmpP[i];
            SetEdgesPri();

            //lightPoint = ProFront(new Point3[] { lightPoint })[0];

            DrawObjects();
            GetBackup();
        }
        private Point3[] ProFront(Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            Matrix R = new Matrix(4, 4);
            R[0, 0] = 1; R[0, 1] = 0; R[0, 2] = 0; R[0, 3] = 0;
            R[1, 0] = 0; R[1, 1] = 1; R[1, 2] = 0; R[1, 3] = 0;
            R[2, 0] = 0; R[2, 1] = 0; R[2, 2] = 0; R[2, 3] = 0;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = 0; R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 2];
            }
            return outMas;
        }

        public void ProGorAll()
        {
            SetBackup();
            Point3[] tmpP;
            tmpP = ProGor(pKon);
            for (int i = 0; i < konN+1 ; i++)
                pKon[i] = tmpP[i];
            SetEdgesKon();

            tmpP = ProGor(pPri);
            for (int i = 0; i < 10; i++)
                pPri[i] = tmpP[i];
            SetEdgesPri();

            DrawObjects();
            GetBackup();
        }
        private Point3[] ProGor(Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            Matrix R = new Matrix(4, 4);
            R[0, 0] = 1; R[0, 1] = 0; R[0, 2] = 0; R[0, 3] = 0;
            R[1, 0] = 0; R[1, 1] = 0; R[1, 2] = 0; R[1, 3] = 0;
            R[2, 0] = 0; R[2, 1] = 0; R[2, 2] = 1; R[2, 3] = 0;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = 0; R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 2];
                outMas[i].Z = outM[0, 1];
            }
            return outMas;
        }

        public void ProProfAll()
        {
            SetBackup();
            Point3[] tmpP;
            tmpP = ProProf(pKon);
            for (int i = 0; i <konN+1; i++)
                pKon[i] = tmpP[i];
            SetEdgesKon();

            tmpP = ProProf(pPri);
            for (int i = 0; i < 10; i++)
                pPri[i] = tmpP[i];
            SetEdgesPri();

            DrawObjects();
            GetBackup();
        }
        private Point3[] ProProf(Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            Matrix R = new Matrix(4, 4);
            R[0, 0] = 0; R[0, 1] = 0; R[0, 2] = 0; R[0, 3] = 0;
            R[1, 0] = 0; R[1, 1] = 1; R[1, 2] = 0; R[1, 3] = 0;
            R[2, 0] = 0; R[2, 1] = 0; R[2, 2] = 1; R[2, 3] = 0;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = 0; R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 2];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 0];
            }
            return outMas;
        }
     

        public void ProAksAll(double fi, double psi)
        {
            SetBackup();
            Point3[] tmpP;
            fi = Math.PI * fi / 180;
            psi = Math.PI * psi / 180;
            tmpP = ProAks(fi, psi, pKon);
            for (int i = 0; i < konN+1 ; i++)
                pKon[i] = tmpP[i];
            SetEdgesKon();

            tmpP = ProAks(fi, psi, pPri);
            for (int i = 0; i < 10; i++)
                pPri[i] = tmpP[i];
            SetEdgesPri();

            DrawObjects();
            GetBackup();
        }
        private Point3[] ProAks(double fi, double psi, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            Matrix R = new Matrix(4, 4);
            R[0, 0] = Math.Cos(psi);    R[0, 1] = Math.Sin(fi) * Math.Sin(psi);     R[0, 2] = 0; R[0, 3] = 0;
            R[1, 0] = 0;                R[1, 1] = Math.Cos(fi);                     R[1, 2] = 0; R[1, 3] = 0;
            R[2, 0] = Math.Sin(psi);    R[2, 1] = -1 * Math.Sin(fi) * Math.Cos(psi);R[2, 2] = 0; R[2, 3] = 0;
            R[3, 0] = 0;                R[3, 1] = 0;                                R[3, 2] = 0; R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 2];
            }
            return outMas;
        }

        public void ProKosAll(double L, double alfa)
        {
            SetBackup();
            Point3[] tmpP;
            alfa = Math.PI * alfa / 180;
            tmpP = ProKos(L, alfa, pKon);
            for (int i = 0; i < konN+1 ; i++)
                pKon[i] = tmpP[i];
            SetEdgesKon();

            tmpP = ProKos(L, alfa, pPri);
            for (int i = 0; i < 10; i++)
                pPri[i] = tmpP[i];
            SetEdgesPri();

            DrawObjects();
            GetBackup();
        }
        private Point3[] ProKos(double L, double alfa, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            Matrix R = new Matrix(4, 4);
            R[0, 0] = 1; R[0, 1] = 0; R[0, 2] = 0; R[0, 3] = 0;
            R[1, 0] = 0; R[1, 1] = 1; R[1, 2] = 0; R[1, 3] = 0;
            R[2, 0] = L * Math.Cos(alfa); R[2, 1] = L * Math.Sin(alfa); R[2, 2] = 0; R[2, 3] = 0;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = 0; R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                outMas[i].X = outM[0, 0];
                outMas[i].Y = outM[0, 1];
                outMas[i].Z = outM[0, 2];
            }
            return outMas;
        }

        public void ProPerAll(double d, double tetta, double fi, double ro)
        {
            SetBackup();
            Point3[] tmpP;
            fi = Math.PI * fi / 180;
            tetta = Math.PI * tetta / 180;
            ro = ro == 0 ? 0.01 : ro;
            tmpP = ProPer(d, tetta, fi, ro, pKon);
            for (int i = 0; i < konN+1 ; i++)
                pKon[i] = tmpP[i];
            SetEdgesKon();

            tmpP = ProPer(d, tetta, fi, ro, pPri);
            for (int i = 0; i < 10; i++)
                pPri[i] = tmpP[i];
            SetEdgesPri();

            DrawObjects();
            GetBackup();
        }
        private Point3[] ProPer(double d, double tetta, double fi, double ro, Point3[] point3s)
        {
            Point3[] outMas = new Point3[point3s.Length];

            Matrix R = new Matrix(4, 4);
            /*R[0, 0] = -Math.Sin(tetta); R[0, 1] = -Math.Cos(fi) * Math.Cos(tetta); R[0, 2] = -Math.Sin(fi) * Math.Cos(tetta); R[0, 3] = 0;
            R[1, 0] = Math.Cos(tetta); R[1, 1] = -Math.Cos(fi) * Math.Sin(tetta); R[1, 2] = -Math.Sin(fi) * Math.Sin(tetta); R[1, 3] = 0;
            R[2, 0] = 0; R[2, 1] = Math.Sin(fi); R[2, 2] = -Math.Cos(fi); R[2, 3] = 0;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = ro; R[3, 3] = 1;*/

            R[0, 0] = Math.Cos(tetta); R[0, 1] = -Math.Cos(fi) * Math.Sin(tetta); R[0, 2] = -Math.Sin(fi) * Math.Sin(tetta); R[0, 3] = 0;
            R[1, 0] = Math.Sin(tetta); R[1, 1] = Math.Cos(fi) * Math.Cos(tetta); R[1, 2] = Math.Sin(fi) * Math.Cos(tetta); R[1, 3] = 0;
            R[2, 0] = 0; R[2, 1] = Math.Sin(fi); R[2, 2] = -Math.Cos(fi); R[2, 3] = 0;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = ro; R[3, 3] = 1;

            for (int i = 0; i < point3s.Length; i++)
            {
                Matrix s = new Matrix(1, 4);
                s[0, 0] = point3s[i].X;
                s[0, 1] = point3s[i].Y;
                s[0, 2] = point3s[i].Z;
                s[0, 3] = 1;

                Matrix outM = Matrix.Multiply(s, R);
                if (outM[0, 2] == 0)
                {
                    outM[0, 2] = 0.1;
                }
                outMas[i].X = outM[0, 0] * d / outM[0, 2];
                outMas[i].Y = outM[0, 1] * d / outM[0, 2];
                outMas[i].Z = outM[0, 2] * d / outM[0, 2];
            }
            return outMas;
        }
        #endregion

        public bool IsVisible(Gran curGr)
        {

            
                Point3 VecA = new Point3();
                Point3 VecB = new Point3();
                Point3 norm = new Point3();
                Point3 Vis = new Point3();
                double normL, visL, ResVis;
                bool isVis;
            // Вектор А
                    VecA.X = curGr.Points[1].X - curGr.Points[0].X;
                    VecA.Y = curGr.Points[1].Y - curGr.Points[0].Y;
                    VecA.Z = curGr.Points[1].Z - curGr.Points[0].Z;
            // Вектор B
                    VecB.X = curGr.Points[2].X - curGr.Points[1].X;
                    VecB.Y = curGr.Points[2].Y - curGr.Points[1].Y;
                    VecB.Z = curGr.Points[2].Z - curGr.Points[1].Z;
            //Теперь найдем нормаль к каждой плоскости:

            norm.X = VecA.Y * VecB.Z - VecA.Z * VecB.Y;
                    norm.Y = VecA.X * VecB.Z - VecA.Z * VecB.X;
                    norm.Z = VecA.X * VecB.Y - VecA.Y * VecB.X;
            //Вектор луча падения мы задаем вручную:  
            Vis.X = 0; Vis.Y = 0; Vis.Z = -1000;
            //Общая нормаль к грани и вектор угла падения будут равны:
                    normL = Math.Sqrt(Math.Pow(norm.X, 2) +
                            Math.Pow(norm.Y, 2) +
                            Math.Pow(norm.Z, 2));

                    visL = Math.Sqrt(Math.Pow(Vis.X, 2) +
                           Math.Pow(Vis.Y, 2) +
                           Math.Pow(Vis.Z, 2));
               
                if (normL == 0 || visL == 0)
                    ResVis = -1;
                else
                {
                //Угол между нормалью и вектором угла падения ищется по формуле:

                ResVis = (norm.X * Vis.X + norm.Y * Vis.Y + norm.Z * Vis.Z) / (normL * visL);
                }
                isVis = (ResVis <= 0);

                if (isLight && !isProj)
                {
                //Зная координаты источника света, можно вычислить длину вектора от источника света до точки рассмотрения:

                visL = Math.Sqrt(Math.Pow(lightPoint.X, 2) +
                        Math.Pow(lightPoint.Y, 2) +
                        Math.Pow(lightPoint.Z, 2));

                //normL = normL == 0 ? 0.0001 : normL;
                visL = visL == 0 ? 0.0001 : visL;
                // Косинус угла между данными векторами находим следующим образом:

                ResVis = (norm.X * lightPoint.X + norm.Y * lightPoint.Y + norm.Z * lightPoint.Z) / (normL * visL);
                //Находим интенсивность:

                curGr.Color = Color.FromArgb((int)(curGr.Color.R * (0.5 + 0.5 * ResVis)),
                                           (int)(curGr.Color.G * (0.5 + 0.5 * ResVis)),
                                           (int)(curGr.Color.B * (0.5 + 0.5 * ResVis)));
                }
                return isVis;
       


        }

       
    }
}



    


