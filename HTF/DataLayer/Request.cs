using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Request
    {
        public string password { get; set; }
        public bool location { get; set; }
        public bool crowd { get; set; }
        public bool mood { get; set; }
        public bool relationship { get; set; }
    }
}
