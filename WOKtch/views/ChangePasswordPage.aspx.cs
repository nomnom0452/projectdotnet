using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class ChangePasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            Member m = (Member)Session["User"];

            if (oldPassTxt.Text != m.MemberPassword)
            {
                errorLb.Text = "Password doesn't Match";
            }
            else if (newPassTxt.Text == "")
            {
                errorLb.Text = "New Password must be filled";
            }
            else if (newPassTxt.Text != rePassTxt.Text)
            {
                errorLb.Text = "Confirm password must exactly same as new password";
            }
            else
            {
                m.MemberPassword = newPassTxt.Text;
                MemberRepository.changeMemberPassword(m);
                Response.Redirect("ProfilePage.aspx");
            }
        }
    }
}