using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace StudentTesting.Application.Utils
{
    public class ExcelLogs : IDisposable
    {
        public static Lazy<ExcelLogs> ExcelLogsInstance { get; } = new Lazy<ExcelLogs> (() => Create(new FileInfo(@"logs.xlsx")));

        private const string WorksheetChangedLog = "Changed";
        private const string WorksheetLoginLog = "Login";

        private readonly Excel.Application _application;
        private readonly FileInfo _fileInfo;

        private Excel.Workbook _workbook;
        private Excel.Worksheet _worksheetChangedLogs;
        private Excel.Worksheet _worksheetLoginLogs;

        public int LastRowChangedLogs { get; private set; }
        public int LastRowLoginLogs { get; private set; }

        private ExcelLogs(Excel.Application application, FileInfo fileInfo)
        {
            _application = application;
            _fileInfo = fileInfo;
        }

        private void Initialize()
        {
            if (TryOpenExistsBook())
                return;

            if (_fileInfo.Exists)
                _fileInfo.Delete();

            _workbook = _application.Workbooks.Add();

            _worksheetChangedLogs = _workbook.Worksheets.Add();
            _worksheetChangedLogs.Name = "Changed";
            _worksheetChangedLogs.Cells[1, 1].Value = "Пользователь";
            _worksheetChangedLogs.Cells[1, 2].Value = "Таблица";
            _worksheetChangedLogs.Cells[1, 3].Value = "Действие";

            _worksheetLoginLogs = _workbook.Worksheets.Add();
            _worksheetLoginLogs.Name = "Login";
            _worksheetLoginLogs.Cells[1, 1].Value = "Пользователь";
            _worksheetLoginLogs.Cells[1, 2].Value = "Действие";
            _worksheetLoginLogs.Cells[1, 3].Value = "Успех?";

            LastRowLoginLogs = LastRowChangedLogs = 1;

            _workbook.SaveAs2(_fileInfo.FullName);
        }

        private bool TryOpenExistsBook()
        {
            if (!_fileInfo.Exists || _fileInfo.Extension != ".xlsx")
                return false;

            Excel.Workbook workbook = null;
            Excel.Worksheet worksheetLoginLogs;
            Excel.Worksheet worksheetChangedLogs;
            try
            {
                workbook = _application.Workbooks.Open(_fileInfo.FullName);
                worksheetLoginLogs = workbook.Worksheets[WorksheetLoginLog];
                worksheetChangedLogs = workbook.Worksheets[WorksheetChangedLog];
            }
            catch (Exception)
            {
                workbook?.Close(false);
                return false;
            }

            _workbook = workbook;
            _worksheetLoginLogs = worksheetLoginLogs;
            _worksheetChangedLogs = worksheetChangedLogs;

            LastRowLoginLogs = _worksheetLoginLogs.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            LastRowChangedLogs = _worksheetChangedLogs.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            return true;
        }

        public static ExcelLogs Create(FileInfo fileInfo)
        {
            var app = new Excel.Application();
            var excelLogs = new ExcelLogs(app, fileInfo);

            excelLogs.Initialize();
            return excelLogs;
        }

        public void AddLoginLog(string user, string action, bool success)
        {
            LastRowLoginLogs++;

            _worksheetLoginLogs.Cells[LastRowLoginLogs, 1].Value = user;
            _worksheetLoginLogs.Cells[LastRowLoginLogs, 2].Value = action;
            _worksheetLoginLogs.Cells[LastRowLoginLogs, 3].Value = success ? "Ok" : "Fail";
        }

        public void AddChangedLog(string user, string table, string action)
        {
            LastRowChangedLogs++;

            _worksheetChangedLogs.Cells[LastRowChangedLogs, 1].Value = user;
            _worksheetChangedLogs.Cells[LastRowChangedLogs, 2].Value = table;
            _worksheetChangedLogs.Cells[LastRowChangedLogs, 3].Value = action;
        }

        public void Save() =>
            _workbook.Save();

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            _workbook?.Close();
            _application.Quit();
        }
    }
}