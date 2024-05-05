using CityApp.Entites;
using CityApp.Models;

namespace CityApp
{
    public class DataContext
    {
        public DataContext() {
            

            Cities = [ 
                new City("MałaWieś",100),
                new City("Pcim",5000),
                new City ("Kraków",800000),
                new City("Wrocław", 600000),
                new City("Warszawa",1800000)
            ];
            Vehicles = [
                new Vehicle("metro",1000000,3000000),
                new Vehicle("tramp",500000, 1000000),
                new Vehicle("bus", 10000,500000),
                new Vehicle("car", 1000, 10000),
                new Vehicle("bicycle", 1, 1000)
                
                ];
            CitiesWithVehicles = [];
            Cities.ForEach(x => UpdateCityDTOList(x));
        }
        public DataContext(List<City> cities, List<Vehicle> vehicles)
        {
            Cities = cities;
            Vehicles = vehicles;
            CitiesWithVehicles = [];
            Cities.ForEach(x => UpdateCityDTOList(x));
        }
        public List<City> Cities { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<CityDTO> CitiesWithVehicles { get; set; }
        public CityDTO UpdateCityDTOList(City city)
        {

            var mostPopularVehicle =Vehicles
                .FirstOrDefault(x =>x.MinPopulation<city.Population && x.MaxPopulation>city.Population)
                ?? new Vehicle("",-90000,-100);
            var cityToAdd = new CityDTO(city.Id, city.Name, city.Population, mostPopularVehicle.VehicleType);
            this.CitiesWithVehicles.Add(cityToAdd);
            return cityToAdd;
        }
    }
}
