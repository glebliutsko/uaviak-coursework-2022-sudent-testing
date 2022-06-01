using Microsoft.EntityFrameworkCore;
using StudentTesting.Application.Database;
using System;
using System.IO;
using System.Linq;
using DbModels = StudentTesting.Database.Models;
using Excel = ClosedXML.Excel;

namespace StudentTesting.Application.Services.ExcelReport
{
    public class ReportDebtors
    {
        public static void GenerateReport(FileInfo file, DbModels.Test test)
        {
            var debtors = DbContextKeeper.Saved.Users
                .Include(x => x.Attempts)
                .ThenInclude(x => x.Test)
                .Where(x => x.Role == DbModels.UserRole.STUDENT && !x.Attempts.Where(a => a.TestId == test.Id).Select(x => x.Id).Contains(x.Id))
                .ToArray();

            var workbook = new Excel.XLWorkbook();
            var worksheet = workbook.Worksheets.Add($"Должники {test.Title}");

            int row = 1;
            worksheet.Cell($"A{row}").Value = "Логин";
            worksheet.Cell($"B{row}").Value = "Имя";
            row++;

            foreach (var debt in debtors)
            {
                worksheet.Cell($"A{row}").Value = debt.Login;
                worksheet.Cell($"B{row}").Value = debt.FullName;
                row++;
            }

            workbook.SaveAs(file.FullName);
        }
    }
}
