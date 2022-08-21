using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantItemsController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public RestaurantItemsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantItem>>> GetRestaurantItems()
        {
          if (_context.RestaurantItems == null)
          {
              return NotFound();
          }
            return await _context.RestaurantItems.ToListAsync();
        }

        // GET: api/RestaurantItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantItem>> GetRestaurantItem(long id)
        {
          if (_context.RestaurantItems == null)
          {
              return NotFound();
          }
            var restaurantItem = await _context.RestaurantItems.FindAsync(id);

            if (restaurantItem == null)
            {
                return NotFound();
            }

            return restaurantItem;
        }

        // PUT: api/RestaurantItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantItem(long id, RestaurantItem restaurantItem)
        {
            if (id != restaurantItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantItemExists(id))
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

        // POST: api/RestaurantItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RestaurantItem>> PostRestaurantItem(RestaurantItem restaurantItem)
        {
          if (_context.RestaurantItems == null)
          {
              return Problem("Entity set 'RestaurantContext.RestaurantItems'  is null.");
          }
            _context.RestaurantItems.Add(restaurantItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRestaurantItem), new { id = restaurantItem.Id }, restaurantItem);
        }

        // DELETE: api/RestaurantItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantItem(long id)
        {
            if (_context.RestaurantItems == null)
            {
                return NotFound();
            }
            var restaurantItem = await _context.RestaurantItems.FindAsync(id);
            if (restaurantItem == null)
            {
                return NotFound();
            }

            _context.RestaurantItems.Remove(restaurantItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantItemExists(long id)
        {
            return (_context.RestaurantItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
