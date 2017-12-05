using System;

namespace DataLayer
{
    public class LocationSensorAccuracy
    {
        public LocationSensorAccuracy(string toString)
        {
            this.code = toString;
        }

        public string code { get; set; }
        public string value { get; set; }

        public override string ToString()
        {
            return code;
        }
    }
}