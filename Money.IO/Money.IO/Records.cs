using System.Collections;
using System.Collections.Generic;

namespace Money.IO
{
    public class Records : IEnumerable<Record>
    {
        private readonly List<Record> records;

        public Records()
        {
            records = new List<Record>();
        }

        public void Add(Record record) => records.Add(record);

        public IEnumerator<Record> GetEnumerator() => 
            records.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            ((IEnumerable) records).GetEnumerator();
    }
}