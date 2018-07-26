using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace Money.IO
{
    public class Repository
    {
        private readonly string fileName;

        public Repository()
        {
            fileName = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), "data.xml");
        }

        public Data Load()
        {
            if (File.Exists(fileName))
            {
                var document = XDocument.Load(fileName);
                var data = new Data();
                var records = document.Root.Elements("record");
                foreach (var element in records)
                {
                    var dateTime = DateTime.Parse(element.Attribute("datetime").Value);
                    var amount = float.Parse(element.Attribute("amount").Value);
                    var record = new Record(dateTime, amount);
                    data.Add(record);
                }
                return data;
            }
            return new Data();
        }

        public void Save(Data data)
        {
            var document = new XDocument(new XElement("records"));
            foreach (Record record in data.Records)
            {
                document?.Root?.Add(
                    new XElement("record",
                        new XAttribute("datetime", record.DateTime.ToString(CultureInfo.InvariantCulture)),
                        new XAttribute("amount", record.Amount)));
            }
            document.Save(fileName);
        }
    }
}