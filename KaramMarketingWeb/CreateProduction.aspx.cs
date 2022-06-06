using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class CreateProduction : System.Web.UI.Page
    {
        clsReserve _Cls = new clsReserve();
        clsReport _ClsReport = new clsReport();
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
                        string ProductionID = Request.QueryString["Id"];
                        string So = Request.QueryString["So"];
                        string SalesOrder = So.Trim();

                            BinddataNew(ProductionID.Trim(), SalesOrder);
                            BinddataGrid(ProductionID.Trim(), SalesOrder);
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

        private void BinddataNew(string ProductionID, string SalesOrder)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                lblProductionID.Value = ProductionID;
                lblSalesOrder.Value = SalesOrder;

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetProdDetails(ProductionID, SalesOrder);

                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        string _DateValue = dtdetails.Rows[0]["ProdTDOD"].ToString();

                        txtRequetsedtdod.Value = dtdetails.Rows[0]["RequestedDate"].ToString();
                        lblReqQty.Value = dtdetails.Rows[0]["RequestedQty"].ToString();

                        lblStatus.Value = dtdetails.Rows[0]["ReserveStatus"].ToString();
                        lblProdDate.Value = dtdetails.Rows[0]["ProdTDOD"].ToString();

                        if(string.IsNullOrEmpty(_DateValue))
                        {
                            pnlRemarks.Visible = false;
                        }
                        else
                        {
                            pnlRemarks.Visible = true;
                        }

                        lblProductionID.Disabled = true;
                        lblSalesOrder.Disabled = true;
                        lblProdDate.Disabled = false;
                        txtRequetsedtdod.Disabled = true;
                        lblReqQty.Disabled = true;
                        lblStatus.Disabled = true;
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        private void BinddataGrid(string ProductionID, string SalesOrder)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetProductionData(ProductionID, SalesOrder, Session["UserName"].ToString());
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

        protected void btnDateUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lvMatdetails.Items.Count; i++)
                {
                    TextBox txtWHDate = (TextBox)lvMatdetails.Items[i].FindControl("txtWHDate");
                    txtWHDate.Text = txtWHTDODate.Text;

                }
                string WHDate = "";
                if (!string.IsNullOrEmpty(txtWHTDODate.Text))
                {
                    if (txtWHTDODate.Text.Contains('-'))
                    {
                        string[] sp1 = txtWHTDODate.Text.Split('-');
                        WHDate = sp1[2] + "-" + sp1[1] + "-" + sp1[0];
                    }
                }
                lblProdDate.Value = txtWHTDODate.Text;

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
                string _ProdTDOD = lblProdDate.Value.Trim();

                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    TextBox txtWHDate = (TextBox)e.Item.FindControl("txtWHDate");
                    LinkButton lnkDone = (LinkButton)e.Item.FindControl("lnkDone");
                    Button imgclose = (Button)e.Item.FindControl("imgclose");
                    Label lblStatus = (Label)e.Item.FindControl("lblStatus");

                    if (string.IsNullOrEmpty(txtWHDate.Text))
                    {
                        txtWHDate.Visible = true;
                        imgclose.Visible = false;
                    }
                    else
                    {
                        txtWHDate.Visible = true;
                        if (lblStatus.Text.ToUpper() == "PENDING")
                        {
                            imgclose.Visible = true;
                        }
                        else
                        {
                            imgclose.Visible = false;
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
        protected void lnkDone_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = Session["UserName"].ToString();

                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                var lb = (Button)sender;
                var row = (ListViewItem)lb.NamingContainer;
                if (row != null)
                {
                    var lblProductionID = row.FindControl("lblProductionID") as Label;
                    var lblSalesOrder = row.FindControl("lblSalesOrder") as Label;
                    var lblItemCode = row.FindControl("lblItemCode") as Label;
                    _ClsReport.UpdateProduction(lblProductionID.Text, lblSalesOrder.Text, lblItemCode.Text, UserName);

                    // GetProductionDashBoard();

                    string ProductionID = Request.QueryString["Id"];
                    string So = Request.QueryString["So"];
                    string SalesOrder = So.Trim();

                    BinddataNew(ProductionID.Trim(), SalesOrder);

                    BinddataGrid(ProductionID.Trim(), SalesOrder);

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
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                UserName = Session["UserName"].ToString();

                string ProductionID = Request.QueryString["Id"];
                string So = Request.QueryString["So"];
                string SalesOrder = So.Trim();

                string DemandDate = "";
                if (!string.IsNullOrEmpty(lblProdDate.Value))
                {
                    string[] sp1 = lblProdDate.Value.Split('-');
                    DemandDate = sp1[0] + "/" + sp1[1] + "/" + sp1[2];
                }
                if (pnlRemarks.Visible == true)
                {
                    _Cls.UpdateProductionReviseTDOD(ProductionID.Trim(), DemandDate, txtRemarks.Text, UserName);
                    lblMsg.Style.Value = "display:block";
                    lblMessage1.Text = "Revised TDOD and Remarks Updated Successfully";
                }


                if (lvMatdetails.Items.Count > 0)
                {
                    bool checkExist = false;
                    for (int i = 0; i < lvMatdetails.Items.Count; i++)
                    {
                        TextBox txtWHDate = (TextBox)lvMatdetails.Items[i].FindControl("txtWHDate");
                        {
                            if(!string.IsNullOrEmpty(txtWHDate.Text))
                            {
                                checkExist = true;
                            }
                        }
                    }
                    if (checkExist == false)
                    {
                        ErrorMsg.Style.Value = "display:block";
                        lblMessage.Text = "Plaese Provide TDOD for atleast 1 item";
                        return;
                    }

                    for (int i = 0; i < lvMatdetails.Items.Count; i++)
                    {
                        TextBox txtWHDate = (TextBox)lvMatdetails.Items[i].FindControl("txtWHDate");
                        LinkButton lnkDone = (LinkButton)lvMatdetails.Items[i].FindControl("lnkDone");
                        Button imgclose = (Button)lvMatdetails.Items[i].FindControl("imgclose");
                        Label lblStatus = (Label)lvMatdetails.Items[i].FindControl("lblStatus");
                        Label lblItemCode = (Label)lvMatdetails.Items[i].FindControl("lblItemCode");


                        string TDODATE = "";
                        //if (txtWHDate.Text.Contains("-"))
                        //{
                        //    if (!string.IsNullOrEmpty(txtWHDate.Text))
                        //    {
                        //        string[] sp1 = txtWHDate.Text.Split('-');
                        //        TDODATE = sp1[2] + "/" + sp1[1] + "/" + sp1[0];
                        //    }
                        //}
                        //else
                        //{
                        //    TDODATE = txtWHDate.Text;
                        //}

                        if (lblStatus.Text.ToUpper()  == "PENDING")
                        {
                            if(!string.IsNullOrEmpty(txtWHDate.Text))
                            {

                                _Cls.UpdateProdTDOD(lblProductionID.Value, lblSalesOrder.Value, lblItemCode.Text, txtWHDate.Text, UserName);
                            }
                        }
                    }
                    lblMsg.Style.Value = "display:block";
                    lblMessage1.Text = "Production TDOD Updated Successfully";


                    

                    BinddataNew(ProductionID.Trim(), SalesOrder);
                    BinddataGrid(ProductionID.Trim(), SalesOrder);

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
                Response.Redirect("~/ProductionReport.aspx", false);
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
    }
}