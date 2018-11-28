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
    public partial class ViewMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) loadAndBindMemberGrid();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string email = e.CommandArgument.ToString();
            if (e.CommandName == "changeRoleBtn")
            {
                MemberRepository.changeRoletoAdmin(email);
            }
            else if(e.CommandName == "deleteMemberBtn")
            {
                MemberRepository.deleteMemberFromDatabase(email);    
            }
            Response.Redirect("ViewMember.aspx");
        }
        private void loadAndBindMemberGrid()
        {
            List<Member> listUser = MemberRepository.getAllMemberDetail();
            memberDetail.DataSource = listUser;
            memberDetail.DataBind();
        }

        protected bool IsMember(string email)
        {
            Member m = MemberRepository.getMemberById(email);

            if (m == null) return false;
            if (m.MemberRole == 2) return false;
            else  return true;
        }
    }
}