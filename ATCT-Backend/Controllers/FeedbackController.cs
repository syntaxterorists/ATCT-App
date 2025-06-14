using Microsoft.AspNetCore.Mvc;
using ATCT_Backend.Data;
using ATCT_Backend.Models;

namespace ATCT_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFeedback([FromBody] SessionFeedback feedback)
        {
            var sessionExists = _context.Sessions.Any(s => s.Id == feedback.SessionId);
            var userExists = _context.Users.Any(u => u.Id == feedback.UserId);

            if (!sessionExists || !userExists)
                return BadRequest("Korisnik ili sesija ne postoje.");

            feedback.SubmittedAt = DateTime.Now;
            _context.SessionFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return Ok("Hvala na feedbacku!");
        }

        [HttpGet("session/{sessionId}")]
        public IActionResult GetFeedbackForSession(int sessionId)
        {
            var feedbacks = _context.SessionFeedbacks
                .Where(f => f.SessionId == sessionId)
                .Select(f => new {
                    f.Rating,
                    f.Comment,
                    User = f.User!.FullName,
                    f.SubmittedAt
                })
                .ToList();

            return Ok(feedbacks);
        }

        [HttpGet("session/{sessionId}/average-rating")]
        public IActionResult GetAverageRating(int sessionId)
        {
            var ratings = _context.SessionFeedbacks
                .Where(f => f.SessionId == sessionId)
                .Select(f => f.Rating)
                .ToList();

            if (ratings.Count == 0)
                return Ok("Još nema recenzija.");

            var average = ratings.Average();
            return Ok($"Prosječna ocjena: {average:F2} / 5");
        }
    }
}
