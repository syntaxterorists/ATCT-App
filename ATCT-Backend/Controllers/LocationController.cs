using Microsoft.AspNetCore.Mvc;
using ATCT_Backend.Data;
using ATCT_Backend.Models;

namespace ATCT2025.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocationsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
        }

        // GET by ID (helper for CreatedAtAction)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
                return NotFound();

            return Ok(location);
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] Location updatedLocation)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
                return NotFound();

            location.Name = updatedLocation.Name;
            location.Description = updatedLocation.Description;
            location.Address = updatedLocation.Address;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
                return NotFound();

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
