using FluentAssertions;
using NUnit.Framework;

namespace Money.IO.Tests.CalculatorTests
{
    public class Sum : TestFixture
    {
        [Test]
        public void Null_Returns0() => 
            Calculator.Sum(null).Should().Be(0.0f);
    }
}