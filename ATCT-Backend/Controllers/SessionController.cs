using Microsoft.AspNetCore.Mvc;
using ATCT_Backend.Data;
using ATCT_Backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace ATCT2025.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionsController(AppDbContext context)
        {
            _context = context;
        }

        // Creating a session
        // POST: api/Sessions
        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, session);
        }

        // Get a session by ID
        // GET by ID
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
                return NotFound();

            return Ok(session);
        }

        // Updating a session
        // PUT: api/Sessions/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, [FromBody] Session updatedSession)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
                return NotFound();

            session.Title = updatedSession.Title;
            session.Description = updatedSession.Description;
            session.Speaker = updatedSession.Speaker;
            session.StartTime = updatedSession.StartTime;
            session.EndTime = updatedSession.EndTime;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Deleting a session
        // DELETE: api/Sessions/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
                return NotFound();

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
