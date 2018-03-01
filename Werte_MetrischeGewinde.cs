using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V01
{
    class Werte_MetrischeGewinde
    {
        public double M1_P = 0.25;
        public double M1_2_P = 0.25;
        public double M1_6_P = 0.35;

        public double M2_P = 0.4;
        public double M2_5_P = 0.45;
        public double M3_P = 0.5;

        public double M3_5_P = 0.6;
        public double M4_P = 0.7;
        public double M5_P = 0.8;

        public double M6_P = 1;
        public double M7_P = 1;
        public double M8_P = 1.25;

        public double M10_P = 1.5;
        public double M12_P = 1.75;
        public double M14_P = 2;

        public double M16_P = 2;
        public double M20_P = 2.5;
        public double M24_P = 3;

        public double M30_P = 3.5;
        public double M36_P = 4;
        public double M42_P = 4.5;

        public double h3; // Gewindetiefe des Außengewindes
        public double R;  // Rundung
        public double P;  // Steigung

        public double[] M_werte= new double[]{1 , 1.2 , 1.6 , 2 , 2.5 , 3 , 3.5 , 4 , 5 , 6 , 7 , 8 , 10 , 12 , 14 , 16 , 20 , 24 , 30 , 36 , 42};

        public Werte_MetrischeGewinde(double D)
        {
            
            switch (D)
            {
                case 1:
                    this.h3 = 0.6134 * M1_P;
                    this.R = 0.1443 * M1_P;
                    this.P = M1_P;
                    break;
                case 1.2:
                    this.h3 = 0.6134 * M1_2_P;
                    this.R = 0.1443 * M1_2_P;
                    this.P = M1_2_P;
                    break;
                case 1.6:
                    this.h3 = 0.6134 * M1_6_P;
                    this.R = 0.1443 * M1_6_P;
                    this.P = M1_6_P;
                    break;

                case 2:
                    this.h3 = 0.6134 * M2_P;
                    this.R = 0.1443 * M2_P;
                    this.P = M2_P;
                    break;
                case 2.5:
                    this.h3 = 0.6134 * M2_5_P;
                    this.R = 0.1443 * M2_5_P;
                    this.P = M2_5_P;
                    break;
                case 3:
                    this.h3 = 0.6134 * M3_P;
                    this.R = 0.1443 * M3_P;
                    this.P = M3_P;
                    break;

                case 3.5:
                    this.h3 = 0.6134 * M3_5_P;
                    this.R = 0.1443 * M3_5_P;
                    this.P = M3_5_P;
                    break;
                case 4:
                    this.h3 = 0.6134 * M4_P;
                    this.R = 0.1443 * M4_P;
                    this.P = M4_P;
                    break;
                case 5:
                    this.h3 = 0.6134 * M5_P;
                    this.R = 0.1443 * M5_P;
                    this.P = M5_P;
                    break;

                case 6:
                    this.h3 = 0.6134 * M6_P;
                    this.R = 0.1443 * M6_P;
                    this.P = M6_P;
                    break;
                case 7:
                    this.h3 = 0.6134 * M7_P;
                    this.R = 0.1443 * M7_P;
                    this.P = M7_P;
                    break;
                case 8:
                    this.h3 = 0.6134 * M8_P;
                    this.R = 0.1443 * M8_P;
                    this.P = M8_P;
                    break;

                case 10:
                    this.h3 = 0.6134 * M10_P;
                    this.R = 0.1443 * M10_P;
                    this.P = M10_P;
                    break;
                case 12:
                    this.h3 = 0.6134 * M12_P;
                    this.R = 0.1443 * M12_P;
                    this.P = M12_P;
                    break;
                case 14:
                    this.h3 = 0.6134 * M14_P;
                    this.R = 0.1443 * M14_P;
                    this.P = M14_P;
                    break;

                case 16:
                    this.h3 = 0.6134 * M16_P;
                    this.R = 0.1443 * M16_P;
                    this.P = M16_P;
                    break;
                case 20:
                    this.h3 = 0.6134 * M20_P;
                    this.R = 0.1443 * M20_P;
                    this.P = M20_P;
                    break;
                case 24:
                    this.h3 = 0.6134 * M24_P;
                    this.R = 0.1443 * M24_P;
                    this.P = M24_P;
                    break;

                case 30:
                    this.h3 = 0.6134 * M30_P;
                    this.R = 0.1443 * M30_P;
                    this.P = M30_P;
                    break;
                case 36:
                    this.h3 = 0.6134 * M36_P;
                    this.R = 0.1443 * M36_P;
                    this.P = M36_P;
                    break;
                case 42:
                    this.h3 = 0.6134 * M42_P;
                    this.R = 0.1443 * M42_P;
                    this.P = M42_P;
                    break;
                    
                default:
                    this.h3 = 0;
                    this.R = 0;
                    this.P = 0;
                    break;
            }
            
        }
    }
}
