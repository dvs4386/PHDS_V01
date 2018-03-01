using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace V01
{
    /// <summary>
    /// Interaktionslogik für phds_wpf.xaml
    /// </summary>
    public partial class phds_wpf : UserControl
    {
        #region Variablen

        string[,] userdata;
        string st_username = "Max Mustermann";          
        string st_useremail = "max.mustermann@net.com"; 
        string username = "";     //userdata[0]
        string useremail = "";    //userdata[1]
        string userdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string folderpath;
        string totalpath;

        string d_data;
        

        #endregion

        #region Initialisieren
        generator gen = new generator();
        public phds_wpf()
        {
            // Initialisieren
            InitializeComponent();

            // Alle Fenster ausblenden bis auf "Frame Main"
            Frames_hide();
            frm_main.Visibility = Visibility.Visible;

            // Pfad zum PHDS Ordner in users/appdata 
            folderpath = System.IO.Path.Combine(userdatapath, "PHDS");
            
            // Alle lokalen Dateien auslesen
            Bin_read();                  
        }

        #endregion

        #region Klasse Frames_hide
        public void Frames_hide()
        {
            frm_verb.Visibility = Visibility.Hidden;
            frm_main.Visibility = Visibility.Hidden;
            frm_dichtungen.Visibility = Visibility.Hidden;
            frm_info.Visibility = Visibility.Hidden;
            frm_verb_schr.Visibility = Visibility.Hidden;
            frm_kauf.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Klassen erstellen und Binär speichern/auslesen

        public void Bin_create(String filename)
        {
            try
            {              
                // prüfen ob Ordner schon vorhanden, wenn nicht wird er neu erstellt
                folderpath = System.IO.Path.Combine(userdatapath, "PHDS");
                Directory.CreateDirectory(folderpath);
                // Datei in diesem Pfad neu erstellen
                totalpath = System.IO.Path.Combine(folderpath, filename);
                FileStream fs = File.Create(totalpath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        public void Bin_write()
        {
            try
            {
                userdata[0] = username;
                userdata[1] = useremail;

                
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream writeStream = File.OpenWrite(totalpath))
                {
                    formatter.Serialize(writeStream, userdata);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bin_read()
        {
            //Alles in Datei userdata.bin speichern und lesen
            //Bin_read("d_data");           // Name und Adresse aus dem Email-Formular
            //Bin_read("d_crtframe");       // aktuelle Frame
            //Bin_read("d_tmline");         // Frames "vor zurück" Funktion (die 10 letzten Frames)
            //Bin_read("d_crt");            // Warenkorb
            //Bin_read("d_fvt");            // Favoriten incl Wunschlisten
            //Bin_read("d_verb_schr");      // Einstellungen Frame - Verbindungen - Schrauben
            
            try
            {
                totalpath = System.IO.Path.Combine(folderpath, "userdata.bin");
                
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream readStream = File.OpenRead(totalpath))
                {
                    userdata = (String[,])formatter.Deserialize(readStream);
                }
                if (String.IsNullOrEmpty(tempArray[0]))
                {
                    username = st_username;
                    useremail = st_useremail;
                }
                else
                {
                    username = tempArray[0];
                    useremail = tempArray[1];
                }

                //Alle Felder aktualisieren:
                box_anfrage_name.Text = username;
                box_anfrage_email.Text = useremail;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                username = "Max Mustermann";
                useremail = "max.mustermann@net.com";
                Bin_create(filename);
                Bin_write();
            }
            
        }

        #endregion

        #region TEST Schrauben erstellen
        private void Button_Click(object sender, RoutedEventArgs e)
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


            gen.schraube_sechskant(L, B, E, K, S, D1, P);
        }

        #endregion

        #region Frame Container
        private void click_phds_logo(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.faz.net");
        }

        private void click_used(object sender, RoutedEventArgs e)
        {
            Bin_create();
        }

        private void click_favorite(object sender, RoutedEventArgs e)
        {
            Bin_read();
        }

        private void click_home(object sender, RoutedEventArgs e)
        {
            Frames_hide();
            frm_main.Visibility = Visibility.Visible;
        }

        private void click_info(object sender, RoutedEventArgs e)
        {
            Frames_hide();
            frm_info.Visibility = Visibility.Visible;
        }

        #endregion

        #region Frame Info
        private void click_zurucksetzen(object sender, RoutedEventArgs e)
        {
            username = "";
            useremail = "";
            Bin_write();
            Bin_read();
        }
        #endregion

        #region Frame Main

        private void click_verbindungstechnik(object sender, RoutedEventArgs e)
        {
            Frames_hide();
            frm_verb.Visibility = Visibility.Visible;
            //MessageBox.Show("Frame Verbindungstechnik");
        }

        private void click_dichtungen(object sender, RoutedEventArgs e)
        {
            
            Frames_hide();
            frm_dichtungen.Visibility = Visibility.Visible;
        }

        private void click_federn(object sender, RoutedEventArgs e)
        {
            Bin_create();
        }

        private void click_lager(object sender, RoutedEventArgs e)
        {

        }

        private void click_profile(object sender, RoutedEventArgs e)
        {

        }

        private void click_leitungen(object sender, RoutedEventArgs e)
        {

        }

        private void click_drehteile(object sender, RoutedEventArgs e)
        {

        }

        private void click_blechteile(object sender, RoutedEventArgs e)
        {

        }

        private void click_druck(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Frame Verbindungstechnik

        private void click_schrauben(object sender, RoutedEventArgs e)
        {
            Frames_hide();
            frm_verb_schr.Visibility = Visibility.Visible;
        }

        private void click_muttern(object sender, RoutedEventArgs e)
        {

        }

        private void click_scheiben(object sender, RoutedEventArgs e)
        {

        }

        private void click_gewinde(object sender, RoutedEventArgs e)
        {

        }

        private void click_spannhulen(object sender, RoutedEventArgs e)
        {

        }

        private void click_sicherungen(object sender, RoutedEventArgs e)
        {

        }

        private void click_splinte(object sender, RoutedEventArgs e)
        {

        }

        private void click_sicherungsringe(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Frame Dichtungen
        private void click_nav_dichtungen(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Frame Anfrage

        bool valid_email = false;

        private void click_anfrage_send(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            //Ist Textbox_Name ausgefüllt?
            if (String.IsNullOrEmpty(box_anfrage_name.Text) || box_anfrage_name.Text == "Bitte Name angeben" || box_anfrage_name.Text == st_username)
            {
                box_anfrage_name.Text = "Bitte Name angeben";
                box_anfrage_name.Foreground = (Brush)bc.ConvertFrom("#FFE46E6E");
            }
            else
            {
                if (valid_email == true && box_anfrage_email.Text != st_useremail)
                {
                    //Durch MessageBox bestätigen, dass Email versendet
                    MessageBox.Show("Email versendet");
                    //Eingabewerte dauerhaft binär speichern
                    username = box_anfrage_name.Text;
                    useremail = box_anfrage_email.Text;
                    try
                    {
                        Bin_write();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Persönliche Einstellungen können nicht gespeichert werden");
                    }
                    
                }
                else
                {
                    box_anfrage_email.Text = "Bitte Email angeben";
                }
            }
        }

        private void focus_anfrage_name(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            if (box_anfrage_name.Text == st_username || box_anfrage_name.Text == "Bitte Name angeben")
            {
                box_anfrage_name.Foreground = (Brush)bc.ConvertFrom("#FF787878");
                box_anfrage_name.Clear();
            }
        }

        private void focus_anfrage_email(object sender, RoutedEventArgs e)
        {
            if (box_anfrage_email.Text == st_useremail || box_anfrage_email.Text == "Bitte Email angeben")
            {
                box_anfrage_email.Clear();
            }
        }

        private void focus_anfrage_nachricht(object sender, RoutedEventArgs e)
        {
            if (box_anfrage_nachricht.Text == "Nachricht")
            {
                box_anfrage_nachricht.Clear();
            }
        }

        private void changed_anfrage_email(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();
            string temp = box_anfrage_email.Text;
            if (new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(temp) == true)
            {
                box_anfrage_email.Foreground = (Brush)bc.ConvertFrom("#FF787878");
                valid_email = true;
            }
            else
            {
                box_anfrage_email.Foreground = (Brush)bc.ConvertFrom("#FFE46E6E");
                valid_email = false;
            }

        }








        #endregion

        private void click_sechskant1(object sender, RoutedEventArgs e)
        {
            btn_schrauben_Copy.BorderBrush = new SolidColorBrush(Colors.Green);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}

        
    
