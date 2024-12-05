using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ParserPhoneEmail.src
{
    public class HtmlParser
    {
        private string url { get; set; }
        private int contextDepth { get; set; }
        private int stringLenght { get; set; }  
        public HtmlParser(string _url, int _contextDepth = 1, int _stringLenght = 100) { 
            url = _url;
            contextDepth = _contextDepth;
            stringLenght = _stringLenght;
        }
        private static string GetHtml(string url)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                    return client.GetStringAsync(url).Result;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private static string DeHtmlCoding(string _text)
        {
            _text = HttpUtility.HtmlDecode(_text);
            _text = Regex.Replace(_text, @"\s?&nbsp;\s?", " ");
            _text = Regex.Replace(_text, @"\s+", " ");
            return _text;
        }
        private bool IsValidText(string _text, HashSet<string> uniqueContext)
        {
            if (uniqueContext.Contains(_text))
            {
                return true;
            }
            uniqueContext.Add(_text);
            if (_text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length > stringLenght)
            {
                return true;
            }
            return false;
        }
        public List<PhoneContext> GetPhoneFromHtml()
        {
            var html = GetHtml(url);
            if (string.IsNullOrEmpty(html))
            {
                Console.WriteLine("Не удалось загрузить страницу");
                return null;
            }
            Console.WriteLine("Начало");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            string phonePattern = @"(?:тел\.?:?\s?\(?\d{3,4}\)?\s?\d{1,3}[-\s/]?\d{2}[-\s]?\d{2}[-\s]?\d{2}|телефон\s?:?\s?\(?\d{3}-\d{1}\)?\s?\d{2}-\d{2}-\d{2}|тел\.?/факс\s?:?\s?\(?\d{3,4}\)?\s?\d{1,3}[-\s/]?\d{2}[-\s]?\d{2}[-\s]?\d{2}|(?:\+7\s?\(?\d{3,4}\)?\s?\d{2,4}[-\s/]?\d{2,3}[-\s]?\d{2,3}))";

            HashSet<string> uniqueText = new HashSet<string>();
            HashSet<string> uniqueContext = new HashSet<string>();
            Regex regex = new Regex(phonePattern, RegexOptions.IgnoreCase);
            var result = new List<PhoneContext>();
            var TextNodes = doc.DocumentNode.Descendants().Where(node => !string.IsNullOrWhiteSpace(node.InnerText))
            .ToList();

            for (int i = 0; i <  TextNodes.Count; i++)
            {
                var text = TextNodes[i].InnerText.Trim();

                text = DeHtmlCoding(text);
                //Console.WriteLine("LINES" + text);
                var lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    // Ищем номер телефона
                    var match = regex.Match(line);

                    if (match.Success)
                    {
                        // Выводим только номер телефона
                        
                        if (uniqueText.Contains(match.Value))
                        {
                            break;
                        }
                        if (match.Success)
                        {
                            //Console.WriteLine("Найден номер телефона: " + match.Value);
                            //Console.WriteLine("LINES" + text);
                            uniqueText.Add(match.Value);
                            //Console.WriteLine(match.Value);
                            var fullcontext = new List<string>();
                            for (int j = Math.Max(0, i - contextDepth); j < i; j++)
                            {
                           
                                var _text = TextNodes[i].InnerText.Trim();
                                _text = DeHtmlCoding(_text);
                                if(IsValidText(_text, uniqueContext))
                                {
                                    continue;
                                }
                                fullcontext.Add(_text);
                            }

                            if (text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length > stringLenght)
                            {
                                result.Add(new PhoneContext
                                {
                                    Phone = match.Value,
                                    context = []
                                });
                                continue;
                            }

                            for (int j = i + 1; j <= Math.Min(TextNodes.Count - 1, i + contextDepth); j++)
                            {
                                var _text = TextNodes[i].InnerText.Trim();
                                _text = DeHtmlCoding(_text);
                                if (IsValidText(_text, uniqueContext))
                                {
                                    continue;
                                }
                                fullcontext.Add(_text);
                            }
                            result.Add(new PhoneContext
                            {
                                Phone = match.Value,
                                context = fullcontext
                            });
                        }
                    }
                }
               

             

            }
            return result;
        }
        public List<EmailContext> GetEmailsFromHtml()
        {
            var html = GetHtml(url);
            if (string.IsNullOrEmpty(html))
            {
                Console.WriteLine("Не удалось загрузить страницу");
                return null;
            }
            Console.WriteLine("Начало парсинга email-адресов");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            HashSet<string> uniqueEmails = new HashSet<string>();
            HashSet<string> uniqueContext = new HashSet<string>();
            Regex regex = new Regex(emailPattern, RegexOptions.IgnoreCase);
            var result = new List<EmailContext>();
            var TextNodes = doc.DocumentNode.Descendants()
                .Where(node => !string.IsNullOrWhiteSpace(node.InnerText))
                .ToList();

            for (int i = 0; i < TextNodes.Count; i++)
            {
                var text = TextNodes[i].InnerText.Trim();
                text = DeHtmlCoding(text);

                var lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    // Ищем email
                    var match = regex.Match(line);

                    if (match.Success)
                    {
                        if (uniqueEmails.Contains(match.Value))
                        {
                            break;
                        }
                        uniqueEmails.Add(match.Value);

                        var fullcontext = new List<string>();
                        for (int j = Math.Max(0, i - contextDepth); j < i; j++)
                        {
                            var _text = TextNodes[j].InnerText.Trim();
                            _text = DeHtmlCoding(_text);
                            if (IsValidText(_text, uniqueContext))
                            {
                                continue;
                            }
                            fullcontext.Add(_text);
                        }

                        if (text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length > stringLenght)
                        {
                            result.Add(new EmailContext
                            {
                                Email = match.Value,
                                context = new List<string>()
                            });
                            continue;
                        }

                        for (int j = i + 1; j <= Math.Min(TextNodes.Count - 1, i + contextDepth); j++)
                        {
                            var _text = TextNodes[j].InnerText.Trim();
                            _text = DeHtmlCoding(_text);
                            if (IsValidText(_text, uniqueContext))
                            {
                                continue;
                            }
                            fullcontext.Add(_text);
                        }

                        result.Add(new EmailContext
                        {
                            Email = match.Value,
                            context = fullcontext
                        });
                    }
                }
            }
            return result;
        }
    }


}
