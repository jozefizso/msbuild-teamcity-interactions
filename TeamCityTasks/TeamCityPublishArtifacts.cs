using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace TeamCityTasks
{
    public class TeamCityPublishArtifacts : Task
    {
        [Required]
        public string Path { get; set; }

        public override bool Execute()
        {
            string messageFormat = "##teamcity[publishArtifacts '{0}']";
            var escapedPath = this.Path.TeamCityEscape();
            string message = String.Format(messageFormat, escapedPath);

            this.Log.LogMessage(MessageImportance.Normal, message);

            return true;
        }
    }
}
