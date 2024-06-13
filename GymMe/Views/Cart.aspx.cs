using GymMe.Handler;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class Cart : System.Web.UI.Page
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
                if (role == "Admin")
                {
                    Response.Redirect("Navigation.aspx");
                }
                else
                {
                    int userID = Convert.ToInt32(id);
                    GridViewCart.DataSource = ProductRepository.GetUserCarts(userID);
                    GridViewCart.DataBind();
                }
            }
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderSupplement.aspx");
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Navigation.aspx");
        }

        protected void ButtonClearCart_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
            ProductHandler.ClearCart(userID);
            Response.Redirect("Cart.aspx");
        }

        protected void ButtonCheckout_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
            ProductHandler.CheckoutOrder(userID);
            Response.Redirect("OrderSupplement.aspx");
        }
    }
}