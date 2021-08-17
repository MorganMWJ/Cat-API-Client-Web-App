using CatWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatWebApp.Services
{
    public interface ICatClient
    {
        Task<List<BreedViewModel>> GetBreedsAsync();

        Task<List<CategoryViewModel>> GetCategoriesAsync();

        Task<List<ImageViewModel>> GetPublicImagesAsync(int amount);

        Task<List<ImageViewModel>> GetPublicImagesAsync(int categoryId, int amount);

        Task<List<ImageViewModel>> GetPublicImagesAsync(string breedId, int amount);

        Task<List<ImageViewModel>> GetPublicImagesAsync(string breedId, int categoryId, int amount);

        Task<List<ImageViewModel>> GetUploadedImagesAsync();

        Task<ImageViewModel> GetImageAsync(string id);

        Task<HttpResponseMessage> UploadImageAsync(HttpContent imageUpload);
              
        Task<HttpResponseMessage> DeleteUploadedImage(string id);
    }
}
