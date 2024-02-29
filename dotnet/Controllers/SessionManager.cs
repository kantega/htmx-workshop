using htmx_test.Models;

namespace htmx_test.Controllers
{
    public class SessionManager
    {

        private readonly IDictionary<String, Cart> carts = new Dictionary<String, Cart>();

        public Cart GetCart(String sessionId)
        {
            if (!carts.ContainsKey(sessionId)) carts[sessionId] = new Cart();
            return carts[sessionId];
        }

    }
}