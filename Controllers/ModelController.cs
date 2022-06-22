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
    public class ModelController : ControllerBase
    {
        private readonly DBMrRefillContext _context;

        List<ModelCompanyType> modelList = null;

        public ModelController(DBMrRefillContext context)
        {
            _context = context;
        }

        // GET: api/Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelCompanyType>>> GetModel()
        {
            modelList = await (from m in _context.Model
                               join c in _context.Company
                               on m.CompanyId equals c.CompanyId
                               join t in _context.CartridgeType
                               on Convert.ToInt32(m.Type) equals t.TypeId
                               select new ModelCompanyType
                               {
                                   CompanyId = c.CompanyId,
                                   ModelId = m.ModelId,
                                   CompanyName = c.CompanyName,
                                   ModelName = m.ModelName,
                                   Type = m.Type,
                                   TypeName = t.TypeName
                               }).ToListAsync<ModelCompanyType>();

            return modelList;
        }

        // GET: api/Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model>> GetModel(int id)
        {
            var model = await _context.Model.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/Model/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model model)
        {
            if (id != model.ModelId)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Model
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(Model model)
        {
            _context.Model.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModel", new { id = model.ModelId }, model);
        }

        // DELETE: api/Model/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Model>> DeleteModel(int id)
        {
            var model = await _context.Model.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Model.Remove(model);
            await _context.SaveChangesAsync();

            return model;
        }

        private bool ModelExists(int id)
        {
            return _context.Model.Any(e => e.ModelId == id);
        }

        // GET: api/Model/ModelByCompanyId/5
        [HttpGet("{ModelByCompanyId}/{id}")]
        public async Task<ActionResult<IEnumerable<Model>>> GetModelByCompanyId(int id)
        {
            List<Model> _models = await (from m in _context.Model
                                         join c in _context.Company
                                         on m.CompanyId equals c.CompanyId
                                         where m.CompanyId == id
                                         select new Model
                                         {
                                             ModelId = m.ModelId,
                                             ModelName = m.ModelName,
                                             CompanyId = m.CompanyId,
                                             Type = m.Type,
                                             IsActive = m.IsActive,
                                             CreatedAt = m.CreatedAt,
                                             UpdatedAt = m.UpdatedAt
                                         }).ToListAsync<Model>();

            return _models;
        }
    }
}
