using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismBookingAPI.Data;
using TourismBookingAPI.Models;

namespace TourismBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public WorkoutsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Workouts.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _context.Workouts.FindAsync(id));

        [HttpGet("byPackage/{packageId}")]
        public async Task<IActionResult> GetByPackageId(int packageId) =>
            Ok(await _context.Workouts.Where(w => w.PackageId == packageId).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Workout w)
        {
            _context.Workouts.Add(w);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = w.Id }, w);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Workout w)
        {
            if (id != w.Id) return BadRequest();
            _context.Entry(w).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var w = await _context.Workouts.FindAsync(id);
            if (w == null) return NotFound();
            _context.Workouts.Remove(w);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}