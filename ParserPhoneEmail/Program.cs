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
            var excel = new ExcelClass(filePath);
            var Data = LinkPickerClass.LinksPick(excel.GetExcelData(), 2, 50);
            Console.WriteLine("Вывод");
            excel.SaveExcelData(Data);
            foreach (var data in Data)
            {
                var name = data.GetName();
                var inn = data.GetINN();
                var url = data.GetURL();
                var listphone = data.GetAllPhoneNumbers();
                var listemail = data.GetAllEmails();
                Console.WriteLine($"\nКомпания {name}\n");
                foreach (var phone in listphone)
                {
                    Console.WriteLine($"Номер телефона: \n{phone.Phone}");
                    Console.WriteLine("Контекст");
                    foreach (var context in phone.context)
                    {
                        Console.WriteLine(context);
                    }
                }
                foreach (var email in listemail)
                {
                    Console.WriteLine($"почта: \n{email.Email}");
                    Console.WriteLine("Контекст");
                    foreach (var context in email.context)
                    {
                        Console.WriteLine(context);
                    }
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
