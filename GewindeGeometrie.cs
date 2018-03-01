using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V01
{
    class GewindeGeometrie
    {
        //Verwendete Formeln und Werte (Tabellenbuch Metall S206):
        // Gewindetiefe h3  = 0,6134 * Steigung
        // Rundung R        = 0,1443 * Steigung
        // Flankenwinkel    = 60°
        
        //WICHTIG: Tabelle mit Daten aus Tabellbuch hinzufügen!!!

        

        public double x1;// { get; set; }
        public double y1;// { get; set; }

        public double x2;// { get; set; }
        public double y2;// { get; set; }

        public double x3;// { get; set; }
        public double y3;// { get; set; }

        public double x4;// { get; set; }
        public double y4;// { get; set; }

        public double x5;// { get; set; }
        public double y5;// { get; set; }

        public double x6;// { get; set; }
        public double y6;// { get; set; }

        public GewindeGeometrie(double D, double L, bool aussengewinde)
        {
            Werte_MetrischeGewinde werte = new Werte_MetrischeGewinde(D);

            //Formeln
            double h3 = werte.h3;
            double R = werte.R;

            this.x1 = L;
            this.y1 = (D / 2) - h3 + R;
            this.x2 = x1 - Math.Cos(Math.PI / 6) * R;
            this.y2 = y1 - Math.Sin(Math.PI / 6) * R;
            this.x3 = x1 + Math.Cos(Math.PI / 6) * R;
            this.y3 = y2;
            this.y4 = (D / 2) + (D / 2) / 100;
            this.x4 = x2 - Math.Sin(Math.PI / 6) * (Math.Cos(Math.PI / 6) / (y4 - y3));
            this.x5 = x3 + Math.Sin(Math.PI / 6) * (Math.Cos(Math.PI / 6) / (y4 - y3));
            this.y5 = y4;



            //this.x1 = L;
            //this.y1 = D / 2;

            //this.y3 = y1 - h3 + R;

            //this.y2 = y3 - Math.Sin(Math.PI / 6) * R;

            //this.y4 = y2;
            //this.y5 = y1;

            //this.x2 = x1 + Math.Sin(Math.PI / 6) * ((y1 - y2) / Math.Cos(Math.PI / 6));

            //this.x3 = x2 + Math.Cos(Math.PI / 6) * R;
            //this.x4 = x3 + Math.Cos(Math.PI / 6) * R;
            //this.x5 = x1 + ((x3 - x1) * 2);

            //this.y6 = y1 - h3;
            //this.x6 = x3;
        }

        
    }
}
