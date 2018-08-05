using System;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace Money.IO
{
    public sealed class Repository
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
                    data.Add(
                        new Record(
                            DateTime.Parse(
                                element.Attribute("datetime").Value,
                                CultureInfo.InvariantCulture),
                            float.Parse(
                                element.Attribute("amount").Value,
                                CultureInfo.InvariantCulture)));
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
                var dateTime = record.DateTime.ToString(CultureInfo.InvariantCulture);
                var amount = record.Amount.ToString(CultureInfo.InvariantCulture);
                document.Root?.Add(
                    new XElement("record",
                        new XAttribute("datetime", dateTime),
                        new XAttribute("amount", amount)));
            }
            document.Save(fileName);
            OnSaved();
        }

        public event EventHandler Saved;

        private void OnSaved() => 
            Saved?.Invoke(this, EventArgs.Empty);
    }
}