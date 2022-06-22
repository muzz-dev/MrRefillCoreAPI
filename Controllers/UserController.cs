using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MrRefillCoreAPI.Models;

namespace MrRefillCoreAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        public UserController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetails>> GetUser(int id)
        {

            var user = await (from u in _context.User
                              join a in _context.Area
                              on u.AreaId equals a.AreaId
                              where u.UserId == id
                              select new UserDetails
                              {
                                  UserId = u.UserId,
                                  Name = u.Name,
                                  AreaId = a.AreaId,
                                  Address = u.Address,
                                  AreaName = a.AreaName,
                                  CompanyName = u.CompanyName,
                                  Contact = u.Contact,
                                  CreatedAt = u.CreatedAt,
                                  EmailId = u.EmailId,
                                  GstNumber = u.GstNumber,
                                  IsBlock = u.IsBlock,
                                  IsVerify = u.IsVerify,
                                  Otp = u.Otp,
                                  Password = u.Password,
                                  RegisterBy = u.RegisterBy,
                                  Type = u.Type,
                                  UpdatedAt = u.UpdatedAt
                              }).FirstOrDefaultAsync<UserDetails>();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/User/GetEmployeeAreaWise/5
        [HttpGet("{GetEmployeeAreaWise}/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByArea(int id)
        {
            List<User> userList = null;

            userList = await (from u in _context.User
                              where u.AreaId == id
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


        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<Boolean> PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("teamwecop@gmail.com");
                message.To.Add(new MailAddress("muzammilaadeez@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "Hello";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("teamwecop@gmail.com", "bdakpulazjixbqme");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) {
                
            }

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
