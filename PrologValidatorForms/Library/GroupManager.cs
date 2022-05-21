using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PrologValidatorForms.Library
{
    class GroupManager
    {
        string dirPath;
        string name;
        string destDir;
        Label label;
        List<ValSolution> vss = new List<ValSolution>();

        public GroupManager(string dirPath, string destDir, Label infoLabel)
        {
            this.dirPath = dirPath;
            this.destDir = destDir;
            this.label = infoLabel;
            this.name = dirPath.Substring(dirPath.Length - 7, 7);
            Console.WriteLine($"{name}");
        }

        public void AnalyzeSolution()
        {
            FileInfo fi = new FileInfo(dirPath + @"\klucz.txt");
            if (fi.Exists)
            {
                foreach (string dir in Directory.GetDirectories(dirPath))
                {
                    if (InputValidator.ValidateStudentDirectory(dir) == true)
                    {
                        ValSolution vs = new ValSolution(dir, label, destDir);
                        vs.AnalyzeSolution();
                        this.vss.Add(vs);
                    }
                }
            }
            else
            {
                MessageBox.Show($"W ścieżce: {dirPath} brak pliku klucz.txt!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label.Text += "w katalogu z rozwiązaniem brak pliku: klucz.txt!\n";
            }
        }
    }
}
