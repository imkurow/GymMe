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
                        AdminChoice.Visible = true;
                        GridViewAdmin.DataSource = ProductRepository.HistoryAdmins();
                        GridViewAdmin.DataBind();
                    }
                    else if (role == "Customer")
                    {
                        CustomerChoice.Visible = true;
                        int userID = Convert.ToInt32(id);
                        GridViewCustomer.DataSource = ProductRepository.HistoryCustomers(userID);
                        GridViewCustomer.DataBind();
                    }

                }
            }
        }
        protected void GridViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            int selectedIndex = gridView.SelectedIndex;
            string transID = gridView.Rows[selectedIndex].Cells[0].Text;
            Response.Redirect("TransactionDetail.aspx?transID=" + transID);
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Navigation.aspx");
        }
    }
}