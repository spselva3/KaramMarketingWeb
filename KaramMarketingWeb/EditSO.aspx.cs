using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class EditSO : System.Web.UI.Page
    {
        clsReserve _Cls = new clsReserve();
        string UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["UserName"] != null)
                {
                    UserName = Session["UserName"].ToString();
                    if (!IsPostBack)
                    {
                        //txtDemandDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                        string ReserveID = Request.QueryString["Id"];
                        BinddataNew(ReserveID.Trim());
                        txtReservation.Text = ReserveID.Trim();
                        BindCartData(ReserveID.Trim());
                    }
                }
                else
                {
                    Response.Redirect("frmSessionOut.aspx");
                }
            }
            catch (Exception exe)
            {
                lblErrorMsg.Text = exe.Message;
            }
        }

        private void BinddataNew(string ReserveID)
        {
            try
            {
                string _Customer = "";
                string _ReserveDate = "";
                string _ReserveStatus = "";
                string _SalesNo = "";
                string _SODate = "";

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetReservationDetails(ReserveID);
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        _Customer = dtdetails.Rows[0]["CustomerName"].ToString();
                        _ReserveDate = dtdetails.Rows[0]["DemandDate"].ToString();
                        _ReserveStatus = dtdetails.Rows[0]["ReservationStatus"].ToString();
                        _SalesNo = dtdetails.Rows[0]["SalesOrder"].ToString();
                        _SODate = dtdetails.Rows[0]["SalesOrderDate"].ToString();


                        txtCustomer.Text = _Customer.Trim();
                        txtSalesOrder.Text = _SalesNo.Trim();
                        txtStatus.Text = _ReserveStatus.Trim();

                        DateTime dt = DateTime.ParseExact(_ReserveDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        string s2 = dt.ToString("dd-MM-yyyy");
                        txtDemandDate.Text = s2.ToString();

                        DateTime dt1 = DateTime.ParseExact(_SODate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        string s21 = dt1.ToString("dd-MM-yyyy");
                        txtSODate.Text = s21.ToString();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        private void BindCartData(string ReserveID)
        {
            try
            {
                UserName = Session["UserName"].ToString();
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetReservedItemsforEdit(ReserveID, UserName);
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
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void lvProductdetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    Label lblItemCode = (Label)e.Item.FindControl("lblItemCode1");
                    Label lblPackStyle = (Label)e.Item.FindControl("lblPackStyle");

                    string PackStyle = lblPackStyle.Text;
                    string _ItemCode = lblItemCode.Text;

                    DropDownList dllPackStyle = (DropDownList)e.Item.FindControl("dllPackStyle");
                    spGetRMRecvMatConditions_Masters_RM(dllPackStyle, _ItemCode.Trim(), PackStyle);

                    dllPackStyle.SelectedValue = PackStyle;

                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void txtDemandPack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem li in lvProductdetails.Items)
                {
                    DropDownList dllPackStyle = (DropDownList)li.FindControl("dllPackStyle");
                    TextBox txtReqPack = (TextBox)li.FindControl("txtDemandPack");
                    Label lblDemand = (Label)li.FindControl("lblDemand");
                    Label lblAvailableQty1 = (Label)li.FindControl("lblAvailableQty1");

                    double PackValue = 0;
                    double ReqPack = 0;
                    double AvailQty = 0;
                    if (!string.IsNullOrWhiteSpace(txtReqPack.Text))
                    {
                        ReqPack = double.Parse(txtReqPack.Text);
                        if (dllPackStyle.SelectedIndex > 0)
                        {
                            PackValue = double.Parse(dllPackStyle.SelectedValue.ToString());
                            AvailQty = double.Parse(lblAvailableQty1.Text);

                            double DemandQty = PackValue * ReqPack;

                            if (DemandQty > AvailQty)
                            {
                                txtReqPack.Text = "0";
                                lblErrorMsg.Text = "Demand Qty is higher than Available Qty";
                            }
                            else
                            {
                                lblDemand.Text = DemandQty.ToString();
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        private void spGetRMRecvMatConditions_Masters_RM(DropDownList dlstConditions, string ItemCode, string PackStyle)
        {
            try
            {
                string PAckQty = "";
                DataTable dtRMMatConditions = new DataTable();
                dtRMMatConditions = _Cls.GetPackStyle(ItemCode);
                if (dtRMMatConditions.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow dr in dtRMMatConditions.Rows)
                    {
                        string NewPackStyle = dr["PT_PACKTYPE"].ToString();
                        if (PackStyle.ToUpper() == NewPackStyle.ToUpper())
                        {
                            PAckQty = dr["PT_PACKQTY"].ToString();
                        }
                    }
                }


                dlstConditions.DataSource = dtRMMatConditions;
                dlstConditions.DataValueField = "PT_PACKQTY";
                dlstConditions.DataTextField = "PT_PACKTYPE";
                dlstConditions.DataBind();
                dlstConditions.Items.Insert(0, new ListItem("Please Select", "0"));
                dlstConditions.SelectedValue = PAckQty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkclose_Click(object sender, EventArgs e)
        {
            try
            {
                string ReserveID = Request.QueryString["Id"];
                UserName = Session["UserName"].ToString();

                lblErrorMsg.Text = "";
                var lb = (LinkButton)sender;
                var row = (ListViewItem)lb.NamingContainer;
                if (row != null)
                {
                    var lblItemCode1 = row.FindControl("lblItemCode1") as Label;
                    _Cls.DeleteReserveItem(ReserveID.Trim(), lblItemCode1.Text, UserName);

                    BindCartData(ReserveID.Trim());
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                UserName = Session["UserName"].ToString();

                if (string.IsNullOrEmpty(txtReservation.Text))
                {
                    lblErrorMsg.Text = "Please try Again";
                    return;
                }
                string ReserveID = txtReservation.Text.Trim();
                string _Customer = txtCustomer.Text.Trim();
                string _SalerOrder = txtSalesOrder.Text.Trim();
                string Status = txtStatus.Text.Trim();

                string DemandDate = "";
                string SODate = "";

                if (!string.IsNullOrEmpty(txtDemandDate.Text))
                {
                    string[] sp1 = txtDemandDate.Text.Split('-');
                    DemandDate = sp1[2] + "/" + sp1[1] + "/" + sp1[0];
                }
                if (!string.IsNullOrEmpty(txtSODate.Text))
                {
                    string[] sp1 = txtSODate.Text.Split('-');
                    SODate = sp1[2] + "/" + sp1[1] + "/" + sp1[0];
                }
                if (!string.IsNullOrEmpty(txtSalesOrder.Text.Trim()))
                {
                    string Message = CheckSOList(txtSalesOrder.Text.Trim());
                    if (Message == "Error" || Message == "No SO Exist" || Message == "ItemCode Not Matched with SO")
                    {
                        // lblErrorMsg.Text = Message;
                        return;
                    }
                }
                if (lvProductdetails.Items.Count == 0)
                {
                    lblErrorMsg.Text = "Add Items in Cart";
                    return;
                }
                bool CheckValueExists = false;
                for (int i = 0; i < lvProductdetails.Items.Count; i++)
                {
                    Label txtDemand1 = (Label)lvProductdetails.Items[i].FindControl("lblDemand");
                    double DEmandQty = double.Parse(txtDemand1.Text);
                    if (DEmandQty > 0)
                    {
                        CheckValueExists = true;
                    }
                }
                if (CheckValueExists == false)
                {
                    lblErrorMsg.Text = "Add Items with Demand Qty";
                    return;
                }
                _Cls.UpdateSalesOrder(ReserveID, DemandDate, _Customer, _SalerOrder, Status, SODate, UserName.Trim() , "");

                try
                {
                    for (int i = 0; i < lvProductdetails.Items.Count; i++)
                    {
                        Label lblItemCode1 = (Label)lvProductdetails.Items[i].FindControl("lblItemCode1");

                        DropDownList dllPackStyle = (DropDownList)lvProductdetails.Items[i].FindControl("dllPackStyle");
                        TextBox txtDemandPack = (TextBox)lvProductdetails.Items[i].FindControl("txtDemandPack");
                        Label txtDemand1 = (Label)lvProductdetails.Items[i].FindControl("lblDemand");

                        string _itemCode = lblItemCode1.Text.Trim();

                        string _DEmandQty = txtDemand1.Text.Trim();
                        string _PackStyle = dllPackStyle.SelectedItem.ToString();
                        string _PackReq = txtDemandPack.Text.Trim();
                        double DEmandQty = double.Parse(txtDemand1.Text);
                        if (DEmandQty > 0)
                        {
                            _Cls.EditReserveItem(ReserveID, _itemCode, _DEmandQty, UserName.Trim(), _PackStyle, _PackReq);
                        }
                    }
                    lblErrorMsg.Text = "Sales Order updated for this Reservation ID";

                    try
                    {
                        _Cls.EmailCreateReservation(ReserveID.Trim());
                    }
                    catch (Exception ex)
                    {
                        lblErrorMsg.Text = "Reservation ID Updated successfully, Problem in sending Email";
                    }
                }
                catch (Exception exe)
                {
                    lblErrorMsg.Text = exe.Message;
                }

            }
            catch (Exception exe)
            {
                lblErrorMsg.Text = exe.Message;
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

        private string CheckSOList(string SalesOrder)
        {
            try
            {
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.CheckSalesOrderDetail(SalesOrder.Trim());
                if (dtdetails != null)
                {
                    string NewSalesOrder = "";
                    string NewCustomer = "";
                    if (dtdetails.Rows.Count > 0)
                    {
                        NewSalesOrder = dtdetails.Rows[0]["SalesOrder"].ToString();
                        NewCustomer = dtdetails.Rows[0]["Customer"].ToString();
                        txtCustomer.Text = NewCustomer.Trim();

                        bool CheckinDbExist = false;
                        foreach (System.Data.DataRow dr in dtdetails.Rows)
                        {
                            string NewItemCode = dr["ItemCode"].ToString();
                            double NewQty = double.Parse(dr["Qty"].ToString());

                            for (int i = 0; i < lvProductdetails.Items.Count; i++)
                            {
                                Label lblItemCode1 = (Label)lvProductdetails.Items[i].FindControl("lblItemCode1");
                                Label txtDemand1 = (Label)lvProductdetails.Items[i].FindControl("lblDemand");

                                string _itemCode = lblItemCode1.Text.Trim();
                                double DEmandQty = double.Parse(txtDemand1.Text);

                                if (NewItemCode.ToUpper() == _itemCode.ToUpper())
                                {
                                    if (NewQty == DEmandQty)
                                    {
                                        CheckinDbExist = true;
                                    }
                                    else
                                    {
                                        lblErrorMsg.Text = "Qty not matched with ItemCode :" + NewItemCode.ToUpper();
                                        return "ItemCode Not Matched with SO";
                                    }
                                }
                            }
                        }
                        if (CheckinDbExist == false)
                        {
                            lblErrorMsg.Text = "Selected ItemCode not matched with Sales Order";
                            return "ItemCode Not Matched with SO";
                        }
                        else
                        {
                            return "ItemCodeAvailable";
                        }
                    }
                    else
                    {
                        txtSalesOrder.Text = "";
                        txtCustomer.Text = "";
                        return "No SO Exist";
                    }
                }
                else
                {
                    txtSalesOrder.Text = "";
                    txtCustomer.Text = "";
                    return "No SO Exist";
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
                return "Error";
            }
        }
    }
}