using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SIA12AutomationSolution
{
    [TestClass]
    public class DummyTests
    {
        [TestMethod]
        public void Should_calculate_correctly()
        {
            var result = 123 + 1;
            Assert.AreEqual(124, result, $"The result is: {result}");
        }

        [TestMethod]
        public void Should_contain_my_name()
        {
            var result = "George Chirila";
            Assert.IsTrue(result.Contains("George"));
        }
    }
}
