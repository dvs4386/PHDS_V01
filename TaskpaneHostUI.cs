using System.Runtime.InteropServices;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using SolidWorks.Interop.swpublished;

namespace V01
{
    [ProgId(TaskpaneIntegration.SWTASKPANE_PROGID)]
    public partial class TaskpaneHostUI : UserControl
    {
        generator gen = new generator();

        public TaskpaneHostUI()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // M10 Daten in mm_________________
            double L = 40;      //Schaftgesamtlänge
            double B = 26;      //Gewindelänge
            double E = 18.9;    //Sechskant Ecke zu Ecke
            double K = 6.4;     //Schraubenkopfhöhe
            double S = 17;      //Sechskant Fläche zu Fläche
            double D1 = 10;     //Durchmesser Schaft   
            double P = 1.5;     //Steigung
            //_________________________________


            gen.schraube_sechskant(L,B,E,K,S,D1,P);

            
        }

        
    }







    
}
