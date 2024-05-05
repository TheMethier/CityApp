using AutoMapper;
using CityApp;
using CityApp.Entites;
using CityApp.Models;
using CityApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAppTests.Services
{
    public class CityServiceTests 
    {
        private IMapper _mapper;

        [SetUp] 
        public void SetUp() {


            var myProfile = new MapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }
 
        [Test]
        public void GetCity_ShouldThrowException_WhenTheGivenCityWhichDoesntBelongToDataContext()
        {
            //Arrange
            var context = new DataContext([new City("Wrocław", 600000)], [new Vehicle("tramp", 50000, 1000000)]);
            var cityService = new CityService(context, _mapper);
            string expected = "Not Found";
            //Act
            var actual = Assert.Throws<Exception>(() => cityService.GetCity(new CityRequest("m", 1000)));
            //Assert
            Assert.That(actual.Message, Is.EqualTo(expected));
        }
        [Test]
        public void GetCity_ShouldReturnExpectedData()
        {
            //Arrange
            var context = new DataContext([new City("Wrocław", 600000)], [
                new Vehicle("tramp", 500000, 700000),
                new Vehicle("bicycle", 1, 1000)]);
            var cityService = new CityService(context, _mapper);
            var city = new CityRequest("Wrocław", 600000);
            var expected = new CityResponseWithVehicle("Wrocław", 600000, "tramp");
            //Act
            var actual = cityService.GetCity(city);
            //Assert
            Assert.That(actual, Is.EqualTo(expected));
            
        }
        [Test]
        public void AddCity_ShouldReturnExpectedData()
        {
            //Arrange
            var context = new DataContext([], [
                new Vehicle("tramp", 500000, 700000),
                new Vehicle("bicycle", 1, 1000)]);
            var cityService = new CityService(context, _mapper);
            var city = new CityRequest("Wrocław", 600000);
            var expected = new CityResponseWithVehicle("Wrocław", 600000, "tramp");
            //Act
            var actual = cityService.AddCity(city);
            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void AddCity_ShouldUpdateCityList()
        {
            //Arrange
            var context = new DataContext([], [
                new Vehicle("tramp", 500000, 700000),
                new Vehicle("bicycle", 1, 1000)]);
            var cityService = new CityService(context, _mapper);
            var city = new CityRequest("Wrocław", 600000);
            var expectedCount = 1;
            //Act
            var actual = cityService.AddCity(city);
            //Assert
            Assert.That(context.Cities, Has.Count.EqualTo(expectedCount));

        }
        [Test]
        public void AddCity_ShouldUpdateCityDTOList()
        {
            //Arrange
            var context = new DataContext([], [
                new Vehicle("tramp", 500000, 700000),
                new Vehicle("bicycle", 1, 1000)]);
            var cityService = new CityService(context, _mapper);
            var city = new CityRequest("Wrocław", 600000);
            var expectedCount = 1;
            //Act
            var actual = cityService.AddCity(city);
            //Assert
            Assert.That(context.CitiesWithVehicles, Has.Count.EqualTo(expectedCount));
        }
        [Test]
        public void AddCity_ShouldReturnCityResponseWithNotSpecifiedVehicle_WhenTheGivenCityDoesntFitIntoAnyVehicle()
        {
            //Arrange
            var context = new DataContext([], [
                new Vehicle("tramp", 500000, 700000),
                new Vehicle("bicycle", 1, 1000)]);
            var cityService = new CityService(context, _mapper);
            var city = new CityRequest("Warszawa", 1100000);
            var expectedVehicle = "Not specified";
            //Act
            var actual = cityService.AddCity(city);
            //Assert
            Assert.That(actual.CommonVehicle, Is.EqualTo(expectedVehicle));
        }

        [Test]
        public void GetCitiesByVehicle_ShouldThrowNotFoundExecption_WhenTheGivenVehicleDoesntBelongToDataContext()
        {
            //Arrange
            var context = new DataContext([new City("Wrocław", 600000)], [new Vehicle("tramp", 500000, 700000)]);
            var cityService = new CityService(context, _mapper);
            var vehicle = new VehicleRequest("bike");
            string expected = "Not Found";
            //Act
            var actual = Assert.Throws<Exception>(() => cityService.GetCitiesByVehicle(vehicle));
            //Assert
            Assert.That(actual.Message, Is.EqualTo(expected));
        }
        [Test]
        public void GetCitiesByVehicle_ShouldReturnExpectedData()
        {
            //Arrange
            var context = new DataContext([new City("Wrocław", 600000)], [new Vehicle("tramp", 500000, 700000)]);
            var cityService = new CityService(context, _mapper);
            var vehicle = new VehicleRequest("tramp");
            List<CityResponseWithoutVehicle> expected = [new CityResponseWithoutVehicle("Wrocław", 600000)];
            //Act
            var actual = cityService.GetCitiesByVehicle(vehicle);
            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void GetRandomCity_ShouldThrowException_WhenCityListIsEmpty()
        {
            //Arrange
            var context = new DataContext([], [new Vehicle("tramp", 500000, 700000)]);
            var cityService = new CityService(context, _mapper);
            string expected = "Not Found";
            //Act
            var actual = Assert.Throws<Exception>(() => cityService.GetRandomCity());
            //Assert
            Assert.That(actual.Message, Is.EqualTo(expected));
        }
        [Test]
        public void GetRandomCity_ShouldReturnCity_FromCityList()
        {
            //Arrange
            var context = new DataContext([new City("Wrocław", 600000)], [new Vehicle("tramp", 500000, 700000)]);
            var cityService = new CityService(context, _mapper);
            //Act
            var city = cityService.GetRandomCity();
            //Assert
            Assert.That(context.Cities.Any(x => x.Name == city.CityName));
        }

    }
}
