using System.Collections.Generic;

namespace HackathonBackend.Models
{
    public class User
    {
        public int ID { get; set; }
        public int LastGeoCoordinateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public GeoCoordinate LastGeoCoordinate { get; set; }
        public ICollection<Historic> Historics { get; set; }
    }
}