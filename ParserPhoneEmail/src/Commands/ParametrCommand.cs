using ParserPhoneEmail.src.DataClass;
using ParserPhoneEmail.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src.Commands
{
    public class ParametrCommand : ICommands
    {
        public string name { get; set; } = "Изменить параметры парсинга";

        public void Command(ParametrClass parametr)
        {
            SelectCommandClass.SelectCommand(new List<ICommands> { new AddContexntLenghtCommand(), new AddDepthContextCommand() }, parametr);
        }
    }
}
