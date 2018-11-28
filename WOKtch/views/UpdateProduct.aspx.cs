using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.factories;
using WOKtch.handler;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                errorLb.Text = "Name must be filled";
            }
            else if (priceTxt.Text == "")
            {
                errorLb.Text = "Price must be filled";
            }
            else if (stockTxt.Text == "")
            {
                errorLb.Text = "Stock must be filled";
            }
            else if (Int32.Parse(stockTxt.Text) <= 0)
            {
                errorLb.Text = "Stock must be greater than zero(0)";
            }
            else if (!imageValidation())
            {
                errorLb.Text = "Image extention must be .jpg or .png";
            }
            else
            {
                updateProduct();
                saveImages();
                Response.Redirect("ProductPage.aspx");
            }
        }

        private bool imageValidation()
        {


            if (pictureUrl.HasFile)
            {
                String name = pictureUrl.FileName;
                if (name.Substring(name.Length - 4) != ".jpg" && name.Substring(name.Length - 4) != ".png")
                {
                    return false;
                }
            }
            return true;
        }

        private void updateProduct()
        {
            int id = Int32.Parse(Request.QueryString["id"]);
            string name = nameTxt.Text;
            int stock = Int32.Parse(stockTxt.Text);
            int price = Int32.Parse(priceTxt.Text);
            string picture = pictureUrl.FileName;

            Product p = ProductFactory.createProduct(name, stock, price, picture);
            ProductRepository.updateProductByIdToDatabase(id, p);
        }

        private void saveImages()
        {
            if (pictureUrl.HasFile)
                pictureUrl.SaveAs(Server.MapPath("~/Assets/ProductPhotos/") + Path.GetFileName(pictureUrl.FileName));
        }
    }
}