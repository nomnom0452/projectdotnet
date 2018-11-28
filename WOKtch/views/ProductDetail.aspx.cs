using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.factories;
using WOKtch.Models;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAndBindProductDetail();
                loadAndBindProductRatingAndReview();
            }
            visible();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            reviewList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(reviewListCommand);
        }

        private void loadAndBindProductDetail()
        {
            int id = Int32.Parse(Request.QueryString["id"]);
            Product p = ProductRepository.getProductById(id);
            List<Product> pe = new List<Product>();
            pe.Add(p);
            FormView1.DataSource = pe;
            FormView1.DataBind();
        }

        private void loadAndBindProductRatingAndReview()
        {
            int id = Int32.Parse(Request.QueryString["id"]);
            List<ReviewViewModel> r = ReviewRepository.getProductReviewAndRatingByProductId(id);
            reviewList.DataSource = r;
            reviewList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(reviewListCommand);
            reviewList.DataBind();
        }
        void reviewListCommand(Object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "updateBtn")
            {
                Response.Redirect("UpdateReview.aspx?id=" + e.CommandArgument);
            }
            else if (e.CommandName == "deleteBtn")
            {
                ReviewRepository.deleteProductReviewByReviewId(Int32.Parse(e.CommandArgument.ToString()));
                Review r = ReviewRepository.getReviewAndRatingByReviewId(Int32.Parse(e.CommandArgument.ToString()));
                Response.Redirect("ProductDetail.aspx?id=" + r.ProductId);
            }
        }

        protected bool IsMember(int id)
        {
            Member m = (Member)Session["User"];
            Review r = ReviewRepository.getReviewAndRatingByReviewId(id);

            if (m == null) return false;
            if (m.MemberRole == 1)
            {
                if (m.MemberEmail == r.MemberEmail) return true;
            }
            else if (m.MemberRole == 2) return true;
            return false;
        }

        private void visible()
        {
            Member m = (Member)Session["User"];

            if (m == null) reviewDiv.Visible = false;
            else reviewDiv.Visible = true;
        }

        protected void postBtn_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.QueryString["id"].ToString());
            if (ratingTxt.Text == "")
            {
                errorLb.Text = "Rating Must be filled";
            }
            else if (Int32.Parse(ratingTxt.Text) < 1 || Int32.Parse(ratingTxt.Text) > 5)
            {
                errorLb.Text = "Rating must be between 1 to 5";
            }
            else if (reviewDescTxt.Text.Length > 255)
            {
                errorLb.Text = "Review Description maximal length is 255 characters";
            }
            else
            {
                string reviewDesc = reviewDescTxt.Text;
                int reviewRating = Int32.Parse(ratingTxt.Text);
                Member m = (Member)Session["User"];
                Review r = ReviewFactory.createReview(reviewRating, reviewDesc, id, m.MemberEmail);
                ReviewRepository.addProductReviewToDatabase(r);
                Response.Redirect("ProductDetail.aspx?id=" + id);
            }
        }
    }
}