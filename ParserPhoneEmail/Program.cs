using ParserPhoneEmail.src;
using System.Text.RegularExpressions;

namespace ParserPhoneEmail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var par = new HtmlParser("https://ekb.hevelsolar.com/contacts/", 3, 100);
            var list = par.GetPhoneFromHtml();
            var list2 = par.GetEmailsFromHtml();
            Console.WriteLine("wew");
            foreach (var phone in list2)
            {
                Console.WriteLine(phone.Email);
                foreach (var item in phone.context)
                {
                    Console.WriteLine("НОВАЯ" + item.Length);
                    Console.WriteLine(item);
                }
            }
            //foreach (var phone in list)
            //{
            //    Console.WriteLine(phone.Phone);
            //    foreach (var item in phone.context)
            //    {
            //        Console.WriteLine("НОВАЯ" + item.Length);
            //        Console.WriteLine(item);
            //    }
            //}
            //string input = "Мой номер телефона: (495) 123-45-67";

            //// Создаем регулярное выражение
            //string pattern = @"(\+7\s?|\(?\d{3}\)?[\s\-]?)\d{1,3}[\s\-]?\d{2}[\s\-]?\d{2}[\s\-]?\d{2}";
            //Regex regex = new Regex(pattern);

            //// Ищем совпадения
            //Match match = regex.Match(input);

            //if (match.Success)
            //{
            //    Console.WriteLine("Найден номер: " + match.Value);
            //}
            //else
            //{
            //    Console.WriteLine("Номер не найден.");
            //}
        }
    }
}
