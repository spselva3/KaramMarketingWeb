using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class DashBoardDeadStock : System.Web.UI.Page
    {
        clsReport _Cls = new clsReport();
        string UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if (Session["UserName"] != null)
                {
                    UserName = Session["UserName"].ToString();
                    if (!IsPostBack)
                    {
                        DashBoardCount();
                        DashBoardReport("DeatStockReport");
                        lblReportName.Text = "Dead Stock Report";
                    }
                }
                else
                {
                    Response.Redirect("frmSessionOut.aspx");
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        public void DashBoardCount()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                UserName = Session["UserName"].ToString();

                lblDeadStock.Text = _Cls.GetDeadStock("DeatStock").Rows[0]["StockValue"].ToString();
                lblSlowMoving.Text = _Cls.GetDeadStock("SlowMoving").Rows[0]["StockValue"].ToString();
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        public void DashBoardReport(string Type)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                UserName = Session["UserName"].ToString();

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetDeadStock(Type);
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        lvRMGateinDetails.DataSource = dtdetails;
                        lvRMGateinDetails.DataBind();
                    }
                    else
                    {
                        lvRMGateinDetails.DataSource = dtdetails;
                        lvRMGateinDetails.DataBind();
                    }
                }

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        [WebMethod]
        public static List<object> CategoryWiseStock()
        {
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
              {
                    "Month" , "Data"
              });

            try
            {
                clsReport cls = new clsReport();

                DataTable dtdetails = new DataTable();
                dtdetails = cls.GetDeadStock("CategoryWise");

                foreach (DataRow dr in dtdetails.Rows)
                {
                    chartData.Add(new object[]
                         {
                             dr["Category"], dr["StockValue"]
                         });
                }

                return chartData;
            }
            catch (Exception ex)
            {
                return chartData;
            }
        }

        protected void btnSlow_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                DashBoardReport("SlowMovingkReport");
                lblReportName.Text = "Slow Moving Report";
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnDeadStock_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                DashBoardReport("DeatStockReport");
                lblReportName.Text = "Dead Stock Report";
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
    }
}