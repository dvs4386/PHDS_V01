using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;

namespace V01
{
    class generator
    {
        public SldWorks swApp;

        public void schraube_sechskant(double L, double B, double E, double K, double S, double D, double P)
        {
            //Erklärung zu übergebenen Variablen:
            // L = Schaftgesamtlänge
            // B = Gewindelänge
            // E = Sechskant Ecke zu Ecke
            // K = Schraubenkopfhöhe
            // S = Sechskant Fläche zu Fläche
            // D1 = Durchmesser Schaft   
            // P = Steigung
            
            //VARIABLEN CUSTOM
            double x1 = 0;
            double y1 = 0;
            double x2 = 0;
            double y2 = 0;
            double x3 = 0;
            double y3 = 0;
            double x4 = 0;
            double y4 = 0;
            double x5 = 0;
            double y5 = 0;
            


            //VARIABLEN API
            swApp = new SldWorks();
            ModelDoc2 swDoc = null;
            bool boolstatus = false;
            SketchSegment skSegment = null;
            SketchText mySketchText = null;
            Werte_MetrischeGewinde werte = new Werte_MetrischeGewinde(D);

            

            //PartDoc swPart = null;
            //DrawingDoc swDrawing = null;
            //AssemblyDoc swAssembly = null;

            //int longstatus = 0;
            //int longwarnings = 0;
            swDoc = ((ModelDoc2)(swApp.NewDocument("C:\\ProgramData\\SolidWorks\\SOLIDWORKS 2016\\templates\\Teil.prtdot", 0, 0, 0)));
            
            swDoc.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swDisplayAxes)), false);
            swDoc.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swDisplayCurves)), false);

            //swApp.ActivateDoc2("Teil1", false, ref longstatus);
            //swDoc = ((ModelDoc2)(swApp.ActiveDoc)); 
            //ModelView myModelView = null;
            //myModelView = ((ModelView)(swDoc.ActiveView));
            //myModelView.FrameState = ((int)(swWindowState_e.swWindowMaximized));
            boolstatus = swDoc.Extension.SelectByID2("Ebene vorne", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
            //swDoc.ClearSelection2(true);
            Array vSkLines = null;

            //Berechnung der Punktkoordinate für ein 6eckiges Polygon
            E = (S / 2) / (Math.Cos(Math.PI / 6));

            //CreatePolygon
            vSkLines = ((Array)(swDoc.SketchManager.CreatePolygon(0, 0, 0, E / 1000, 0, 0, 6, true)));
            // X coordinate for the center
            // Y coordinate for the center
            // Z coordinate for the center
            // X coordinate of a vertex
            // Y coordinate of a vertex
            // Z coordinate of a vertex
            // Number of sides in the polygon
            // True to show an inscribed construction circle, false to show a circumscribed construction circle


            //swDoc.ClearSelection2(true);
            swDoc.SketchManager.InsertSketch(true);
            //swDoc.ShowNamedView2("*Trimetrisch", 8);
            //swDoc.ClearSelection2(true);
            boolstatus = swDoc.Extension.SelectByID2("Skizze1", "SKETCH", 0, 0, 0, false, 4, null, 0);
            Feature myFeature = null;
            myFeature = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, K / 1000, 0, false, false, false, false, 17453292519943334, 17453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
            swDoc.ISelectionManager.EnableContourSelection = false;

            //PART2

            boolstatus = swDoc.Extension.SelectByID2("", "FACE", 0.002, 0.002, 0, true, 0, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Point1@Ursprung", "EXTSKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            boolstatus = swDoc.InsertAxis2(true);

            boolstatus = swDoc.Extension.SelectByID2("Ebene rechts", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
            swDoc.ClearSelection2(true);

            //echtes E berechnen

            //CreateLine
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(0, ((S / 2) - (S / 20)) / 1000, 0, -(K / 10) / 1000, E / 1000, 0)));
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(-(K / 10) / 1000, E / 1000, 0, 0, E / 1000, 0)));
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(0, E / 1000, 0, 0, ((S / 2) - (S / 20)) / 1000, 0)));

            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(-K / 1000, ((S / 2) - (S / 20)) / 1000, 0, -K / 1000 + (K / 10) / 1000, E / 1000, 0)));
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(-K / 1000 + (K / 10) / 1000, E / 1000, 0, -K / 1000, E / 1000, 0)));
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(-K / 1000, E / 1000, 0, -K / 1000, ((S / 2) - (S / 20)) / 1000, 0)));
            // X coordinate of the line start point
            // Y coordinate of the line start point
            // Z coordinate of the line start point
            // X coordinate of the line end point
            // Y coordinate of the line end point
            // Z coordinate of the line end point


            boolstatus = swDoc.Extension.SelectByID2("Skizze2", "SKETCH", 0, 0, 0, false, 0, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Achse1", "AXIS", 10189040183033668, 0, -3031167994862023, true, 16, null, 0);

            myFeature = ((Feature)(swDoc.FeatureManager.FeatureRevolve2(true, true, false, true, false, false, 0, 0, 6.2831853071796, 0, false, false, 0.01, 0.01, 0, 0, 0, true, true, true)));
            swDoc.ClearSelection2(true);
            //swDoc.ISelectionManager.EnableContourSelection = false;

            //PART3

            
            boolstatus = swDoc.Extension.SelectByID2("", "FACE", 0.001, 0.001, 0, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
            swDoc.ClearSelection2(true);

            //CreateCircle
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCircle(0, 0, 0, D/2/1000, 0, 0)));
            // X coordinate of the circle center point
            // Y coordinate of the circle center point
            // Z coordinate of the circle center point
            // X coordinate of the point on the circle
            // Y coordinate of the point on the circle
            // Z coordinate of the point on the circle
            
            boolstatus = swDoc.Extension.SelectByID2("Skizze3", "SKETCH", 0, 0, 0, false, 4, null, 0);
            myFeature = ((Feature)(swDoc.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, L/1000, 1, false, false, false, false, 17453292519943334, 17453292519943334, false, false, false, false, true, true, true, 0, 0, false)));
            
            swDoc.ClearSelection2(true);

            boolstatus = swDoc.Extension.SelectByID2("", "EDGE", D/2/1000, 0, -L/1000, true, 0, null, 0);
            myFeature = ((Feature)(swDoc.FeatureManager.InsertFeatureChamfer(4, 1, 1.5*werte.h3/1000, 0.78539816339745, 0, 0, 0, 0)));

            swDoc.ClearSelection2(true);

            //HELIX erzeugen
            boolstatus = swDoc.Extension.SelectByID2("", "FACE", 0, 0, -L / 1000, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true); //Erstellt Skizze und kann auch Skizze beenden
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCircle(0, 0, 0, D / 2 / 1000, 0, 0)));
            swDoc.SketchManager.InsertSketch(true); //Erstellt Skizze und kann auch Skizze beenden

            boolstatus = swDoc.Extension.SelectByID2("Skizze4", "SKETCH", 0, 0, 0, false, 0, null, 0);
            //InsertVariablePitchHelix 
            boolstatus = swDoc.FeatureManager.InsertVariablePitchHelix(true, true, 2, 1.5707963267949);
            // True to reverse the variable-pitch helix, false to not
            // True to create the variable-pitch helix in a clockwise direction, false to create in a counter-clockwise direction
            // Definition of variable-pitch helix:  0 = swHelixDefinedByPitchAndRevolution  1 = swHelixDefinedByHeightAndRevolution  2 = swHelixDefinedByHeightAndPitch  3 = swHelixDefinedBySpiral
            // Angle at which to start the variable-pitch helix
            boolstatus = swDoc.FeatureManager.AddVariablePitchHelixSegment(0, D / 1000, werte.P / 1000);
            boolstatus = swDoc.FeatureManager.AddVariablePitchHelixSegment(B / 1000, D / 1000, werte.P / 1000);
            boolstatus = swDoc.FeatureManager.AddVariablePitchHelixSegment((B + (B / 20)) / 1000, (D + 2*werte.h3) / 1000, werte.P / 1000);
            myFeature = ((Feature)(swDoc.FeatureManager.EndVariablePitchHelix()));

            boolstatus = swDoc.Extension.SelectByID2("Skizze4", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swDoc.BlankSketch();


            //GEWINDEskizze erzeugen und AUSGETRAGENER SCHNITT

            boolstatus = swDoc.Extension.SelectByID2("Ebene rechts", "PLANE", 0, 0, 0, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
            swDoc.ClearSelection2(true);

            bool aussengewinde = true;

            GewindeGeometrie result = new GewindeGeometrie(D, L ,aussengewinde); 
            x1 = result.x1;
            y1 = result.y1;
            x2 = result.x2;
            y2 = result.y2;
            x3 = result.x3;
            y3 = result.y3;
            x4 = result.x4;
            y4 = result.y4;
            x5 = result.x5;
            y5 = result.y5;
            

            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(x2/1000, y2/1000, 0, x4/1000, y4/1000, 0))); //Punkt 2 zu Punkt 4
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(x4/1000, y4/1000, 0, x5/1000, y5/1000, 0))); //Punkt 4 zu Punkt 5
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateLine(x5/1000, y5/1000, 0, x3/1000, y3/1000, 0))); //Punkt 5 zu Punkt 3

            //CreateArc
            //skSegment = ((SketchSegment)(swDoc.SketchManager.CreateArc(x1 / 1000, y1 / 1000, 0, x2 / 1000, y2 / 1000, 0, x3 / 1000, y3 / 1000, 0 , 1))); // Mitte = P1 ; Anfang = P2 ; Ende = P3
            // X coordinate of the circle center point in meters
            // Y coordinate of the circle center point in meters
            // Z coordinate of the circle center point in meters
            // X coordinate of the start point of the arc in meters
            // Y coordinate of the start point of the arc in meters
            // Z coordinate of the start point of the arc in meters
            // X coordinate of the end point of the arc in meters
            // Y coordinate of the end point of the arc in meters
            // Z coordinate of the end point of the arc in meters
            // Direction: +1 : Go from the start point to the end point in a counter-clockwise direction ; -1 : Go from the start point to the end point in a clockwise direction

            //Create3PointArc 
            //skSegment = ((SketchSegment)(swDoc.SketchManager.Create3PointArc(x2 / 1000, y2 / 1000, 0, x3 / 1000, y3 / 1000, 0, x1 / 1000, (y1)  / 1000, 0)));
            // X coordinate of the point 1
            // Y coordinate of the point 1
            // Z coordinate of the point 1
            // X coordinate of the point 2
            // Y coordinate of the point 2
            // Z coordinate of the point 2
            // X coordinate of the point 3
            // Y coordinate of the point 3
            // Z coordinate of the point 3

            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateTangentArc(x2 / 1000, y2 / 1000, 0, x3 / 1000, y3 / 1000, 0, 1)));

            boolstatus = swDoc.Extension.SelectByID2("Skizze5", "SKETCH", 0, 0, 0, false, 1, null, 0);
            boolstatus = swDoc.Extension.SelectByID2("Spirale/Helix1", "REFERENCECURVES", -36556516020512488, 9661121742863088, -39820777354806240, true, 4, null, 0);
            myFeature = ((Feature)(swDoc.FeatureManager.InsertCutSwept4(false, true, 0, false, false, 0, 0, false, 0, 0, 0, 10, true, true, 0, true, true, true, false)));

            //Schriftzug einfügen
            boolstatus = swDoc.Extension.SelectByID2("", "FACE", 0, 0, 6.4 / 1000, false, 0, null, 0);
            swDoc.SketchManager.InsertSketch(true);
            mySketchText = ((SketchText)(swDoc.InsertSketchText(-5.9E-03, -1.8E-03, 0, "<b>PHDS</b>", 0, 0, 0, 100, 100)));
            swDoc.SketchManager.InsertSketch(true);
            swDoc.ClearSelection2(true);
        }
    }
}


