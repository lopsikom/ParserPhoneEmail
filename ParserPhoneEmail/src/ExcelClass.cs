using OfficeOpenXml;
using ParserPhoneEmail.src.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPhoneEmail.src
{
    public class ExcelClass
    {
        private string path {  get; set; }
        public ExcelClass(string _path)
        {
            path = _path;
        }
        public List<ParseData> GetExcelData()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rows = worksheet.Dimension.Rows;
                int cols = worksheet.Dimension.Columns;
                var list = new List<ParseData>();
                for (int i = 2; i < cols; i++)
                {
                    var name = worksheet.Cells[i, 1].Text;
                    var inn = worksheet.Cells[i, 2].Text;
                    var url = worksheet.Cells[i, 3].Text;
                    list.Add(new ParseData(name, inn, url));
                }
                return list;
            }
        }
        public void SaveExcelData(List<ParseData> list)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Count > 1
                ? package.Workbook.Worksheets[1]
                : package.Workbook.Worksheets.Add("Лист2");
                var countrow = 1;
                for(int i = 1; i < 8; i++)
                {
                    worksheet.Column(i).Style.WrapText = true;
                    worksheet.Column(i).Width = 30;
                    //worksheet.Column(i).AutoFit();
                }
                foreach(var data in list)
                {
                    var phonelist = data.GetAllPhoneNumbers();
                    var emaillist = data.GetAllEmails();
                    var count = phonelist.Count > emaillist.Count ?
                        data.GetAllPhoneNumbers().Count 
                        : data.GetAllEmails().Count;
                    for(int i = 0; i < count; i++)
                    {
                        //Console.WriteLine(phonelist.Count);
                        countrow++;
                        if(phonelist.Count > i)
                        {
                            
                            worksheet.Cells[countrow, 1].Value = data.GetName();
                            worksheet.Cells[countrow, 2].Value = data.GetINN();
                            worksheet.Cells[countrow, 3].Value = data.GetURL();
                            worksheet.Cells[countrow, 4].Value = phonelist[i].Phone;
                            worksheet.Cells[countrow, 5].Value = string.Join(" ", phonelist[i].context);
                        }
                        if (emaillist.Count > i)
                        {
                            worksheet.Cells[countrow, 1].Value = data.GetName();
                            worksheet.Cells[countrow, 2].Value = data.GetINN();
                            worksheet.Cells[countrow, 3].Value = data.GetURL();
                            worksheet.Cells[countrow, 6].Value = emaillist[i].Email;
                            worksheet.Cells[countrow, 7].Value = string.Join(" ", emaillist[i].context);
                        }
                    }
                }
                package.Save();
                Console.WriteLine("Данные успешно записаны в существующий файл!");
            }
        }
    }
}
