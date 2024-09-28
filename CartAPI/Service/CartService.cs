using CartAPI.Model;

namespace CartAPI.Service
{
    public class CartService
    {
        private static List<CartItem> cartItems = new List<CartItem>();

        public IEnumerable<CartItem> GetCartItems()
        {
            return cartItems;
        }

        public CartItem AddToCart(CartItem item)
        {
            var existingItem = cartItems.FirstOrDefault(x => x.ProdId == item.ProdId);
            if (existingItem == null)
            {
                cartItems.Add(item);
            }
            else
            {
                existingItem.Qnt += item.Qnt;
            }
            return item;
        }

        public void RemoveFromCart(int prodId)
        {
            var item = cartItems.FirstOrDefault(x => x.ProdId == prodId);
            if (item != null)
            {
                cartItems.Remove(item);
            }
        }

        public void UpdateCartItem(int prodId, int quantity)
        {
            var item = cartItems.FirstOrDefault(x => x.ProdId == prodId);
            if (item != null)
            {
                item.Qnt = quantity;
            }
        }

        public void ClearCart()
        {
            cartItems.Clear();
        }
    }
}
