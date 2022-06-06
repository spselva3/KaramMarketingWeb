using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class AddSalesOrder : System.Web.UI.Page
    {
        clsReserve _Cls = new clsReserve();
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
                        string DateValue = DateTime.Now.ToString("dd/MM/yyyy");

                        try
                        {
                           
                        }
                        catch (Exception exe)
                        {
                            ErrorMsg.Style.Value = "display:block";
                            lblMessage.Text = exe.Message;
                        }
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

        protected void btnSearchSO_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if(string.IsNullOrEmpty(txtSalesOrder.Text))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Select a Sales Order";
                    return;
                }

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetSalesOrderItem(txtSalesOrder.Text);
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        lvProductdetails.DataSource = dtdetails;
                        lvProductdetails.DataBind();

                    }
                    else
                    {
                        lvProductdetails.DataSource = dtdetails;
                        lvProductdetails.DataBind();
                    }
                }

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void lvProductdetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if (lvProductdetails.Items.Count == 0)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please select a valid Sales Order";
                    return;
                }

                if (string.IsNullOrEmpty(txtReservationID.Text))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Generate a Reservation ID";
                    return;
                }
               // _Cls.AddSalesOrderWithReservation(txtReservationID.Text, txtSalesOrder.Text.Trim(), UserName);

                lblMsg.Style.Value = "display:block";
                lblMessage1.Text = "Reservation ID Generated : " + txtReservationID.Text;

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                Response.Redirect("~/frmLogisticList.aspx", false);
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnGenerateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                string NewReservationID = "";
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetReservationID(UserName.Trim());
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        NewReservationID = dtdetails.Rows[0]["ReserveID"].ToString();
                        txtReservationID.Text = NewReservationID;
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetSalesOrder(string prefixText)
        {
            clsReserve cls = new clsReserve();
            DataTable dtt = cls.GetSo(prefixText);
            List<string> Output = new List<string>();
            foreach (DataRow dtrow in dtt.Rows)
            {
                string str = dtrow["SalesOrder"].ToString();
                Output.Add(str);
            }
            return Output;
        }
    }
}