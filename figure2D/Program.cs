using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace figure2D
{
    static class Program
    {
        
        static void Main()
        {
            Form myForm;
            Bitmap btmp;
            Graphics grphcs;

            Ligne ligne1, ligne2, ligne3, ligne4, ligne5;
            btmp = new Bitmap(800, 400);

            ligne1 = new Ligne(20, 20, 100, 20, 100, 100, 100);
            ligne2 = new Ligne(100, 20, 100, 100, 100, 100, 100);
            ligne3 = new Ligne(100, 100, 20, 100, 100, 100, 100);
            ligne4 = new Ligne(20, 100, 20, 20, 100, 100, 100);
            ligne5 = new Ligne(20, 100, 100, 20, 255, 0, 0);

            grphcs = Graphics.FromImage(btmp);

            ligne1.Dessiner(grphcs);
            ligne2.Dessiner(grphcs);
            ligne3.Dessiner(grphcs);
            ligne4.Dessiner(grphcs);
            ligne5.Dessiner(grphcs);

            ligne4.ChangeCouleur(0, 255, 0);
            ligne4.Dessiner(grphcs);
            /*ligne1.Translation(20, 20);
            ligne1.Dessiner(grphcs);
            ligne1.Rotation(50);
            ligne1.Dessiner(grphcs);*/


            myForm = new Form();
            myForm.Text = "CNAM Licence Cyber-Sécurité 2021-2022";
            myForm.BackColor = Color.FromArgb(255, 255, 255);
            myForm.ClientSize = btmp.Size;
            myForm.BackgroundImage = btmp;
            myForm.Cursor = Cursors.Cross;
            myForm.ShowDialog();
            myForm.Dispose();

        }
    }

    class Figure2D
    {
        //Champs
        //protected : accessible dans les classes enfants
        protected Point centre;       
        protected int angle, r, v, b, epaisseur;

        //Constructeur
        public Figure2D(int rouge, int vert, int bleu)
        {
            angle = 0;
            epaisseur = 2;
            r = rouge; v = vert; b = bleu;
        }
        public void ChangeCouleur(int rouge, int vert, int bleu)
        {
            this.r = rouge; this.v = vert; this.b = bleu;
        }
        public void Rotation(int alpha)
        {
            angle = angle + alpha;
        }

        //virtual signifie qu'on peut surcharger cette méthode dans un enfant
        public virtual void Translation(int x, int y)
        {
            centre.X += x;
            centre.Y += y;
        }
    }


    class Ligne : Figure2D
    {

        private Point A, B;
        
        //Constructeur
        public Ligne(int xA, int yA, int xB, int yB, int rouge, int vert, int bleu) : base(rouge,vert,bleu)
        {

            //xA, yA coordonnée de l'origine
            //xB, yB corrdonnée de l'extrémité
            A.X = xA;
            A.Y = yA;
            B.X = xB;
            B.Y = yB;
        }
        public void Dessiner(Graphics grphcs)
        {
            grphcs.RotateTransform(angle);
            Pen pen = new Pen(Color.FromArgb(r, v, b));
            pen.Width = epaisseur;
            grphcs.DrawLine(pen, A, B);

        }

        //override signifie qu'on surcharge la méthode Translation
        public override void Translation(int x, int y)
        {
            A.X += x;
            A.Y += y;
            B.X += x;
            B.Y += y;
        }

        public void Echelle(double coeff)
        {
            int mX, mY;
            mX = ((A.X + B.X) / 2);
            mY = ((A.Y + B.Y) / 2);

            Translation(-mX, -mY);

            A.X = (int)(A.X * coeff);
            A.Y = (int)(A.Y * coeff);
            B.X = (int)(B.X * coeff);
            B.Y = (int)(B.Y * coeff);

            Translation(mX, mY);
        }


    }

}
