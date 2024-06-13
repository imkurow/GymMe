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
    public partial class TransactionQueue : System.Web.UI.Page
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
                    GridViewQueue.DataSource = ProductRepository.GetTransactionsQueue();
                    GridViewQueue.DataBind();
                }
            }
        }

        protected void GridViewQueue_SelectedIndexChanged(object sender, EventArgs e)
        {
            int transID = Convert.ToInt32(GridViewQueue.SelectedRow.Cells[1].Text);
            ProductHandler.HandleTransactionStatus(transID);
            Response.Redirect("TransactionQueue.aspx");
        }

        protected void LinkButtonNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("Navigation.aspx");
        }
    }
}