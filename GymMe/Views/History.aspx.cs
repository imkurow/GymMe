using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                        AdminChoice.Visible = true;
                    }
                    else if (role == "Customer")
                    {
                        CustomerChoice.Visible = true;
                    }

                }
            }
        }
    }
}