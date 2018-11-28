using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WOKtch.views.layout
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            greeting();
            buttonVisibility();
            dateLb.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void greeting()
        {
            if(Session["User"] == null)
            {
                greetingLb.Text = "Hallo guest! Welcome to WOKtch!";
            }
            else
            {
                Member m = (Member)Session["User"];
                greetingLb.Text = "Hello " + m.MemberName + "! Welcome to WOKtch!";
            }
        }

        private void buttonVisibility()
        {
            loginBtn.Visible = false;
            registerBtn.Visible = false;
            LogoutBtn.Visible = false;
            profileBtn.Visible = false;
            viewMemberBtn.Visible = false;
            cartBtn.Visible = false;
            transcationPageBtn.Visible = false;

            Member m = (Member)Session["User"];
            if(m == null)
            {
                loginBtn.Visible = true;
                registerBtn.Visible = true;
            }
            else if(m.MemberRole == 2)
            {
                viewMemberBtn.Visible = true;
                LogoutBtn.Visible = true;
                profileBtn.Visible = true;
                cartBtn.Visible = true;
                transcationPageBtn.Visible = true;
            }
            else
            {
                LogoutBtn.Visible = true;
                profileBtn.Visible = true;
                cartBtn.Visible = true;
                transcationPageBtn.Visible = true;
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loginpage.aspx");
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registerpage.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("Homepage.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
        }

        protected void viewMemberBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewMember.aspx");
        }

        protected void cartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }

        protected void transcationPageBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionPage.aspx");
        }
    }
}