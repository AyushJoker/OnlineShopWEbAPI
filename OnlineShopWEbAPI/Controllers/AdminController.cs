using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWEbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWEbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; }

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> Get()
        {
            return Ok(_context.Admins.ToList());
        }

        [Route("alogin")]
        [HttpPost]
        public ActionResult<Retailer> LogInChecker(Admin details)
        {
            var data = _context.Admins.FirstOrDefault(p => (p.username == details.username && p.Password == details.Password));
            if (data == null)
            {
                return BadRequest("Email or Password is incorrect");
            }
            return Ok(data);
        }
    }
}
