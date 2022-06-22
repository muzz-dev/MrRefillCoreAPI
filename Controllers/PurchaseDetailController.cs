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
    public class PurchaseDetailController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        public PurchaseDetailController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDetails>>> GetPurchaseDetails()
        {
            return await _context.PurchaseDetails.ToListAsync();
        }

        // GET: api/PurchaseDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PurchaseDetailExtend>>> GetPurchaseDetails(int id)
        {
            List<PurchaseDetailExtend> _purchaseDetails = null;

            _purchaseDetails = await (from p in _context.PurchaseDetails
                                      join pur in _context.Purchase
                                      on p.PurchaseId equals pur.PurchaseId
                                      join u in _context.User
                                      on pur.UserId equals u.UserId
                                      join prod in _context.ProductMaster
                                      on p.ProductId equals prod.ProductId
                                      where p.PurchaseId == id
                                      select new PurchaseDetailExtend
                                      {
                                          UserId = u.UserId,
                                          UserName = u.Name,
                                          CompanyName = u.CompanyName,
                                          Address = u.Address,
                                          Contact = u.Contact,
                                          EmailId = u.EmailId,
                                          PurchaseDate = pur.PurchaseDate,
                                          PurchaseId = p.PurchaseId,
                                          ProductId = p.ProductId,
                                          Quantity = p.Quantity,
                                          ProductName = prod.ProductName,
                                          Price = prod.Price
                                      }
                                      ).ToListAsync<PurchaseDetailExtend>();

            return _purchaseDetails;
        }

        // PUT: api/PurchaseDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseDetails(int id, PurchaseDetails purchaseDetails)
        {
            if (id != purchaseDetails.PurchaseId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseDetailsExists(id))
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

        // POST: api/PurchaseDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseDetails>> PostPurchaseDetails(PurchaseDetails purchaseDetails)
        {
            _context.PurchaseDetails.Add(purchaseDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseDetailsExists(purchaseDetails.PurchaseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseDetails", new { id = purchaseDetails.PurchaseId }, purchaseDetails);
        }

        // DELETE: api/PurchaseDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<PurchaseDetails>>> DeletePurchaseDetails(int id)
        {
            List<PurchaseDetails> _purchaseDetails = null;

            _purchaseDetails = await (from p in _context.PurchaseDetails
                                      where p.PurchaseId == id
                                      select new PurchaseDetails
                                      {
                                          PurchaseId = p.PurchaseId,
                                          BuyPrice = p.BuyPrice,
                                          ProductId = p.ProductId,
                                          Quantity = p.Quantity,
                                          UpdatedAt = p.UpdatedAt,
                                          CreatedAt = p.CreatedAt
                                      }).ToListAsync<PurchaseDetails>();

            if (_purchaseDetails == null)
            {
                return NotFound();
            }

            _context.PurchaseDetails.RemoveRange(_purchaseDetails);
            await _context.SaveChangesAsync();

            return _purchaseDetails;
        }

        private bool PurchaseDetailsExists(int id)
        {
            return _context.PurchaseDetails.Any(e => e.PurchaseId == id);
        }

        
    }
}
