using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Feedback
    {
        public string androidId { get; set; }
        public double lattitude { get; set; }
        public double longitude { get; set; }
        public int crowd { get; set; }
        public string mood { get; set; }
        public string relationship { get; set; }
        public DateTime timestamp { get; set; }
        public bool autonomousRequest { get; set; }
    }
}
