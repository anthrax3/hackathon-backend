using System.Collections.Generic;

namespace HackathonBackend.Models
{
    public class Style
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<StyleSong> StyleSongs { get; set; }
    }
}