using System.Runtime.InteropServices;

namespace CityApp.Entites
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Population { get; set; }

        public  City (string name, float population)
        {
            Id = Guid.NewGuid();
            Name = name;
            Population = population; 
        }
        
    }
}
