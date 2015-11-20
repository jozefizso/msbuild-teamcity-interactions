using System;
using System.Collections.Generic;
using Microsoft.Build.Evaluation;
using NUnit.Framework;

namespace TeamCityTasksTests.IntegrationTests
{
    [TestFixture]
    public class TeamCityMessageTaskProjectTests
    {
        [Test]
        public void TeamCityMessageTaskProject_RunsBuildTarget_OutputsTeamCityMessageInLog()
        {
            var props = new Dictionary<string, string>();
            props.Add("TeamCityTasksPath", Environment.CurrentDirectory + @"\");

            var logger = new LoggerMock();

            var projects = new ProjectCollection();
            var project = projects.LoadProject(@"IntegrationTests\MessageTask.targets", props, "4.0");
            var result = project.Build(logger);

            Assert.True(result);
            CollectionAssert.Contains(logger.LoggedMessages, "##teamcity[message text='Reporting a message to TeamCity build log.']");
        }
    }
}
