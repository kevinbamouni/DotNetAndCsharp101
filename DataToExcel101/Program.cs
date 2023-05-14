// See https://aka.ms/new-console-template for more information
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MathNet.Numerics.LinearAlgebra;

Console.WriteLine("Hello, World!");
// create a dense matrix with 3 rows and 4 columns
// filled with random numbers sampled from the standard distribution
Matrix<double> m = Matrix<double>.Build.Random(3, 4);

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.WriteLine(m[i, j]);
    }
}

// Create a spreadsheet document by supplying the filepath.
// By default, AutoSave = true, Editable = true, and Type = xlsx.
// SpreadsheetDocument
SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(@"C:\Users\work\source\repos\databasesoft\DataToExcel101\output\test.xlsx", SpreadsheetDocumentType.Workbook);

// Add a WorkbookPart to the document.
// SpreadsheetDocument <--- WorkbookPart
WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
workbookpart.Workbook = new Workbook();

// Add a WorksheetPart to the WorkbookPart.
// SpreadsheetDocument <--- WorkbookPart <--- WorksheetPart
WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
worksheetPart.Worksheet = new Worksheet(new SheetData());

// Add Sheets to the Workbook. Sheets containt Sheet
Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

// Append a new worksheet and associate it with the workbook.
// 
Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "mySheet" };
sheets.Append(sheet);

Worksheet worksheet = new Worksheet();
SheetData sheetData = new SheetData();
Row row = new Row();
Cell cell = new Cell()
{
    CellReference = "A1",
    DataType = CellValues.String,
    CellValue = new CellValue("Microsoft")
};

row.Append(cell);

//for (int i = 0; i < 3; i++)
//{
//    Row r = new Row();
//    for (int j = 0; j < 4; j++)
//    {
//        Console.WriteLine(m[i, j]);
//        Cell c = new Cell()
//        {
//            DataType = CellValues.Number,
//            CellValue = new CellValue(m[i, j])
//        };
//        r.Append(c);
//    }

//}

sheetData.Append(row);
worksheet.Append(sheetData);
worksheetPart.Worksheet = worksheet;

workbookpart.Workbook.Save();

// Close the document.
spreadsheetDocument.Close();
