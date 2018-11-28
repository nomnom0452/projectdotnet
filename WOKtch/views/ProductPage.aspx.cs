using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.handler;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAndBindAllProduct();
                buttonVisibility();
            }
        }

        void buttonCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "addCartBtn")
                Response.Redirect("AddToCartPage.aspx?id=" + id);
            else if (e.CommandName == "detailBtn")
                Response.Redirect("ProductDetail.aspx?id=" + id);
            else if (e.CommandName == "updateProductBtn")
                Response.Redirect("UpdateProduct.aspx?id=" + id);
            else if (e.CommandName == "deleteProductBtn")
            {
                ProductRepository.deleteProductByIdFromDatabase(Int32.Parse(id));
                Response.Redirect("ProductPage.aspx");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            productList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(buttonCommand);
        }

        public void loadAndBindAllProduct()
        {
            productList.DataSource = ProductRepository.getAllProductDetail();
            productList.DataBind();
        }

        public void buttonVisibility()
        {
            Member m = (Member)Session["User"];
            addBtn.Visible = false;
            if (m != null)
            {
                if (m.MemberRole == 2) addBtn.Visible = true;
            }
        }

        protected bool IsAdmin()
        {
            Member m = (Member)Session["User"];

            if (m == null) return false;
            else if (m.MemberRole == 1) return false;
            return true;
         }
        protected bool IsMember()
        {
            Member m = (Member)Session["User"];

            if (m == null) return false;
            return true;
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }
    }
}