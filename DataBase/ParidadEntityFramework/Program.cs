using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using ParidadEntityFramework;

internal class Program
{
    static void Main(string[] args)
    {
        // your existing code to access database
        DbContextOptionsBuilder<ParidadesContext> builder =
            new DbContextOptionsBuilder<ParidadesContext>();
        builder.UseSqlServer("Server=DESKTOP-10Q01PT; Database=Paridades; Trusted_Connection=True; Encrypt=False;");




        using (ParidadesContext context = new ParidadesContext(builder.Options))
        {
            var paridad = context.Paridades.ToList();

            foreach (var divisa in paridad)
            {
                Console.WriteLine(divisa.ParidadesId + " " + divisa.Nombre + " " + divisa.MontoDolar);
            }
        }

        // display Excel data
        Console.WriteLine(" ");
        DisplayExcelData();

    }



        static void DisplayExcelData()
        {
            var excelDataList = ExcelLoader.LoadExcelData(@"C:\Users\books\OneDrive\Desktop\Afex\Paridades\PARIDADES ABRIL.xlsx");
            foreach (var excelData in excelDataList)
            {
                Console.WriteLine($"{excelData.Column1} {excelData.Column2}");
            }
        }





}