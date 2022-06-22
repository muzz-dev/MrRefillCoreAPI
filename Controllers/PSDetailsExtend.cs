using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrRefillCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrRefillCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PSDetailsExtend : ControllerBase
    {

        private readonly DBMrRefillContext _context;

        public PSDetailsExtend(DBMrRefillContext context)
        {
            _context = context;
        }


        // GET: api/PSDetailsExtend/PurchaseDetailsExtend/5
        [HttpGet("{id}")]
        [Route("{PurchaseDetailsExtend}/{id}")]
        public async Task<ActionResult<PurchaseDetailExtend>> GetPurchaseDetailsExtend(int id)
        {
            PurchaseDetailExtend _purchaseDetails = null;

            _purchaseDetails = await (from pd in _context.PurchaseDetails
                                      join p in _context.Purchase
                                      on pd.PurchaseId equals p.PurchaseId
                                      join u in _context.User
                                      on p.UserId equals u.UserId
                                      where p.PurchaseId == id
                                      select new PurchaseDetailExtend
                                      {
                                          PurchaseId = p.PurchaseId,
                                          UserId = u.UserId,
                                          UserName = u.Name,
                                          CompanyName = u.CompanyName,
                                          EmailId = u.EmailId,
                                          Contact = u.Contact,
                                          Address = u.Address,
                                          PurchaseDate = p.PurchaseDate,
                                      }
                                      ).FirstOrDefaultAsync<PurchaseDetailExtend>();

            return _purchaseDetails;
        }


        // GET: api/PSDetailsExtend/SalesDetailsExtend/Sales/5
        [HttpGet("{id}")]
        [Route("{SalesDetailsExtend}/{Sales}/{id}")]
        public async Task<ActionResult<SalesDetailExtend>> GetSalesDetailsExtend(int id)
        {
            SalesDetailExtend _salesDetails = null;

            _salesDetails = await (from sd in _context.SalesDetails
                                      join s in _context.Sales
                                      on sd.SalesId equals s.SalesId
                                      join u in _context.User
                                      on s.UserId equals u.UserId
                                      where s.SalesId == id
                                      select new SalesDetailExtend
                                      {
                                          SalesId = s.SalesId,
                                          UserId = u.UserId,
                                          UserName = u.Name,
                                          CompanyName = u.CompanyName,
                                          EmailId = u.EmailId,
                                          Contact = u.Contact,
                                          Address = u.Address,
                                          SalesDate = s.SalesDate
                                      }
                                      ).FirstOrDefaultAsync<SalesDetailExtend>();

            return _salesDetails;
        }

    }
}
