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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                string id = Request.Cookies["user_cookie"].Value;
                string role = UserRepository.GetUserRole(id);
                if (role == "Admin")
                {
                    Label1.Text = "Welcome, " + Request.Cookies["user_cookie"].Value;
                    List<MsUser> users = UserRepository.GetUsers();
                    GridViewCustomer.DataSource = users;
                    GridViewCustomer.DataBind();
                }
                else
                {
                    Response.Redirect("navigation.aspx");
                }
            }
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("navigation.aspx");
        }
    }
}