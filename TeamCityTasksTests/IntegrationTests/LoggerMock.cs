using System.Collections.Generic;
using Microsoft.Build.Framework;
using NUnit.Framework;

namespace TeamCityTasksTests.IntegrationTests
{
    public class LoggerMock : ILogger
    {
        private List<string> messages;

        public LoggerMock()
        {
            this.messages = new List<string>();
            this.Verbosity = LoggerVerbosity.Normal;
        }

        public void Initialize(IEventSource eventSource)
        {
            eventSource.MessageRaised += (sender, args) =>
            {
                this.messages.Add(args.Message);
            };

            eventSource.ErrorRaised += (sender, args) =>
            {
                Assert.Fail(args.Message);
            };
        }

        public void Shutdown()
        {
        }

        public LoggerVerbosity Verbosity { get; set; }

        public string Parameters { get; set; }

        public IList<string> LoggedMessages
        {
            get { return this.messages; }
        }
    }
}
