using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _Context;
        public ProductsController(StoreContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task< ActionResult<List<Product>>> GetProducts( )
        {
          var products= await  _Context.Products.ToListAsync();
            return Ok(products);
         }
         
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _Context.Products.FindAsync(id);
        }

    }
}
