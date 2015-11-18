using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace TeamCityTasksTests
{
    public class MockBuildEngine : IBuildEngine
    {
        private List<string> messages;
             
        public MockBuildEngine()
        {
            this.messages = new List<string>();
        }

        public void LogErrorEvent(BuildErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void LogWarningEvent(BuildWarningEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void LogMessageEvent(BuildMessageEventArgs e)
        {
            this.messages.Add(e.Message);
        }

        public void LogCustomEvent(CustomBuildEventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool BuildProjectFile(string projectFileName, string[] targetNames, IDictionary globalProperties, IDictionary targetOutputs)
        {
            throw new NotImplementedException();
        }

        public bool ContinueOnError { get; }

        public int LineNumberOfTaskNode { get; }

        public int ColumnNumberOfTaskNode { get; }

        public string ProjectFileOfTaskNode { get; }

        public IList<string> LoggedMessages
        {
            get { return this.messages; }
        }
    }
}
