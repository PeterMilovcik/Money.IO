using System;
using System.Linq;

namespace Money.IO
{
    public class Calculator
    {
        public double Sum(Records records) => 
            records.Sum(record => record.Amount);

        public double Rate(Records records) =>
            records.Count() > 1
                ? (Duration(records).TotalSeconds > 0
                    ? Sum(records) / Duration(records).TotalSeconds
                    : 0.0f)
                : 0.0f;

        private TimeSpan Duration(Records records)
        {
            var ordered = records.OrderBy(record => record.DateTime).ToList();
            return ordered.Count() > 1
                ? ordered.Last().DateTime - ordered.First().DateTime
                : new TimeSpan();
        }
    }
}