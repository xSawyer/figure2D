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

        public void translation(int x, int y)
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

        public void translation(int x, int y)
        {
            centre.X += x;
            centre.Y += y;
        }


    }

}
