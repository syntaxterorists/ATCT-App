using Microsoft.AspNetCore.Mvc;
using ATCT_Backend.Data;
using ATCT_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {
            var session = await _context.Sessions
        .Include(s => s.Speaker) // učitava povezani entitet
        .FirstOrDefaultAsync(s => s.Id == id);
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

        [HttpPost("{sessionId}/register/{userId}")]
        public async Task<IActionResult> RegisterUserToSession(int sessionId, int userId)
        {
            var session = await _context.Sessions.FindAsync(sessionId);
            if (session == null)
                return NotFound("Sesija nije pronađena.");

            if (session.CurrentAttendees >= session.MaxAttendees)
                return BadRequest("Sesija je popunjena.");

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return NotFound("Korisnik nije pronađen.");

            // Provjera da li je već registrovan
            bool alreadyRegistered = _context.UserSessions.Any(us => us.SessionId == sessionId && us.UserId == userId);
            if (alreadyRegistered)
                return BadRequest("Korisnik je već prijavljen na ovu sesiju.");

            session.CurrentAttendees += 1;

            var userSession = new UserSession
            {
                SessionId = sessionId,
                UserId = userId
            };

            _context.UserSessions.Add(userSession);
            await _context.SaveChangesAsync();

            return Ok("Uspješno ste prijavljeni na sesiju.");
        }

    }
}
