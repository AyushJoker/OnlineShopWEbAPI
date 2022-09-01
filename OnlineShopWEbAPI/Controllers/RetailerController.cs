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
    public class RetailerController : ControllerBase
    {
        public RetailerController(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; }

        [HttpGet]
        public ActionResult<IEnumerable<Retailer>> Get()
        {
            return Ok(_context.Retailers.ToList());
        }
        [HttpGet("{id}")]

        public ActionResult<Retailer> Get(int id)
        {
            var data = _context.Retailers.FirstOrDefault(c => c.RID == id);
            if (data == null)
            {
                return BadRequest("Retailer has not registered");
            }
            return Ok(data);
        }

        [HttpPost]
        public ActionResult Post(Retailer newretailer)
        {
            _context.Retailers.Add(newretailer);
            _context.SaveChanges();
            //return Ok();
            return CreatedAtAction("Get", new { newretailer.RID }, newretailer);
        }

        [HttpPut("{id}")]
        [Route("updateretailer/{id}")]
        public ActionResult Put(int id, Retailer modifiedretailer)
        {
            var data = _context.Retailers.FirstOrDefault(c => c.RID == id);
            if (data == null)
                return BadRequest();
            else
            {
                data.RName = modifiedretailer.RName;
                data.Password = modifiedretailer.Password;
                data.email = modifiedretailer.email;
                data.Contactnumber = modifiedretailer.Contactnumber;


                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        [Route("isavailable/{id}")]
        public ActionResult Updateavailablity(int id, Retailer modifiedretailer)
        {
            var data = _context.Retailers.FirstOrDefault(c => c.RID == id);
            if (data == null)
                return BadRequest();
            else
            {
                if (data.Isavailable == 0)
                {
                    data.Isavailable = 1;
                }
                else
                {
                    data.Isavailable = 0;
                }
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            var data = _context.Retailers.FirstOrDefault(c => c.RID == id);
            if (data == null)
                return BadRequest();
            else
            {
                _context.Retailers.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
        }


        [Route("rlogin")]
        [HttpPost]
        public ActionResult<Retailer> LogInChecker(Retailer details)
        {
            var data = _context.Retailers.FirstOrDefault(p => (p.email == details.email && p.Password == details.Password));
            if (data == null)
            {
                return BadRequest("Email or Password is incorrect");
            }
            return Ok(data);
        }

    }
}

