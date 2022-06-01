using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Database;
using StudentTesting.Application.DTOModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DbModels = StudentTesting.Database.Models;
using Excel = ClosedXML.Excel;

namespace StudentTesting.Application.Services.ExcelReport
{
    public static class ReportDebts
    {
        public static void GenerateReport(FileInfo file, DbModels.User student)
        {
            var debts = DbContextKeeper.Saved.Tests
                .Include(x => x.Course)
                .Include(x => x.Attempts)
                .ThenInclude(x => x.Student)
                .Where(x => !x.Attempts.Select(x => x.StudentId).Contains(student.Id))
                .ToArray();

            var workbook = new Excel.XLWorkbook();
            var worksheet = workbook.Worksheets.Add($"Долги {student.FullName}");

            int row = 1;
            worksheet.Cell($"A{row}").Value = "Курс";
            worksheet.Cell($"B{row}").Value = "Тест";
            row++;

            foreach (var debt in debts)
            {
                worksheet.Cell($"A{row}").Value = debt.Course.Title;
                worksheet.Cell($"B{row}").Value = debt.Title;
                row++;
            }

            workbook.SaveAs(file.FullName);
        }
    }
}
