using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Server_SIde.Models;
using Newtonsoft.Json.Linq;

namespace Client.Connection
{
    public class EquipmentConnection
    {
        private const string _uri = "https://localhost:7280/equipment";

        private readonly HttpClient _httpClient;

        public EquipmentConnection()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipment()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var equipments = JsonConvert.DeserializeObject<IEnumerable<Equipment>>(responseContent);

                return equipments;
            }

            return null;
        }

        public async Task<Equipment> GetById(int id)
        {
            var valueSerialize = JsonConvert.SerializeObject(id);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getById", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var equipment = JsonConvert.DeserializeObject<Equipment>(responseContent);

                return equipment;
            }

            return null;
        }

        public async void Add(Equipment equipment)
        {
            var equipmentSerialize = JsonConvert.SerializeObject(equipment);

            var content = new StringContent(equipmentSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(Equipment equipment)
        {
            var sportItemSerialize = JsonConvert.SerializeObject(equipment);

            var content = new StringContent(sportItemSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }
    }
}
