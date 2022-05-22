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
                    //Informacje podstawowe
                    ws = excelPackage.Workbook.Worksheets.Add(item.SolutionName);
                    int basicCellsRow = 2;
                    int basicCellsColumn = 2;
                    ws.Cells[basicCellsRow, basicCellsColumn, basicCellsRow, basicCellsColumn + 1].Merge = true;
                    ws.Cells[basicCellsRow, basicCellsColumn].Value = "Informacje Podstawowe";

                    ws.Cells[basicCellsRow + 1, basicCellsColumn].Value = "Numer Albumu:";
                    ws.Cells[basicCellsRow + 1, basicCellsColumn + 1].Value = Convert.ToInt32(item.SolutionName.Substring(3, 6));
                    ws.Cells[basicCellsRow + 2, basicCellsColumn].Value = "Numer podejścia:";
                    ws.Cells[basicCellsRow + 2, basicCellsColumn + 1].Value = Convert.ToInt32(item.SolutionName.Substring(1, 1));
                    ws.Cells[basicCellsRow + 3, basicCellsColumn].Value = "Grupa:";
                    ws.Cells[basicCellsRow + 3, basicCellsColumn + 1].Value = Convert.ToInt32(item.SolutionName.Substring(10, 1));


                    //Informacje o plikach

                    int infCellsRow = 2;
                    int infCellsColumn = 6;

                    ws.Cells[infCellsRow, infCellsColumn, infCellsRow, infCellsColumn + item.Tasks.Count].Merge = true;
                    ws.Cells[infCellsRow, infCellsColumn].Value = "Informacje o plikach";

                    ws.Cells[infCellsRow + 1, infCellsColumn].Value = "Nazwa pliku";
                    ws.Cells[infCellsRow + 2, infCellsColumn].Value = "Data utworzenia";
                    ws.Cells[infCellsRow + 3, infCellsColumn].Value = "Rozmiar";

                    infCellsColumn++;

                    ws.Cells[10, 10].Value = item.Tasks.Count;

                    for (int i = 0; i < item.Tasks.Count; i++)
                    {
                        ws.Cells[infCellsRow + 1, infCellsColumn + i].Value = item.Tasks[i].TaskName;
                        ws.Cells[infCellsRow + 2, infCellsColumn + i].Value = item.Tasks[i].CreationTime;
                        ws.Cells[infCellsRow + 3, infCellsColumn + i].Value = item.Tasks[i].SizeOfFile;
                    }


                    //Automatyczne wyrównanie kolumn

                    ws.Cells[1, 1, 30, 30].AutoFitColumns();
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
