using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repo
{
    public class AndroidRepo
    {
        private static string TEAMID = "";
        private static HttpClient _client;

        public AndroidRepo()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://bba23444.ngrok.io");
        }

        public async Task<List<Androids>> get()
        {
            HttpResponseMessage response = await _client.GetAsync($"/feedback");
            List<Androids> androids;
            if (response.IsSuccessStatusCode)
            {
                androids = await response.Content.ReadAsAsync<List<Androids>>();
                return androids;
            }
            return null;
        }


        //public async Task<String> post()
        //{
            
        //}





    }
}
