namespace HackathonBackend.Models
{
    public class ArtistAgendaEvent
    {
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public int AgendaEventID { get; set; }
        public AgendaEvent AgendaEvent { get; set; }
    }
}