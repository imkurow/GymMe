using GymMe.Controllers;
using GymMe.Factories;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class OrderSupplement : System.Web.UI.Page
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
                        Response.Redirect("Navigation.aspx");
                    }
                    else
                    {
                        DropDownListSupName.DataSource = ProductRepository.GetSupplementNames();
                        DropDownListSupName.DataBind();
                        GridViewSupplement.DataSource = ProductRepository.GetSupplements();
                        GridViewSupplement.DataBind();
                    }
                }
            }
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Navigation.aspx");
        }

        protected void LinkButtonCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void ButtonOrder_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
            string SupplementName = DropDownListSupName.SelectedValue;
            int supID = ProductRepository.GetSupplementID(SupplementName);
            int Quantity = Convert.ToInt32(TextBoxQuantity.Text);
            if (!ProductController.isValidQuantity(Quantity))
            {
                LabelQuantityError.Text = "Quantity must be more than 0";
            }
            else
            {
                MsCart newCart = ProductFactory.CreateCart(userID, supID, Quantity);
                ProductRepository.InsertCart(newCart);
                Response.Redirect("OrderSupplement.aspx");
            }
        }
    }
}