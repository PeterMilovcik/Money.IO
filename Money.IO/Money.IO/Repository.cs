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
                    Environment.SpecialFolder.LocalApplicationData), "records.xml");
        }

        public Records Load()
        {
            if (File.Exists(fileName))
            {
                var document = XDocument.Load(fileName);
                var data = new Records();
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
            return new Records();
        }

        public void Save(Records records)
        {
            var document = new XDocument(new XElement("records"));
            foreach (var record in records)
            {
                document?.Root?.Add(
                    new XElement("record",
                        new XAttribute("datetime", record.DateTime.ToString(CultureInfo.InvariantCulture)),
                        new XAttribute("amount", record.Amount)));
            }
            document.Save(fileName);
            OnSaved();
        }

        public event EventHandler Saved;

        protected virtual void OnSaved() => 
            Saved?.Invoke(this, EventArgs.Empty);
    }
}