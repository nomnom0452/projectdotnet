using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.factories
{
    public class CartFactory
    {
        public static Cart createCartProduct(string email, int productId, int quanitity)
        {
            Cart c = new Cart();
            c.MemberEmail = email;
            c.ProductId = productId;
            c.ProductQuantity = quanitity;
            return c;
        }

        public static CartViewModel CreateCartView(int id, string name, int quantity, int price, string pictureUrl)
        {
            return new CartViewModel()
            {
                CartId = id,
                productName = name,
                quantity = quantity,
                price = price,
                pictureUrl = pictureUrl
            };
        }
    }
}