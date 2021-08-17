
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatWebApp.Models
{
    public class ImageViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("categories")]
        public List<CategoryViewModel> Categories {get; set;}

        [JsonProperty("breeds")]
        public List<BreedViewModel> Breeds { get; set; }
    }
}
