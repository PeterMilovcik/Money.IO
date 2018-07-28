using NUnit.Framework;

namespace Money.IO.Tests.CalculatorTests
{
    public class TestFixture
    {
        protected Calculator Calculator { get; private set; }

        [SetUp]
        public virtual void SetUp() => Calculator = new Calculator();
    }
}