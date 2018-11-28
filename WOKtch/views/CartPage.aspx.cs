using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.factories;
using WOKtch.Models;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        protected void cartDetail_DataBound(object sender, EventArgs e)
        {
            Member m = (Member)Session["User"];
            int grandTotal = 0;
            if (m != null)
            {
                List<CartViewModel> c = CartRepository.getCartViewData(m.MemberEmail);
                if (cartDetail.Rows.Count > 0)
                {

                    for (int i = 0; i < cartDetail.Rows.Count; i++)
                    {
                        grandTotal += Int32.Parse(cartDetail.Rows[i].Cells[4].Text);
                    }
                    addGridViewRow("Total", grandTotal.ToString());
                }
                else
                {
                    Label1.Text = "Cart is Empty";
                    checkOutBtn.Visible = false;
                }
            }
        }

        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            insertIntoTransaction();
            updateProductStock();
            deleteAllProductInCart();
            Response.Redirect("TransactionPage.aspx");
        }

        protected void cartDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            CartRepository.deleteProductFromCartByCartId(id);
            Response.Redirect("CartPage.aspx");
        }

        private void insertIntoTransaction()
        {
            Member m = (Member)Session["User"];
            List<Cart> c = CartRepository.getCartProductByMember(m.MemberEmail);
            string date = DateTime.Today.ToShortDateString();
            HeaderTransaction ht = TransactionFactory.createTransaction(date, "Pending", m.MemberEmail);
            TransactionRepository.addTransactionToDatabase(ht);
            foreach (Cart item in c)
            {
                TransactionDetail td = TransactionFactory.createDetailTransaction(ht.HeaderTransactionId, item.ProductId, item.ProductQuantity);
                TransactionRepository.addTransactionDetailToDatabase(td);
            }
        }

        private void updateProductStock()
        {
            Member m = (Member)Session["User"];
            List<Cart> c = CartRepository.getCartProductByMember(m.MemberEmail);
            foreach (Cart item in c)
            {
                ProductRepository.updateStockProduct(item.ProductId, item.ProductQuantity);
            }
        }
        private void deleteAllProductInCart()
        {
            Member m = (Member)Session["User"];
            CartRepository.deleteAllProductFromMemberCart(m.MemberEmail);
        }
        private void addGridViewRow(string labelText, string value)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            row.Cells.AddRange(new TableCell[5]
            {
                new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right },
                new TableCell(),
                new TableCell(),
                new TableCell(),
                new TableCell { Text = value, HorizontalAlign =HorizontalAlign.Right }
            });
            cartDetail.Controls[0].Controls.Add(row);
        }

        private void loadData()
        {
            Member m = (Member)Session["User"];
            if (m != null)
            {
                List<CartViewModel> c = CartRepository.getCartViewData(m.MemberEmail);
                cartDetail.DataSource = c;
                cartDetail.DataBind();
            }
            else
            {
                Label1.Text = "Cart is Empty";
                checkOutBtn.Visible = false;
            }

        }
    }
}