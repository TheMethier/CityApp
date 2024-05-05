using CityApp;
using CityApp.Entites;
using CityApp.Models;
using CityApp.Services;

namespace CityAppTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void UpdateCityDTO_ShouldReturnExpectedData()
        {
            //Arrange
            var dataContext = new DataContext([], [new Vehicle("tramp",500000,700000), new Vehicle("bike",1,1000)]);
            var city = new City("Wroc³aw", 600000);
            var expected = new CityDTO(city.Id, "Wroc³aw", 600000, "tramp");
            //Act
            var actual = dataContext.UpdateCityDTOList(city);
            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void UpdateCityDTO_ShouldReturnData_WhenCityPopulationIsInRangeDescribedByVehicle()
        {
            //Arrange
            var dataContext = new DataContext([], [new Vehicle("tramp", 500000, 700000), new Vehicle("bike", 1, 1000)]);
            var city = new City("Wroc³aw", 600000);
            var expectedVehicle = new Vehicle("tramp", 500000, 700000);
            //Act
            var actual = dataContext.UpdateCityDTOList(city);
            //Assert
            Assert.That(actual.Population, Is.InRange(expectedVehicle.MinPopulation,expectedVehicle.MaxPopulation));
        }
        [Test]
        public void UpdateCityDTO_ShouldReturnData_WhenCityDTOHasExpectedCommonVehicle()
        {
            //Arrange
            var dataContext = new DataContext([], [new Vehicle("tramp", 500000, 700000), new Vehicle("bike", 1, 1000)]);
            var city = new City("Wroc³aw", 600000);
            var expectedVehicle = new Vehicle("tramp", 500000, 700000);
            //Act
            var actual = dataContext.UpdateCityDTOList(city);
            //Assert
            Assert.That(actual.CommonVehicle, Is.EqualTo(expectedVehicle.VehicleType));
        }
        [Test]
        public void UpdateCityDTO_ShouldReturnCityDTOWithEmptyString_WhenDoesNotFoundCommonVehicleForCity()
        {
            //Arrange
            var dataContext = new DataContext([], [new Vehicle("tramp", 500000, 700000), new Vehicle("bike", 1, 1000)]);
            var city = new City("Rawicz", 20000);
            string expectedCommonVehilce = "";
            //Act
            var actual = dataContext.UpdateCityDTOList(city);
            //Assert
            Assert.That(actual.CommonVehicle, Is.EqualTo(expectedCommonVehilce));

        }
    }
}