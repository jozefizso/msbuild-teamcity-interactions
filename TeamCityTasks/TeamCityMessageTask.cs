using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace TeamCityTasks
{
    public class TeamCityMessageTask : Task
    {
        public string Text { get; set; }

        ////public string ErrorDetails { get; set; }

        ////public string Status { get; set; }

        public override bool Execute()
        {
            string messageFormat = "##teamcity[message text='{0}']";
            var escapedValue = this.Text.TeamCityEscape();
            string message = String.Format(messageFormat, escapedValue);

            this.Log.LogMessage(MessageImportance.Normal, message);

            return true;
        }
    }
}
