using GymMe.Controllers;
using GymMe.Handler;
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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["user_cookie"] == null && Session["user"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    string id = "";
                    if (Request.Cookies["user_cookie"] != null)
                    {
                        id = Request.Cookies["user_cookie"].Value;
                    }
                    if (Session["user"] != null)                    
                    {
                        id = Session["user"].ToString();
                    }
                    MsUser currentUser = UserRepository.GetUserById(id);
                    TextBoxUsername.Text = currentUser.UserName;
                    TextBoxEmail.Text = currentUser.UserEmail;
                    LabelDOBData.Text = currentUser.UserDOB.ToString("dd/MM/yyyy");
                    CalendarDOB.SelectedDate = currentUser.UserDOB;
                    DropDownListGender.SelectedValue = currentUser.UserGender;
                }
            }
        }

        protected void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            string id = Request.Cookies["user_cookie"].Value;
            int isvalid = 1;
            string oldPassword = UserRepository.GetPassword(id);
            string password = TextBoxPassword.Text;
            string password2 = TextBoxPassword2.Text;
            if (!UserController.IsPasswordAlphanumeric(password))
            {
                LabelPasswordError.Text = "Password must alphanumeric";
                isvalid = 0;
            }
            if (!UserController.IsPasswordAlphanumeric(password2))
            {
                LabelPassword2Error.Text = "Password must alphanumeric";
                isvalid = 0;
            }
            if (password != oldPassword)
            {
                LabelPasswordError.Text = "Old password is wrong";
                isvalid = 0;
            }
            if (password.Equals(""))
            {
                LabelPasswordError.Text = "Password cant empty";
                isvalid = 0;
            }
            if (password2.Equals(""))
            {
                LabelPassword2Error.Text = "New Password cant empty";
                isvalid = 0;
            }
            {

            }
            if (isvalid == 1)
            {
                UserHandler.UpdateUserCredential(id, password2);
                HttpCookie userCookie = new HttpCookie("user_cookie");
                userCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
                Response.Redirect("login.aspx");
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            int isvalid = 1;
            string id = Request.Cookies["user_cookie"].Value;
            string username = TextBoxUsername.Text;
            string email = TextBoxEmail.Text;
            string gender = DropDownListGender.SelectedValue;
            DateTime bod = CalendarDOB.SelectedDate;

            if (username.Length < 5 || username.Length > 15)
            {
                LabelUsernameError.Text = "Minimum is 5 and max is 15";
                isvalid = 0;
            }
            if (!UserController.isValidEmail(email))
            {
                LabelEmailError.Text = "Email must end with .com";
                isvalid = 0;
            }

            if (username.Equals(""))
            {
                LabelUsernameError.Text = "Username cant empty";
                isvalid = 0;
            }
            if (email.Equals(""))
            {
                LabelEmailError.Text = "Email cant empty";
                isvalid = 0;
            }
            if (gender.Equals(""))
            {
                LabelGenderError.Text = "Gender cant empty";
                isvalid = 0;
            }
            if (bod.Equals(""))
            {
                LabelDOBError.Text = "Date of birth cant empty";
                isvalid = 0;
            }
            if (isvalid == 1)
            {
                UserHandler.UpdateUserProfile(id, username, email, gender, bod);
                Response.Redirect("navigation.aspx");
            }
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("navigation.aspx");
        }
    }
}