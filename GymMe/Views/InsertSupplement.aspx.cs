using GymMe.Controllers;
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
    public partial class InsertSupplement : System.Web.UI.Page
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
                        List<String> types = ProductRepository.GetSupplementTypes();
                        DropDownListType.DataSource = types;
                        DropDownListType.DataBind();
                    }
                    else
                    {
                        Response.Redirect("navigation.aspx");
                    }
                }
            }
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Navigation.aspx");
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            int isvalid = 1;
            string suppName = TextBoxSuplement.Text;
            DateTime suppExpDate = CalendarExpiry.SelectedDate;
            int price = Convert.ToInt32(TextBoxPrice.Text);
            string type = DropDownListType.SelectedValue;

            if (suppName.Equals(""))
            {
                LabelSupError.Text = "Supplement name must be filled";
                isvalid = 0;
            }
            if (!ProductController.isContainSupplement(suppName))
            {
                LabelSupError.Text = "Supplement name must contain 'Supplement'";
                isvalid = 0;
            }
            if (price < 0)
            {
                LabelPriceError.Text = "Price must be positive";
                isvalid = 0;
            }
            if (!ProductController.isValidPrice(price))
            {
                LabelPriceError.Text = "Price minimum is 3000";
                isvalid = 0;
            }
            if (!ProductController.isGreaterThanToday(suppExpDate))
            {
                LabelExpiryError.Text = "Expiry date must be greater than today";
                isvalid = 0;
            }
            if (isvalid == 1)
            {
                int TypeId = ProductRepository.GetTypeId(type);
                MsSuplement sup = ProductFactory.CreateSupplement(suppName, price, suppExpDate, TypeId);
                ProductHandler.InsertSupplement(sup);
                Response.Redirect("ManageSupplement.aspx");
            }
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSupplement.aspx");
        }
    }
}