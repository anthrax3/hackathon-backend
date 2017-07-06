using System;

namespace HackathonBackend.Models
{
    public class Historic
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public int UserID { get; set; }
        public DateTime TimeStamp { get; set; }
        public LikeType LikeType { get; set; }

        public Song Song { get; set; }
        public User User { get; set; }
    }
}