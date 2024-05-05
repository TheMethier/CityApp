using System.ComponentModel.DataAnnotations;

namespace CityApp.Models
{
    public class VehicleRequest
    {
        public VehicleRequest()
        {
            VehicleType = string.Empty;
        }

        public VehicleRequest(string vehicleType)
        {
            VehicleType = vehicleType;
        }

        [Required]
        [MinLength(2)]

        public string VehicleType {  get; set; }


    }
}
