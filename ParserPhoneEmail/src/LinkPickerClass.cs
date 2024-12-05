using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src
{
    public static class LinkPickerClass
    {
        public static List<ParseData> LinksPick(List<string> Urls, int contextDepth = 1, int stringLenght = 100)
        {
            Console.WriteLine($"Количество логических ядер: {Environment.ProcessorCount}");
            var DataList = new ConcurrentBag<ParseData>();
            Parallel.ForEach(Urls, Url =>
            {
                var Data = new ParseData(Url, contextDepth, stringLenght);
                DataList.Add(Data);
            });
            return DataList.ToList();
        }
    }
}
