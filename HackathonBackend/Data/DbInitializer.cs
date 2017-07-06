using System;
using System.Collections.Generic;
using HackathonBackend.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HackathonBackend.Data
{
    public class DbInitializer
    {
        public static void Initialize(SeekseedsContext context)
        {
            //context.Database.Migrate();
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var styles = new Style[]
            {
                new Style {Name = "Rock"},
                new Style {Name = "Jazz"},
                new Style {Name = "Punk"},
                new Style {Name = "Folk"},
                new Style {Name = "Metal"},
                new Style {Name = "Cover"},
                new Style {Name = "HipHop"},
                new Style {Name = "House"},
                new Style {Name = "Reggae"},
                new Style {Name = "World"}
            };
            foreach (var s in styles)
            {
                context.Styles.Add(s);
            }
            context.SaveChanges();



            var geoCoordinates = new GeoCoordinate[]
            {
                new GeoCoordinate {Latitude = 50.618770, Longitude = 5.556980, City = "Liège", CitySearch = "LIEGE"},
                new GeoCoordinate {Latitude = 50.583883, Longitude = 5.499630, City = "Seraing", CitySearch = "SERAING"},
                new GeoCoordinate {Latitude = 50.656940, Longitude = 5.528550, City = "Ans", CitySearch = "ANS"},
                new GeoCoordinate {Latitude = 50.424640, Longitude = 6.028328, City = "Malmedy", CitySearch = "MALMEDY"},
                new GeoCoordinate {Latitude = 50.638320, Longitude = 5.575885, City = "Liège", CitySearch = "LIEGE"},
                new GeoCoordinate {Latitude = 50.565641, Longitude = 5.723833, City = "Trooz", CitySearch = "TROOZ"},
                new GeoCoordinate {Latitude = 50.609240, Longitude = 5.536660, City = "Liège", CitySearch = "LIEGE"},
                new GeoCoordinate {Latitude = 50.590304, Longitude = 5.606921, City = "Chaudfontaine", CitySearch = "CHAUDFONTAINE"},
                new GeoCoordinate {Latitude = 50.645470, Longitude = 5.634880, City = "Liège", CitySearch = "LIEGE"},
                new GeoCoordinate {Latitude = 50.620590, Longitude = 5.686216, City = "Fléron", CitySearch = "FLERON"},
                new GeoCoordinate {Latitude = 50.623204, Longitude = 5.647077, City = "Beyne-Heusay", CitySearch = "BEYNEHEUSAY"},
                new GeoCoordinate {Latitude = 50.629203, Longitude = 6.033711, City = "Eupen", CitySearch = "EUPEN"},
                new GeoCoordinate {Latitude = 35.673540, Longitude = 139.569960, City = "Tokyo", CitySearch = "TOKYO"},
                new GeoCoordinate {Latitude = 19.404311, Longitude = -99.245260, City = "Mexico", CitySearch = "MEXICO"},
                new GeoCoordinate {Latitude = 50.651877, Longitude = 5.568298, City = "Liège", CitySearch = "LIEGE"},
                new GeoCoordinate {Latitude = 50.627903, Longitude = 5.567151, City = "Liège", CitySearch = "LIEGE"}
            };
            foreach (var gc in geoCoordinates)
            {
                context.GeoCoordinates.Add(gc);
            }
            context.SaveChanges();



            var artists = new Artist[]
            {
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.618770 && x.Longitude == 5.556980).ID,
                    Name = "Arcus",
                    PhotoUrl = "https://scontent.fbru1-1.fna.fbcdn.net/v/t1.0-1/c1.0.424.424/10418453_863253433716576_5732962819798875562_n.jpg?oh=25d9c423042a47b6f9b0941052fc584c&oe=5A0278D2",
                    FacebookUrl = "https://www.facebook.com/yokolelemusic/",
                    SoundCloudUrl = ""
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.583883 && x.Longitude == 5.499630).ID,
                    Name = "Yokolele",
                    PhotoUrl = "https://scontent.fbru1-1.fna.fbcdn.net/v/t1.0-1/p480x480/18157522_300793483684723_865777591785619445_n.jpg?oh=32aa33ee7fe62131fdecd22f20b11b7a&oe=5A0E323F",
                    FacebookUrl = "",
                    SoundCloudUrl = ""
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.656940 && x.Longitude == 5.528550).ID,
                    Name = "Tontonkief",
                    PhotoUrl = "https://yt3.ggpht.com/-SdHBHiUQP2k/AAAAAAAAAAI/AAAAAAAAAAA/fa21BNe0I5w/s88-c-k-no-mo-rj-c0xffffff/photo.jpg",
                    FacebookUrl = "",
                    SoundCloudUrl = "https://soundcloud.com/kevin-peters-445511882"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.424640 && x.Longitude == 6.028328).ID,
                    Name = "Kuwsi",
                    PhotoUrl = "https://i1.sndcdn.com/avatars-000313154813-4dp3ih-t500x500.jpg",
                    FacebookUrl = "",
                    SoundCloudUrl = "https://soundcloud.com/kuwsi/sets/2016-kuwsisel"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.638320 && x.Longitude == 5.575885).ID,
                    Name = "Kennedy's Bridge",
                    PhotoUrl = "https://scontent.fbru1-1.fna.fbcdn.net/v/t1.0-9/10537034_10152402593698495_5096346312980121023_n.jpg?oh=7a663a3c0f0ec5fecb985fc66314456c&oe=59D4A75C",
                    FacebookUrl = "https://www.facebook.com/kennedysbrigde/",
                    SoundCloudUrl = "https://soundcloud.com/kennedysbridge"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.565641 && x.Longitude == 5.723833).ID,
                    Name = "FDON",
                    PhotoUrl = "https://scontent.fbru1-1.fna.fbcdn.net/v/t1.0-1/c9.0.480.480/p480x480/13012711_1599619340359974_1434756275918429363_n.jpg?oh=fc69dfb7f294eeeeed97f6dd8769b252&oe=5A06CBF7",
                    FacebookUrl = "https://www.facebook.com/fdon.be/",
                    SoundCloudUrl = "https://soundcloud.com/fdonliege"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.609240 && x.Longitude == 5.536660).ID,
                    Name = "Toine Thys",
                    PhotoUrl = "",
                    FacebookUrl = "https://www.facebook.com/toine.thys/",
                    SoundCloudUrl = ""
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.590304 && x.Longitude == 5.606921).ID,
                    Name = "Peppergrains",
                    PhotoUrl = "https://scontent.fbru1-1.fna.fbcdn.net/v/t1.0-1/p480x480/16142451_1202648463157868_5649141152417201329_n.jpg?oh=788ff6d7e4519d298107f7b6b0556157&oe=5A018F67",
                    FacebookUrl = "https://www.facebook.com/Peppergrains/",
                    SoundCloudUrl = "https://soundcloud.com/peppergrainsofficial"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.645470 && x.Longitude == 5.634880).ID,
                    Name = "Matt Ray",
                    PhotoUrl = "",
                    FacebookUrl = "",
                    SoundCloudUrl = "https://soundcloud.com/philippe-matray"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.620590 && x.Longitude == 5.686216).ID,
                    Name = "D-Nite",
                    PhotoUrl = "https://scontent.fbru1-1.fna.fbcdn.net/v/t1.0-1/p480x480/15032798_10154894003425934_3985203443468931393_n.jpg?oh=2f26b5d5fd8353b39d35b4e5ca8aabc3&oe=5A01A6DA",
                    FacebookUrl = "https://www.facebook.com/compuphonicmax/",
                    SoundCloudUrl = "https://soundcloud.com/compuphonic-1"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.623204 && x.Longitude == 5.647077).ID,
                    Name = "Sandoo",
                    PhotoUrl = "https://scontent.fbru1-1.fna.fbcdn.net/v/t1.0-1/p480x480/1385212_495475797215145_14760639_n.jpg?oh=dc7a213eace5a1d32980ab8f75e5c65e&oe=59CABAB6",
                    FacebookUrl = "https://www.facebook.com/SANDOO-142205229208872/?pnref=lhc",
                    SoundCloudUrl = "https://soundcloud.com/sandoo-belgium"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.629203 && x.Longitude == 6.033711).ID,
                    Name = "Bong Of B",
                    PhotoUrl = "",
                    FacebookUrl = "",
                    SoundCloudUrl = "https://soundcloud.com/bongofb"
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 35.673540 && x.Longitude == 139.569960).ID,
                    Name = "Kikagaku Moyo",
                    PhotoUrl = "http://images.sk-static.com/images/media/profile_images/artists/6750884/huge_avatar",
                    FacebookUrl = "",
                    SoundCloudUrl = ""
                },
                new Artist
                {
                    GeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 19.404311 && x.Longitude == -99.245260).ID,
                    Name = "La Castañeda",
                    PhotoUrl = "http://cps-static.rovicorp.com/3/JPG_400/MI0001/415/MI0001415402.jpg?partner=allrovi.com",
                    FacebookUrl = "",
                    SoundCloudUrl = ""
                }
            };
            foreach (var a in artists)
            {
                context.Artists.Add(a);
            }
            context.SaveChanges();



            var songs = new Song[]
            {
                new Song
                {
                    ArtistID = 1,
                    Title = "Zombie",
                    Duration = new TimeSpan(0, 4, 17),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 1)
                },
                new Song
                {
                    ArtistID = 1,
                    Title = "Reflexe - animal",
                    Duration = new TimeSpan(0, 2, 19),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 1)
                },
                new Song
                {
                    ArtistID = 2,
                    Title = "Here comes the sun",
                    Duration = new TimeSpan(0, 3, 07),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 2)
                },
                new Song
                {
                    ArtistID = 2,
                    Title = "Johnny B Goode",
                    Duration = new TimeSpan(0, 2, 07),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 2)
                },
                new Song
                {
                    ArtistID = 3,
                    Title = "Beat It",
                    Duration = new TimeSpan(0, 2, 56),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 3)
                },
                new Song
                {
                    ArtistID = 3,
                    Title = "All of me",
                    Duration = new TimeSpan(0, 2, 25),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 3)
                },
                new Song
                {
                    ArtistID = 4,
                    Title = "NVR AGN",
                    Duration = new TimeSpan(0, 3, 14),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 4)
                },
                new Song
                {
                    ArtistID = 5,
                    Title = "Come Closer",
                    Duration = new TimeSpan(0, 3, 38),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 5)
                },
                new Song
                {
                    ArtistID = 6,
                    Title = "Corona Desert",
                    Duration = new TimeSpan(0, 3, 37),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 6)
                },
                new Song
                {
                    ArtistID = 7,
                    Title = "Osama",
                    Duration = new TimeSpan(0, 2, 24),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 7)
                },
                new Song
                {
                    ArtistID = 8,
                    Title = "Bounty Hunter",
                    Duration = new TimeSpan(0, 4, 29),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 8)
                },
                new Song
                {
                    ArtistID = 8,
                    Title = "Lost Lust",
                    Duration = new TimeSpan(0, 3, 10),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 8)
                },
                new Song
                {
                    ArtistID = 9,
                    Title = "Ellie",
                    Duration = new TimeSpan(0, 4, 28),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 9)
                },
                new Song
                {
                    ArtistID = 10,
                    Title = "Fresh Air",
                    Duration = new TimeSpan(0, 7, 12),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 10)
                },
                new Song
                {
                    ArtistID = 10,
                    Title = "L'après midi à la plage",
                    Duration = new TimeSpan(0, 5, 00),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 10)
                },
                new Song
                {
                    ArtistID = 11,
                    Title = "Face à la bière",
                    Duration = new TimeSpan(0, 6, 03),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 11)
                },
                new Song
                {
                    ArtistID = 12,
                    Title = "Hold Me",
                    Duration = new TimeSpan(0, 3, 36),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 12)
                },
                new Song
                {
                    ArtistID = 12,
                    Title = "Hidden",
                    Duration = new TimeSpan(0, 3, 31),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 12)
                },
                new Song
                {
                    ArtistID = 13,
                    Title = "Tree Smoke",
                    Duration = new TimeSpan(0, 6, 39),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 13)
                },
                new Song
                {
                    ArtistID = 14,
                    Title = "Cenit",
                    Duration = new TimeSpan(0, 4, 25),
                    Artist = context.Artists.FirstOrDefault(x => x.ID == 14)
                }
            };
            foreach (var s in songs)
            {
                context.Songs.Add(s);
            }
            context.SaveChanges();



            var users = new User[]
            {
                new User
                {
                    LastGeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.651877 && x.Longitude == 5.568298).ID,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@demo.be",
                    Username = "Demo",
                    Password = "Demo"
                },
                new User
                {
                    LastGeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.651877 && x.Longitude == 5.568298).ID,
                    FirstName = "Kenichi",
                    LastName = "Shinoda",
                    Email = "kenichi.shinoda@demo.be",
                    Username = "Kenichi",
                    Password = "Demo"
                },
                new User
                {
                    LastGeoCoordinateID = geoCoordinates.Single(x => x.Latitude == 50.627903 && x.Longitude == 5.567151).ID,
                    FirstName = "Joaquin Guzman",
                    LastName = "Loera",
                    Email = "joaquinguzman.loera@demo.be",
                    Username = "Joaquin",
                    Password = "Demo"
                }
            };
            foreach (var u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();



            var historics = new Historic[]
            {
                new Historic
                {
                    SongID = 19,
                    UserID = 2,
                    TimeStamp = DateTime.Now,
                    LikeType = LikeType.Ambassador
                },
                new Historic
                {
                    SongID = 20,
                    UserID = 3,
                    TimeStamp = DateTime.Now,
                    LikeType = LikeType.Ambassador
                }
            };
            foreach (var h in historics)
            {
                context.Historics.Add(h);
            }
            context.SaveChanges();
            


            var styleSongs = new StyleSong[]
            {
                new StyleSong
                {
                    SongID = 1,
                    StyleID = 1
                },
                new StyleSong
                {
                    SongID = 2,
                    StyleID = 1
                },
                new StyleSong
                {
                    SongID = 3,
                    StyleID = 6
                },
                new StyleSong
                {
                    SongID = 4,
                    StyleID = 6
                },
                new StyleSong
                {
                    SongID = 5,
                    StyleID = 6
                },
                new StyleSong
                {
                    SongID = 6,
                    StyleID = 2
                },
                new StyleSong
                {
                    SongID = 7,
                    StyleID = 7
                },
                new StyleSong
                {
                    SongID = 8,
                    StyleID = 1
                },
                new StyleSong
                {
                    SongID = 9,
                    StyleID = 5
                },
                new StyleSong
                {
                    SongID = 10,
                    StyleID = 8
                },
                new StyleSong
                {
                    SongID = 11,
                    StyleID = 1
                },
                new StyleSong
                {
                    SongID = 12,
                    StyleID = 1
                },
                new StyleSong
                {
                    SongID = 13,
                    StyleID = 7
                },
                new StyleSong
                {
                    SongID = 14,
                    StyleID = 8
                },
                new StyleSong
                {
                    SongID = 15,
                    StyleID = 8
                },
                new StyleSong
                {
                    SongID = 16,
                    StyleID = 6
                },
                new StyleSong
                {
                    SongID = 17,
                    StyleID = 7
                },
                new StyleSong
                {
                    SongID = 18,
                    StyleID = 7
                },
                new StyleSong
                {
                    SongID = 19,
                    StyleID = 1
                },
                new StyleSong
                {
                    SongID = 20,
                    StyleID = 1
                }
            };
            foreach (var ss in styleSongs)
            {
                context.StyleSongs.Add(ss);
            }
            context.SaveChanges();
        }
    }
}