using CartAPI.Model;
using CartAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private static List<CartItem> cart = new List<CartItem>();

        // GET: api/cart
        [HttpGet]
        public IActionResult GetCart()
        {
            return Ok(cart);
        }

        // POST: api/cart/add
        [HttpPost("add")]
        public IActionResult AddToCart([FromBody] CartItem newItem)
        {
            var existingItem = cart.FirstOrDefault(x => x.ProdId == newItem.ProdId);
            if (existingItem == null)
            {
                cart.Add(newItem);
            }
            else
            {
                existingItem.Qnt += newItem.Qnt;
            }
            return Ok(cart);
        }

        // PUT: api/cart/update
        [HttpPut("update")]
        public IActionResult UpdateCart([FromBody] CartItem updatedItem)
        {
            var existingItem = cart.FirstOrDefault(x => x.ProdId == updatedItem.ProdId);
            if (existingItem != null)
            {
                existingItem.Qnt = updatedItem.Qnt;
            }
            return Ok(cart);
        }

        // DELETE: api/cart/remove/{id}
        [HttpDelete("remove/{id}")]
        public IActionResult RemoveFromCart(int id)
        {
            var item = cart.FirstOrDefault(x => x.ProdId == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            return Ok(cart);
        }

        [HttpDelete("clear")]
        public IActionResult ClearCart()
        {
            cart.Clear();  
            return Ok(cart); 
        }
    }
}
