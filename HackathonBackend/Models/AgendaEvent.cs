using System;
using System.Collections.Generic;

namespace HackathonBackend.Models
{
    public class AgendaEvent
    {
        public int ID { get; set; }
        public int GeoCoordinateID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

        public GeoCoordinate GeoCoordinate { get; set; }
        public ICollection<ArtistAgendaEvent> ArtistAgendaEvents { get; set; }
    }
}