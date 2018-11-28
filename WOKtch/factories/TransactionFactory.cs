using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.factories
{
    public class TransactionFactory
    {
        public static HeaderTransaction createTransaction(string date, string status, string email)
        {
            return new HeaderTransaction()
            {
                TransactionDate = Convert.ToDateTime(date),
                TransactionStatus = status,
                MemberEmail = email
            };
        }
        public static TransactionDetail createDetailTransaction(int headerId, int productId, int productQty)
        {
            return new TransactionDetail()
            {
                HeaderTransactionId = headerId,
                ProductId = productId,
                ProductQuantity = productQty
            };
        }
        public static TransactionViewModel createTransactionView(int transactionId, string memberEmail, string memberName,
            string transactionDate, string transactionStatus, int productId, string productName, int productQuantity, 
            int productPrice, int subtotal)
        {
            return new TransactionViewModel()
            {
                transactionId = transactionId,
                memberEmail = memberEmail,
                memberName = memberName,
                transactionDate = transactionDate,
                transactionStatus = transactionStatus,
                productId = productId,
                productName = productName,
                productQuantity = productQuantity,
                productPrice = productPrice,
                subtotal = subtotal
            };
        }
    }
}