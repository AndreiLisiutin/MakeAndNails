using FRI3NDZ.MakeAndNails.Web;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRI3NDZ.MakeAndNails.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(1, 1, 2)]
        [TestCase(-1, -1, -2)]
        [TestCase(100, 5, 105)]
        public void CanAddNumbers(int x, int y, int expected)
        {
            Assert.That(Calculator.Add(x, y), Is.EqualTo(expected));
        }

        [TestCase(1, 1, 0)]
        [TestCase(-1, -1, 0)]
        [TestCase(100, 5, 95)]
        public void CanSubtract(int x, int y, int expected)
        {
            Assert.That(Calculator.Subtract(x, y), Is.EqualTo(expected));
        }

        [TestCase(1, 1, 1)]
        [TestCase(-1, -1, 1)]
        [TestCase(100, 5, 500)]
        public void CanMultiply(int x, int y, int expected)
        {
            Assert.That(Calculator.Multiply(x, y), Is.EqualTo(expected));
        }

        [TestCase(1, 1, 1)]
        [TestCase(-1, -1, 1)]
        [TestCase(100, 5, 20)]
        public void CanDivide(int x, int y, int expected)
        {
            Assert.That(Calculator.Divide(x, y), Is.EqualTo(expected));
        }
    }
}
