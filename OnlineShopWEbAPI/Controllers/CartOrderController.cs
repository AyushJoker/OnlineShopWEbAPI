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
    public class CartOrderController : ControllerBase
    {
        public CartOrderController(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; }
        [HttpGet]
        public ActionResult<IEnumerable<CartOrder>> Get()
        {
            return Ok(_context.CartOrders.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var data = _context.CartOrders.FirstOrDefault(co => co.COID == id);
            return Ok(data);
        }
        [HttpPost]
        public ActionResult Post(CartOrder newcartitem)
        {
            _context.CartOrders.Add(newcartitem);
            _context.SaveChanges();
            //return Ok();
            return CreatedAtAction("Get", new { newcartitem.COID }, newcartitem);
        }
    }
}

