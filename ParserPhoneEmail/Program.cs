using OfficeOpenXml;
using ParserPhoneEmail.src;
using System.Text.RegularExpressions;
using System;
using System.Windows.Forms;
using Spectre.Console;
using ParserPhoneEmail.src.Interfaces;
using ParserPhoneEmail.src.DataClass;
using ParserPhoneEmail.src.Commands;

namespace ParserPhoneEmail
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            var parametrs = new ParametrClass();
            while(true)
            {
                AnsiConsole.Clear();
                SelectCommandClass.SelectCommand(new List<ICommands> { new ParametrCommand(), 
                    new StartParsingCommand() }, 
                    parametrs);
            }

        }
       
    }
}
