using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismBookingAPI.Data;
using TourismBookingAPI.Models;

namespace TourismBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ExercisesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Exercises.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _context.Exercises.FindAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(Exercise e)
        {
            _context.Exercises.Add(e);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = e.Id }, e);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Exercise e)
        {
            if (id != e.Id) return BadRequest();
            _context.Entry(e).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _context.Exercises.FindAsync(id);
            if (e == null) return NotFound();
            _context.Exercises.Remove(e);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}