using System;

namespace DataLayer
{
    public class AutoPilot
    {
        public string code { get; set; }
        public string value { get; set; }

        public AutoPilot(string code)
        {
            this.code = code;
        }

        public override string ToString()
        {
            return code;
        }
    }
}