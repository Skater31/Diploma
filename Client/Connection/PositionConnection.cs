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
    public class PositionConnection
    {
        private const string _uri = "https://localhost:7280/position";

        private readonly HttpClient _httpClient;

        public PositionConnection()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var positions = JsonConvert.DeserializeObject<IEnumerable<Position>>(responseContent);

                return positions;
            }

            return null;
        }

        public async void Add(Position position)
        {
            var positionSerialize = JsonConvert.SerializeObject(position);

            var content = new StringContent(positionSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Delete(Position position)
        {
            var positionSerialize = JsonConvert.SerializeObject(position);

            var content = new StringContent(positionSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
