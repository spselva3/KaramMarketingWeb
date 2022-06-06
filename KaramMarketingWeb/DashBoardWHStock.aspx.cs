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
    public partial class DashBoardWHStock : System.Web.UI.Page
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
                        DashBoardReport();
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


                lblFilled.Text = _Cls.GetWareHouseStock("FilledStock").Rows[0]["StockValue"].ToString();
                lblStock.Text = _Cls.GetWareHouseStock("StockValue").Rows[0]["StockValue"].ToString();
                lblWHItem.Text = _Cls.GetWareHouseStock("WarehouseItems").Rows[0]["StockValue"].ToString();
                lblnonWH.Text = _Cls.GetWareHouseStock("Non-WarehouseItems").Rows[0]["StockValue"].ToString();

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        public void DashBoardReport()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                UserName = Session["UserName"].ToString();

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetWareHouseStock("Report");
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
        protected void btnFilled_Click(object sender, EventArgs e)
        {

        }

        protected void btnStock_Click(object sender, EventArgs e)
        {

        }

        protected void btnWHItem_Click(object sender, EventArgs e)
        {

        }

        protected void btnNonWHItem_Click(object sender, EventArgs e)
        {

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
                dtdetails = cls.GetWareHouseStock("CategoryWiseStock");

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

    }
}