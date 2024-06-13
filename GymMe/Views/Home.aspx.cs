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
                string role = UserRepository.GetUserRole(id);
                string name = UserRepository.GetUserName(id);
                if (role == "Admin")
                {
                    AdminChoice.Visible = true;
            
                    List<MsUser> users = UserRepository.GetUsers();
                    GridViewCustomer.DataSource = users;
                    GridViewCustomer.DataBind();
                }
                if (role == "Customer")
                {
                    CustomerChoice.Visible = true;
                    LabelRole.Text = role;
                    LabelName.Text = name;
                }
            }
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("navigation.aspx");
        }
    }
}