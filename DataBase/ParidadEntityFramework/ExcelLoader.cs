using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ParidadEntityFramework
{
    public class ExcelLoader
    {
        
        public static List<ExcelData> LoadExcelData(string filePath)
        {
            var dataList = new List<ExcelData>();

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(@"C:\Users\books\OneDrive\Desktop\Afex\Paridades\PARIDADES ABRIL.xlsx", false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                foreach (Row row in sheetData.Elements<Row>().Skip(4)) // Skip header row
                {
                    var data = new ExcelData
                    {
                        Column1 = GetCellValue(workbookPart, (Cell)row.ElementAt(0)),
                        Column2 = decimal.Parse(GetCellValue(workbookPart, (Cell)row.ElementAt(1))),
                     
                    };

                    dataList.Add(data);
                }
            }

            return dataList;
        }

        private static string GetCellValue(WorkbookPart workbookPart, Cell cell)
        {
            if (cell == null) return null;
            var value = cell.CellValue;
            if (value == null) return null;
            var stringTable = workbookPart.SharedStringTablePart.SharedStringTable;
            return (cell.DataType != null && cell.DataType == CellValues.SharedString) ? stringTable.ChildElements[int.Parse(value.InnerText)].InnerText : value.InnerText;
        }
    }
}


