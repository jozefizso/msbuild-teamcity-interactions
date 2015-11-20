using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace TeamCityTasks
{
    public class TeamCitySetParameter : Task
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public override bool Execute()
        {
            string messageFormat = "##teamcity[setParameter name='{0}' value='{1}']";
            var escapedValue = this.Value.TeamCityEscape();
            string message = String.Format(messageFormat, this.Name, escapedValue);

            this.Log.LogMessage(MessageImportance.Normal, message);

            return true;
        }
    }
}
