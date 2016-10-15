using System.Web.Mvc;
using CarShowroom.Domain;

namespace CarShowroom.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string SessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart) controllerContext.HttpContext.Session[SessionKey];
            }

            if (cart != null) return cart;
            cart = new Cart();
            if (controllerContext.HttpContext.Session != null)
            {
                controllerContext.HttpContext.Session[SessionKey] = cart;
            }

            return cart;
        }
    }
}