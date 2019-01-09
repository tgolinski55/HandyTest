using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HandyTest.BL
{
    class SaveXml
    {
        public static void SaveSelectedProject(object obj, string filename, string id)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            XmlTextWriter writer = new XmlTextWriter(filename, null);
            writer.WriteStartDocument();
            writer.WriteStartElement("root");
            writer.WriteStartElement("Project");
            writer.WriteString(obj.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Id");
            writer.WriteString(id);
            writer.WriteEndElement();

            writer.WriteEndDocument();

            //sr.Serialize(writer, obj);
            writer.Close();
        }
    }
}
