using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Member m = (Member)Session["User"];
                CrystalReport1 cr1 = new CrystalReport1();
                if (m.MemberRole == 1) cr1.SetDataSource(getDataForMember());
                else if (m.MemberRole == 2) cr1.SetDataSource(getDataForAdmin());
                CrystalReportViewer1.ReportSource = cr1;
            }
        }

        protected DataSet1 getDataForAdmin()
        {
            DataSet1 ds = new DataSet1();
            var transactionTable = ds.HeaderTransaction;
            var detailTable = ds.DetailTransaction;

            List<HeaderTransaction> transactionList = TransactionRepository.getAllHeaderTransaction();

            foreach (HeaderTransaction item in transactionList)
            {
                int grandTotal = 0;
                var transactionRow = transactionTable.NewRow();

                Member m = MemberRepository.getMemberById(item.MemberEmail);

                transactionRow["TransactionId"] = item.HeaderTransactionId;
                transactionRow["TransactionDate"] = item.TransactionDate.ToString("d");
                transactionRow["TransactionStatus"] = item.TransactionStatus;
                transactionRow["MemberName"] = m.MemberName;
                transactionRow["MemberEmail"] = item.MemberEmail;

                List<TransactionDetail> detailList = TransactionRepository.getTransactionDetailByHeaderTransactionId(item.HeaderTransactionId);

                foreach (TransactionDetail td in detailList)
                {
                    Product p = ProductRepository.getProductById(td.ProductId);
                    var detailTransactionRow = detailTable.NewRow();
                    detailTransactionRow["ProductName"] = p.ProductName;
                    detailTransactionRow["ProductQuantity"] = td.ProductQuantity;
                    detailTransactionRow["ProductPrice"] = p.ProductPrice;
                    detailTransactionRow["Subtotal"] = p.ProductPrice * td.ProductQuantity;
                    detailTransactionRow["DetailId"] = td.TransactionDetailId;
                    detailTransactionRow["TransactionId"] = td.HeaderTransactionId;
                    grandTotal += p.ProductPrice * td.ProductQuantity;

                    detailTable.Rows.Add(detailTransactionRow);
                }
                transactionRow["Total"] = grandTotal;
                transactionTable.Rows.Add(transactionRow);
            }
            return ds;
        }

        protected DataSet1 getDataForMember()
        {
            Member m = (Member)Session["User"];
            DataSet1 ds = new DataSet1();
            var transactionTable = ds.HeaderTransaction;
            var detailTable = ds.DetailTransaction;

            List<HeaderTransaction> transactionList = TransactionRepository.getHeaderTransactionByEmail(m.MemberEmail);

            foreach (HeaderTransaction item in transactionList)
            {
                int grandTotal = 0;
                var transactionRow = transactionTable.NewRow();
                transactionRow["TransactionId"] = item.HeaderTransactionId;
                transactionRow["TransactionDate"] = item.TransactionDate.ToString("d");
                transactionRow["TransactionStatus"] = item.TransactionStatus;
                transactionRow["MemberName"] = m.MemberName;
                transactionRow["MemberEmail"] = m.MemberEmail;      

                List<TransactionDetail> detailList = TransactionRepository.getTransactionDetailByHeaderTransactionId(item.HeaderTransactionId);

                foreach (TransactionDetail detail in detailList)
                {
                    Product p = ProductRepository.getProductById(detail.ProductId);
                    var detailTransactionRow = detailTable.NewRow();
                    detailTransactionRow["ProductName"] = p.ProductName;
                    detailTransactionRow["ProductQuantity"] = detail.ProductQuantity;
                    detailTransactionRow["ProductPrice"] = p.ProductPrice;
                    detailTransactionRow["Subtotal"] = p.ProductPrice * detail.ProductQuantity;
                    detailTransactionRow["DetailId"] = detail.TransactionDetailId;
                    detailTransactionRow["TransactionId"] = detail.HeaderTransactionId;
                    grandTotal += (p.ProductPrice * detail.ProductQuantity);

                    detailTable.Rows.Add(detailTransactionRow);
                }
                transactionRow["Total"] = grandTotal;
                transactionTable.Rows.Add(transactionRow);
            }
            return ds;
        }
    }
}