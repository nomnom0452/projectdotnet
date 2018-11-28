using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class TransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        protected void reportTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReport.aspx");
        }

        protected void adminTransactionView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            HeaderTransaction ht = TransactionRepository.getHeaderTransactionById(id);
            if(ht.TransactionStatus == "Pending")
            {
                TransactionRepository.updateStatusTransactionById(id, "Approved");
            }
            else if(ht.TransactionStatus == "Approved")
            {
                TransactionRepository.updateStatusTransactionById(id, "Pending");
            }
            Response.Redirect("TransactionPage.aspx");
        }

        private void loadData()
        {
            Member m = (Member)Session["User"];
            if (m.MemberRole == 1)
            {
                memberTransactionView.DataSource = TransactionRepository.getMemberTransactionViewByEmail(m.MemberEmail);
                memberTransactionView.DataBind();
            }
            else if(m.MemberRole == 2)
            {
                adminTransactionView.DataSource = TransactionRepository.getAllTransactionView();
                adminTransactionView.DataBind();
            }
        }
    }
}