using GymMe.Dataset;
using GymMe.Report;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class TransactionReport : System.Web.UI.Page
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
                        CrystalReport report = new CrystalReport();
                        CrystalReportViewer1.ReportSource = report;
                        DataSet data = ProductRepository.GetReports();
                        report.SetDataSource(data);
                    }
                    else if (role == "Customer")
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
    }
}