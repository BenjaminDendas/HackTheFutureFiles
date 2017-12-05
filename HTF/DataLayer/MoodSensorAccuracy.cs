namespace DataLayer
{
    public class MoodSensorAccuracy
    {
        public MoodSensorAccuracy(string toString)
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