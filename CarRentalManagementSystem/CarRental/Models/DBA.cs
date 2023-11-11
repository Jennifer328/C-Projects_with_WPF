using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class DBA
    {
        public static HttpClient client = new HttpClient();
        static DBA()
        {
            client.BaseAddress = new Uri("https://localhost:7122/CarRental/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
