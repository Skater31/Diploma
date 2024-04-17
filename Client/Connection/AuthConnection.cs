using Newtonsoft.Json;
using Server_SIde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Connection
{
    public class AuthConnection
    {
        private readonly string _uri = "https://localhost:7280/auth";
        private readonly HttpClient _httpClient;

        public AuthConnection()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> IsAuthenticated(User user)
        {
            var userDtoSerialize = JsonConvert.SerializeObject(user);

            var content = new StringContent(userDtoSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var isAuth = JsonConvert.DeserializeObject<bool>(responseContent);

                return isAuth;
            }

            return false;
        }
    }
}
