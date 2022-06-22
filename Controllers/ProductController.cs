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
    public class ProductController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        private readonly IWebHostEnvironment _env;

        public ProductController(DBMrRefillContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductExtend>>> GetProductMaster()
        {
            List<ProductExtend> _productList = await (from p in _context.ProductMaster
                                                      join c in _context.Category
                                                      on p.CategoryId equals c.CategoryId
                                                      select new ProductExtend
                                                      {
                                                          ProductId = p.ProductId,
                                                          ProductName = p.ProductName,
                                                          CategoryId = p.CategoryId,
                                                          CategoryName = c.CategoryName,
                                                          Description = p.Description,
                                                          ImageUrl = p.ImageUrl,
                                                          Price = p.Price,
                                                          IsActive = p.IsActive,
                                                          CreatedAt = p.CreatedAt,
                                                          UpdatedAt = p.UpdatedAt
                                                      }).ToListAsync<ProductExtend>();
            return _productList;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMaster>> GetProductMaster(int id)
        {
            var productMaster = await _context.ProductMaster.FindAsync(id);

            if (productMaster == null)
            {
                return NotFound();
            }

            return productMaster;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMaster(int id, ProductMaster productMaster)
        {
            if (id != productMaster.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMasterExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductMaster>> PostProductMaster(ProductMaster productMaster)
        {
            _context.ProductMaster.Add(productMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductMaster", new { id = productMaster.ProductId }, productMaster);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductMaster>> DeleteProductMaster(int id)
        {
            var productMaster = await _context.ProductMaster.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            _context.ProductMaster.Remove(productMaster);
            await _context.SaveChangesAsync();

            return productMaster;
        }

        private bool ProductMasterExists(int id)
        {
            return _context.ProductMaster.Any(e => e.ProductId == id);
        }

        [Route("ProductFile")]
        [HttpPost]
        public JsonResult ProductFile()
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
