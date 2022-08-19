using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookup.Models;

namespace ParksLookup.Controllers
{
  [Route("api/Parks")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    
    private readonly ParksLookupContext _db;

    public ParksController(ParksLookupContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get([FromQuery]string parkName, string stateName, string description)
    {
      var query = _db.Parks.AsQueryable();
      
      if (parkName != null)
      {
        query = query.Where(entry => entry.ParkName == parkName);
      }

      if (stateName != null)
      {
        query = query.Where(entry => entry.StateName == stateName);
      }        
      if( description != null)
      {
        query = query.Where(e => e.Description == description)
      }
      return await query.ToListAsync();
    }

    // GET: api/Parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        var park = await _db.Parks.FindAsync(id);

        if (park == null)
        {
            return NotFound();
        }

        return park;
    }

    // PUT: api/Parks/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Park
    [HttpPost]
    public async Task<ActionResult<Park>> Post([FromBody]Park park)
    {
      // DateTime date1 = DateTime.Now;
      // var longDateValue = date1.ToLongDateString();
      // park.PostDate = longDateValue;
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId}, park);
    }

    // DELETE: api/Parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    [HttpGet("random")]
    public async Task<IActionResult<Park>> GetRandom()
    {


      int randomId = random.Next(1,5);
      var park = await _db.Parks.FindAsync(randomId);
      return park;
    }
    
    
    
    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}
  

