using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class DashBoardWareHouse : System.Web.UI.Page
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
                        
                        GetWareHouseReport(UserName, "", "", "NewOrders");
                        WareHOusecDashBoard(UserName, "", "", "");
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
        public string GetClassName(string Status)
        {
            if (Status.ToUpper() == "PENDING")
            {
                return "White";
            }
            else if (Status.ToUpper() == "IN-PROGRESS")
            {
                return "Orange";
            }
            else if (Status.ToUpper() == "DONE")
            {
                return "Green";
            }
            else if (Status.ToUpper() == "CANCELLED")
            {
                return "Red";
            }
            else
            {
                return "White";
            }
        }
       
        protected void gvInventoryOrderprogress_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string Status = e.Row.Cells[8].Text;
                    string setColorClass = string.Empty;
                    if (Status.ToUpper() == "PENDING")
                    {
                        setColorClass = "White";
                    }
                    if (Status.ToUpper() == "IN-PROGRESS")
                    {
                        setColorClass = "Orange";
                    }
                    if (Status.ToUpper() == "DONE")
                    {
                        setColorClass = "Green";
                    }
                    if (Status.ToUpper() == "CANCELLED")
                    {
                        setColorClass = "Red";
                    }
                    e.Row.CssClass = setColorClass;

                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetWareHouseReport("", "", "", "");
                WareHOusecDashBoard("", "", "", "");
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnTodayOrders_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    UserName = Session["UserName"].ToString();
                    GetWareHouseReport(UserName, txtFrom.Value.ToString(), txtTo.Value.ToString(), "TodayOrder");
                }
                catch (Exception exe)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = exe.Message;
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnWeekTDOD_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    UserName = Session["UserName"].ToString();
                    GetWareHouseReport(UserName, txtFrom.Value.ToString(), txtTo.Value.ToString(), "WeekOrder");
                }
                catch (Exception exe)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = exe.Message;
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnPendingOrders_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = Session["UserName"].ToString();
                GetWareHouseReport(UserName, txtFrom.Value.ToString(), txtTo.Value.ToString(), "Pending");
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void lvRMGateinDetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }

        protected void btnNewOrders_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = Session["UserName"].ToString();
                GetWareHouseReport(UserName, txtFrom.Value.ToString(), txtTo.Value.ToString(), "NewOrders");
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }


        public void WareHOusecDashBoard(string User, string FromDate, string ToDate, string Status)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                UserName = Session["UserName"].ToString();
                string fromdate = "";
                string Todate = "";
                if (!string.IsNullOrEmpty(txtFrom.Value.ToString()))
                {
                    string From = txtFrom.Value.ToString();
                    string[] sp1 = From.Split('-');
                    fromdate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }
                if (!string.IsNullOrEmpty(txtTo.Value.ToString()))
                {
                    string To = txtTo.Value.ToString();
                    string[] sp1 = To.Split('-');
                    Todate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }

                lblNewOrders.Text = _Cls.WareHouseDashBoardCount(UserName, fromdate, Todate, "NewOrders").Rows[0]["Count"].ToString();
                lblTodayOrder.Text = _Cls.WareHouseDashBoardCount(UserName, fromdate, Todate, "TodayOrder").Rows[0]["Count"].ToString();
                lblWeekTDOD.Text = _Cls.WareHouseDashBoardCount(UserName, fromdate, Todate, "WeekOrder").Rows[0]["Count"].ToString();
                lblPendingOrders.Text = _Cls.WareHouseDashBoardCount(UserName, fromdate, Todate, "Pending").Rows[0]["Count"].ToString();

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
        public void GetWareHouseReport(string User, string FromDate, string ToDate, string Status)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                UserName = Session["UserName"].ToString();
                string fromdate = "";
                string Todate = "";
                if (!string.IsNullOrEmpty(txtFrom.Value.ToString()))
                {
                    string From = txtFrom.Value.ToString();
                    string[] sp1 = From.Split('-');
                    fromdate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }
                if (!string.IsNullOrEmpty(txtTo.Value.ToString()))
                {
                    string To = txtTo.Value.ToString();
                    string[] sp1 = To.Split('-');
                    Todate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.WareHouseDashBoardNew(UserName, fromdate, Todate, Status);
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
    }
}