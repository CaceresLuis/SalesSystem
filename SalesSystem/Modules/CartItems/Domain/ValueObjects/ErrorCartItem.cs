using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Modules.CartItems.Domain.ValueObjects
{
    public class ErrorCartItem
    {
        public static Error NotFoundCartItem => Error.NotFound("CartItem", "Cart Item don't exist.");
    }
}
