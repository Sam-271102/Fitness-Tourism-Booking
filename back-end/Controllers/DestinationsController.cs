using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismBookingAPI.Data;
using TourismBookingAPI.Models;

namespace TourismBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DestinationsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Destinations.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _context.Destinations.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Destination dest)
        {
            _context.Destinations.Add(dest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = dest.Id }, dest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Destination dest)
        {
            if (id != dest.Id) return BadRequest();
            _context.Entry(dest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dest = await _context.Destinations.FindAsync(id);
            if (dest == null) return NotFound();
            _context.Destinations.Remove(dest);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
