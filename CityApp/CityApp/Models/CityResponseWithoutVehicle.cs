using System.ComponentModel.DataAnnotations;

namespace CityApp.Models
{
    public class CityResponseWithoutVehicle(string name, float population) : IEquatable<CityResponseWithoutVehicle?>
    {
        public string Name { get; set; } = name;

        public float Population { get; set; } = population;

        public override bool Equals(object? obj)
        {
            return obj is CityResponseWithoutVehicle vehicle &&
                   Name == vehicle.Name &&
                   Population == vehicle.Population;
        }

        public bool Equals(CityResponseWithoutVehicle? other)
        {
            return other is not null &&
                   Name == other.Name &&
                   Population == other.Population;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Population);
        }

        public static bool operator ==(CityResponseWithoutVehicle? left, CityResponseWithoutVehicle? right)
        {
            return EqualityComparer<CityResponseWithoutVehicle>.Default.Equals(left, right);
        }

        public static bool operator !=(CityResponseWithoutVehicle? left, CityResponseWithoutVehicle? right)
        {
            return !(left == right);
        }
    }
}
