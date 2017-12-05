using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
using System.IO;

namespace HackTheFuture.Controllers
{
    public class FeedbackController : ApiController
    {
        private static string teamID = "02845afe-2dcf-40ff-19e1-08d537d2cddd";
        private HttpClient client;
        public FeedbackController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://bba23444.ngrok.io");
        }
        // GET: api/Feedback
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // POST: api/Feedback
        public IHttpActionResult Post([FromBody]Feedback feedback)
        {
   
            using (StreamWriter sw = new StreamWriter("feedback.txt"))
            {
                sw.WriteLine(feedback.androidId + ";"
                    + feedback.lattitude + ";"
                    + feedback.longitude + ";"
                    + feedback.crowd + ";"
                    + feedback.mood + ";"
                    + feedback.relationship + ";"
                    + feedback.timestamp + ";" 
                    + feedback.autonomousRequest);
            }

            // niks opvragen ge krijgt
            return Ok(new Response(teamID));
        }
    }
}
