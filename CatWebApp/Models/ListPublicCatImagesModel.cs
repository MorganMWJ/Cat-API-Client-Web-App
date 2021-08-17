using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatWebApp.Models
{
    public class ListPublicCatImagesModel
    {
        public List<ImageViewModel> CatImages { get; set; }

        public string BreedFilter { get; set; }

        public int? CategoryFilter { get; set; }

        public int AmountFilter { get; set; }
    }
}
