using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataEntryApplication.Client.Services.Interfaces;
using DataEntryApplication.Shared;
using Microsoft.AspNetCore.Components;

namespace DataEntryApplication.Client.Services
{
    public class CMD1Service : ICMD1Services
    {
        private readonly HttpClient _httpClient;

        public CMD1Service(HttpClient httpClient)
        {
            _httpClient=httpClient;;
        }
        public async Task<IList<CMD1Model>> GetValuesOfCMD1()
        {
            var result = await _httpClient.GetJsonAsync<IList<CMD1Model>>("api/CMD1");

            return result;
        }

        public async Task<bool> Save(IList<CMD1Model> values, int mode)
        {
            var json = JsonSerializer.Serialize(values);
            var response = await _httpClient.PostAsync($"api/CMD1/{mode}", new StringContent(json, Encoding.UTF8, "application/json"));
            return response.IsSuccessStatusCode;
        }
    }
}
