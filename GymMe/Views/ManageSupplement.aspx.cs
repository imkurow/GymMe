using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class ManageSupplement : System.Web.UI.Page
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
                if (role == "Customer")
                {
                    Response.Redirect("Navigation.aspx");
                }
                else
                {

                }
            }
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Navigation.aspx");
        }

        protected void LinkButtonInsertSup_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertSupplement.aspx");
        }
    }
}