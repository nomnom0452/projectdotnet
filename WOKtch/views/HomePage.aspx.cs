using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAndBindTopProduct();
        }
        private void loadAndBindTopProduct()
        {
            List<Product> listProduct = ProductRepository.getAllProductDetail().GetRange(0, 2);
            topProductLV.DataSource = listProduct;
            topProductLV.DataBind();
        }
        protected void productBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductPage.aspx");
        }
    }
}