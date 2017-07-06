using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackathonBackend.Helpers;
using HackathonBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackathonBackend.Controllers
{
    [Route("api/[controller]")]
    public class SongsController : Controller
    {
        private readonly SeekseedsContext _context;

        public SongsController(SeekseedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Song> GetAll()
        {
            return _context.Songs
                .Include(x => x.Artist).ThenInclude(x => x.GeoCoordinate)
                .Include(x => x.Historics)
                .Include(x => x.StyleSongs).ThenInclude(x => x.Style)
                .ToList();
        }

        [HttpGet("Latitude/{latitude}/Longitude/{longitude}", Name = "GetNearSongs")]
        public IEnumerable<SongDistance> GetNearSongs(double latitude, double longitude)
        {
            var songsFromAmbassadors = _context.Historics
                .Include(x => x.User)
                .Include(x => x.Song).ThenInclude(x => x.Artist)
                .Where(x => x.LikeType == LikeType.Ambassador)
                .Select(x => new SongDistance
                {
                    Song = x.Song,
                    Distance = Math.Round(DistanceHelper.CalculateDistance(latitude, longitude, x.User.LastGeoCoordinate.Latitude, x.User.LastGeoCoordinate.Longitude), 1)
                })
                .ToList();

            var nearSongs = _context.Songs
                .Include(x => x.Artist).ThenInclude(x => x.GeoCoordinate)
                .Include(x => x.Historics)
                .Include(x => x.StyleSongs)
                .Select(x => new SongDistance
                {
                    Song = x,
                    Distance = Math.Round(DistanceHelper.CalculateDistance(latitude, longitude, x.Artist.GeoCoordinate.Latitude, x.Artist.GeoCoordinate.Longitude), 1)
                })
                .ToList();

            var result = nearSongs
                .Concat(songsFromAmbassadors)
                .OrderBy(x => x.Distance)
                .GroupBy(x => x.Song.ID)
                .Select(g => g.First())
                .ToList();

            return result;
        }

        [HttpGet("Latitude/{latitude}/Longitude/{longitude}/Style/{styleId}", Name = "GetNearSongsByStyle")]
        public IEnumerable<SongDistance> GetNearSongs(double latitude, double longitude, int styleId)
        {
            var songsFromAmbassadors = _context.Historics
                .Include(x => x.User)
                .Include(x => x.Song).ThenInclude(x => x.Artist)
                .Where(x => x.LikeType == LikeType.Ambassador && x.Song.StyleSongs.Any(y => y.StyleID == styleId))
                .Select(x => new SongDistance
                {
                    Song = x.Song,
                    Distance = Math.Round(DistanceHelper.CalculateDistance(latitude, longitude, x.User.LastGeoCoordinate.Latitude, x.User.LastGeoCoordinate.Longitude), 1)
                })
                .ToList();

            var nearSongs = _context.Songs
                .Include(x => x.Artist).ThenInclude(x => x.GeoCoordinate)
                .Include(x => x.Historics)
                .Include(x => x.StyleSongs)
                .Where(x => x.StyleSongs.Any(y => y.StyleID == styleId))
                .Select(x => new SongDistance
                {
                    Song = x,
                    Distance = Math.Round(DistanceHelper.CalculateDistance(latitude, longitude, x.Artist.GeoCoordinate.Latitude, x.Artist.GeoCoordinate.Longitude), 1)
                })
                .ToList();

            var result = nearSongs
                .Concat(songsFromAmbassadors)
                .OrderBy(x => x.Distance)
                .GroupBy(x => x.Song.ID)
                .Select(g => g.First())
                .ToList();

            return result;
        }

        [HttpGet("{id}", Name = "GetSong")]
        public IActionResult GetById(int id)
        {
            var item = _context.Songs
                .Include(x => x.Artist).ThenInclude(x => x.GeoCoordinate)
                .Include(x => x.Historics)
                .Include(x => x.StyleSongs).ThenInclude(x => x.Style)
                .FirstOrDefault(t => t.ID == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Song item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Songs.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetSong", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Song item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var song = _context.Songs.FirstOrDefault(t => t.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            song.Title = item.Title;

            _context.Songs.Update(song);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = _context.Songs.First(t => t.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
