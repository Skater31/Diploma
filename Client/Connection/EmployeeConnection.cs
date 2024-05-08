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
    public class EmployeeConnection
    {
        private const string _uri = "https://localhost:7280/employee";

        private readonly HttpClient _httpClient;

        public EmployeeConnection()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseContent);

                return employees;
            }

            return null;
        }

        public async Task<Employee> GetById(int id)
        {
            var valueSerialize = JsonConvert.SerializeObject(id);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getById", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var employee = JsonConvert.DeserializeObject<Employee>(responseContent);

                return employee;
            }

            return null;
        }

        public async Task<IEnumerable<FreeEquipment>> GetAllByEmployeeId(int employeeId)
        {
            var valueSerialize = JsonConvert.SerializeObject(employeeId);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getAllByEmployeeId", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var employeeFreeEquiomnet = JsonConvert.DeserializeObject<IEnumerable<FreeEquipment>>(responseContent);

                return employeeFreeEquiomnet;
            }

            return null;
        }

        public async void Add(Employee employee)
        {
            var employeeSerialize = JsonConvert.SerializeObject(employee);

            var content = new StringContent(employeeSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(Employee employee)
        {
            var employeeSerialize = JsonConvert.SerializeObject(employee);

            var content = new StringContent(employeeSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Delete(Employee employee)
        {
            var employeeSerialize = JsonConvert.SerializeObject(employee);

            var content = new StringContent(employeeSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
