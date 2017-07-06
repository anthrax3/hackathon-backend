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
    public class StyleSongsController : Controller
    {
        private readonly SeekseedsContext _context;

        public StyleSongsController(SeekseedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<StyleSong> GetAll()
        {
            return _context.StyleSongs
                .Include(x => x.Style)
                .Include(x => x.Song)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetStyleSong")]
        public IActionResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Style item)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Style item)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
