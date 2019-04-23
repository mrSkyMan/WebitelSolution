using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webitel.Models;

namespace Webitel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly ContextDb _context;

        public OrderProductController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/OrderProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderProduct>>> GetOrderProducts()
        {
            await _context.SaveChangesAsync();
            return await _context.OrderProducts.ToListAsync();
        }

        // GET: api/OrderProduct/{Guid}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderProduct>> GetOrderProduct(Guid id)
        {
            var orderProduct = await _context.OrderProducts.FindAsync(id);

            if (orderProduct == null)
            {
                return NotFound();
            }

            return orderProduct;
        }

        // POST: api/OrderProduct
        [HttpPost]  
        public async Task<ActionResult<OrderProduct>> PostOrderProduct([FromBody]OrderProduct orderProduct)
        {
            _context.OrderProducts.Add(orderProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderProduct", new { id = orderProduct.Id }, orderProduct);
        }

        //DELETE: api/OrderProduct
        [HttpDelete]
        public async Task<ActionResult<OrderProduct>> DeleteProduct()
        {
            _context.OrderProducts.RemoveRange(_context.OrderProducts);
            await _context.SaveChangesAsync();
            return Ok($"All entries have been successfully deleted");
        }


        // DELETE: api/OrderProduct/{Guid}
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderProduct>> DeleteOrderProduct(Guid id)
        {
            var orderProduct = await _context.OrderProducts.FindAsync(id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            _context.OrderProducts.Remove(orderProduct);
            await _context.SaveChangesAsync();

            return orderProduct;
        }
    }
}
