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
    public class ArtistsController : Controller
    {
        private readonly SeekseedsContext _context;

        public ArtistsController(SeekseedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists
                .Include(x => x.GeoCoordinate)
                .Include(x => x.Songs)
                .Include(x => x.ArtistAgendaEvents)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetArtist")]
        public IActionResult GetById(int id)
        {
            var item = _context.Artists
                .Include(x => x.GeoCoordinate)
                .Include(x => x.Songs)
                .Include(x => x.ArtistAgendaEvents)
                .FirstOrDefault(t => t.ID == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //[HttpGet("Latitude/{latitude}/Longitude/{longitude}", Name = "GetNearArtists")]
        //public IEnumerable<ArtistDistance> GetNearArtists(double latitude, double longitude)
        //{
        //    var artistsFromAmbassadors = _context.Historics
        //        .Include(x => x.User)
        //        .Include(x => x.Song).ThenInclude(x => x.Artist)
        //        .Where(x => x.LikeType == LikeType.Ambassador)
        //        .Select(x => new ArtistDistance
        //        {
        //            Artist = x.Song.Artist,
        //            Distance = Math.Round(DistanceHelper.CalculateDistance(latitude, longitude, x.User.LastGeoCoordinate.Latitude, x.User.LastGeoCoordinate.Longitude), 1)
        //        })
        //        .ToList();

        //    var nearArtists = _context.Artists
        //        .Include(x => x.GeoCoordinate)
        //        .Include(x => x.Songs)
        //        .Include(x => x.ArtistAgendaEvents)
        //        .Select(x => new ArtistDistance
        //        {
        //            Artist = x,
        //            Distance = Math.Round(DistanceHelper.CalculateDistance(latitude, longitude, x.GeoCoordinate.Latitude, x.GeoCoordinate.Longitude), 1)
        //        })
        //        .ToList();

        //    return nearArtists
        //        .Concat(artistsFromAmbassadors)
        //        .OrderBy(x => x.Distance)
        //        //.Take(5)
        //        .ToList();
        //}

        [HttpPost]
        public IActionResult Create([FromBody] Artist item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Artists.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetArtist", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Artist item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var artist = _context.Artists.FirstOrDefault(t => t.ID == id);
            if (artist == null)
            {
                return NotFound();
            }

            artist.Name = item.Name;

            _context.Artists.Update(artist);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var artist = _context.Artists.First(t => t.ID == id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
