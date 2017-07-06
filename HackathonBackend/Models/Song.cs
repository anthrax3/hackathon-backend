using System;
using System.Collections.Generic;
using System.Linq;

namespace HackathonBackend.Models
{
    public class Song
    {
        public int ID { get; set; }
        public int ArtistID { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }

        public Artist Artist { get; set; }

        public ICollection<Historic> Historics { get; set; }
        public ICollection<StyleSong> StyleSongs { get; set; }

        public string SongUrl
            => $"http://hackathonbackend20170705065408.azurewebsites.net/songs/{ID}.mp3";

        public int Score
        {
            get
            {
                if (Historics == null)
                {
                    return 0;
                }

                return (Historics.Count(x => x.LikeType == LikeType.Ambassador) * 5) +
                       (Historics.Count(x => x.LikeType == LikeType.Like));
            }
        }
    }
}