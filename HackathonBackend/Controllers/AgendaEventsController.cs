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
    public class AgendaEventsController : Controller
    {
        private readonly SeekseedsContext _context;

        public AgendaEventsController(SeekseedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AgendaEvent> GetAll()
        {
            return _context.AgendaEvents
                .Include(x => x.GeoCoordinate)
                .Include(x => x.ArtistAgendaEvents)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetAgendaEvent")]
        public IActionResult GetById(int id)
        {
            var item = _context.AgendaEvents
                .Include(x => x.GeoCoordinate)
                .Include(x => x.ArtistAgendaEvents)
                .FirstOrDefault(t => t.ID == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AgendaEvent item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.AgendaEvents.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAgendaEvent", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AgendaEvent item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var agendaEvent = _context.AgendaEvents.FirstOrDefault(t => t.ID == id);
            if (agendaEvent == null)
            {
                return NotFound();
            }

            agendaEvent.Name = item.Name;

            _context.AgendaEvents.Update(agendaEvent);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var agendaEvent = _context.AgendaEvents.First(t => t.ID == id);
            if (agendaEvent == null)
            {
                return NotFound();
            }

            _context.AgendaEvents.Remove(agendaEvent);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
