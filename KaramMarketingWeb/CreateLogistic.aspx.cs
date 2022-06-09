using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class CreateLogistic : System.Web.UI.Page
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
                        string ReserveID = Request.QueryString["Id"];
                        string So = Request.QueryString["So"];
                        string SalesOrder = So.Trim();

                        if(ReserveID.Trim() == "-")
                        {
                            panelReservation.Visible = false;
                            panelSalesorder.Visible = true;
                            lblReservation.Value = "Un-Reserved SalesOrder";
                            GetSalesorderDetails(SalesOrder);
                            GetSalesorderDetailsDatatable(SalesOrder);
                        }
                        else
                        {
                            lblReservation.Value = ReserveID.Trim();
                            BinddataNew(ReserveID.Trim());
                            BinddataGrid(ReserveID.Trim());

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
        private void BinddataGrid(string _ReserveID)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetLogisticData(_ReserveID);
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        lvMatdetails.DataSource = dtdetails;
                        lvMatdetails.DataBind();

                    }
                    else
                    {
                        lvMatdetails.DataSource = dtdetails;
                        lvMatdetails.DataBind();
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        private void BinddataNew(string _ReserveID)
        {
            try
            {
                string LogisticStatus = "";
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetLogisticDetails(_ReserveID);
                if (dtdetails != null)
                {
                   
                    if (dtdetails.Rows.Count > 0)
                    {
                        txtDemandDate.Value = dtdetails.Rows[0]["DemandDate"].ToString();
                        lblSalesOrder.Value = dtdetails.Rows[0]["SalesOrder"].ToString();
                        lblSoDate.Value = dtdetails.Rows[0]["SalesOrderDate"].ToString();
                        lblCustomer.Value = dtdetails.Rows[0]["CustomerName"].ToString();
                        lblMTDOD.Value = dtdetails.Rows[0]["MTDOD"].ToString();
                        LogisticStatus = dtdetails.Rows[0]["LogisticReservationStatus"].ToString();
                    }
                }
                if(LogisticStatus.ToUpper() != "PENDING")
                {
                    pnlRemarks.Visible = true;
                }
                else
                {
                    pnlRemarks.Visible = false;
                }
                lblReservation.Disabled = true;
                txtDemandDate.Disabled = false;
                lblSalesOrder.Disabled = true;
                lblSoDate.Disabled = true;
                lblCustomer.Disabled = true;
                lblMTDOD.Disabled = true;
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        private void GetSalesorderDetails(string SalesOrder)
        {
            try
            {
                string LogisticStatus = "";

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetLogisticDetailsForSalesOrder(SalesOrder);
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        txtDemandDate.Value = dtdetails.Rows[0]["DemandDate"].ToString();
                        lblSalesOrder.Value = dtdetails.Rows[0]["SO_SalesOrder"].ToString();
                        lblSoDate.Value = dtdetails.Rows[0]["Sodate"].ToString();
                        lblCustomer.Value = dtdetails.Rows[0]["SO_Customer"].ToString();
                        lblMTDOD.Value = dtdetails.Rows[0]["MarketingDate"].ToString();
                        LogisticStatus = dtdetails.Rows[0]["LogisticReservationStatus"].ToString();
                    }
                }
                if (LogisticStatus.ToUpper() != "PENDING")
                {
                    pnlRemarks.Visible = true;
                }
                else
                {
                    pnlRemarks.Visible = false;
                }
                lblReservation.Disabled = true;
                lblSalesOrder.Disabled = true;
                lblSoDate.Disabled = true;
                lblCustomer.Disabled = true;
                lblMTDOD.Disabled = true;
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        private void GetSalesorderDetailsDatatable(string SalesOrder)
        {
            try
            {
                if (string.IsNullOrEmpty(SalesOrder))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Select a Sales Order";
                    return;
                }

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetSalesOrderItem(SalesOrder);
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        lvSalesOrder.DataSource = dtdetails;
                        lvSalesOrder.DataBind();

                    }
                    else
                    {
                        lvSalesOrder.DataSource = dtdetails;
                        lvSalesOrder.DataBind();
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string ReserveID = Request.QueryString["Id"];
                string So = Request.QueryString["So"];
                string SalesOrder = So.Trim();


                string DemandDate = null;
                if (!string.IsNullOrEmpty(txtDemandDate.Value))
                {
                    string[] sp1 = txtDemandDate.Value.Split('-');
                    DemandDate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }

                if (ReserveID == "-")
                {
                    UserName = Session["UserName"].ToString();
                    ErrorMsg.Style.Value = "display:none";
                    lblMessage.Text = "";
                    string NewReservationID = "";
                    DataTable dtReservation = new DataTable();
                    dtReservation = _Cls.GetReservationID(UserName.Trim());
                    if (dtReservation != null)
                    {
                        if (dtReservation.Rows.Count > 0)
                        {
                            NewReservationID = dtReservation.Rows[0]["ReserveID"].ToString();
                            NewReservationID = "UN-" + NewReservationID;
                        }
                    }

                    _Cls.AddSalesOrderWithReservation( NewReservationID, SalesOrder, UserName , DemandDate);

                    if (lvSalesOrder.Items.Count > 0)
                    {
                        bool _isProductsselected = false;
                        string NewLogisticID = "";
                        DataTable dtdetails = new DataTable();
                        dtdetails = _Cls.GetLogisticID(UserName.Trim());
                        if (dtdetails != null)
                        {
                            if (dtdetails.Rows.Count > 0)
                            {
                                NewLogisticID = dtdetails.Rows[0]["LogisticID"].ToString();
                            }

                            if (!string.IsNullOrEmpty(NewLogisticID))
                            {

                                for (int i = 0; i < lvSalesOrder.Items.Count; i++)
                                {
                                    CheckBox chkproduct = (CheckBox)lvSalesOrder.Items[i].FindControl("chkSelectSalesOrder");
                                    if (chkproduct.Checked == true)
                                    {
                                        _isProductsselected = true;

                                        Label lblItemCode = (Label)lvSalesOrder.Items[i].FindControl("lblItemCode1");

                                        _Cls.UpdateLogistic(NewLogisticID.Trim(), NewReservationID.Trim(), DemandDate ,lblItemCode.Text.Trim(), UserName );
                                    }
                                }
                                if (_isProductsselected == false)
                                {
                                    ErrorMsg.Style.Value = "display:none";
                                    lblMessage.Text = "Please Select Atleast one Item";
                                    return;
                                }
                                else
                                {
                                    lblMsg.Style.Value = "display:block";
                                    lblMessage1.Text = "Item Codes Updated for Sales Order";

                                    ErrorMsg.Style.Value = "display:none";
                                    lblMessage.Text = "Item Codes Updated";
                                  //  BinddataGrid(ReserveID);
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {

                    UserName = Session["UserName"].ToString();
                    ErrorMsg.Style.Value = "display:none";
                    lblMessage.Text = "";

                    if(pnlRemarks.Visible == true )
                    {
                        _Cls.UpdateLogisticTDOD(ReserveID.Trim(), DemandDate , txtRemarks.Text , UserName);

                        lblMsg.Style.Value = "display:block";
                        lblMessage1.Text = "Revised TDOD and Remarks Updated Successfully";

                    }

                    if (lvMatdetails.Items.Count > 0)
                    {
                        bool _isProductsselected = false;
                        string NewLogisticID = "";
                        DataTable dtdetails = new DataTable();
                        dtdetails = _Cls.GetLogisticID(UserName.Trim());
                        if (dtdetails != null)
                        {
                            if (dtdetails.Rows.Count > 0)
                            {
                                NewLogisticID = dtdetails.Rows[0]["LogisticID"].ToString();
                            }

                            if (!string.IsNullOrEmpty(NewLogisticID))
                            {

                                for (int i = 0; i < lvMatdetails.Items.Count; i++)
                                {
                                    CheckBox chkproduct = (CheckBox)lvMatdetails.Items[i].FindControl("chkSelect");
                                    if (chkproduct.Checked == true)
                                    {
                                        _isProductsselected = true;

                                        Label lblItemCode = (Label)lvMatdetails.Items[i].FindControl("lblItemCode");


                                        _Cls.UpdateLogistic(NewLogisticID.Trim(), ReserveID.Trim(), DemandDate, lblItemCode.Text.Trim(), UserName  );
                                    }
                                }
                                if (_isProductsselected == false)
                                {
                                    ErrorMsg.Style.Value = "display:none";
                                    lblMessage.Text = "Please Select Atleast one Item";
                                    return;
                                }
                                else
                                {
                                    lblMsg.Style.Value = "display:block";
                                    lblMessage1.Text = "Item Codes Updated for Reservation ID";

                                    ErrorMsg.Style.Value = "display:none";
                                    lblMessage.Text = "Item Codes Updated";
                                    BinddataGrid(ReserveID);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                CheckBox chckheader = (CheckBox)lvMatdetails.FindControl("chkHeader");
                for (int i = 0; i < lvMatdetails.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)lvMatdetails.Items[i].FindControl("chkSelect");
                    if (chckheader.Checked == true)
                    {
                        chk.Checked = false;
                    }
                }
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
                Response.Redirect("~/frmLogisticList.aspx", false);
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                CheckBox chckheader = (CheckBox)lvMatdetails.FindControl("chkHeader");
                for (int i = 0; i < lvMatdetails.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)lvMatdetails.Items[i].FindControl("chkSelect");
                    if (chckheader.Checked == true)
                    {
                        chk.Checked = true;
                    }
                    else
                    {
                        chk.Checked = false;
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void lvSalesOrder_ItemDataBound(object sender, ListViewItemEventArgs e)
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

        protected void chkHeaderSalesOrder_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                CheckBox chkHeaderSalesOrder = (CheckBox)lvSalesOrder.FindControl("chkHeaderSalesOrder");
                for (int i = 0; i < lvSalesOrder.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)lvSalesOrder.Items[i].FindControl("chkSelectSalesOrder");
                    if (chkHeaderSalesOrder.Checked == true)
                    {
                        chk.Checked = true;
                    }
                    else
                    {
                        chk.Checked = false;
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