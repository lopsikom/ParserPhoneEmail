using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src.DataClass
{
    public class ParametrClass
    {
        public int contextDepth { get; set; }
        public int stringLenght { get; set; }
        public string path { get; set; }
        public ParametrClass()
        {
            contextDepth = 1;
            stringLenght = 50;
            path = DialogClass.ShowDialog();
        }
    }
}
