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
    public class ImageController : Controller
    {
        private readonly ICatClient _catClient;

        public ImageController(ICatClient catClient)
        {
            _catClient = catClient;
        }

        [Route("images")]
        public async Task<IActionResult> ListPublicCatImages()
        {
            List<ImageViewModel> catImages = await _catClient.GetPublicImagesAsync();
            //List<BreedViewModel> breeds = await _catClient.GetBreedsAsync();
            //ViewBag.Breeds = breeds;
            //List<CategoryViewModel> categories = await _catClient.GetCategoriesAsync();
            //ViewBag.Categories = categories;
            return View(catImages);
        }

        [Route("images/uploaded")]
        public async Task<IActionResult> ListUploadedCatImages()
        {
            List<ImageViewModel> catImages = await _catClient.GetUploadedImagesAsync();
            return View(catImages);
        }

        [Route("images/{imageId}")]
        public async Task<IActionResult> ViewCatImage(string imageId)
        {
            ImageViewModel image = await _catClient.GetImageAsync(imageId);
            return View(image);
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(ListUploadedCatImages));
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Image/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(ListUploadedCatImages));
            }
            catch
            {
                return View();
            }
        }
    }
}