using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class MyGameHTTPClient
    {
        private static string baseAdress = "http://193.137.46.2/swagger";

        private static HttpClient client;

        public static HttpClient Client
        {
            get
            {
                if (client==null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri(baseAdress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return client;
            }
        }
    }
}
