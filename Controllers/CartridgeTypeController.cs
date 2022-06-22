using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrRefillCoreAPI.Models;

namespace MrRefillCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartridgeTypeController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        public CartridgeTypeController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/CartridgeType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartridgeType>>> GetCartridgeType()
        {
            return await _context.CartridgeType.ToListAsync();
        }

        // GET: api/CartridgeType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartridgeType>> GetCartridgeType(int id)
        {
            var cartridgeType = await _context.CartridgeType.FindAsync(id);

            if (cartridgeType == null)
            {
                return NotFound();
            }

            return cartridgeType;
        }

        // PUT: api/CartridgeType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartridgeType(int id, CartridgeType cartridgeType)
        {
            if (id != cartridgeType.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(cartridgeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartridgeTypeExists(id))
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

        // POST: api/CartridgeType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CartridgeType>> PostCartridgeType(CartridgeType cartridgeType)
        {
            _context.CartridgeType.Add(cartridgeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartridgeType", new { id = cartridgeType.TypeId }, cartridgeType);
        }

        // DELETE: api/CartridgeType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartridgeType>> DeleteCartridgeType(int id)
        {
            var cartridgeType = await _context.CartridgeType.FindAsync(id);
            if (cartridgeType == null)
            {
                return NotFound();
            }

            _context.CartridgeType.Remove(cartridgeType);
            await _context.SaveChangesAsync();

            return cartridgeType;
        }

        private bool CartridgeTypeExists(int id)
        {
            return _context.CartridgeType.Any(e => e.TypeId == id);
        }
    }
}
