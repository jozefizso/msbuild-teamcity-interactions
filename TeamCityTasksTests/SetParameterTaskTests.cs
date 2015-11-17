using System;
using Microsoft.Build.Utilities;
using NUnit.Framework;
using TeamCityTasks;

namespace TeamCityTasksTests
{
    [TestFixture]
    public class SetParameterTaskTests
    {
        [Test]
        public void SetParameterTask_Class_IsMsbuildTask()
        {
            var task = new SetParameterTask();

            Assert.IsInstanceOf<Task>(task);
        }

        [Test]
        public void Execute_NameAndValueIsSet_OutputsCorrectMessage()
        {
            var expectedName = "MyParameter";
            var expectedValue = "parameter value";

            var engine = new MockBuildEngine();
            var task = new SetParameterTask();
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
            var task = new SetParameterTask();
            task.BuildEngine = engine;

            task.Name = expectedName;
            task.Value = expectedValue;

            var actualResult = task.Execute();

            Assert.True(actualResult);
            CollectionAssert.Contains(engine.LoggedMessages, "##teamcity[setParameter name='MyParameter' value='parameter value&apos;s']");
        }
    }
}
