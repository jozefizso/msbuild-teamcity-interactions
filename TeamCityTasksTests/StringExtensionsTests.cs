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
    }
}
