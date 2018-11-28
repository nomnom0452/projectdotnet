using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.repositories;

namespace WOKtch.handler
{
    public class CartHandler
    {
        public static bool checkQuantity(int productId, int qty)
        {
            Product p = ProductRepository.getProductById(productId);
            if(qty > p.ProductStock)
            {
                return false;
            }
            return true;
        }
        public static bool isProductExistInCart(string email, int productId)
        {
            if (CartRepository.getSpecificProductInCart(email, productId) != null)
                return true;
            return false;
        }
    }
}