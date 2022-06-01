using StudentTesting.Application.DTOModels;
using StudentTesting.Application.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Excel = ClosedXML.Excel;

namespace StudentTesting.Application.Services.ExcelReport
{
    public static class ReportAttempt
    {
        public static void GenerateReport(FileInfo file, ICollection<AttemptDTO> attempts)
        {
            var workbook = new Excel.XLWorkbook();

            foreach (var testAttempt in attempts.GroupBy(x => x.TestTitle))
            {
                var worksheet = workbook.Worksheets.Add(testAttempt.Key);

                int row = 1;
                worksheet.Cell($"A{row}").Value = "Курс";
                worksheet.Cell($"B{row}").Value = "Тест";
                worksheet.Cell($"C{row}").Value = "Студент";
                worksheet.Cell($"D{row}").Value = "Баллы";
                worksheet.Cell($"C{row}").Value = "Баллы (Всего)";
                worksheet.Cell($"E{row}").Value = "Оценка";

                row++;

                foreach (var attempt in testAttempt)
                {
                    worksheet.Cell($"A{row}").Value = attempt.CourseTitle;
                    worksheet.Cell($"B{row}").Value = attempt.TestTitle;
                    worksheet.Cell($"C{row}").Value = attempt.StudentName;
                    worksheet.Cell($"D{row}").Value = attempt.Score;
                    worksheet.Cell($"C{row}").Value = attempt.AllScore;
                    worksheet.Cell($"E{row}").Value = attempt.Mark;

                    (var r, var g, var b) = ColorMark.ToColorRgb(attempt.Mark);
                    worksheet.Cell($"E{row}").Style.Fill.BackgroundColor = Excel.XLColor.FromArgb(r, g, b);

                    row++;
                }
            }

            if (workbook.Worksheets.Count == 0)
                workbook.Worksheets.Add("New worksheets");
            workbook.SaveAs(file.FullName);
        }
    }
}
