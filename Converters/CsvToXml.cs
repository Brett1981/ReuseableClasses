using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Re_useable_Classes.Converters
{
    internal class CsvToXml
    {
        /*
          Example Use
          string[] fieldNames = {
                               "Id",
                               "Name",
                               "Age"
                            };
                            CsvToXmlConvert("c:\\temp\\example.txt", "TempTable", ";", "c:\\temp\\example.xml", fieldNames);*/
        /// <summary>
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="dataName"></param>
        /// <param name="separator"></param>
        /// <param name="outputFile"></param>
        /// <param name="fieldnames"></param>
        public static void CsvToXmlConvert
            (
            string inputFile,
            string dataName,
            char separator,
            string outputFile,
            string[] fieldnames = null)
        {
            var dt = new DataTable(dataName);
            bool firstRow = true;

            using (var sr = new StreamReader(inputFile))
            {
                while (!(sr.EndOfStream))
                {
                    string readLine = sr.ReadLine();
                    if (readLine == null)
                    {
                        continue;
                    }
                    string[] fields = readLine.Split(separator);
                    IEnumerable<string> e = from s in fields
                                            select s;
                    int c = e.Count();
                    if (firstRow)
                    {
                        for (int ii = 0;
                             ii <= c - 1;
                             ii++)
                        {
                            string fName = "";
                            if ((fieldnames == null))
                            {
                                fName = "Field" + ii.ToString("000");
                            }
                            else
                            {
                                fName = fieldnames[ii];
                            }
                            dt.Columns.Add(fName);
                        }
                        firstRow = false;
                    }

                    foreach (string field in fields)
                    {
                        dt.Rows.Add(field);
                    }
                }

                dt.WriteXml(outputFile);
                dt.Dispose();
            }
        }
    }
}
