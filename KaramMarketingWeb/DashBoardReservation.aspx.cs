using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class DashBoardReservation : System.Web.UI.Page
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
                        GetReserveReport("","","","");
                        DashBoard("", "", "", "");
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
                    string  Status = e.Row.Cells[5].Text;
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
                GetReserveReport("", "", "", "");
                DashBoard("", "", "", "");
            }
            catch(Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;

            }
        }

        [WebMethod]
        public static List<object> GraphReserve()
        {
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
            {
                    "Month", "Data"
            });
            try
            {
                clsReport cls = new clsReport();

                DataTable dtdetails = new DataTable();
                dtdetails = cls.GraphReserve();
                foreach (DataRow dr in dtdetails.Rows)
                {
                    chartData.Add(new object[]
                         {
                             dr["MonthWise"], dr["ReserveCount"]
                         });
                }

                return chartData;
            }
            catch (Exception ex)
            { 
                return chartData;
            }
        }

        [WebMethod]
        public static List<object> GraphCanellation()
        {
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
              {
                    "Month", "Data"
              });

            try
            {
                clsReport cls = new clsReport();

                DataTable dtdetails = new DataTable();
                dtdetails = cls.GraphReserveCancellation();
                foreach (DataRow dr in dtdetails.Rows)
                {
                    chartData.Add(new object[]
                         {
                             dr["MonthWise"], dr["ReserveCount"]
                         });
                }

                return chartData;
            }
            catch (Exception ex)
            {
                return chartData;
            }
        }

        protected void lvRMGateinDetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                UserName = Session["UserName"].ToString();

                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    Label lblReservationStatus = (Label)e.Item.FindControl("lblReservationStatus");
                    Image imgclose = (Image)e.Item.FindControl("imgclose");
                    Label lblSalesOrder = (Label)e.Item.FindControl("lblSalesOrder");

                    Label lblUser = (Label)e.Item.FindControl("lblUser");
                    string _Status = lblReservationStatus.Text.Trim();
                    string _SO = lblSalesOrder.Text.Trim();
                    string _User = lblUser.Text.Trim();

                    if (_Status.ToUpper() == "PENDING")
                    {
                        if (string.IsNullOrEmpty(_SO))
                        {
                            if (UserName.ToUpper() == _User.ToUpper())
                            {
                                imgclose.Visible = true;
                            }
                            else
                            {
                                imgclose.Visible = false;
                            }
                        }
                        else
                        {
                            imgclose.Visible = false;
                        }
                    }
                    else
                    {
                        imgclose.Visible = false;
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
        public void DashBoard(string User, string FromDate, string ToDate, string Status)
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

                lblReserved.Text = _Cls.DashBoardCount(User, fromdate, Todate, "").Rows[0]["Count"].ToString();
                lblProgress.Text = _Cls.DashBoardCount(User, fromdate, Todate, "In-Progress").Rows[0]["Count"].ToString();
                lblPending.Text = _Cls.DashBoardCount(User, fromdate, Todate, "Pending").Rows[0]["Count"].ToString();
                lblDispatch.Text = _Cls.DashBoardCount(User, fromdate, Todate, "Done").Rows[0]["Count"].ToString();
                lblExpired.Text = _Cls.DashBoardCount(User, fromdate, Todate, "Cancelled").Rows[0]["Count"].ToString();
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        public void GetReserveReport(string User, string FromDate , string ToDate , string Status)
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
                    fromdate = sp1[0] +"/"+ sp1[1] +"/"+ sp1[2];
                }
                if (!string.IsNullOrEmpty(txtTo.Value.ToString()))
                {
                    string To = txtTo.Value.ToString();
                    string[] sp1 = To.Split('-');
                    Todate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetReservationDashBoard(User, fromdate, Todate, Status);
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

        protected void btnReserved_Click(object sender, EventArgs e)
        {
            try
            {
                GetReserveReport("", txtFrom.Value.ToString(), txtTo.Value.ToString(), "");
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }

        }

        protected void btnExpired_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    GetReserveReport("", txtFrom.Value.ToString(), txtTo.Value.ToString(), "Cancelled");
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

        protected void btnDispatch_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    GetReserveReport("", txtFrom.Value.ToString(), txtTo.Value.ToString(), "Done");
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

        protected void btnPrnding_Click(object sender, EventArgs e)
        {
            
                try
                {
                    GetReserveReport("", txtFrom.Value.ToString(), txtTo.Value.ToString(), "Pending");
                }
                catch (Exception exe)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = exe.Message;
                }
            
        }

        protected void btnProgress_Click(object sender, EventArgs e)
        {
            try
            {
                GetReserveReport("", txtFrom.Value.ToString(), txtTo.Value.ToString(), "In-Progress");
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/CreateReservation.aspx", false);
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
    }
}