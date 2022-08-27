using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopWEbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWEbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatProdController : ControllerBase
    {
        public CatProdController(AppDbContext context)
        {
            _context = context;
        }
        public AppDbContext _context { get; }

        [HttpGet("{id}")]
        public ActionResult Index(int id)
        {
            var data = _context.CatIdwiseProducts.FromSqlInterpolated($"Sp_CatIdWiseProd {id}");
            return Ok(data);

        }
        [HttpGet("{id}/{id1}")]
        public ActionResult Index1(int id,int id1)
        {
            var data = _context.CatIdwiseProducts.FromSqlInterpolated($"SP_CatIdWiseProdDetail {id},{id1}");
            return Ok(data);

        }
    }
}
