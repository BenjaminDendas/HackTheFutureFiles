namespace DataLayer
{
    public  class CrowdSensorAccuracy
    {
        public string code { get; set; }
        public string value { get; set; }

        public CrowdSensorAccuracy(string code)
        {
            this.code = code;
        }
        public override string ToString()
        {
            return code;
        }
    }
}