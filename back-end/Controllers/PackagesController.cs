using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismBookingAPI.Data;
using TourismBookingAPI.Models;

namespace TourismBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PackagesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Packages.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _context.Packages.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Package p)
        {
            _context.Packages.Add(p);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = p.Id }, p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Package p)
        {
            if (id != p.Id) return BadRequest();
            _context.Entry(p).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _context.Packages.FindAsync(id);
            if (p == null) return NotFound();
            _context.Packages.Remove(p);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
