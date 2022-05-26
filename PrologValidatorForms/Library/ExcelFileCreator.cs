using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrologValidatorForms
{
    partial class StudentTasksManager
    {
        private void CreateExcelFile()
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Title = "Podsumowanie";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Podsumowanie");

                int dataCellsRow = 2;
                int dataCellsColumn = 2;
                ws.Cells[dataCellsRow, dataCellsColumn].Value = "Numer Albumu:";
                ws.Cells[dataCellsRow, dataCellsColumn + 1].Value = Convert.ToInt32(solutionName.Substring(3, 6));
                ws.Cells[dataCellsRow + 2, dataCellsColumn].Value = "Numer podejścia:";
                ws.Cells[dataCellsRow + 2, dataCellsColumn + 1].Value = Convert.ToInt32(solutionName.Substring(1, 1));
                ws.Cells[dataCellsRow + 1, dataCellsColumn].Value = "Grupa:";
                ws.Cells[dataCellsRow + 1, dataCellsColumn + 1].Value = Convert.ToInt32(solutionName.Substring(10, 1));

                int podsCellsRow = 5;
                int podsCellsColumn = 5;
                ws.Cells[podsCellsRow, podsCellsColumn].Value = "Podsumowanie";
                ws.Cells[podsCellsRow, podsCellsColumn].Style.Font.Size = 13;
                ws.Cells[podsCellsRow, podsCellsColumn, podsCellsRow, podsCellsColumn + 4].Merge = true;
                ws.Cells[podsCellsRow, podsCellsColumn, podsCellsRow, podsCellsColumn + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[podsCellsRow + 1, podsCellsColumn].Value = "Nazwa";
                ws.Cells[podsCellsRow + 1, podsCellsColumn + 1].Value = "Data utworzenia";
                ws.Cells[podsCellsRow + 1, podsCellsColumn + 2].Value = "Rozmiar pliku w bajtach";
                ws.Cells[podsCellsRow + 1, podsCellsColumn + 3].Value = "Zaliczone testy";
                ws.Cells[podsCellsRow + 1, podsCellsColumn + 4].Value = "Wszystkie testy";

                int row = 6;
                int column = 5;

                for (int i = 0; i < tasks.Count; i++)
                {
                    ws.Cells[podsCellsRow + 2, podsCellsColumn].Value = tasks[i].TaskName;
                    ws.Cells[podsCellsRow + 2, podsCellsColumn + 1].Value = tasks[i].CreationTime;
                    ws.Cells[podsCellsRow + 2, podsCellsColumn + 2].Value = tasks[i].SizeOfFile;
                    ws.Cells[podsCellsRow + 2, podsCellsColumn + 3].Value = tasks[i].CorrectAnswers;
                    ws.Cells[podsCellsRow + 2, podsCellsColumn + 4].Value = tasks[i].TotalAnswers;
                    podsCellsRow++;

                }
                podsCellsRow++;
                podsCellsColumn = 9;

                // Styles
                ws.Cells[dataCellsRow, dataCellsRow].Style.Font.Bold = true;
                ws.Cells[dataCellsRow, dataCellsRow].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[dataCellsRow, dataCellsRow].Style.Fill.BackgroundColor.SetColor(Color.LimeGreen);
                ws.Cells[dataCellsRow + 1, dataCellsRow].Style.Font.Bold = true;
                ws.Cells[dataCellsRow + 1, dataCellsRow].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[dataCellsRow + 1, dataCellsRow].Style.Fill.BackgroundColor.SetColor(Color.LimeGreen);
                ws.Cells[dataCellsRow + 2, dataCellsRow].Style.Font.Bold = true;
                ws.Cells[dataCellsRow + 2, dataCellsRow].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[dataCellsRow + 2, dataCellsRow].Style.Fill.BackgroundColor.SetColor(Color.LimeGreen);

                string infoCells = "B2:C4";
                ws.Cells[infoCells].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[infoCells].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[infoCells].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[infoCells].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[infoCells].Style.Border.Top.Color.SetColor(Color.Black);
                ws.Cells[infoCells].Style.Border.Bottom.Color.SetColor(Color.Black);
                ws.Cells[infoCells].Style.Border.Right.Color.SetColor(Color.Black);
                ws.Cells[infoCells].Style.Border.Left.Color.SetColor(Color.Black);

                string headCells = "E6:I6";
                ws.Cells[headCells].Style.Font.Bold = true;
                ws.Cells[headCells].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[headCells].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

                string podsCells = "E5:I5";
                ws.Cells[podsCells].Style.Font.Bold = true;
                ws.Cells[podsCells].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[podsCells].Style.Fill.BackgroundColor.SetColor(Color.DarkOliveGreen);
                ws.Cells[podsCells].Style.Border.Top.Style = ExcelBorderStyle.Thick;
                ws.Cells[podsCells].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                ws.Cells[podsCells].Style.Border.Right.Style = ExcelBorderStyle.Thick;
                ws.Cells[podsCells].Style.Border.Left.Style = ExcelBorderStyle.Thick;
                ws.Cells[podsCells].Style.Border.Top.Color.SetColor(Color.Black);
                ws.Cells[podsCells].Style.Border.Bottom.Color.SetColor(Color.Black);
                ws.Cells[podsCells].Style.Border.Right.Color.SetColor(Color.Black);
                ws.Cells[podsCells].Style.Border.Left.Color.SetColor(Color.Black);

                ws.Cells[row, column, podsCellsRow, podsCellsColumn].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[row, column, podsCellsRow, podsCellsColumn].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[row, column, podsCellsRow, podsCellsColumn].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[row, column, podsCellsRow, podsCellsColumn].Style.Border.Bottom.Color.SetColor(Color.Black);
                ws.Cells[row, column, podsCellsRow, podsCellsColumn].Style.Border.Left.Color.SetColor(Color.Black);
                ws.Cells[row, column, podsCellsRow, podsCellsColumn].Style.Border.Right.Color.SetColor(Color.Black);

                ws.Cells[1, 1, podsCellsRow, podsCellsColumn].AutoFitColumns();

                //try
                //{
                //    FileInfo fi = new FileInfo(finalPath + @"\File.xlsx");
                //    excelPackage.SaveAs(fi);
                //    System.Diagnostics.Process.Start(finalPath + @"\File.xlsx");
                //}
                //catch(System.InvalidOperationException ioe)
                //{
                    
                //}
                //catch(Exception e)
                //{
                    
                //}
            }
        }
    }
}
