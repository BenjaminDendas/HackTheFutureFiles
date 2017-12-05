using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Response
    {
        public string TeamId { get; set; }

        public Response(string id)
        {
            this.TeamId = id;
        }
    }
}
