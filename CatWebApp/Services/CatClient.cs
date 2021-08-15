using CatWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatWebApp.Services
{
    public class CatClient : ICatClient
    {
        private readonly IHttpClientFactory _factory;

        public CatClient(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<BreedViewModel>> GetBreedsAsync()
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.GetAsync($"/v1/breeds");

            List<BreedViewModel> breedList;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                breedList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BreedViewModel>>(responseString);
            }
            else
            {
                breedList = null;
            }

            return breedList;
        }

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.GetAsync($"/v1/categories");

            List<CategoryViewModel> categories;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                categories = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CategoryViewModel>>(responseString);
            }
            else
            {
                categories = null;
            }

            return categories;
        }
    }
}
