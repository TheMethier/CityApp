using CityApp.Entites;
using CityApp.Models;

namespace CityApp.Services
{
    public interface ICityService
    {
        CityResponseWithVehicle GetCity(CityRequest cityDTO);
        CityResponseWithVehicle GetRandomCity();
        List<CityResponseWithoutVehicle> GetCitiesByVehicle(VehicleRequest vehicleRequest);
        CityResponseWithVehicle AddCity(CityRequest city);




    }
}
