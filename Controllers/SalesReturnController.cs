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
    public class SalesReturnController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        public SalesReturnController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/SalesReturn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesReturnExtend>>> GetSalesReturn()
        {
            List<SalesReturnExtend> _salesReturnExtends = null;

            _salesReturnExtends = await (from s in _context.SalesReturn
                                         join u in _context.User
                                         on s.Sales.UserId equals u.UserId
                                         select new SalesReturnExtend
                                         {
                                             SalesReturnId = s.SalesReturnId,
                                             SalesId = s.SalesId,
                                             UserName = u.Name,
                                             ProductId = s.ProductId,
                                             Remark = s.Remark,
                                             Quantity = s.Quantity,
                                             ReturnAmount = s.ReturnAmount,
                                             CreatedAt = s.CreatedAt,
                                             UpdatedAt = s.UpdatedAt
                                         }).ToListAsync<SalesReturnExtend>();

            return _salesReturnExtends;
        }

        // GET: api/SalesReturn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesReturnExtend>> GetSalesReturn(int id)
        {
            SalesReturnExtend _salesReturnExtends = null;
            _salesReturnExtends = await (from s in _context.SalesReturn
                                         join u in _context.User
                                         on s.Sales.UserId equals u.UserId
                                         select new SalesReturnExtend
                                         {
                                             SalesReturnId = s.SalesReturnId,
                                             SalesId = s.SalesId,
                                             UserName = u.Name,
                                             Address = u.Address,
                                             Contact = u.Contact,
                                             Email = u.EmailId,
                                             ProductName = s.Product.ProductName,
                                             ReturnDate = s.CreatedAt,
                                             SalesDate = s.Sales.SalesDate,
                                             ProductId = s.ProductId,
                                             Remark = s.Remark,
                                             Quantity = s.Quantity,
                                             ReturnAmount = s.ReturnAmount,
                                             CreatedAt = s.CreatedAt,
                                             UpdatedAt = s.UpdatedAt
                                         }).FirstOrDefaultAsync<SalesReturnExtend>();

            return _salesReturnExtends;
        }

        // PUT: api/SalesReturn/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesReturn(int id, SalesReturn salesReturn)
        {
            if (id != salesReturn.SalesReturnId)
            {
                return BadRequest();
            }

            _context.Entry(salesReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesReturnExists(id))
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

        // POST: api/SalesReturn
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalesReturn>> PostSalesReturn(SalesReturn salesReturn)
        {
            _context.SalesReturn.Add(salesReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesReturn", new { id = salesReturn.SalesReturnId }, salesReturn);
        }

        // DELETE: api/SalesReturn/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesReturn>> DeleteSalesReturn(int id)
        {
            var salesReturn = await _context.SalesReturn.FindAsync(id);
            if (salesReturn == null)
            {
                return NotFound();
            }

            _context.SalesReturn.Remove(salesReturn);
            await _context.SaveChangesAsync();

            return salesReturn;
        }

        private bool SalesReturnExists(int id)
        {
            return _context.SalesReturn.Any(e => e.SalesReturnId == id);
        }
    }
}
