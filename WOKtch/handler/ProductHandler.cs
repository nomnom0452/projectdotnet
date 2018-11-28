using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.repositories;

namespace WOKtch.handler
{
    public class ProductHandler
    {
        public static bool isProductExist(int id)
        {
            if (ProductRepository.getProductById(id) != null)
                return true;
            return false;
        }
    }
}