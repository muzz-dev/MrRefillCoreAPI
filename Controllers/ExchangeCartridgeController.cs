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
    public class ExchangeCartridgeController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        List<AllocatedRequest> allocatedRequests = null;

        public ExchangeCartridgeController(DBMrRefillContext context)
        {
            _context = context;
        }


        //Get All Exchange Cartridge with Employee Details
        // GET: api/ExchangeCartridge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllocatedRequest>>> GetExchangeCartridge()
        {
            allocatedRequests = await (from e in _context.ExchangeCartridge
                                       join u in _context.User
                                       on e.UserId equals u.UserId
                                       join p in _context.Problem
                                        on e.ProblemId equals p.ProblemId
                                       join c in _context.Cartridge
                                       on e.CartridgeId equals c.CartridgeId
                                       join a in _context.Area
                                       on e.AreaId equals a.AreaId
                                       join ass in _context.AssignRequest
                                      on e.ExchangeId equals ass.ExchangeId
                                      into AllocatedRequest
                                       from Assign in AllocatedRequest.DefaultIfEmpty()
                                       select new AllocatedRequest
                                       {
                                           ExchangeId = e.ExchangeId,
                                           UserId = u.UserId,
                                           AssignId = Assign.AssignId,
                                           UserName = u.Name,
                                           CartridgeId = c.CartridgeId,
                                           CartridgeName = c.CartridgeName,
                                           Address = e.Address,
                                           AreaId = a.AreaId,
                                           AreaName = a.AreaName,
                                           Remark = p.ProblemName,
                                           ProblemId = e.ProblemId,
                                           RequestDate = e.RequestDate,
                                           Status = e.Status,
                                           IsComplete = Assign.Status,
                                           CreatedAt = e.CreatedAt,
                                           UpdatedAt = e.UpdatedAt
                                       }).ToListAsync<AllocatedRequest>();
            return allocatedRequests;
        }

        // GET: api/ExchangeCartridge/AllocatedRequestDetail/5
        [HttpGet("{AllocatedRequestDetail}/{id}")]
        public async Task<ActionResult<AllocatedRequest>> GetExchangeCartridge(int id)
        {
            AllocatedRequest allocatedRequest = null;
            allocatedRequest = await (from e in _context.ExchangeCartridge
                                      join u in _context.User
                                      on e.UserId equals u.UserId
                                      join p in _context.Problem
                                     on e.ProblemId equals p.ProblemId
                                      join c in _context.Cartridge
                                      on e.CartridgeId equals c.CartridgeId
                                      join a in _context.Area
                                      on e.AreaId equals a.AreaId
                                      join ass in _context.AssignRequest
                                      on e.ExchangeId equals ass.ExchangeId
                                      into AllocatedRequest
                                      from Assign in AllocatedRequest.DefaultIfEmpty()
                                      where e.ExchangeId == id
                                      select new AllocatedRequest
                                      {
                                          ExchangeId = e.ExchangeId,
                                          AssignId = Assign.AssignId,
                                          UserId = u.UserId,
                                          UserName = u.Name,
                                          EmployeeId = Assign.UserId,
                                          EmployeeName = Assign.User.Name,
                                          userContactNumber = u.Contact,
                                          employeeContactNumber = Assign.User.Contact,
                                          CartridgeId = c.CartridgeId,
                                          CartridgeName = c.CartridgeName,
                                          Address = e.Address,
                                          AreaId = a.AreaId,
                                          AreaName = a.AreaName,
                                          Remark = p.ProblemName,
                                          ProblemId = p.ProblemId,
                                          Amount = p.Price,
                                          Datetime = Assign.Datetime,
                                          PaymentMode = Assign.PaymentMode,
                                          RequestDate = e.RequestDate,
                                          Status = Assign.Status,
                                          CreatedAt = e.CreatedAt,
                                          UpdatedAt = e.UpdatedAt
                                      }).FirstOrDefaultAsync<AllocatedRequest>();

            if (allocatedRequest == null)
            {
                return NotFound();
            }

            return allocatedRequest;
        }

        // GET: api/ExchangeCartridge/AllocatedRequest/5
        [HttpGet("{id}")]
        [Route("{AllocatedRequest}/{id}")]
        public async Task<ActionResult<IEnumerable<AllocatedRequest>>> GetAllocatedExchangeCartridge(int id)
        {

            allocatedRequests = await (from e in _context.ExchangeCartridge
                                       join u in _context.User
                                       on e.UserId equals u.UserId
                                       join c in _context.Cartridge
                                       on e.CartridgeId equals c.CartridgeId
                                       join a in _context.Area
                                       on e.AreaId equals a.AreaId
                                       join p in _context.Problem
                                     on e.ProblemId equals p.ProblemId
                                       join ass in _context.AssignRequest
                                       on e.ExchangeId equals ass.ExchangeId
                                       into AllocatedRequest
                                       from Assign in AllocatedRequest.DefaultIfEmpty()
                                       where Assign.UserId == id
                                       where Assign.Status.Contains("pending")
                                       select new AllocatedRequest
                                       {
                                           ExchangeId = e.ExchangeId,
                                           UserId = u.UserId,
                                           UserName = u.Name,
                                           AssignId = Assign.AssignId,
                                           Amount = p.Price,
                                           employeeContactNumber = Assign.User.Contact,
                                           CartridgeId = c.CartridgeId,
                                           CartridgeName = c.CartridgeName,
                                           EmployeeId = Assign.User.UserId,
                                           EmployeeName = Assign.User.Name,
                                           Address = e.Address,
                                           AreaId = a.AreaId,
                                           AreaName = a.AreaName,
                                           Remark = p.ProblemName,
                                           RequestDate = e.RequestDate,
                                           Status = Assign.Status,
                                           CreatedAt = e.CreatedAt,
                                           UpdatedAt = e.UpdatedAt
                                       }).ToListAsync<AllocatedRequest>();


            if (allocatedRequests == null)
            {
                return NotFound();
            }

            return allocatedRequests;
        }

        // PUT: api/ExchangeCartridge/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExchangeCartridge(int id, ExchangeCartridge exchangeCartridge)
        {
            if (id != exchangeCartridge.ExchangeId)
            {
                return BadRequest();
            }

            _context.Entry(exchangeCartridge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeCartridgeExists(id))
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

        // POST: api/ExchangeCartridge
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExchangeCartridge>> PostExchangeCartridge(ExchangeCartridge exchangeCartridge)
        {
            _context.ExchangeCartridge.Add(exchangeCartridge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExchangeCartridge", new { id = exchangeCartridge.ExchangeId }, exchangeCartridge);
        }

        // DELETE: api/ExchangeCartridge/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExchangeCartridge>> DeleteExchangeCartridge(int id)
        {
            var exchangeCartridge = await _context.ExchangeCartridge.FindAsync(id);
            if (exchangeCartridge == null)
            {
                return NotFound();
            }

            _context.ExchangeCartridge.Remove(exchangeCartridge);
            await _context.SaveChangesAsync();

            return exchangeCartridge;
        }

        private bool ExchangeCartridgeExists(int id)
        {
            return _context.ExchangeCartridge.Any(e => e.ExchangeId == id);
        }
    }
}
