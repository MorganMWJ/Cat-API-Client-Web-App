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

        //todo add query param methods for searching images

        public async Task<List<ImageViewModel>> GetPublicImagesAsync(int amount=100)
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.GetAsync($"/v1/images/search?limit={amount}");

            List<ImageViewModel> images;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageViewModel>>(responseString);
            }
            else
            {
                images = null;
            }

            return images;
        }

        public async Task<List<ImageViewModel>> GetPublicImagesByCategoryAsync(int categoryId, int amount = 100)
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.GetAsync($"/v1/images/search?limit={amount}&category_ids={categoryId}");

            List<ImageViewModel> images;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageViewModel>>(responseString);
            }
            else
            {
                images = null;
            }

            return images;
        }

        public async Task<List<ImageViewModel>> GetPublicImagesByBreedAsync(string breedId, int amount = 100)
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.GetAsync($"/v1/images/search?limit={amount}&breed_id={breedId}");

            List<ImageViewModel> images;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageViewModel>>(responseString);
            }
            else
            {
                images = null;
            }

            return images;
        }

        public async Task<List<ImageViewModel>> GetUploadedImagesAsync()
        {
            var client = _factory.CreateClient("CatClient");
            HttpResponseMessage response = await client.GetAsync($"/v1/images");

            List<ImageViewModel> images;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImageViewModel>>(responseString);
            }
            else
            {
                images = null;
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
