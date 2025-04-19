using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismBookingAPI.Data;
using TourismBookingAPI.Models;

namespace TourismBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookingsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Bookings.Include(b => b.Package).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _context.Bookings.Include(b => b.Package).FirstOrDefaultAsync(b => b.Id == id));

        [HttpGet("byCustomer/{name}")]
        public async Task<IActionResult> GetByCustomer(string name) =>
            Ok(await _context.Bookings
                .Where(b => b.CustomerName.Contains(name))
                .Include(b => b.Package)
                .ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Booking b)
        {
            b.BookingDate = DateTime.UtcNow;
            _context.Bookings.Add(b);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = b.Id }, b);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Booking b)
        {
            if (id != b.Id) return BadRequest();
            _context.Entry(b).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var b = await _context.Bookings.FindAsync(id);
            if (b == null) return NotFound();
            _context.Bookings.Remove(b);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}