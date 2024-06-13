using GymMe.Factories;
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
    public partial class InsertSupplementType : System.Web.UI.Page
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
                    string role = UserRepository.GetUserRole(id);

                    if (role == "Customer")
                    {
                        Response.Redirect("navigation.aspx");
                    }
                }
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            string type = TextBoxType.Text;
            MsSuplementType newType = ProductFactory.CreateSupplementType(type);
            ProductHandler.CreateType(newType);
            Response.Redirect("ManageSupplement.aspx");
        }
    }
}