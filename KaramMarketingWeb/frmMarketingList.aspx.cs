using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class frmMarketingList : System.Web.UI.Page
    {
        clsReport _Cls = new clsReport();
        clsBusinesslayer objbusinesslayer = new clsBusinesslayer();
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
                        BindRegion();
                        GetReserveReport();
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
        public void GetReserveReport()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetReservationDashBoard("", "", "", "All" ,"All");
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

        protected void btnSearch_Click(object sender, EventArgs e)
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
                string Status = ddlStatus.SelectedValue.ToString();
                string Region = ddlRegion.SelectedValue.ToString();

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetReservationDashBoard(UserName, fromdate, Todate, Status , Region);
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
                            if(UserName.ToUpper() == _User.ToUpper())
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


        public void BindRegion()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if (ddlRegion.Items.Count > 0)
                {
                    ddlRegion.Items.Clear();
                }
                DataTable dtroles = new DataTable();
                dtroles = objbusinesslayer.spGetRegionsReservation_Web();
                if (dtroles != null)
                {
                    if (dtroles.Rows.Count > 0)
                    {
                        ddlRegion.DataSource = dtroles;
                        ddlRegion.DataValueField = "Region";
                        ddlRegion.DataTextField = "Region";
                        ddlRegion.DataBind();
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