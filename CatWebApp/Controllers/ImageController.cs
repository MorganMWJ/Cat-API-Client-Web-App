using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        public async Task<IActionResult> ListPublicCatImages(string breedId = null, int? categoryId = null, int? amount = null)
        {
            if (amount == null)
            {
                /* Default to 50 cats */
                amount = 50;
            }

            List<ImageViewModel> catImages = new List<ImageViewModel>();
            if (breedId == null && categoryId == null)
            {
                catImages = await _catClient.GetPublicImagesAsync((int)amount);
            }
            else if (breedId == null && categoryId != null)
            {
                catImages = await _catClient.GetPublicImagesAsync((int)categoryId, (int)amount);
            }
            else if (breedId != null && categoryId == null)
            {
                catImages = await _catClient.GetPublicImagesAsync(breedId, (int)amount);
            }
            else if (breedId != null && categoryId != null)
            {
                catImages = await _catClient.GetPublicImagesAsync(breedId, (int)categoryId, (int)amount);
            }

            /* Get Breeds for user to filter by breed */
            List<BreedViewModel> breeds = await _catClient.GetBreedsAsync();
            ViewBag.Breeds = breeds;

            /* Get Categories for user to filter by category */
            List<CategoryViewModel> categories = await _catClient.GetCategoriesAsync();
            ViewBag.Categories = categories;

            ListPublicCatImagesModel model = new ListPublicCatImagesModel();
            model.CatImages = catImages;
            if (breedId != null)
                model.BreedFilter = breedId;
            if (categoryId != null)
                model.CategoryFilter = (int)categoryId;
            model.AmountFilter = (int)amount;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterImages(ListPublicCatImagesModel model)
        {
            if (model.BreedFilter.Equals("Any..."))
            {
                model.BreedFilter = null;
            }
            if (model.CategoryFilter.Equals("Any..."))
            {
                model.CategoryFilter = null;
            }
            return RedirectToAction("ListPublicCatImages", new { breedId = model.BreedFilter, categoryId = model.CategoryFilter, amount = model.AmountFilter });
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
        public async Task<IActionResult> ImageUpload()
        {
            return View(new UploadFileModel());
        }

        // POST: Image/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImageUpload(UploadFileModel model)
        {
            byte[] data;
            ByteArrayContent bytes;
            MultipartFormDataContent multiContent;
            if (model.ImageFile == null)
            {
                ViewBag.ErrorMessage = "Please upload a file";
                return View(model);
            }
            else
            {

                using (var br = new BinaryReader(model.ImageFile.OpenReadStream()))
                    data = br.ReadBytes((int)model.ImageFile.OpenReadStream().Length);

                bytes = new ByteArrayContent(data);


                multiContent = new MultipartFormDataContent();

                multiContent.Add(bytes, "file", model.ImageFile.FileName);
                HttpResponseMessage response = await _catClient.UploadImageAsync(multiContent);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Invalid format or content on file uploaded. {response.StatusCode} - {response.ReasonPhrase}";
                    return View(model);
                }

            }

            return RedirectToAction(nameof(ListUploadedCatImages));
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int id)
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