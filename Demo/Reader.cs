using IronXL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Demo
{
    public class Reader
    {
        public string ReadTextFile(Stream reader)
        {
            string inputContent;
            using (StreamReader inputStreamReader = new StreamReader(reader))
            {
                inputContent = inputStreamReader.ReadToEnd();
            }
            return inputContent;
        }

        public string ReadCSVFile(Stream reader)
        {
            string inputContent;
            using (StreamReader inputStreamReader = new StreamReader(reader))
            {
                inputContent = inputStreamReader.ReadToEnd();
            }
            return inputContent;
        }

        public List<IronXL.Cell> ReadExcellFile(byte[] bytes)
        {
            //Supported spreadsheet formats for reading include: XLSX, XLS, CSV and TSV
            WorkBook workbook = WorkBook.Load(bytes);
            WorkSheet sheet = workbook.WorkSheets.First();
            //This is how we get range from Excel worksheet
            List<IronXL.Cell> cells = sheet.FilledCells.ToList();
            return cells;
        }
    }
}