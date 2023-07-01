using SpreadsheetLight;
using System;

SLDocument sl = new SLDocument("C:\\Users\\books\\OneDrive\\Documents\\ReportesVisualStudio\\TI Paridad Banco Central Noviembre 2022.xlsx");
for (int i = 2; i <= 42; ++i)
{
    decimal MonedaId = sl.GetCellValueAsDecimal("B" + i);
    string NombrePais = sl.GetCellValueAsString("C" + i);
    string ParidadValor = sl.GetCellValueAsString("D" + i);
    Console.WriteLine(MonedaId + " "+NombrePais+" "+ParidadValor);
}