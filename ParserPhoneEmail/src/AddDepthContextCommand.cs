﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src
{
    public class AddDepthContextCommand : ICommands
    {
        public string name { get; set; } = "Глубину контекста";
        public void Command(ParametrClass parametr)
        {
            Console.WriteLine("Введите глубину контекста (Рекомендуется брать 1)");
            parametr.contextDepth = Convert.ToInt32(Console.ReadLine());
        }
    }
}
