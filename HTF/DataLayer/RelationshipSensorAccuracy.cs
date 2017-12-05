namespace DataLayer
{
    public  class RelationshipSensorAccuracy
    {
        public RelationshipSensorAccuracy(string toString)
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