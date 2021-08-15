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
    public class BreedController : Controller
    {

        private readonly ICatClient _catClient;

        public BreedController(ICatClient catClient)
        {
            _catClient = catClient;
        }
     
        [Route("breeds")]
        public async Task<IActionResult> ListBreeds()
        {
            List<BreedViewModel> breeds = await _catClient.GetBreedsAsync();
            return View(breeds);
        }

        // GET: Breed/Details/5
        public async Task<IActionResult> Details(string id)
        {
            List<BreedViewModel> breeds = await _catClient.GetBreedsAsync();
      
            foreach (BreedViewModel breed in breeds)
            {
                if (breed.Id.Equals(id))
                {
                    return View(breed);
                }
            }

            return RedirectToAction("Error", "Home");
        }
    }
}