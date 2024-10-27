using diarioOnlineAPI.Data;
using diarioOnlineAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;

namespace diarioOnlineAPI.Controller { 
[Route("api/[controller]")]
[ApiController]
public class DiaryEntryController : ControllerBase
{
    private readonly AppDbContext _context;

    public DiaryEntryController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/diaryentry
    [HttpGet]
    public async Task<ActionResult<List<DiaryEntries>>> GetDiaryEntries()
    {
        return await _context.DiaryEntries.ToListAsync();
    }

        // POST: api/diaryentry
        [HttpPost]
        public async Task<ActionResult<DiaryEntries>> CreateDiaryEntry([FromBody] DiaryEntries entry)
        {
            if (entry == null)
            {
                Console.WriteLine("La entrada es nula.");
                return BadRequest("Entrada no puede ser nula.");
            }

            Console.WriteLine($"Entrada recibida: {JsonSerializer.Serialize(entry)}");

            entry.CreatedAt = DateTime.UtcNow;
            _context.DiaryEntries.Add(entry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDiaryEntries), new { id = entry.Id }, entry);
        }
        // DELETE: diaryentry/{id}
        [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDiaryEntry(int id)
    {
        var entry = await _context.DiaryEntries.FindAsync(id);
        if (entry == null)
        {
            return NotFound();
        }

        _context.DiaryEntries.Remove(entry);
        await _context.SaveChangesAsync();

        return NoContent(); // Devuelve un estado 204 sin contenido
    }
}
}