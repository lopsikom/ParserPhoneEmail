using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserPhoneEmail.src.DataClass;
using ParserPhoneEmail.src.Interfaces;

namespace ParserPhoneEmail.src.Commands
{
    public class StartParsingCommand : ICommands
    {
        public string name { get; set; } = "Начать парсинг";
        public void Command(ParametrClass parametr)
        {
            var excel = new ExcelClass(parametr.path);
            var Data = LinkPickerClass.LinksPick(excel.GetExcelData(), 2, 50);
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
            Console.WriteLine("Нажмите Enter чтобы продолжить");
            Console.ReadLine();
        }
    }
}
