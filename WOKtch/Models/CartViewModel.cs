using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }

        public String productName { get; set; }

        public int quantity { get; set; }

        public int price { get; set; }

        public int subtotal { get; set; }

        public string  pictureUrl { get; set; }
    }
}