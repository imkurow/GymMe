using GymMe.Controllers;
using GymMe.Factories;
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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            int isvalid = 1;

            string username = TextBoxUsername.Text;
            string email = TextBoxEmail.Text;
            string password = TextBoxPassword.Text;
            string password2 = TextBoxPassword2.Text;
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
            if (!UserController.IsPasswordAlphanumeric(password))
            {
                LabelPasswordError.Text = "Password must alphanumeric";
                isvalid = 0;
            }
            if (!(password.Equals(password2)))
            {
                LabelPassword2.Text = "Password and password confirmation not match";
                isvalid = 0;
            }
            if (!UserController.IsPasswordAlphanumeric(password2))
            {
                LabelPassword2Error.Text = "Password must alphanumeric";
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
            if (password.Equals(""))
            {
                LabelPasswordError.Text = "Password cant empty";
                isvalid = 0;
            }
            if (password2.Equals(""))
            {
                LabelPassword2Error.Text = "Password confirmation cant empty";
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
                MsUser newUser = UserFactory.createUser(username, email, password, gender, bod);
                UserRepository.CreateUser(newUser);
                Response.Redirect("login.aspx");
            }
        }
    }
}