﻿using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class EmployeRepository
    {
        private readonly string request;
        private readonly HttpContextAccessor contextAccessor;
        private HttpClient httpClient;

        public EmployeRepository(string request = "Employee/")
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7205/api/")
            };
        }


        public async Task<ResponseDataVM<List<Employee>>> Get()
        {
            ResponseDataVM<List<Employee>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Employee>>>(apiResponse);
            }
            return entityVM;
        }


        public async Task<ResponseDataVM<Employee>> Get(string nik)
        {
            ResponseDataVM<Employee> entity = null;

            using (var response = await httpClient.GetAsync(request + nik))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Employee>>(apiResponse);
            }
            return entity;
        }


        public async Task<ResponseDataVM<string>> Post(Employee employee)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }


        public async Task<ResponseDataVM<string>> Put(string NIK, Employee employee)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }


        public async Task<ResponseDataVM<Employee>> Delete(string nik)
        {
            ResponseDataVM<Employee> entity = null;

            using (var response = await httpClient.DeleteAsync(request + nik))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Employee>>(apiResponse);
            }
            return entity;
        }
    }
}