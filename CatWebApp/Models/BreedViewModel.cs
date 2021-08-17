using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatWebApp.Models
{
    public class BreedViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("temperament")]
        public string Temperament { get; set; }

        [JsonProperty("life_span")]
        public string LifeSpan { get; set; }

        [JsonProperty("alt_names")]
        public string AlternativeNames { get; set; }

        [JsonProperty("wikipedia_url")]
        public string WikipediaLink { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("weight_imperial")]
        public string Weight { get; set; }

        [JsonProperty("hairless")]
        public bool Hairless { get; set; }

        [JsonProperty("natural")]
        public bool Natural { get; set; }

        [JsonProperty("short_legs")]
        public bool ShortLegs { get; set; }

        [JsonProperty("hypoallergenic")]
        public bool Hypoallergenic { get; set; }

        [JsonProperty("adaptability")]
        public int Adaptability { get; set; }

        [JsonProperty("affection_level")]
        public int AffectionLevel { get; set; }

        [JsonProperty("child_friendly")]
        public int ChildFriendly { get; set; }

        [JsonProperty("dog_friendly")]
        public int DogFriendly { get; set; }

        [JsonProperty("energy_level")]
        public int EnergyLevel { get; set; }

        [JsonProperty("grooming")]
        public int Grooming { get; set; }

        [JsonProperty("health_issues")]
        public int HealthIssues { get; set; }

        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty("shedding_level")]
        public int SheddingLevel { get; set; }

        [JsonProperty("social_needs")]
        public int SocialNeeds { get; set; }

        [JsonProperty("stranger_friendly")]
        public int StrangerFriendly { get; set; }

        [JsonProperty("vocalisation")]
        public int Vocalisation { get; set; }
    }
}
