using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class CreateWHList : System.Web.UI.Page
    {
        clsReserve _Cls = new clsReserve();
        string UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    ErrorMsg.Style.Value = "display:none";
                    lblMessage.Text = "";

                    UserName = Session["UserName"].ToString();
                    if (!IsPostBack)
                    {
                        string ReserveID = Request.QueryString["Id"];
                        string So = Request.QueryString["So"];
                        string SalesOrder = So.Trim();

                        if (ReserveID.StartsWith("UN-"))
                        {
                            BinddataNew(ReserveID.Trim(), SalesOrder);
                            UnReserve_BinddataGrid(ReserveID.Trim(), SalesOrder);
                        }
                        else
                        {
                            BinddataNew(ReserveID.Trim(), SalesOrder);
                            BinddataGrid(ReserveID.Trim(), SalesOrder);
                            btnProduction.Visible = false;
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

        private void LoadData()
        {
            try
            {
                string ReserveID = Request.QueryString["Id"];
                string So = Request.QueryString["So"];
                string SalesOrder = So.Trim();

                if (ReserveID.StartsWith("UN-"))
                {
                    UnReserve_BinddataGrid(ReserveID.Trim(), SalesOrder);
                }
                else
                {
                    BinddataGrid(ReserveID.Trim(), SalesOrder);
                    btnProduction.Visible = false;
                }

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnDateUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvMatdetails.Items.Count; i++)
                {
                    TextBox txtWHDate = (TextBox)lvMatdetails.Items[i].FindControl("txtWHDate");
                    string WHDate = "";
                    if (!string.IsNullOrEmpty(txtWHTDODate.Text))
                    {
                        if (txtWHTDODate.Text.Contains('-'))
                        {
                            string[] sp1 = txtWHTDODate.Text.Split('-');
                            WHDate = sp1[2] + "-" + sp1[1] + "-" + sp1[0];
                        }
                    }
                    txtWHDate.Text = WHDate;
                }

                lblDemandDate.Value = txtWHTDODate.Text;
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
        private void BinddataNew(string _ReserveID, string SalesOrder)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                lblReservation.Value = _ReserveID;
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetWHDetails(_ReserveID, SalesOrder);
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        string _Date = dtdetails.Rows[0]["WHTDOD"].ToString();
                        lblDemandDate.Value = dtdetails.Rows[0]["WHTDOD"].ToString();
                        lblSalesOrder.Value = dtdetails.Rows[0]["SalesOrder"].ToString();
                        lblSoDate.Value = dtdetails.Rows[0]["SalesOrderDate"].ToString();
                        lblCustomer.Value = dtdetails.Rows[0]["CustomerName"].ToString();
                        lblMTDOD.Value = dtdetails.Rows[0]["LogTDOD"].ToString();

                        if(!string.IsNullOrEmpty(_Date))
                        {
                            pnlRemarks.Visible = true;
                        }
                        else
                        {
                            pnlRemarks.Visible = false;
                        }
                        lblDemandDate.Disabled = false;
                        lblSalesOrder.Disabled = true;
                        lblSoDate.Disabled = true;
                        lblCustomer.Disabled = true;
                        lblMTDOD.Disabled = true;
                        lblReservation.Disabled = true;
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
        protected void btnLogistics_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = Session["UserName"].ToString();
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                string ReserveID = Request.QueryString["Id"];

                string DemandDate = "";
                if (!string.IsNullOrEmpty(lblDemandDate.Value))
                {
                    string[] sp1 = lblDemandDate.Value.Split('-');
                    DemandDate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }
                if (pnlRemarks.Visible == true)
                {
                    _Cls.UpdateWHTDOD(ReserveID.Trim(), DemandDate, txtRemarks.Text, UserName);

                    lblMsg.Style.Value = "display:block";
                    lblMessage1.Text = "Revised TDOD and Remarks Updated Successfully";

                }
                if (lvMatdetails.Items.Count > 0)
                {
                    bool checkExist = false;
                    for (int i = 0; i < lvMatdetails.Items.Count; i++)
                    {
                        CheckBox chkproduct = (CheckBox)lvMatdetails.Items[i].FindControl("chkSelect");
                        {
                            if (chkproduct.Checked == true)
                            {
                                checkExist = true;
                            }
                        }
                    }
                    if (checkExist == false)
                    {
                        ErrorMsg.Style.Value = "display:block";
                        lblMessage.Text = "No Items selected";
                        return;
                    }
                }
              
                string NewWHID = "";
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetWHId(UserName.Trim());
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        NewWHID = dtdetails.Rows[0]["WHID"].ToString();
                    }
                    for (int i = 0; i < lvMatdetails.Items.Count; i++)
                    {
                        CheckBox chkproduct = (CheckBox)lvMatdetails.Items[i].FindControl("chkSelect");
                        {
                            if (chkproduct.Checked == true)
                            {
                                Label lblItemCode = (Label)lvMatdetails.Items[i].FindControl("lblItemCode");
                                Label lblItemDesc = (Label)lvMatdetails.Items[i].FindControl("lblItemDesc");
                                Label lblCategory = (Label)lvMatdetails.Items[i].FindControl("lblCategory");
                                Label lblUOM = (Label)lvMatdetails.Items[i].FindControl("lblUOM");
                                Label lblAvailableQty = (Label)lvMatdetails.Items[i].FindControl("lblAvailableQty");
                                Label lblDemandQty = (Label)lvMatdetails.Items[i].FindControl("lblDemandQty");
                                TextBox txtWHDate = (TextBox)lvMatdetails.Items[i].FindControl("txtWHDate");

                                string WHDate = "";
                                if (!string.IsNullOrEmpty(txtWHDate.Text))
                                {
                                    string[] sp1 = txtWHDate.Text.Split('-');
                                    WHDate = sp1[2] + "/" + sp1[1] + "/" + sp1[0];
                                }
                                _Cls.UpdateWHData(NewWHID.Trim(), lblReservation.Value.Trim(), lblItemCode.Text, lblItemDesc.Text,
                                    lblCategory.Text, lblUOM.Text, lblDemandQty.Text, WHDate, UserName);

                            }
                        }
                    }
                    //ErrorMsg.Style.Value = "display:block";
                    //lblMessage.Text = "ItemCodes Updated Successfully";

                    lblMsg.Style.Value = "display:block";
                    lblMessage1.Text = "ItemCodes Updated Successfully";

                    LoadData();
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnProduction_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = Session["UserName"].ToString();
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                string So = Request.QueryString["So"];
                string SalesOrder = So.Trim();
                string ReserveID = Request.QueryString["Id"];
                string DemandDate = "";
                if (!string.IsNullOrEmpty(lblDemandDate.Value))
                {
                    string[] sp1 = lblDemandDate.Value.Split('-');
                    DemandDate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }

                _Cls.UpdateWHResivedTDOD(ReserveID.Trim(), DemandDate, txtRemarks.Text, UserName);

                if (lvMatdetails.Items.Count > 0)
                {
                    bool checkExist = false;
                    for (int i = 0; i < lvMatdetails.Items.Count; i++)
                    {
                        CheckBox chkproduct = (CheckBox)lvMatdetails.Items[i].FindControl("chkSelect");
                        {
                            if (chkproduct.Visible == true)
                            {
                                checkExist = true;
                            }
                        }
                    }
                    if (checkExist == false)
                    {
                        ErrorMsg.Style.Value = "display:block";
                        lblMessage.Text = "No Items Available for sending to production";
                        return;
                    }
                }
                string NewProductionID = "";
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetProdId(UserName.Trim());
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        NewProductionID = dtdetails.Rows[0]["ProdID"].ToString();
                    }
                    for (int i = 0; i < lvMatdetails.Items.Count; i++)
                    {
                        CheckBox chkproduct = (CheckBox)lvMatdetails.Items[i].FindControl("chkSelect");
                        {
                            if (chkproduct.Visible == true)
                            {
                                if (chkproduct.Checked == true)
                                {
                                    Label lblItemCode = (Label)lvMatdetails.Items[i].FindControl("lblItemCode");
                                    Label lblItemDesc = (Label)lvMatdetails.Items[i].FindControl("lblItemDesc");
                                    Label lblCategory = (Label)lvMatdetails.Items[i].FindControl("lblCategory");
                                    Label lblUOM = (Label)lvMatdetails.Items[i].FindControl("lblUOM");
                                    Label lblAvailableQty = (Label)lvMatdetails.Items[i].FindControl("lblAvailableQty");
                                    Label lblDemandQty = (Label)lvMatdetails.Items[i].FindControl("lblDemandQty");
                                    Label lblWhStatus = (Label)lvMatdetails.Items[i].FindControl("lblWhStatus");

                                    TextBox txtWHDate = (TextBox)lvMatdetails.Items[i].FindControl("txtWHDate");


                                    if(lblWhStatus.Text.ToUpper() == "PRODUCTION-PENDING")
                                    {
                                        ErrorMsg.Style.Value = "display:block";
                                        lblMessage.Text = "Please Unselect the Production Pending Line item";
                                        return;
                                    }

                                    string WHDate = "";
                                    if (!string.IsNullOrEmpty(txtWHDate.Text))
                                    {
                                        string[] sp1 = txtWHDate.Text.Split('-');
                                        WHDate = sp1[2] + "/" + sp1[1] + "/" + sp1[0];
                                    }

                                    double _AvailQty = double.Parse(lblAvailableQty.Text);
                                    double _DemandQty = double.Parse(lblDemandQty.Text);
                                    double ReqQty = 0;

                                    if (_AvailQty > _DemandQty)
                                    {
                                        ReqQty = _DemandQty;
                                    }
                                    else if(_AvailQty == _DemandQty)
                                    {
                                        ReqQty = _DemandQty;
                                    }
                                    else
                                    {
                                        ReqQty = _DemandQty - _AvailQty;
                                    }
                                    _Cls.RequestProduction(NewProductionID.Trim(), lblReservation.Value.Trim(), lblItemCode.Text, lblItemDesc.Text,
                                        lblCategory.Text, lblUOM.Text, ReqQty.ToString(), UserName, SalesOrder , WHDate);

                                }
                            }
                        }
                    }

                    lblMsg.Style.Value = "display:block";
                    lblMessage1.Text = "ItemCodes Updated to Production Team Successfully";

                    LoadData();
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
                Response.Redirect("~/frmWHList.aspx", false);
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
        private void BinddataGrid(string _ReserveID , string SalesOrder)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                lblReservation.Value = _ReserveID;
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetWHData(_ReserveID , SalesOrder);
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


        private void UnReserve_BinddataGrid(string _ReserveID, string SalesOrder)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                lblReservation.Value = _ReserveID;
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetWHData_UnReserve(_ReserveID, SalesOrder);
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
        protected void lvMatdetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                string ReserveID = Request.QueryString["Id"];
                string So = Request.QueryString["So"];
                string SalesOrder = So.Trim();
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    Label lblItemCode = (Label)e.Item.FindControl("lblItemCode");
                    Label lblAvailableQty = (Label)e.Item.FindControl("lblAvailableQty");
                    Label lblDemandQty = (Label)e.Item.FindControl("lblDemandQty");
                    Label lblFloor = (Label)e.Item.FindControl("lblFloor");
                    CheckBox chkSelect = (CheckBox)e.Item.FindControl("chkSelect");
                    TextBox WHDate = (TextBox)e.Item.FindControl("txtWHDate");  //lblWhStatus
                    Label lblWhStatus = (Label)e.Item.FindControl("lblWhStatus");

                    string _ItemCode = lblItemCode.Text.Trim();
                    double _DemandQty = double.Parse(lblDemandQty.Text);
                    if (ReserveID.StartsWith("UN-"))
                    {
                        if(lblWhStatus.Text.ToUpper().Trim() == "DONE")
                        {
                            WHDate.Visible = false;
                            chkSelect.Visible = false;

                        }
                        else
                        {
                            //  string DateValue = DateTime.Now.ToString("yyyy-MM-dd");
                            //  WHDate.Text = DateValue.ToString();
                            //if (!string.IsNullOrEmpty(lblDemandDate.Value))
                            //{
                            //    string[] sp1 = lblDemandDate.Value.Split('-');
                            //    string DemandDate = sp1[2] + "-" + sp1[1] + "-" + sp1[0];
                            //    WHDate.Text = DemandDate;
                            //}
                            WHDate.Visible = true;
                            WHDate.ReadOnly = true;
                            chkSelect.Visible = true;
                        }

                        //    double _AvailQty = double.Parse(lblAvailableQty.Text);
                        //if (_AvailQty >= _DemandQty)
                        //{
                            
                        //    WHDate.Visible = true;
                        //    chkSelect.Visible = true;
                        //    lblFloor.Visible = true;
                        //}
                        //else
                        //{
                        //    WHDate.Visible = true;
                        //    chkSelect.Visible = true;
                        //    lblFloor.Visible = true;
                        //}
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