using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class DeliveryPlanReport : System.Web.UI.Page
    {
        clsPlan _Cls = new clsPlan();
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
                        GetDeliveryPlan();
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

        public void GetDeliveryPlan()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetDeliveryPlan("", "", "", "Pending");
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

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetDeliveryPlan(UserName, fromdate, Todate, Status);
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