using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src
{
    public class ParametrCommand : ICommands
    {
        public string name { get; set; } = "Изменить параметры парсинга";

        public void Command(ParametrClass parametr)
        {
            SelectCommandClass.SelectCommand(new List<ICommands> { new AddContexntLenghtCommand(), new AddDepthContextCommand()}, parametr);
        }
    }
}
