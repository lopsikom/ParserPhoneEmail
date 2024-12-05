using OfficeOpenXml;
using ParserPhoneEmail.src;
using System.Text.RegularExpressions;

namespace ParserPhoneEmail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\lopsik\\source\\repos\\ParserPhoneEmail\\ParserPhoneEmail\\test.xlsx";

            // Убедитесь, что лицензия EPPlus включена (для версии 5 и выше)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Открываем первый лист Excel
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // Узнаем количество строк и столбцов
                int rows = worksheet.Dimension.Rows;
                int cols = worksheet.Dimension.Columns;
                Console.WriteLine("Назване компаний");
                for (int i = 2; i < cols; i++)
                {
                    var value = worksheet.Cells[i, 1].Text;
                    Console.WriteLine(value);
                }
                Console.WriteLine("Назване компаний");
                for (int i = 2; i < cols; i++)
                {
                    var value = worksheet.Cells[i, 2].Text;
                    Console.WriteLine(value);
                }
                Console.WriteLine("Назване компаний");
                for (int i = 2; i < cols; i++)
                {
                    var value = worksheet.Cells[i, 3].Text;
                    Console.WriteLine(value);
                }
            }
        }
        //var UrlLis = new List<string>() {
        //    "http://erkc.vseversk.ru/about_us",
        //    "https://ekb.hevelsolar.com/contacts/",
        //    "https://www.himprom.com/contacts/",
        //    "https://www.kolesnica21.ru/index.php/2014-02-12-10-33-43/2014-02-12-10-34-11",
        //    "https://теплицырегионов.рф/contacts"
        //};
        //var Data = LinkPickerClass.LinksPick(UrlLis, 2);
        //Console.WriteLine("Вывод");
        //foreach (var data in Data)
        //{
        //    var url = data.GetURL();
        //    var listphone = data.GetAllPhoneNumbers();
        //    var listemail = data.GetAllEmails();
        //    Console.WriteLine($"\nСсылка {url}\n");
        //    foreach (var phone in listphone)
        //    {
        //        Console.WriteLine($"Номер телефона: \n{phone.Phone}");
        //        Console.WriteLine("Контекст");
        //        foreach (var context in phone.context)
        //        {
        //            Console.WriteLine(context);
        //        }
        //    }
        //    foreach (var email in listemail)
        //    {
        //        Console.WriteLine($"почта: \n{email.Email}");
        //        Console.WriteLine("Контекст");
        //        foreach (var context in email.context)
        //        {
        //            Console.WriteLine(context);
        //        }
        //    }
        //}  
    }
}
