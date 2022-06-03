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
    public partial class Main : Form
    {

        GroupManager gm;

        public Main()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
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
        }

        private string DisplayErrors(string path, string finalPath)
        {
            string result = "";

            if (path == "")
            {
                result += "Nie podano ścieżki z rozwiązaniem!\n";
            }
            else if (InputValidator.ValidateStudentDirectory(path) != true)
            {
                result += "podana ścieżka jest w nieprawidłowym formacie, poprawny: Kx_yyyyyy_Z\n";
            }
            if (finalPath == "")
            {
                result += "nie podano ścieżki do zapisu pliku .xlsx!\n";
            }

            return result;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            
            string inputPath = cb2.PresentPath;
            string outputpath = cb1.PresentPath;
            if (InputValidator.ValidateGroupDirectory(inputPath) == true)
            {
                panel5.Width = 10;                
                timer1.Start();
                panel4.Visible = true;
                panel5.Visible = true;
                do
                {
                    panel5.Width += 17;
                    Thread.Sleep(2);

                } while (panel5.Width <= 1408);

                timer1.Stop();
                panel5.Visible = false;
                panel4.Visible = false;
                gm = new GroupManager(inputPath, outputpath, labelInfo);
                gm.AnalyzeSolution();
            }
            else
            {
                MessageBox.Show($"Nieprawidłowy format ścięzki z rozwiązaniem! Prawidłowy format: Gx_YYYY", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cb2_Load(object sender, EventArgs e)
        {

        }

        private void cb1_Load(object sender, EventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static class Control
        {
            public static void Minimize(Form form)
            {
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }
                else if (form.WindowState == FormWindowState.Normal)
                {
                    form.WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control.Minimize(this);
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {           
        }
    }
}

