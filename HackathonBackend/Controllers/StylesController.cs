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
    public class StylesController : Controller
    {
        private readonly SeekseedsContext _context;

        public StylesController(SeekseedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Style> GetAll()
        {
            return _context.Styles
                .Include(x => x.StyleSongs)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetStyle")]
        public IActionResult GetById(int id)
        {
            var item = _context.Styles
                .Include(x => x.StyleSongs).ThenInclude(x => x.Song)
                .FirstOrDefault(t => t.ID == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Style item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Styles.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetStyle", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Style item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var style = _context.Styles.FirstOrDefault(t => t.ID == id);
            if (style == null)
            {
                return NotFound();
            }

            style.Name = item.Name;

            _context.Styles.Update(style);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var style = _context.Styles.First(t => t.ID == id);
            if (style == null)
            {
                return NotFound();
            }

            _context.Styles.Remove(style);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
