using System;
using Microsoft.Build.Utilities;
using NUnit.Framework;
using TeamCityTasks;
using TeamCityTasksTests.IntegrationTests;

namespace TeamCityTasksTests
{
    [TestFixture]
    public class TeamCityPublishArtifactsTests
    {
        [Test]
        public void TeamCityPublishArtifacts_Class_IsMsbuildTask()
        {
            var task = new TeamCityPublishArtifacts();

            Assert.IsInstanceOf<Task>(task);
        }

        [Test]
        public void Execute_PathIsSet_OutputsCorrectMessage()
        {
            var expectedPath = "bin\\artifact.zip";

            var engine = new MockBuildEngine();
            var task = new TeamCityPublishArtifacts();
            task.BuildEngine = engine;

            task.Path = expectedPath;

            var actualResult = task.Execute();

            Assert.True(actualResult);
            CollectionAssert.Contains(engine.LoggedMessages, "##teamcity[publishArtifacts 'bin\\artifact.zip']");
        }
    }
}
