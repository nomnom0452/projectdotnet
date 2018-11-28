using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.factories
{
    public class ProductFactory
    {
       public static Product createProduct(String productName, int productPrice, int productStock, string productPicture)
        {
            return new Product()
            {
                ProductName = productName,
                ProductPrice = productPrice,
                ProductStock = productStock,
                ProductPicture = productPicture
            };
        }
    }
}