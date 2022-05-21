using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;

namespace PrologValidatorForms.Library
{
    class GroupManager
    {
        string dirPath;
        string name;
        string destDir;
        Label label;
        string keyPath;
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
                keyPath = dirPath + @"\klucz.txt";
                foreach (string dir in Directory.GetDirectories(dirPath))
                {
                    if (InputValidator.ValidateStudentDirectory(dir) == true)
                    {
                        ValSolution vs = new ValSolution(dir, label, destDir, keyPath);
                        vs.AnalyzeSolution();
                        this.vss.Add(vs);
                    }
                }
                CreateExcelFile();
            }
            else
            {
                MessageBox.Show($"W ścieżce: {dirPath} brak pliku klucz.txt!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label.Text += "w katalogu z rozwiązaniem brak pliku: klucz.txt!\n";
            }
        }

        public void CreateExcelFile()
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Title = "Podsumowanie";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Podsumowanie");

                foreach (ValSolution item in vss)
                {
                    ws = excelPackage.Workbook.Worksheets.Add(item.SolutionName.Substring(3, 6));
                    int dataCellsRow = 2;
                    int dataCellsColumn = 2;
                    ws.Cells[dataCellsRow, dataCellsColumn].Value = "Numer Albumu:";
                    ws.Cells[dataCellsRow, dataCellsColumn + 1].Value = Convert.ToInt32(item.SolutionName.Substring(3, 6));
                    ws.Cells[dataCellsRow + 2, dataCellsColumn].Value = "Numer podejścia:";
                    ws.Cells[dataCellsRow + 2, dataCellsColumn + 1].Value = Convert.ToInt32(item.SolutionName.Substring(1, 1));
                    ws.Cells[dataCellsRow + 1, dataCellsColumn].Value = "Grupa:";
                    ws.Cells[dataCellsRow + 1, dataCellsColumn + 1].Value = Convert.ToInt32(item.SolutionName.Substring(10, 1));
                }



                try
                {
                    FileInfo fi = new FileInfo(destDir + @"\File.xlsx");
                    excelPackage.SaveAs(fi);
                    System.Diagnostics.Process.Start(destDir + @"\File.xlsx");
                }
                catch (System.InvalidOperationException ioe)
                {
                    label.Text += $"plik {destDir + @"\File.xlsx"} jest obecnie otwarty!, {ioe.Message}\n";
                }
                catch (Exception e)
                {
                    label.Text += $"Wystąpił niespodziewany błąd: {e.Message}\n";
                }
            }
        }
    }
}
