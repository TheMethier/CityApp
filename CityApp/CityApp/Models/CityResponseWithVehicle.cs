using Lombok.NET;

namespace CityApp.Models
{

    public class CityResponseWithVehicle : IEquatable<CityResponseWithVehicle?>
    {
        public CityResponseWithVehicle()
        {
            CityName = "";

            CommonVehicle = "";
        }

       

        public CityResponseWithVehicle(string cityName, int population, string vehicle)
        {
            CityName = cityName;
            Population = population;
            CommonVehicle = vehicle;
        }

        public string CityName { get; set; }
        public float Population { get; set; }    
        public string CommonVehicle { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CityResponseWithVehicle);
        }

        public bool Equals(CityResponseWithVehicle? other)
        {
            return other is not null &&
                   CityName == other.CityName &&
                   Population == other.Population &&
                   CommonVehicle == other.CommonVehicle;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CityName, Population, CommonVehicle);
        }

        public static bool operator ==(CityResponseWithVehicle? left, CityResponseWithVehicle? right)
        {
            return EqualityComparer<CityResponseWithVehicle>.Default.Equals(left, right);
        }

        public static bool operator !=(CityResponseWithVehicle? left, CityResponseWithVehicle? right)
        {
            return !(left == right);
        }
    }
}
