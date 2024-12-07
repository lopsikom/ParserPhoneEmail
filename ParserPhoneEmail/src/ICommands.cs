using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src
{
    public interface ICommands
    {
        public string name {  get; set; }
        public void Command(ParametrClass parametr);
    }
}
