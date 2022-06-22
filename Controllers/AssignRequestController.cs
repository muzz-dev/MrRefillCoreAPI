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
    public class AssignRequestController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        public AssignRequestController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/AssignRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignRequest>>> GetAssignRequest()
        {
            return await _context.AssignRequest.ToListAsync();
        }

        // GET: api/AssignRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignRequest>> GetAssignRequest(int id)
        {
            var assignRequest = await _context.AssignRequest.FindAsync(id);

            if (assignRequest == null)
            {
                return NotFound();
            }

            return assignRequest;
        }

        // PUT: api/AssignRequest/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignRequest(int id, AssignRequest assignRequest)
        {
            if (id != assignRequest.AssignId)
            {
                return BadRequest();
            }

            _context.Entry(assignRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignRequestExists(id))
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

        // POST: api/AssignRequest
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssignRequest>> PostAssignRequest(AssignRequest assignRequest)
        {
            _context.AssignRequest.Add(assignRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignRequest", new { id = assignRequest.AssignId }, assignRequest);
        }

        // DELETE: api/AssignRequest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssignRequest>> DeleteAssignRequest(int id)
        {
            var assignRequest = await _context.AssignRequest.FindAsync(id);
            if (assignRequest == null)
            {
                return NotFound();
            }

            _context.AssignRequest.Remove(assignRequest);
            await _context.SaveChangesAsync();

            return assignRequest;
        }

        private bool AssignRequestExists(int id)
        {
            return _context.AssignRequest.Any(e => e.AssignId == id);
        }
    }
}
