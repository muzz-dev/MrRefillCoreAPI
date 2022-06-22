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
    public class UserListingController : ControllerBase
    {
        List<AllocatedRequest> allocatedRequests = null;

        private readonly DBMrRefillContext _context;
        public UserListingController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/UserListing/GetEmployeeList
        [HttpGet]
        [Route("{GetEmployeeList}")]
        public async Task<ActionResult<IEnumerable<User>>> GetEmployeeList()
        {
            List<User> userList = null;

            userList = await (from u in _context.User
                              where u.Type.Contains("Employee")
                              select new User
                              {
                                  UserId = u.UserId,
                                  Name = u.Name,
                                  Password = u.Password,
                                  AreaId = u.AreaId,
                                  Address = u.Address,
                                  Area = u.Area,
                                  AssignRequest = u.AssignRequest,
                                  CompanyName = u.CompanyName,
                                  Contact = u.Contact,
                                  EmailId = u.EmailId,
                                  GstNumber = u.GstNumber,
                                  Type = u.Type,
                                  Otp = u.Otp,
                                  RegisterBy = u.RegisterBy,
                                  IsVerify = u.IsVerify,
                                  IsBlock = u.IsBlock,
                                  CreatedAt = u.CreatedAt,
                                  UpdatedAt = u.UpdatedAt
                              }).ToListAsync<User>();
            return userList;
        }

        // GET: api/UserListing/List/GetUserList
        [HttpGet]
        [Route("{List}/{GetUserList}")]
        public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserList()
        {
            List<UserDetails> userList = null;

            userList = await (from u in _context.User 
                              join a in _context.Area
                              on u.AreaId equals a.AreaId
                              where u.Type.Contains("User")
                              select new UserDetails
                              {
                                  UserId = u.UserId,
                                  Name = u.Name,
                                  Password = u.Password,
                                  AreaId = u.AreaId,
                                  Address = u.Address,
                                  AreaName = a.AreaName,
                                  CompanyName = u.CompanyName,
                                  Contact = u.Contact,
                                  EmailId = u.EmailId,
                                  GstNumber = u.GstNumber,
                                  Type = u.Type,
                                  Otp = u.Otp,
                                  RegisterBy = u.RegisterBy,
                                  IsVerify = u.IsVerify,
                                  IsBlock = u.IsBlock,
                                  CreatedAt = u.CreatedAt,
                                  UpdatedAt = u.UpdatedAt
                              }).ToListAsync<UserDetails>();
            return userList;
        }
    }
}
