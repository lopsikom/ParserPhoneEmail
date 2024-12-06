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
        public ParseData(string compnanyname, string inn, string url) {
            CompanyName = compnanyname;
            INN = inn;
            URL = url;
            PhoneNumbers = new List<PhoneContext>();
            Emails = new List<EmailContext>();
        }

        public void AddEmail(List<EmailContext> email)
        {
            Emails = email;
        }
        public void AddPhone(List<PhoneContext> phone)
        {
            PhoneNumbers = phone;
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
