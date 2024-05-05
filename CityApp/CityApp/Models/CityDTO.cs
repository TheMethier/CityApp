using Lombok.NET;
using System.Runtime.InteropServices;

namespace CityApp.Models
{

    public class CityDTO : IEquatable<CityDTO?>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Population { get; set; }
        public string CommonVehicle { get; set; }

        public CityDTO() {
            Name = string.Empty;
            CommonVehicle = string.Empty;
        }
        public CityDTO(Guid id, string name, float population, string vehicle)
        {
            Id = id;
            Name = name;
            Population = population;
            CommonVehicle = vehicle;
        }
        public CityDTO(Guid id, string name, float population)
        {
            Id = id;
            Name = name;
            Population = population;
            CommonVehicle= string.Empty;
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as CityDTO);
        }

        public bool Equals(CityDTO? other)
        {
            return other is not null &&
                   Id.Equals(other.Id) &&
                   Name == other.Name &&
                   Population == other.Population &&
                   CommonVehicle == other.CommonVehicle;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Population, CommonVehicle);
        }

        public static bool operator ==(CityDTO? left, CityDTO? right)
        {
            return EqualityComparer<CityDTO>.Default.Equals(left, right);
        }

        public static bool operator !=(CityDTO? left, CityDTO? right)
        {
            return !(left == right);
        }
    }
}
