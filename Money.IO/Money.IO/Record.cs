using System;

namespace Money.IO
{
    public class Record
    {
        public DateTime DateTime { get; }
        public float Amount { get; }

        public Record(DateTime dateTime, float amount)
        {
            DateTime = dateTime;
            Amount = amount;
        }
    }
}