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
    public class PurchaseReturnController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        public PurchaseReturnController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseReturn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseReturnExtend>>> GetPurchaseReturn()
        {
            List<PurchaseReturnExtend> _purchaseReturnList = null;

            _purchaseReturnList = await (from pr in _context.PurchaseReturn
                                         join u in _context.User
                                         on pr.Purchase.UserId equals u.UserId
                                         select new PurchaseReturnExtend
                                         {
                                             PurchaseReturnId = pr.PurchaseReturnId,
                                             PurchaseId = pr.PurchaseId,
                                             ProductId = pr.ProductId,
                                             Quantity = pr.Quantity,
                                             UserName = u.Name,
                                             ReturnAmount = pr.ReturnAmount,
                                             Remark = pr.Remark,
                                             CreatedAt = pr.CreatedAt,
                                             UpdatedAt = pr.UpdatedAt
                                         }).ToListAsync<PurchaseReturnExtend>();


            return _purchaseReturnList;
        }

        // GET: api/PurchaseReturn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseReturnExtend>> GetPurchaseReturn(int id)
        {
            PurchaseReturnExtend purchaseReturn = null;


            purchaseReturn = await (from pr in _context.PurchaseReturn
                                    join u in _context.User
                                    on pr.Purchase.UserId equals u.UserId
                                    select new PurchaseReturnExtend
                                    {
                                        PurchaseReturnId = pr.PurchaseReturnId,
                                        PurchaseId = pr.PurchaseId,
                                        ProductId = pr.ProductId,
                                        Quantity = pr.Quantity,
                                        UserName = u.Name,
                                        Contact = u.Contact,
                                        Address = u.Address,
                                        Email = u.EmailId,
                                        ReturnDate = pr.CreatedAt,
                                        PurchaseDate = pr.Purchase.PurchaseDate,
                                        ProductName = pr.Product.ProductName,
                                        ReturnAmount = pr.ReturnAmount,
                                        Remark = pr.Remark,
                                        CreatedAt = pr.CreatedAt,
                                        UpdatedAt = pr.UpdatedAt
                                    }).FirstOrDefaultAsync<PurchaseReturnExtend>();


            return purchaseReturn;
        }

        // PUT: api/PurchaseReturn/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseReturn(int id, PurchaseReturn purchaseReturn)
        {
            if (id != purchaseReturn.PurchaseReturnId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseReturnExists(id))
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

        // POST: api/PurchaseReturn
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseReturn>> PostPurchaseReturn(PurchaseReturn purchaseReturn)
        {
            _context.PurchaseReturn.Add(purchaseReturn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseReturn", new { id = purchaseReturn.PurchaseReturnId }, purchaseReturn);
        }

        // DELETE: api/PurchaseReturn/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseReturn>> DeletePurchaseReturn(int id)
        {
            var purchaseReturn = await _context.PurchaseReturn.FindAsync(id);
            if (purchaseReturn == null)
            {
                return NotFound();
            }

            _context.PurchaseReturn.Remove(purchaseReturn);
            await _context.SaveChangesAsync();

            return purchaseReturn;
        }

        private bool PurchaseReturnExists(int id)
        {
            return _context.PurchaseReturn.Any(e => e.PurchaseReturnId == id);
        }
    }
}
