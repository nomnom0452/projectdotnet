using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WOKtch.views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Member m = (Member)Session["User"];
            List<Member> me = new List<Member>();
            me.Add(m);
            memberProfileF.DataSource = me;
            memberProfileF.DataBind();
        }

        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePasswordPage.aspx");
        }
    }
}