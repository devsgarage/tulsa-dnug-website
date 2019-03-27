using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using tulsa_dnug_website.shared_kernel.Models;

namespace tulsa_dnug_website.Services
{
    public class WebsiteDataService
    {

        public async Task<Leader[]> GetLeadersAsync()
        {
            List<Leader> leaders = new List<Leader>();

            // ... Use HttpClient.
            string page = "https://localhost:44346/api/leaders";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string json = await content.ReadAsStringAsync();
                leaders = JsonConvert.DeserializeObject<List<Leader>>(json);

            }

            return leaders.ToArray();
        }
    }
}



