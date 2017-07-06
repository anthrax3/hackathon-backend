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
    public class UsersController : Controller
    {
        private readonly SeekseedsContext _context;

        public UsersController(SeekseedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.Users
                .Include(x => x.LastGeoCoordinate)
                .Include(x => x.Historics)
                .ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(int id)
        {
            var item = _context.Users
                .Include(x => x.LastGeoCoordinate)
                .Include(x => x.Historics)
                .FirstOrDefault(t => t.ID == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("login/{username}/password/{password}", Name = "GetUserByName")]
        public IActionResult GetByName(string username, string password)
        {
            var item = _context.Users
                .Include(x => x.LastGeoCoordinate)
                .Include(x => x.Historics)
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Users.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var user = _context.Users.FirstOrDefault(t => t.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            //user.Name = item.Name;

            _context.Users.Update(user);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.First(t => t.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
