using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrRefillCoreAPI.Models;

namespace MrRefillCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartridgeController : ControllerBase
    {
        List<CartridgeModelType> cartridgeList = null;

        private readonly DBMrRefillContext _context;

        private readonly IWebHostEnvironment _env;

        public CartridgeController(DBMrRefillContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Cartridge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartridgeModelType>>> GetCartridge()
        {
            cartridgeList = await (from c in _context.Cartridge
                                   join m in _context.Model
                                   on c.ModelId equals m.ModelId
                                   join t in _context.CartridgeType
                                   on c.TypeId equals t.TypeId
                                   select new CartridgeModelType
                                   {
                                       CartridgeId = c.CartridgeId,
                                       CartridgeName = c.CartridgeName,
                                       Price = c.Price,
                                       Description = c.Description,
                                       ImageUrl = c.ImageUrl,
                                       ModelId = c.ModelId,
                                       ModelName = m.ModelName,
                                       TypeId = c.TypeId,
                                       TypeName = t.TypeName,
                                       IsActive = c.IsActive,
                                       CreatedAt = c.CreatedAt,
                                       UpdatedAt = c.UpdatedAt
                                   }).ToListAsync<CartridgeModelType>();

            return cartridgeList;
        }

        // GET: api/Cartridge/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cartridge>> GetCartridge(int id)
        {
            var cartridge = await _context.Cartridge.FindAsync(id);

            if (cartridge == null)
            {
                return NotFound();
            }

            return cartridge;
        }

        // PUT: api/Cartridge/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartridge(int id, Cartridge cartridge)
        {
            if (id != cartridge.CartridgeId)
            {
                return BadRequest();
            }

            _context.Entry(cartridge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartridgeExists(id))
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

        // POST: api/Cartridge
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cartridge>> PostCartridge(Cartridge cartridge)
        {
            _context.Cartridge.Add(cartridge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartridge", new { id = cartridge.CartridgeId }, cartridge);
        }

        // DELETE: api/Cartridge/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cartridge>> DeleteCartridge(int id)
        {
            var cartridge = await _context.Cartridge.FindAsync(id);
            if (cartridge == null)
            {
                return NotFound();
            }

            _context.Cartridge.Remove(cartridge);
            await _context.SaveChangesAsync();

            return cartridge;
        }

        private bool CartridgeExists(int id)
        {
            return _context.Cartridge.Any(e => e.CartridgeId == id);
        }

        // GET: api/Cartridge/CartridgeByModelId/5
        [HttpGet("{CartridgeByModelId}/{id}")]
        public async Task<ActionResult<IEnumerable<Cartridge>>> GetCartridgeByModelId(int id)
        {
            List<Cartridge> _cartridges = await (from c in _context.Cartridge
                                                 join m in _context.Model
                                                 on c.ModelId equals m.ModelId
                                                 where c.ModelId == id
                                                 select new Cartridge
                                                 {
                                                     CartridgeId = c.CartridgeId,
                                                     CartridgeName = c.CartridgeName,
                                                     Description = c.Description,
                                                     ImageUrl = c.ImageUrl,
                                                     Price = c.Price,
                                                     TypeId = c.TypeId,
                                                     ModelId = m.ModelId,
                                                     IsActive = c.IsActive,
                                                     CreatedAt = c.CreatedAt,
                                                     UpdatedAt = c.UpdatedAt
                                                 }).ToListAsync<Cartridge>();

            return _cartridges;
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Images/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }
    }
}
