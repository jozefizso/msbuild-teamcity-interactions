using System;
using System.Collections.Generic;
using Microsoft.Build.Evaluation;
using NUnit.Framework;

namespace TeamCityTasksTests.IntegrationTests
{
    [TestFixture]
    public class SetParameterTaskProjectFile
    {
        [Test]
        public void SetParameterTaskProject_RunsBuildTarget_OutputsSetParameterMessageInLog()
        {
            var props = new Dictionary<string, string>();
            props.Add("TeamCityTasksPath", Environment.CurrentDirectory + @"\");

            var logger = new LoggerMock();

            var projects = new ProjectCollection();
            var project = projects.LoadProject(@"IntegrationTests\SetParameterTask.targets", props, "4.0");
            var result = project.Build(logger);

            Assert.True(result);
            CollectionAssert.Contains(logger.LoggedMessages, "##teamcity[setParameter name='BuildTag' value='MyApp_v1.0.0']");
        }
    }
}
