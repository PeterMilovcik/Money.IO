using System;

namespace Money.IO
{
    public class Record
    {
        public DateTime DateTime { get; }
        public double Amount { get; }

        public Record(DateTime dateTime, double amount)
        {
            DateTime = dateTime;
            Amount = amount;
        }
    }
}