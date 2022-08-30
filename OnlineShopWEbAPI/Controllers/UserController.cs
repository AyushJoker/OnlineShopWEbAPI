using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWEbAPI.Models;

namespace WEB_API.Controllers
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
        [HttpGet("{useremail}")]
        public ActionResult<User> Get(string useremail)
        {
            var data = _context.Users.FirstOrDefault(ue => ue.Email == useremail);
            return (data);
        }
        [HttpPost]
        public ActionResult Post(User newuser)
        {
            _context.Users.Add(newuser);
            _context.SaveChanges();
            //return Ok();
            return CreatedAtAction("Get", new { newuser.UID }, newuser);
        }
        [HttpPut("{useremail}")]
        public ActionResult Put(string useremail, User modifieduser)
        {
            var data = _context.Users.FirstOrDefault(u => u.Email == useremail);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                data.Firstname = modifieduser.Firstname;
                data.Lastname = modifieduser.Lastname;
                data.Email = modifieduser.Email;
                data.Password = modifieduser.Password;
                data.Confirm_Password = modifieduser.Confirm_Password;
                data.Mobile = modifieduser.Mobile;
                data.City = modifieduser.City;
                data.Pincode = modifieduser.Pincode;
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var data = _context.Users.FirstOrDefault(u => u.UID == id);
            _context.Users.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
        [Route("login")]
        [HttpPost]
        public ActionResult<User> LogInChecker(User details)
        {
            var data = _context.Users.FirstOrDefault(p => (p.Email == details.Email && p.Password == details.Password));
            if (data == null)
            {
                return BadRequest("Email or Password is incorrect");
            }
            return Ok(data);
        }
    }
}
