using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src
{
    public static class SelectCommandClass
    {
        public static void SelectCommand(IEnumerable<ICommands> Commands, ParametrClass parametr)
        {
            SelectionPrompt<ICommands> prompt = new SelectionPrompt<ICommands>().
            Title("Выберите команду").
                PageSize(10).
                AddChoices(Commands).
                UseConverter(x => x.name);
            var command = AnsiConsole.Prompt(prompt);
            command.Command(parametr);
        }
    }
}
