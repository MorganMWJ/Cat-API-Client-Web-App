using CatWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatWebApp.Services
{
    public interface ICatClient
    {
        Task<List<BreedViewModel>> GetBreedsAsync();

        Task<List<CategoryViewModel>> GetCategoriesAsync();
    }
}
