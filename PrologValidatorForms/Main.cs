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

namespace PrologValidatorForms
{
    public partial class Main : Form
    {

        GroupManager gm;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    labelInfo.Text = "";
        //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        pathName = folderBrowserDialog1.SelectedPath;
        //        label1.Text = pathName;
        //    }
        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    labelInfo.Text = "";
        //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        finalPath = folderBrowserDialog1.SelectedPath;
        //        label2.Text = finalPath;
        //    }
        //}

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



            //}

            // Wybieramy ścieżke -> jak dobra idziemy dalej -> zatwierdź żeby zapisać informacje w PROGRAMIE -> zapisz jako excel żęby zapisać z programu do excela


            // Zmiana ciała metody btn_confirm_Click
            private void btn_confirm_Click(object sender, EventArgs e)
            {
                string inputPath = cb1.PresentPath;
                string outputpath = cb2.PresentPath;
                if (InputValidator.ValidateGroupDirectory(inputPath) == true)
                {
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
        }
    }

