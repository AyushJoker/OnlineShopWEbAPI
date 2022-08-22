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
    public class UserController : ControllerBase
    {
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; }
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_context.Users.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var data = _context.Users.FirstOrDefault(u => u.UID == id);
            return (data);
        }
        [HttpPost]
        public ActionResult Post(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            //return Ok();
            return CreatedAtAction("Get", new { newUser.UID }, newUser);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, User modifiedCat)
        {
            var data = _context.Users.FirstOrDefault(u => u.UID == id);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                data.Lastname = modifiedCat.Lastname;
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var data = _context.Users.FirstOrDefault(u=> u.UID == id);
            _context.Users.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}
