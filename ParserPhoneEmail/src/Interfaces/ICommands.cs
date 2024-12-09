using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserPhoneEmail.src.DataClass;

namespace ParserPhoneEmail.src.Interfaces
{
    public interface ICommands
    {
        public string name { get; set; }
        public void Command(ParametrClass parametr);
    }
}
