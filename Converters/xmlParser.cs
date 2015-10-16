using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Re_useable_Classes.Converters
{
    public static class XmlParser
    {
        /// <summary>
        /// Converts XML string to DataTable
        /// </summary>
        /// <param name="name">DataTable name</param>
        /// <param name="xmlString">XML string</param>
        /// <returns></returns>
        public static DataTable BuildDataTableFromXml(string name, string xmlString)
        {
            var doc = new XmlDocument();
            doc.Load(new StringReader(xmlString));
            var dt = new DataTable(name);
            try
            {

                var nodoEstructura = doc.FirstChild.FirstChild;
                //  Table structure (columns definition) 
                foreach (XmlNode columna in nodoEstructura.ChildNodes)
                {
                    dt.Columns.Add(columna.Name, typeof(String));
                }

                var filas = doc.FirstChild;
                //  Data Rows 
                foreach (XmlNode fila in filas.ChildNodes)
                {
                    var valores = new List<string>();
                    foreach (XmlNode columna in fila.ChildNodes)
                    {
                        valores.Add(columna.InnerText);
                    }
                    dt.Rows.Add(valores.ToArray());
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return dt;
        }
    }
}
