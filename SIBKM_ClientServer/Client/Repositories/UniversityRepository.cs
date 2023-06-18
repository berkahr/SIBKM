using API.ViewModels;
using API.Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class UniversitityRepository
    {
        private readonly string request;
        private readonly HttpContextAccessor contextAccessor;
        private readonly HttpClient httpClient;
        public UniversitityRepository(string request = "Universities/")
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7205/api/")
            };
        }
        public async Task<ResponseDataVM<List<Universities>>> Get()
        {
            ResponseDataVM<List<Universities>> entityVM = null;
            using (var response = await httpClient.GetAsync(this.request))
            {
                string apiRensponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Universities>>>(apiRensponse);
            }
            return entityVM;
        }
        public async Task<ResponseDataVM<string>> Post(Universities universities)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(universities), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request, content).Result) //localhost/api/university {method:post} -> content
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }
        public async Task<ResponseDataVM<Universities>> Get(int id)
        {
            ResponseDataVM<Universities> entity = null;
            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Universities>>(apiResponse);
            }
            return entity;
        }
    }
}