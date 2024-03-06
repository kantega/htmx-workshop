using htmx_test.Models;

namespace htmx_test.Controllers
{
    public class SessionManager
    {

        private Cart _cart = new Cart();

        public Cart GetCart(String sessionId)
        {
            //TODO: Implement proper session handling
            return _cart;
        }

    }
}