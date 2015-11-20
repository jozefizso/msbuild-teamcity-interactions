using System;
using Microsoft.Build.Utilities;
using NUnit.Framework;
using TeamCityTasks;
using TeamCityTasksTests.IntegrationTests;

namespace TeamCityTasksTests
{
    [TestFixture]
    public class TeamCitySetParameterTests
    {
        [Test]
        public void TeamCitySetParameter_Class_IsMsbuildTask()
        {
            var task = new TeamCitySetParameter();

            Assert.IsInstanceOf<Task>(task);
        }

        [Test]
        public void Execute_NameAndValueIsSet_OutputsCorrectMessage()
        {
            var expectedName = "MyParameter";
            var expectedValue = "parameter value";

            var engine = new MockBuildEngine();
            var task = new TeamCitySetParameter();
            task.BuildEngine = engine;

            task.Name = expectedName;
            task.Value = expectedValue;

            var actualResult = task.Execute();

            Assert.True(actualResult);
            CollectionAssert.Contains(engine.LoggedMessages, "##teamcity[setParameter name='MyParameter' value='parameter value']");
        }

        [Test]
        public void Execute_ValueWithSpecialCharactersIsSet_OutputsEscapedMessage()
        {
            var expectedName = "MyParameter";
            var expectedValue = "parameter value's";

            var engine = new MockBuildEngine();
            var task = new TeamCitySetParameter();
            task.BuildEngine = engine;

            task.Name = expectedName;
            task.Value = expectedValue;

            var actualResult = task.Execute();

            Assert.True(actualResult);
            CollectionAssert.Contains(engine.LoggedMessages, "##teamcity[setParameter name='MyParameter' value='parameter value|'s']");
        }
    }
}
