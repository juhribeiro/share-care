using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShareCare.Service.Services
{
    public class SpecialtyService : ISpecialtyService, IDisposable
    {
        private readonly HttpClient httpClient;


        public SpecialtyService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }


        public async Task<IEnumerable<string>> GetSpecialtyAsync()
        {
            var response = await httpClient.GetAsync("?resource_id=e0623b0e-f9b8-494c-8726-8652b8495fdd&limit=50");

            string jsonString = await response.Content.ReadAsStringAsync();

            var getSpecialty = JsonSerializer.Deserialize<GetSpecialtyModels>(jsonString);

            return getSpecialty.Result.Records.Select(x => x.SpecialtyDescription);
        }
    }
}
