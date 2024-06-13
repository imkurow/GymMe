using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class TransactionDetail : System.Web.UI.Page
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
                    int transID = Convert.ToInt32(Request.QueryString["transID"]);
                    GridViewDetail.DataSource = ProductRepository.GetTransactionsDetails(transID);
                    GridViewDetail.DataBind();
                }
            }
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx");
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Navigation.aspx");
        }
    }
}