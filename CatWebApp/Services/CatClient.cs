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

        public async Task<List<ImageViewModel>> GetPublicImagesAsync(int amount)
        {
            return await GetImages($"/v1/images/search?limit={amount}");
        }

        public async Task<List<ImageViewModel>> GetPublicImagesAsync(int categoryId, int amount)
        {
            return await GetImages($"/v1/images/search?limit={amount}&category_ids={categoryId}");
        }

        public async Task<List<ImageViewModel>> GetPublicImagesAsync(string breedId, int amount)
        {           
            return await GetImages($"/v1/images/search?limit={amount}&breed_id={breedId}");
        }

        public async Task<List<ImageViewModel>> GetPublicImagesAsync(string breedId, int categoryId, int amount)
        {
            return await GetImages($"/v1/images/search?limit={amount}&breed_id={breedId}&category_ids={categoryId}");
        }

        public async Task<List<ImageViewModel>> GetUploadedImagesAsync()
        {
            return await GetImages($"/v1/images");
        }

        internal async Task<List<ImageViewModel>> GetImages(string url)
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.GetAsync(url);

            List<ImageViewModel> images = new List<ImageViewModel>();
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageViewModel>>(responseString);
            }

            return images;
        }

        public async Task<ImageViewModel> GetImageAsync(string id)
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.GetAsync($"/v1/images/{id}");

            ImageViewModel image;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                image = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageViewModel>(responseString);
            }
            else
            {
                image = null;
            }

            return image;
        }
       
        public async Task<HttpResponseMessage> UploadImageAsync(HttpContent imageUpload)
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.PostAsync($"/v1/images/upload", imageUpload);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteUploadedImage(string id)
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.DeleteAsync($"/v1/images/{id}");
            return response;
        }


    }
}
