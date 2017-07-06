using System.Collections.Generic;

namespace HackathonBackend.Models
{
    public class GeoCoordinate
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string CitySearch { get; set; }

        public ICollection<Artist> Artists { get; set; }
        public ICollection<AgendaEvent> AgendaEvents { get; set; }
        public ICollection<User> Users { get; set; }
    }
}