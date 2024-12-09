using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserPhoneEmail.src.DataClass;

namespace ParserPhoneEmail.src
{
    public static class LinkPickerClass
    {
        public static List<ParseData> LinksPick(List<ParseData> Urls, int contextDepth = 1, int stringLenght = 100)
        {
            //Console.WriteLine($"Количество логических ядер: {Environment.ProcessorCount}");
            //var DataList = new ConcurrentBag<ParseData>();
            Parallel.ForEach(Urls, Url =>
            {
                var par = new HtmlParser(Url.GetURL(), contextDepth, stringLenght);
                Url.AddPhone(par.GetPhoneFromHtml());
                Url.AddEmail(par.GetEmailsFromHtml());
            });
            return Urls;
        }
    }
}
