using AutoMapper;
using CityApp.Entites;
using CityApp.Models;

namespace CityApp.Services
{
    public class CityService(DataContext dataContext, IMapper mapper) : ICityService
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly IMapper _mapper = mapper;

        public CityResponseWithVehicle GetCity(CityRequest city)
        {
            var cityFromCityDTO = _dataContext
                .CitiesWithVehicles
                .Find(x => x.Name == city.Name) ?? throw new Exception("Not Found");
            CityResponseWithVehicle response = _mapper.Map<CityResponseWithVehicle>(cityFromCityDTO);
            return response;
        }
        public CityResponseWithVehicle AddCity(CityRequest city)
        {
            var cityToAdd = new City(city.Name, city.Population);
            var cityDTO = _dataContext.UpdateCityDTOList(cityToAdd);
            _dataContext.Cities.Add(cityToAdd); 
            var response = _mapper.Map<CityResponseWithVehicle>(cityDTO);
            return response;
        }
        public CityResponseWithVehicle GetRandomCity()
        {
            var random = new Random();
            var city = _dataContext.CitiesWithVehicles.Count != 0 ? 
                _dataContext.CitiesWithVehicles[random.Next(_dataContext.CitiesWithVehicles.Count)] :
                throw new Exception("Not Found");
            var response = _mapper.Map<CityResponseWithVehicle>(city);
            return response;

        }
        public List<CityResponseWithoutVehicle> GetCitiesByVehicle(VehicleRequest vehicleRequest)
        {
            List<CityDTO> cityDTOList = _dataContext
                .CitiesWithVehicles
                .Where(x => x.CommonVehicle == vehicleRequest.VehicleType)
                .ToList();
            if (cityDTOList.Count == 0)
                throw new Exception("Not Found");
            List<CityResponseWithoutVehicle> cities = _mapper.Map<List<CityResponseWithoutVehicle>>(cityDTOList);
            return cities;
        }


    }
}
