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
    public class SalesDetailController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        public SalesDetailController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/SalesDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesDetails>>> GetSalesDetails()
        {
            return await _context.SalesDetails.ToListAsync();
        }

        // GET: api/SalesDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SalesDetailExtend>>> GetSalesDetails(int id)
        {

            List<SalesDetailExtend> _salesDetailExtends = null;
            
            _salesDetailExtends = await (from s in _context.SalesDetails
                                         join sales in _context.Sales
                                         on s.SalesId equals sales.SalesId
                                         join u in _context.User
                                         on sales.UserId equals u.UserId
                                         join prod in _context.ProductMaster
                                         on s.ProductId equals prod.ProductId
                                         where s.SalesId == id
                                         select new SalesDetailExtend
                                         {
                                             UserId = u.UserId,
                                             UserName = u.Name,
                                             CompanyName = u.CompanyName,
                                             Address = u.Address,
                                             Contact = u.Contact,
                                             EmailId = u.EmailId,
                                             ProductId = s.ProductId,
                                             Quantity = s.Quantity,
                                             ProductName = prod.ProductName,
                                             Price = prod.Price,
                                             SalesId = sales.SalesId,
                                             SalesDate = sales.SalesDate
                                         }
                                      ).ToListAsync<SalesDetailExtend>();

            return _salesDetailExtends;
        }

        // PUT: api/SalesDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesDetails(int id, SalesDetails salesDetails)
        {
            if (id != salesDetails.SalesId)
            {
                return BadRequest();
            }

            _context.Entry(salesDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesDetailsExists(id))
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

        // POST: api/SalesDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalesDetails>> PostSalesDetails(SalesDetails salesDetails)
        {
            _context.SalesDetails.Add(salesDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesDetailsExists(salesDetails.SalesId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesDetails", new { id = salesDetails.SalesId }, salesDetails);
        }

        // DELETE: api/SalesDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<SalesDetails>>> DeleteSalesDetails(int id)
        {
            List<SalesDetails> _salesDetails = null;

            _salesDetails = await (from s in _context.SalesDetails
                                      where s.SalesId == id
                                      select new SalesDetails
                                      {
                                          SalesId = s.SalesId,
                                          SalesPrice = s.SalesPrice,
                                          ProductId = s.ProductId,
                                          Quantity = s.Quantity,
                                          UpdatedAt = s.UpdatedAt,
                                          CreatedAt = s.CreatedAt
                                      }).ToListAsync<SalesDetails>();

            if (_salesDetails == null)
            {
                return NotFound();
            }

            _context.SalesDetails.RemoveRange(_salesDetails);
            await _context.SaveChangesAsync();

            return _salesDetails;
        }

        private bool SalesDetailsExists(int id)
        {
            return _context.SalesDetails.Any(e => e.SalesId == id);
        }
    }
}
