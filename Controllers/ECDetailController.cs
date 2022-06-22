using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrRefillCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MrRefillCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECDetailController : ControllerBase
    {
        List<AllocatedRequest> allocatedRequests = null;

        private readonly DBMrRefillContext _context;
        public ECDetailController(DBMrRefillContext context)
        {
            _context = context;
        }


        // GET api/<ECDetailController>/5
        [HttpGet("{id}")]
        [Route("{ExchangeDetail}/{Detail}/{id}")]
        public async Task<ActionResult<AllocatedRequest>> GetExchangeCartridgeDetail(int id)
        {
            AllocatedRequest exchangeRequest = null;
            exchangeRequest = await (from e in _context.ExchangeCartridge
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
                                     where e.ExchangeId == id
                                     select new AllocatedRequest
                                     {
                                         ExchangeId = e.ExchangeId,
                                         UserId = u.UserId,
                                         UserName = u.Name,
                                         AssignId = Assign.AssignId,
                                         Amount = p.Price,
                                         employeeContactNumber = Assign.User.Contact,
                                         userContactNumber = u.Contact,
                                         CartridgeId = c.CartridgeId,
                                         CartridgeName = c.CartridgeName,
                                         EmployeeId = Assign.User.UserId,
                                         EmployeeName = Assign.User.Name,
                                         Address = e.Address,
                                         AreaId = a.AreaId,
                                         IsPay = Assign.IsPay,
                                         PaymentMode = Assign.PaymentMode,
                                         Datetime = Assign.Datetime,
                                         AreaName = a.AreaName,
                                         Remark = p.ProblemName,
                                         ProblemId = p.ProblemId,
                                         Status = Assign.Status,
                                         RequestDate = e.RequestDate,
                                         CreatedAt = e.CreatedAt,
                                         UpdatedAt = e.UpdatedAt
                                     }).FirstOrDefaultAsync<AllocatedRequest>();

            if (exchangeRequest == null)
            {
                return NotFound();
            }

            return exchangeRequest;
        }

        // GET: api/ECDetail/MyRequests/5
        [HttpGet("{userId}")]
        [Route("{MyRequests}/{userId}")]
        public async Task<ActionResult<IEnumerable<AllocatedRequest>>> GetMyRequests(int userId)
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
                                       where e.UserId == userId
                                       select new AllocatedRequest
                                       {
                                           ExchangeId = e.ExchangeId,
                                           UserId = u.UserId,
                                           UserName = u.Name,
                                           AssignId = Assign.AssignId,
                                           Amount = p.Price,
                                           employeeContactNumber = Assign.User.Contact,
                                           userContactNumber = e.User.Contact,
                                           EmployeeId = Assign.User.UserId,
                                           EmployeeName = Assign.User.Name,
                                           CartridgeId = c.CartridgeId,
                                           CartridgeName = c.CartridgeName,
                                           Address = e.Address,
                                           AreaId = a.AreaId,
                                           AreaName = a.AreaName,
                                           Remark = p.ProblemName,
                                           RequestDate = e.RequestDate,
                                           Status = Assign.Status,
                                           CreatedAt = e.CreatedAt,
                                           UpdatedAt = e.UpdatedAt
                                       })
                                       .ToListAsync<AllocatedRequest>();


            if (allocatedRequests == null)
            {
                return NotFound();
            }

            return allocatedRequests;
        }

        // GET api/ECDetail/Employee/PreviousRequest/AllRequest/5
        [HttpGet("{employeeId}")]
        [Route("{Employee}/{PreviousRequest}/{AllRequest}/{employeeId}")]
        public async Task<ActionResult<IEnumerable<AllocatedRequest>>> GetEmployeePreviousRequest(int employeeId)
        {
            allocatedRequests = await (from ass in _context.AssignRequest
                                       join e in _context.ExchangeCartridge
                                       on ass.ExchangeId equals e.ExchangeId
                                       join p in _context.Problem
                                     on e.ProblemId equals p.ProblemId
                                       join c in _context.Cartridge
                                       on e.CartridgeId equals c.CartridgeId
                                       join u in _context.User
                                       on ass.UserId equals u.UserId
                                       where ass.UserId == employeeId
                                       select new AllocatedRequest
                                       {
                                           ExchangeId = ass.Exchange.ExchangeId,
                                           UserId = e.UserId,
                                           UserName = e.User.Name,
                                           AssignId = ass.AssignId,
                                           Amount = p.Price,
                                           employeeContactNumber = ass.User.Contact,
                                           userContactNumber = u.Contact,
                                           CartridgeId = c.CartridgeId,
                                           CartridgeName = c.CartridgeName,
                                           EmployeeId = ass.User.UserId,
                                           EmployeeName = ass.User.Name,
                                           Address = ass.Exchange.Address,
                                           Remark = p.ProblemName,
                                           Status = ass.Status,
                                           RequestDate = ass.Exchange.RequestDate,
                                           CreatedAt = ass.Exchange.CreatedAt,
                                           UpdatedAt = ass.Exchange.UpdatedAt
                                       }).ToListAsync<AllocatedRequest>();

            if (allocatedRequests == null)
            {
                return NotFound();
            }

            return allocatedRequests;
        }

    }
}
