using System.Collections.Generic;

namespace Money.IO
{
    public class Data
    {
        private readonly List<Record> records;

        public Data()
        {
            records = new List<Record>();
        }

        public IEnumerable<Record> Records => records;

        public void Add(Record record) => records.Add(record);
    }
}