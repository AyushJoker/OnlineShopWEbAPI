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
    public class ProductController : ControllerBase
    {
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; }
        [HttpGet]

        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_context.Products.ToList());
        }
        [HttpGet("{id}")]

        public ActionResult<Product> Get(int id)
        {
            var data = _context.Products.FirstOrDefault(c => c.PID == id);
            if (data == null)
            {
                return BadRequest("User has not registered");
            }
            return Ok(data);
        }

        [HttpPost]
        public ActionResult Post(Product newproduct)
        {
            _context.Products.Add(newproduct);
            _context.SaveChanges();
            //return Ok();
            return CreatedAtAction("Get", new { newproduct.PID }, newproduct);
        }

        [HttpPut("{id}")]

        public ActionResult Put(int id, Product modifiedproduct)
        {
            var data = _context.Products.FirstOrDefault(c => c.PID == id);
            if (data == null)
                return BadRequest();
            else
            {
                data.PName = modifiedproduct.PName;
                data.PDetail = modifiedproduct.PDetail;
                data.PImage1 = modifiedproduct.PImage1;
                data.PImage2 = modifiedproduct.PImage2;
                data.PImage3 = modifiedproduct.PImage3;
                data.Price = modifiedproduct.Price;

                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            var data = _context.Products.FirstOrDefault(c => c.PID == id);
            if (data == null)
                return BadRequest();
            else
            {
                _context.Products.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}

