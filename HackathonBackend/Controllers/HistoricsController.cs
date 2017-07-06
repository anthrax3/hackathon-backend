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
    public class HistoricsController : Controller
    {
        private readonly SeekseedsContext _context;

        public HistoricsController(SeekseedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Historic> GetAll()
        {
            return _context.Historics
                .Include(x => x.Song)
                .Include(x => x.User)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetHistoric")]
        public IActionResult GetById(int id)
        {
            var item = _context.Historics
                .Include(x => x.Song)
                .Include(x => x.User)
                .FirstOrDefault(t => t.ID == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Historic item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            // get last create
            var lastCreate = _context.Historics
                .FirstOrDefault(x => x.SongID == item.SongID &&
                                     x.UserID == item.UserID);

            if (lastCreate != null)
            {
                Delete(lastCreate.ID);
            }

            _context.Historics.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetHistoric", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Historic item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var historic = _context.Historics.FirstOrDefault(t => t.ID == id);
            if (historic == null)
            {
                return NotFound();
            }

            historic.TimeStamp = item.TimeStamp;

            _context.Historics.Update(historic);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var historic = _context.Historics.First(t => t.ID == id);
            if (historic == null)
            {
                return NotFound();
            }

            _context.Historics.Remove(historic);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
