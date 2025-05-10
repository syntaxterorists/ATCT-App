using Microsoft.AspNetCore.Mvc;
using ATCT_Backend.Data;
using ATCT_Backend.Models;

namespace ATCT_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/User
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.Id)
                return BadRequest("ID mismatch");

            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
                return NotFound();

            // Ažuriraj potrebna polja
            existingUser.FullName = updatedUser.FullName;
            existingUser.Email = updatedUser.Email;
            // Dodaj i ostala polja ako ih imaš

            _context.Users.Update(existingUser);
            _context.SaveChanges();

            return Ok(existingUser);
        }
    }
}
