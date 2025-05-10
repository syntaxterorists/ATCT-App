using Microsoft.AspNetCore.Mvc;
using ATCT_Backend.Data;
using ATCT_Backend.Models;

namespace ATCT2025.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpeakersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Speaker>> GetSpeakers()
        {
            return Ok(_context.Speakers.ToList());
        }

        [HttpPost]
        public ActionResult<Speaker> AddSpeaker(Speaker speaker)
        {
            _context.Speakers.Add(speaker);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSpeakers), new { id = speaker.Id }, speaker);
        }
    }
}
