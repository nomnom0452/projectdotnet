using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class UpdateReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.QueryString["id"].ToString());
            string reviewDesc = reviewTxt.Text;
            int reviewRating = Int32.Parse(ratingTxt.Text);

            if (ratingTxt.Text == "")
            {
                errorLb.Text = "Rating Must be filled";
            }
            else if (reviewRating < 1 || reviewRating > 5)
            {
                errorLb.Text = "Rating must be between 1 to 5";
            }
            else if (reviewDesc.Length > 255)
            {
                errorLb.Text = "Review Description maximal length is 255 characters";
            }
            else
            {
                ReviewRepository.updateProductReviewByMemberId(id, reviewRating, reviewDesc);
                Review r = ReviewRepository.getReviewAndRatingByReviewId(id);
                Response.Redirect("ProductDetail.aspx?id=" + r.ProductId);
            }
        }
    }
}