﻿using System;
using Microsoft.Build.Utilities;
using NUnit.Framework;
using TeamCityTasks;
using TeamCityTasksTests.IntegrationTests;

namespace TeamCityTasksTests
{
    [TestFixture]
    public class TeamCityMessageTests
    {
        [Test]
        public void TeamCityMessage_Class_IsMsbuildTask()
        {
            var task = new TeamCityMessage();

            Assert.IsInstanceOf<Task>(task);
        }

        [Test]
        public void Execute_TextIsSet_OutputsCorrectMessage()
        {
            var expectedText = "My TeamCity message.";

            var engine = new MockBuildEngine();
            var task = new TeamCityMessage();
            task.BuildEngine = engine;

            task.Text = expectedText;

            var actualResult = task.Execute();

            Assert.True(actualResult);
            CollectionAssert.Contains(engine.LoggedMessages, "##teamcity[message text='My TeamCity message.']");
        }

        [Test]
        public void Execute_ValueWithSpecialCharactersIsSet_OutputsEscapedMessage()
        {
            var expectedText = "My special ' | \n characters.";

            var engine = new MockBuildEngine();
            var task = new TeamCityMessage();
            task.BuildEngine = engine;

            task.Text = expectedText;

            var actualResult = task.Execute();

            Assert.True(actualResult);
            CollectionAssert.Contains(engine.LoggedMessages, "##teamcity[message text='My special |' || |n characters.']");
        }
    }
}
