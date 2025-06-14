using Microsoft.AspNetCore.Mvc;
using ATCT_Backend.Data;
using ATCT_Backend.Models;

namespace ATCT_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CheckInController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CheckInUser([FromQuery] int userId, [FromQuery] int sessionId)
        {
            var user = await _context.Users.FindAsync(userId);
            var session = await _context.Sessions.FindAsync(sessionId);

            if (user == null || session == null)
                return NotFound("Korisnik ili sesija nije pronađena.");

            var alreadyCheckedIn = _context.CheckInRecords.Any(c => c.UserId == userId && c.SessionId == sessionId);
            if (alreadyCheckedIn)
                return BadRequest("Korisnik je već evidentiran za ovu sesiju.");

            var record = new CheckInRecord
            {
                UserId = userId,
                SessionId = sessionId,
                CheckInTime = DateTime.Now
            };

            _context.CheckInRecords.Add(record);
            await _context.SaveChangesAsync();

            return Ok("Dolazak evidentiran.");
        }
    }
}
