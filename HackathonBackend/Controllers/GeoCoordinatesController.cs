using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackathonBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackathonBackend.Controllers
{
    [Route("api/[controller]")]
    public class GeoCoordinatesController : Controller
    {
        private readonly SeekseedsContext _context;

        public GeoCoordinatesController(SeekseedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<GeoCoordinate> GetAll()
        {
            return _context.GeoCoordinates
                .Include(x => x.Artists)
                .Include(x => x.AgendaEvents)
                .Include(x => x.Users)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetGeoCoordinate")]
        public IActionResult GetById(int id)
        {
            var item = _context.GeoCoordinates
                .Include(x => x.Artists)
                .Include(x => x.AgendaEvents)
                .Include(x => x.Users)
                .FirstOrDefault(t => t.ID == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] GeoCoordinate item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.GeoCoordinates.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetGeoCoordinate", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GeoCoordinate item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var geoCoordinate = _context.GeoCoordinates.FirstOrDefault(t => t.ID == id);
            if (geoCoordinate == null)
            {
                return NotFound();
            }

            geoCoordinate.Latitude = item.Latitude;
            geoCoordinate.Longitude = item.Longitude;

            _context.GeoCoordinates.Update(geoCoordinate);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var geoCoordinate = _context.GeoCoordinates.First(t => t.ID == id);
            if (geoCoordinate == null)
            {
                return NotFound();
            }

            _context.GeoCoordinates.Remove(geoCoordinate);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
