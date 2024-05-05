using System.ComponentModel.DataAnnotations;

namespace CityApp.Models
{
    public class CityRequest
    {
        public CityRequest()
        {
            Name = string.Empty;
          
        }

        public CityRequest(string name, float population)
        {
            Name = name;
            Population = population;
        }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [Range(0, float.MaxValue)]
        public float Population { get; set; }
    }
}
