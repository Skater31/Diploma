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
    public class FreeEquipmentConnection
    {
        private const string _uri = "https://localhost:7280/freeEquipment";

        private readonly HttpClient _httpClient;

        public FreeEquipmentConnection()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<FreeEquipment>> GetAllFreeEquipment(int warehouseId)
        {
            var valueSerialize = JsonConvert.SerializeObject(warehouseId);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getAllFreeEquipment", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var freeEquipments = JsonConvert.DeserializeObject<IEnumerable<FreeEquipment>>(responseContent);

                return freeEquipments;
            }

            return null;
        }

        public async Task<IEnumerable<FreeEquipment>> GetAllFreeEquipment()
        {
            var response = await _httpClient.GetAsync(_uri + "/getAllFreeEquipment");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var freeEquipments = JsonConvert.DeserializeObject<IEnumerable<FreeEquipment>>(responseContent);

                return freeEquipments;
            }

            return null;
        }

        public async Task<FreeEquipment> GetById(int id)
        {
            var valueSerialize = JsonConvert.SerializeObject(id);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getById", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var freeEquipment = JsonConvert.DeserializeObject<FreeEquipment>(responseContent);

                return freeEquipment;
            }

            return null;
        }

        public async void Add(FreeEquipment freeEquipment)
        {
            var freeEquipmentSerialize = JsonConvert.SerializeObject(freeEquipment);

            var content = new StringContent(freeEquipmentSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(FreeEquipment freeEquipment)
        {
            var freeEquipmentSerialize = JsonConvert.SerializeObject(freeEquipment);

            var content = new StringContent(freeEquipmentSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Edit(IEnumerable<FreeEquipment> freeEquipment)
        {
            var freeEquipmentSerialize = JsonConvert.SerializeObject(freeEquipment);

            var content = new StringContent(freeEquipmentSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/editRange", content);
        }

        public async void Delete(FreeEquipment freeEquipment)
        {
            var freeEquipmentSerialize = JsonConvert.SerializeObject(freeEquipment);

            var content = new StringContent(freeEquipmentSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }

        public async Task<IEnumerable<FreeEquipment>> Find(string value, int warehouseId)
        {
            var valueSerialize = JsonConvert.SerializeObject(value + $"+{warehouseId}");

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/find", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var foundedFreeEquipments = JsonConvert.DeserializeObject<IEnumerable<FreeEquipment>>(responseContent);

                return foundedFreeEquipments;
            }

            return null;
        }
    }
}
