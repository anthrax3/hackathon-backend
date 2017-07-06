using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HackathonBackend.Models
{
    public class SeekseedsContext : DbContext
    {
        public SeekseedsContext(DbContextOptions<SeekseedsContext> options)
            : base(options)
        {
        }

        public DbSet<AgendaEvent> AgendaEvents { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<GeoCoordinate> GeoCoordinates { get; set; }
        public DbSet<Historic> Historics { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ArtistAgendaEvent> ArtistAgendaEvents { get; set; }
        public DbSet<StyleSong> StyleSongs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AgendaEvent>().ToTable("AgendaEvent");
            modelBuilder.Entity<Artist>().ToTable("Artist");
            modelBuilder.Entity<GeoCoordinate>().ToTable("GeoCoordinate");
            modelBuilder.Entity<Historic>().ToTable("Historic");
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<Style>().ToTable("Style");
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<ArtistAgendaEvent>().ToTable("ArtistAgendaEvent");
            modelBuilder.Entity<StyleSong>().ToTable("StyleSong");

            modelBuilder.Entity<ArtistAgendaEvent>()
                .HasKey(aae => new {aae.ArtistID, aae.AgendaEventID});
            modelBuilder.Entity<StyleSong>()
                .HasKey(aae => new {aae.StyleID, aae.SongID});

            //modelBuilder.Entity<ArtistAgendaEvent>()
            //    .HasKey(aae => new {aae.ArtistID, aae.AgendaEventID});

            //modelBuilder.Entity<ArtistAgendaEvent>()
            //    .HasOne(aae => aae.Artist)
            //    .WithMany(a => a.ArtistAgendaEvents)
            //    .HasForeignKey(aae => aae.ArtistID);

            //modelBuilder.Entity<ArtistAgendaEvent>()
            //    .HasOne(aae => aae.AgendaEvent)
            //    .WithMany(ae => ae.ArtistAgendaEvents)
            //    .HasForeignKey(aae => aae.AgendaEventID);

            //modelBuilder.Entity<StyleSong>()
            //    .HasKey(ss => new {ss.StyleID, ss.SongID});

            //modelBuilder.Entity<StyleSong>()
            //    .HasOne(ss => ss.Style)
            //    .WithMany(s => s.StyleSongs)
            //    .HasForeignKey(ss => ss.StyleID);

            //modelBuilder.Entity<StyleSong>()
            //    .HasOne(ss => ss.Song)
            //    .WithMany(s => s.StyleSongs)
            //    .HasForeignKey(ss => ss.SongID);
        }
    }
}