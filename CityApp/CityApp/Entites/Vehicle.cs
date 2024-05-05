namespace CityApp.Entites
{
    public class Vehicle
    {
        public Vehicle()
        {
            VehicleType = string.Empty;

        }

        public Vehicle(string vehicleType, float minPopulation, float maxPopulation)
        {
            VehicleType = vehicleType;
            MinPopulation = minPopulation;
            MaxPopulation = maxPopulation;
        }

        public string VehicleType { get; set; }
        public float MinPopulation { get; set; }
        public float MaxPopulation { get; set; }

    }
}
