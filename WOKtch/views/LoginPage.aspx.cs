using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.handlers;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class LoginPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["email"] != null && !IsPostBack)
                emailTxt.Text = Request.Cookies["email"].Value;
        }

        private void isRemembered()
        {
            if (rememberCheck.Checked)
            {
                Response.Cookies["email"].Value = emailTxt.Text;
                Response.Cookies["email"].Expires.AddHours(1);
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            string errorMsg = "";

            if (email == "")
                errorMsg = "Email Must be Filled";
            else if (password == "")
            {
                errorMsg = "Password Must be Filled";
            }
            else if (!MemberHandler.checkEmailExist(email))
            {
                errorMsg = "Email Doesn't Exist";
            }
            else if (!MemberHandler.checkEmailandPasswordMatch(email, password))
            {
                errorMsg = "Email and passoword Doesn't Match";
            }
            else
            {
                Session["User"] = MemberRepository.getMemberById(email);
                isRemembered();
                Response.Redirect("Homepage.aspx");
            }
            errorLb.Text = errorMsg;

        }
    }
}