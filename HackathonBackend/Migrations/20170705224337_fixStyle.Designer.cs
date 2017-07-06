using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HackathonBackend.Models;

namespace HackathonBackend.Migrations
{
    [DbContext(typeof(SeekseedsContext))]
    [Migration("20170705224337_fixStyle")]
    partial class fixStyle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HackathonBackend.Models.AgendaEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GeoCoordinateID");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("GeoCoordinateID");

                    b.ToTable("AgendaEvent");
                });

            modelBuilder.Entity("HackathonBackend.Models.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<string>("FacebookUrl");

                    b.Property<int>("GeoCoordinateID");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoUrl");

                    b.Property<string>("SoundCloudUrl");

                    b.HasKey("ID");

                    b.HasIndex("GeoCoordinateID");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("HackathonBackend.Models.ArtistAgendaEvent", b =>
                {
                    b.Property<int>("ArtistID");

                    b.Property<int>("AgendaEventID");

                    b.HasKey("ArtistID", "AgendaEventID");

                    b.HasIndex("AgendaEventID");

                    b.ToTable("ArtistAgendaEvent");
                });

            modelBuilder.Entity("HackathonBackend.Models.GeoCoordinate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("ID");

                    b.ToTable("GeoCoordinate");
                });

            modelBuilder.Entity("HackathonBackend.Models.Historic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GeoCoordinateID");

                    b.Property<int>("LikeType");

                    b.Property<int>("SongID");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("GeoCoordinateID");

                    b.HasIndex("SongID");

                    b.HasIndex("UserID");

                    b.ToTable("Historic");
                });

            modelBuilder.Entity("HackathonBackend.Models.Song", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistID");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("HackathonBackend.Models.Style", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Style");
                });

            modelBuilder.Entity("HackathonBackend.Models.StyleSong", b =>
                {
                    b.Property<int>("StyleID");

                    b.Property<int>("SongID");

                    b.HasKey("StyleID", "SongID");

                    b.HasIndex("SongID");

                    b.ToTable("StyleSong");
                });

            modelBuilder.Entity("HackathonBackend.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("GeoCoordinateID");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.HasIndex("GeoCoordinateID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HackathonBackend.Models.AgendaEvent", b =>
                {
                    b.HasOne("HackathonBackend.Models.GeoCoordinate", "GeoCoordinate")
                        .WithMany("AgendaEvents")
                        .HasForeignKey("GeoCoordinateID");
                });

            modelBuilder.Entity("HackathonBackend.Models.Artist", b =>
                {
                    b.HasOne("HackathonBackend.Models.GeoCoordinate", "GeoCoordinate")
                        .WithMany("Artists")
                        .HasForeignKey("GeoCoordinateID");
                });

            modelBuilder.Entity("HackathonBackend.Models.ArtistAgendaEvent", b =>
                {
                    b.HasOne("HackathonBackend.Models.AgendaEvent", "AgendaEvent")
                        .WithMany("ArtistAgendaEvents")
                        .HasForeignKey("AgendaEventID");

                    b.HasOne("HackathonBackend.Models.Artist", "Artist")
                        .WithMany("ArtistAgendaEvents")
                        .HasForeignKey("ArtistID");
                });

            modelBuilder.Entity("HackathonBackend.Models.Historic", b =>
                {
                    b.HasOne("HackathonBackend.Models.GeoCoordinate", "GeoCoordinate")
                        .WithMany("Historics")
                        .HasForeignKey("GeoCoordinateID");

                    b.HasOne("HackathonBackend.Models.Song", "Song")
                        .WithMany("Historics")
                        .HasForeignKey("SongID");

                    b.HasOne("HackathonBackend.Models.User", "User")
                        .WithMany("Historics")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("HackathonBackend.Models.Song", b =>
                {
                    b.HasOne("HackathonBackend.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistID");
                });

            modelBuilder.Entity("HackathonBackend.Models.StyleSong", b =>
                {
                    b.HasOne("HackathonBackend.Models.Song", "Song")
                        .WithMany("StyleSongs")
                        .HasForeignKey("SongID");

                    b.HasOne("HackathonBackend.Models.Style", "Style")
                        .WithMany("StyleSongs")
                        .HasForeignKey("StyleID");
                });

            modelBuilder.Entity("HackathonBackend.Models.User", b =>
                {
                    b.HasOne("HackathonBackend.Models.GeoCoordinate", "GeoCoordinate")
                        .WithMany("Users")
                        .HasForeignKey("GeoCoordinateID");
                });
        }
    }
}
