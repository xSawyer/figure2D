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
        Point centre;
        private int angle, r, v, b, epaisseur;

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
    }


    class Ligne : Figure2D
    {
        



    }

}
