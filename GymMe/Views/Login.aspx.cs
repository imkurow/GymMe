
using GymMe.Controllers;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("navigation.aspx");
            }
        }

        protected void LinkButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;
            bool rememberMe = CheckBoxRemember.Checked;

            int isvalid = 1;

            if (username.Length < 5 || username.Length > 15)
            {
                LabelUsernameError.Text = "Minimum is 5 and max is 15";
                isvalid = 0;
            }
            if (username.Equals(""))
            {
                LabelUsernameError.Text = "Username cannot be empty";
                isvalid = 0;
            }
            if (!UserController.IsPasswordAlphanumeric(password))
            {
                LabelPassowordError.Text = "Password must alphanumeric";
                isvalid = 0;
            }
            if (password.Equals(""))
            {
                LabelPassowordError.Text = "Password cannot be empty";
                isvalid = 0;
            }
            if (isvalid == 1)
            {
                bool isExist = UserRepository.IsExist(username, password);
                if (isExist)
                {
                    MsUser user = UserRepository.GetUserByUsername(username);
                    if (rememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("user_cookie");
                        cookie.Value = user.UserID.ToString();
                        cookie.Expires = DateTime.Now.AddHours(48);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        Session["user"] = user.UserID;
                    }
                    Response.Redirect("navigation.aspx");
                }
            }
        }
    }
}