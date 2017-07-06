using System.Collections.Generic;

namespace HackathonBackend.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public int GeoCoordinateID { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string PhotoUrl { get; set; }
        public string SoundCloudUrl { get; set; }
        public string FacebookUrl { get; set; }

        public GeoCoordinate GeoCoordinate { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<ArtistAgendaEvent> ArtistAgendaEvents { get; set; }
    }
}