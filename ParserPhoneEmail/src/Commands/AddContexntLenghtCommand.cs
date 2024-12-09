using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserPhoneEmail.src.DataClass;
using ParserPhoneEmail.src.Interfaces;

namespace ParserPhoneEmail.src.Commands
{
    public class AddContexntLenghtCommand : ICommands
    {
        public string name { get; set; } = "Размер контекста";
        public void Command(ParametrClass parametr)
        {
            Console.WriteLine("Введите Размер контекста (Рекомендуется брать 20)");
            parametr.stringLenght = Convert.ToInt32(Console.ReadLine());
        }
    }
}
