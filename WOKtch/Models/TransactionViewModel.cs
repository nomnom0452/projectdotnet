using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.Models
{
    public class TransactionViewModel
    {
        public int transactionId { get; set; }
        public string memberEmail { get; set; }
        public string memberName { get; set; }
        public string transactionDate { get; set; }
        public string transactionStatus { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int productQuantity { get; set; }
        public int productPrice { get; set; }
        public int subtotal { get; set; }
    }
}