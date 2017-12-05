using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Androids
    {
        public string password { get; set; }
        public AutoPilot autoPilot { get; set; }
        public LocationSensorAccuracy locationSensorAccuracy { get; set; }
        public CrowdSensorAccuracy crowdSensorAccuracy { get; set; }
        public MoodSensorAccuracy moodSensorAccuracy { get; set; }
        public RelationshipSensorAccuracy relationshipSensorAccuracy { get; set; }

        public override string ToString()
        {
            return "Level: " + autoPilot.code;
        }
    }
}
