using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PrologValidatorForms.Library;
using System.Threading;

namespace PrologValidatorForms
{
    /// <summary>
    /// Klasa zawierająca 
    /// </summary>
    /// <param name="mouse_Down">Przechowywyje </param>
    /// <param name="offset">Przechowuje obiekt typu Point</param>
    public partial class Main : Form
    {

        GroupManager gm;
        static readonly double maxProgressBarValue = 1408;

        /// <summary>
        /// Konstruktor kopiujący inicializujący pola klasy
        /// </summary>
        public Main()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            panel5.Width = 0;
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern System.IntPtr CreateRoundRectRgn(
           int nLeftRect, // x-współrzędne lewego-górnego rogu
           int nTopRect, // y-współrzędne lewego-górnego rogu
           int nRightRect, // x-współrzędne prawego-dolnego rogu
           int nBottomRect, // y-współrzędne prawego-dolnego rogu
           int nWidthEllipse, // wysokość obiektu
           int nHeightEllipse // szerokość obiektu
           );

        /// <summary>
        /// Metoda 
        /// </summary>
        /// <param name="sender">Przechowywuje </param>
        /// <param name="e">Przechowywuje obiekt typu EventArgs</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            btn_export.Hide();            
            btn_confirm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_confirm.Width, btn_confirm.Height, 30, 30));
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 30, 30));
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 30, 30));            
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 30, 30));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 30, 30));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 70, 70));
            informator1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, informator1.Width, informator1.Height, 30, 30));
            pictureBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox1.Width, pictureBox1.Height, 30, 30));
        }

        /// <summary>
        /// Metoda aktualizująca postęp ProgressBaru
        /// </summary>
        private void UpdateProgressBar()
        {
            panel5.Width = 10;
            timer1.Start();
            panel4.Visible = true;
            panel5.Visible = true;
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 30, 30));
            do
            {
                panel5.Width += 17;
                panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 30, 30));
                Thread.Sleep(2);
            } while (panel5.Width <= 1408);

            timer1.Stop();
            panel5.Visible = false;
            panel4.Visible = false;
        }

        /// <summary>
        /// Metoda obsługująca przycisk do zatwierdzania
        /// </summary>
        /// <param name="sender">Przechowywuje </param>
        /// <param name="e">Przechowywuje obiekt typu EventArgs</param>
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            
            string inputPath = cb2.PresentPath;
            string outputpath = cb1.PresentPath;
            if (InputValidator.ValidateGroupDirectory(inputPath) == true)
            {
                panel4.Visible = true;
                panel5.Visible = true;

                gm = new GroupManager(inputPath, outputpath, maxProgressBarValue, panel5);
                gm.AnalyzeSolution();

                panel4.Visible = false;
                panel5.Visible = false;
            }
            else
            {
                MessageBox.Show($"Nieprawidłowy format ścięzki z rozwiązaniem! Prawidłowy format: Gx_YYYY", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="sender">Przechowywuje </param>
        /// <param name="e">Przechowywuje obiekt typu EventArgs</param>
        private void cb2_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="sender">Przechowywuje </param>
        /// <param name="e">Przechowywuje obiekt typu EventArgs</param>
        private void cb1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="sender">Przechowywuje </param>
        /// <param name="e">Przechowywuje obiekt typu EventArgs</param>
        private void btn_export_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="sender">Przechowywuje </param>
        /// <param name="e">Przechowywuje obiekt typu EventArgs</param>
        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="sender">Przechowywuje </param>
        /// <param name="e">Przechowywuje obiekt typu EventArgs</param>
        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu EventArgs będący informacją o zdarzeniu</param>
        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu PaintEventArgs klasy do rysowania prostokątów w formularzu</param>
        private void panel4_Paint(object sender, PaintEventArgs e)
        {            
        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu PaintEventArgs klasy do rysowania prostokątów w formularzu</param>
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            panel4.Visible = false;
            panel5.Visible = false;
        }

        /// <summary>
        /// Metoda słóżąca do zamykania aplikacji za pomocą przycisku "Exit"
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu EventArgs będący informacją o zdarzeniu</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Klasa zawierająca metodę do minimalizowania okna 
        /// </summary>
        static class Control
        {
            /// <summary>
            /// Metoda minimalizująca okno aplikacji
            /// </summary>
            /// <param name="form">Przetrzymuje obiekt typu typu Form</param>
            public static void Minimize(Form form)
            {
                   form.WindowState = FormWindowState.Minimized;
                
            }
        }

        /// <summary>
        /// Metoda minimalizująca okno aplikacji
        /// </summary>
        /// <param name="form">Przetrzymuje obiekt typu typu Form</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Control.Minimize(this);
        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu EventArgs będący informacją o zdarzeniu</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu EventArgs będący informacją o zdarzeniu</param>
        private void Main_Paint(object sender, PaintEventArgs e)
        {           
        }

        /// <summary>
        /// Metoda 
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu EventArgs będący informacją o zdarzeniu</param>
        private void informator1_MouseHover(object sender, EventArgs e)
        {
            string Information = "------------------------------------------- INSTRUKCJA ------------------------------------------- \n" +
                                 "1. Twój folder z folderami rozwiązań studentów powinien być nazywany w formacie: GK_XXXX, \n"
                                 + "gdzie X - to numer grupy , a XXXX - to rocznik utowrzenia folderu. \n" +
                                 "2. W tym folderze powinny znajdować się foldery rozwiązań studentów w formacie: Kx_yyyyyy_z, \n"
                                 + "gdzie X - to numer podejścia , a yyyyyy - to numer albumu, a z- to grupa studencka. \n"
                                 + "3. W folderze GK_XXXX powinien się także znajdiować plik .txt o nazwie \"klucz\". \n"
                                 + "4. W folderze Kx_yyyyyy_z powinny się znajdować pliki .pl w formacie ZadX.pl , \n"
                                 + "gdzie X - to numer zadania \n"
                                 + "-----------------------------------------------------------------------------------------------------";
            toolTip1.Show(Information, informator1);
        }

        private void informator1_MouseClick(object sender, MouseEventArgs e)
        {
            string Information = "------------------------------------------- INSTRUKCJA ------------------------------------------- \n" +
                                 "1. Twój folder z folderami rozwiązań studentów powinien być nazywany w formacie: GK_XXXX, \n"
                                 + "gdzie X - to numer grupy , a XXXX - to rocznik utowrzenia folderu. \n" +
                                 "2. W tym folderze powinny znajdować się foldery rozwiązań studentów w formacie: Kx_yyyyyy_z, \n"
                                 + "gdzie X - to numer podejścia , a yyyyyy - to numer albumu, a z- to grupa studencka. \n"
                                 + "3. W folderze GK_XXXX powinien się także znajdiować plik .txt o nazwie \"klucz\". \n"
                                 + "4. W folderze Kx_yyyyyy_z powinny się znajdować pliki .pl w formacie ZadX.pl , \n"
                                 + "gdzie X - to numer zadania \n"
                                 + "-----------------------------------------------------------------------------------------------------";
            toolTip1.Show(Information, informator1);
        }

        //Funkcjonalność przesuwania oknem po pulpicie 
        bool mouse_Down;
        private Point offset;
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouse_Down = true;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouse_Down == true)
            {
                Point current_Screen_Position = PointToScreen(e.Location);
                Location = new Point(current_Screen_Position.X - offset.X, current_Screen_Position.Y - offset.Y);
            }
        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu EventArgs będący informacją o zdarzeniu</param>
        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_Down = false;
        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu EventArgs będący informacją o zdarzeniu</param>
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Metoda generowana automatycznie
        /// </summary>
        /// <param name="keyManager">Przechowywuje odwołanie do obiektu</param>
        /// <param name="keyManager">Przechowywuje obiekt typu EventArgs będący informacją o zdarzeniu</param>
        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

