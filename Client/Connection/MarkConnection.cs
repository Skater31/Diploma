using Newtonsoft.Json;
using Server_SIde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client.Connection
{
    public class MarkConnection
    {
        private const string _uri = "https://localhost:7280/mark";

        private readonly HttpClient _httpClient;

        public MarkConnection()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Mark>> GetAllMarks()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var marks = JsonConvert.DeserializeObject<IEnumerable<Mark>>(responseContent);

                return marks;
            }

            return null;
        }
    }
}
