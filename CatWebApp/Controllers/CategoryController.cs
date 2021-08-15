using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatWebApp.Models;
using CatWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICatClient _catClient;

        public CategoryController(ICatClient catClient)
        {
            _catClient = catClient;
        }

        [Route("categories")]
        public async Task<IActionResult> ListCategories()
        {
            List<CategoryViewModel> categories = await _catClient.GetCategoriesAsync();
            return View(categories);
        }
    }
}