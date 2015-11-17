using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Build.Utilities;
using NUnit.Framework;
using TeamCityTasks;

namespace TeamCityTasksTests
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InvokeAsExtensionMethod")]
    public class StringExtensionsTests
    {
        [Test]
        public void StringExtensions_SimpleText_ReturnsTheSameText()
        {
            const string expectedMessage = "simple text";

            var actualMessage = StringExtensions.TeamCityEscape(expectedMessage);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        [TestCase("'", "|'")]
        [TestCase("\n", "|n")]
        [TestCase("\r", "|r")]
        [TestCase("|", "||")]
        [TestCase("[", "|[")]
        [TestCase("]", "|]")]
        public void StringExtensions_SingleSpecialSymbol_ReturnsEscapedString(string symbol, string expectedEscapedValue)
        {
            var actualEscapedValue = StringExtensions.TeamCityEscape(symbol);

            Assert.AreEqual(expectedEscapedValue, actualEscapedValue);
        }

        [Test]
        [TestCase("'\n\r|[]", "|'|n|r|||[|]")]
        [TestCase("||", "||||")]
        [TestCase("my value's", "my value|'s")]
        [TestCase("[1,2,3]|[1,2,3]", "|[1,2,3|]|||[1,2,3|]")]
        public void StringExtensions_MultipleSpecialSymbols_ReturnsEscapedString(string symbol, string expectedEscapedValue)
        {
            var actualEscapedValue = StringExtensions.TeamCityEscape(symbol);

            Assert.AreEqual(expectedEscapedValue, actualEscapedValue);
        }
    }
}
