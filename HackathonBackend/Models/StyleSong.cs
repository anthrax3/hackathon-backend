namespace HackathonBackend.Models
{
    public class StyleSong
    {
        public int StyleID { get; set; }
        public Style Style { get; set; }
        public int SongID { get; set; }
        public Song Song { get; set; }
    }
}