using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WOKtch.factories;
using WOKtch.handlers;
using WOKtch.repositories;

namespace WOKtch.views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "")
            {
                errorLb.Text = "Name must be filled";
            }
            else if (emailTxt.Text == "")
            {
                errorLb.Text = "Email must be filled";
            }
            else if (MemberHandler.checkEmailExist(emailTxt.Text))
            {
                errorLb.Text = "Email already exist";
            }
            else if (passwordTxt.Text == "")
            {
                errorLb.Text = "Password must be filled";
            }
            else if (repasswordTxt.Text != passwordTxt.Text)
            {
                errorLb.Text = "Confirm password must exactly same as password";
            }
            else if (!maleRb.Checked && !femaleRb.Checked)
            {
                errorLb.Text = "Gender must be chosen";
            }
            else if (dobTxt.Text == "")
            {
                errorLb.Text = "Birth date must be filled";
            }
            else if (!imageValidation())
            {
                errorLb.Text = "Image extension must be .jpg or .png";
            }
            else if (phoneNumberTxt.Text == "")
            {
                errorLb.Text = "Phone number must be filled";
            }
            else if (addressTxt.Text == "")
            {
                errorLb.Text = "Address must be filled";
            }
            else
            {
                createMember();
                saveImages();
                Response.Redirect("Homepage.aspx");
            }
        }

        private void saveImages()
        {
            if (pictureUrl.HasFile)
                pictureUrl.SaveAs(Server.MapPath("~/Assets/MemberPhotos/") + Path.GetFileName(pictureUrl.FileName));
        }
        private void createMember()
        {
            string name = nameTxt.Text;
            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            string gender = (maleRb.Checked) ? "M" : "F";
            string dob = dobTxt.Text;
            string picture = pictureUrl.FileName;
            string number = phoneNumberTxt.Text;
            string address = addressTxt.Text;

            Member m = MemberFactory.createMember(name, email, password, gender, dob, picture, number, address);
            MemberRepository.addMembertoDatabase(m);
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
    }
}