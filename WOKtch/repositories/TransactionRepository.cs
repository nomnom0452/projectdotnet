using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.repositories
{
    public class TransactionRepository
    {
        static Database1Entities db = new Database1Entities();


        /*==================Header transaction Repository=====================*/

            /*  Manipulate Header Transaction  */
        public static int addTransactionToDatabase(HeaderTransaction t)
        {
            db.HeaderTransactions.Add(t);
            return db.SaveChanges();
        }
        public static int updateStatusTransactionById(int transactionId, string status)
        {
            HeaderTransaction h = db.HeaderTransactions.Find(transactionId);
            h.TransactionStatus = status;
            return db.SaveChanges();
        }

            /*  GET Data Header Transaction  */
        public static HeaderTransaction getHeaderTransactionById(int transactionId)
        {
            return db.HeaderTransactions.Find(transactionId);
        }
        public static List<HeaderTransaction> getAllHeaderTransaction()
        {
            return db.HeaderTransactions.ToList();
        }
        public static List<HeaderTransaction> getHeaderTransactionByEmail(string email)
        {
            return (from x in db.HeaderTransactions where x.MemberEmail == email select x).ToList();
        }



        /*==================Detail transaction Repository=====================*/
            /*  Manipulate DetailTransaction  */
        public static int addTransactionDetailToDatabase(TransactionDetail td)
        {
            db.TransactionDetails.Add(td);
            return db.SaveChanges();
        }
            /*  GET Data Detail Transaction  */
        public static List<TransactionDetail> getTransactionDetailByHeaderTransactionId(int headerTransactionId)
        {
            return (from x in db.TransactionDetails where x.HeaderTransactionId == headerTransactionId select x).ToList();
        }



        /*==================Custom transaction Repository=====================*/
            /*  GET data Custom Transaction  */
        public static List<TransactionViewModel> getAllTransactionView()
        {
            return (from t in db.HeaderTransactions
                    join d in db.TransactionDetails on t.HeaderTransactionId equals d.HeaderTransactionId
                    join m in db.Members on t.MemberEmail equals m.MemberEmail
                    join p in db.Products on d.ProductId equals p.ProductId
                    select new TransactionViewModel()
                    {
                        memberEmail = t.MemberEmail,
                        memberName = m.MemberName,
                        productId = d.ProductId,
                        productName = p.ProductName,
                        productPrice = p.ProductPrice,
                        productQuantity = d.ProductQuantity,
                        transactionDate = t.TransactionDate.ToString(),
                        transactionId = t.HeaderTransactionId,
                        transactionStatus = t.TransactionStatus,
                        subtotal = d.ProductQuantity * p.ProductPrice
                    }).ToList();
        }

        public static List<TransactionViewModel> getMemberTransactionViewByEmail(string email)
        {
            return (from t in db.HeaderTransactions
                    join d in db.TransactionDetails on t.HeaderTransactionId equals d.HeaderTransactionId
                    join m in db.Members on t.MemberEmail equals m.MemberEmail
                    join p in db.Products on d.ProductId equals p.ProductId
                    where t.MemberEmail == email
                    select new TransactionViewModel()
                    {
                        memberEmail = t.MemberEmail,
                        memberName = m.MemberName,
                        productId = d.ProductId,
                        productName = p.ProductName,
                        productPrice = p.ProductPrice,
                        productQuantity = d.ProductQuantity,
                        transactionDate = t.TransactionDate.ToString(),
                        transactionId = t.HeaderTransactionId,
                        transactionStatus = t.TransactionStatus,
                        subtotal = d.ProductQuantity * p.ProductPrice
                    }).ToList();
        }        
    }
}