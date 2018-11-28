using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.factories;
using WOKtch.handler;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class AddToCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadProductName();
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            int quantity = Int32.Parse(quantityTxt.Text);
            int id = Int32.Parse(Request.QueryString["id"]);
            if (quantityTxt.Text == "")
            {
                errorLb.Text = "Quantity must be filled";
            }
            else if(quantity <= 0)
            {
                errorLb.Text = "Quantity must be greater than zero";
            }
            else if (!CartHandler.checkQuantity(id, quantity))
            {
                errorLb.Text = "Quantity exceeds the limit";
            }
            else
            {
                addProduct();
            }
        }


        private void addProduct()
        {
            Member m = (Member)Session["User"];
            int productId = Int32.Parse(Request.QueryString["id"]);
            int quantity = Int32.Parse(quantityTxt.Text);

            if (CartHandler.isProductExistInCart(m.MemberEmail, productId))
            {
                Cart c = CartRepository.getSpecificProductInCart(m.MemberEmail, productId);
                c.ProductQuantity += quantity;
                CartRepository.updateProductInCart(c.CartId, c);
            }
            else
            {
                Cart c = CartFactory.createCartProduct(m.MemberEmail, productId, quantity);
                CartRepository.addProductToCart(c);
            }
            Response.Redirect("ProductPage.aspx");
        }

        private void loadProductName()
        {
            int id = Int32.Parse(Request.QueryString["id"]);
            Product p = ProductRepository.getProductById(id);
            List<Product> pe = new List<Product>();
            pe.Add(p);
            FormView1.DataSource = pe;
            FormView1.DataBind();
        }
    }
}