using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src
{
    public class ParseData
    {
        private string CompanyName {  get; set; }
        private string INN {  get; set; }
        private string URL {  get; set; }
        private List<PhoneContext> PhoneNumbers { get; set; }
        private List<EmailContext> Emails { get; set; }
        public ParseData(string compnanyname, string inn, string url, int contextDepth = 1, int stringLenght = 100) {
            CompanyName = compnanyname;
            INN = inn;
            URL = url;
            var par = new HtmlParser(url, contextDepth, stringLenght);
            PhoneNumbers = par.GetPhoneFromHtml();
            Emails = par.GetEmailsFromHtml();
        }

        public void AddEmail(EmailContext email)
        {
            Emails.Add(email);
        }
        public void AddPhone(PhoneContext phone)
        {
            PhoneNumbers.Add(phone);
        }
        public List<PhoneContext> GetAllPhoneNumbers()
        {
            return PhoneNumbers;
        }
        public List <EmailContext> GetAllEmails()
        {
            return Emails;
        }
        public string GetURL()
        {
            return URL;
        }
        public string GetName()
        {
            return CompanyName;
        }
        public string GetINN()
        {
            return INN;
        }
    }
}
