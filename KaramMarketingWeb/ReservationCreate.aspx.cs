using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class ReservationCreate : System.Web.UI.Page
    {
        clsReserve _Cls = new clsReserve();
        string UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               // Session["UserName"] = "Selva";
                if (Session["UserName"] != null)
                {
                    UserName = Session["UserName"].ToString();
                    if (!IsPostBack)
                    {
                        string DateValue = DateTime.Now.ToString("dd-MM-yyyy");

                        txtDemandDate.Text = DateValue.ToString();
                        txtSODate.Text = DateValue.ToString();
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

        protected void btnSearchItem_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                CheckPreviousData();
                BinddataNew();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        private void CheckPreviousData()
        {
            try
            {
                UserName = Session["UserName"].ToString();
                if (lvProductdetails.Items.Count > 0)
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
                            _Cls.UpdateCartItems(_itemCode, _DEmandQty, UserName.Trim(), _PackStyle, _PackReq);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        private void BinddataNew()
        {
            try
            {

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetItemFiltersItems(txtItemCode.Text, txtItemDesc.Text.Trim(), txtCategory.Text.Trim());
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
                else
                {
                    lvMatdetails.DataSource = dtdetails;
                    lvMatdetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
        private void BindCartData()
        {
            try
            {
                UserName = Session["UserName"].ToString();
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetCartItems(UserName);
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
        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
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
                lblErrorMsg.Text = exe.Message;
                return;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CheckPreviousData();
                UserName = Session["UserName"].ToString();
                lblErrorMsg.Text = "";
                bool _isProductsselected = false;
                for (int i = 0; i < lvMatdetails.Items.Count; i++)
                {
                    CheckBox chkproduct = (CheckBox)lvMatdetails.Items[i].FindControl("chkSelect");
                    if (chkproduct.Checked == true)
                    {
                        _isProductsselected = true;

                        Label lblItemCode = (Label)lvMatdetails.Items[i].FindControl("lblItemCode");
                        Label lblItemDesc = (Label)lvMatdetails.Items[i].FindControl("lblItemDesc");
                        Label lblCategory = (Label)lvMatdetails.Items[i].FindControl("lblCategory");
                        Label lblUOM = (Label)lvMatdetails.Items[i].FindControl("lblUOM");
                        Label lblAvailableQty = (Label)lvMatdetails.Items[i].FindControl("lblAvailableQty");
                        //TextBox txtDemand = (TextBox)lvMatdetails.Items[i].FindControl("txtDemand");

                        _Cls.InsertintoCart(lblItemCode.Text, lblItemDesc.Text, lblCategory.Text, lblUOM.Text,
                            "0", UserName.Trim());

                        chkproduct.Checked = false;
                    }
                }
                BindCartData();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtItemCode.Text = string.Empty;
                txtItemDesc.Text = string.Empty;

                txtCategory.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void btnLoadCart_Click(object sender, EventArgs e)
        {

            try
            {
                CheckPreviousData();
                BindCartData();
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

        protected void lnkclose_Click(object sender, EventArgs e)
        {
            try
            {
                UserName = Session["UserName"].ToString();

                lblErrorMsg.Text = "";
                var lb = (LinkButton)sender;
                var row = (ListViewItem)lb.NamingContainer;
                if (row != null)
                {
                    var lblItemCode1 = row.FindControl("lblItemCode1") as Label;
                    _Cls.DeleteCartItem(lblItemCode1.Text, UserName);

                    BindCartData();
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetItemCode(string prefixText)
        {
            clsReserve cls = new clsReserve();
            DataTable dtt = cls.GetItemCode(prefixText);
            List<string> Output = new List<string>();
            foreach (DataRow dtrow in dtt.Rows)
            {
                string str = dtrow["ItemCode"].ToString();
                Output.Add(str);
            }
            return Output;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetItemDesc(string prefixText)
        {
            clsReserve cls = new clsReserve();
            DataTable dtt = cls.GetItemDesc(prefixText);
            List<string> Output = new List<string>();
            foreach (DataRow dtrow in dtt.Rows)
            {
                string str = dtrow["ItemDesc"].ToString();
                Output.Add(str);
            }
            return Output;
        }



        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCategory(string prefixText)
        {
            clsReserve cls = new clsReserve();
            DataTable dtt = cls.GetCategory(prefixText);
            List<string> Output = new List<string>();
            foreach (DataRow dtrow in dtt.Rows)
            {
                string str = dtrow["Category"].ToString();
                Output.Add(str);
            }
            return Output;
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


        public List<clsCartItem> CartList = new List<clsCartItem>();
        public class clsCartItem
        {
            public int Serial { get; set; }
            public string ItemCode { get; set; }
            public string ItemDesc { get; set; }
            public string Category { get; set; }
            public string UOM { get; set; }
            public string AvailableQty { get; set; }
            public string DemandQty { get; set; }
            public string LocationCode { get; set; }
            public string Source { get; set; }
            public double Qty { get; set; }
            public double Print { get; set; }

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            UserName = Session["UserName"].ToString();
            lblErrorMsg.Text = "";
            try
            {
                if (lvProductdetails.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(txtSalesOrder.Text.Trim()))
                    {
                        string Message = CheckSOList(txtSalesOrder.Text.Trim());
                        if (Message == "Error" || Message == "No SO Exist" || Message == "ItemCode Not Matched with SO")
                        {
                            // lblErrorMsg.Text = Message;
                            return;
                        }
                    }
                    if(lvProductdetails.Items.Count == 0)
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
                    if(CheckValueExists == false)
                    {
                        lblErrorMsg.Text = "Add Items with Demand Qty";
                        return;
                    }

                    string NewReservationID = "";
                    DataTable dtdetails = new DataTable();
                    dtdetails = _Cls.GetReservationID(UserName.Trim());
                    if (dtdetails != null)
                    {
                        if (dtdetails.Rows.Count > 0)
                        {
                            NewReservationID = dtdetails.Rows[0]["ReserveID"].ToString();
                        }

                        if (!string.IsNullOrEmpty(NewReservationID))
                        {
                            string SalesOrder = txtSalesOrder.Text.Trim();
                            string Customer = txtCustomer.Text.Trim();
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
                            for (int i = 0; i < lvProductdetails.Items.Count; i++)
                            {
                                Label lblItemCode1 = (Label)lvProductdetails.Items[i].FindControl("lblItemCode1");
                                Label lblItemDesc1 = (Label)lvProductdetails.Items[i].FindControl("lblItemDesc1");
                                Label lblCategory1 = (Label)lvProductdetails.Items[i].FindControl("lblCategory1");
                                Label lblUOM1 = (Label)lvProductdetails.Items[i].FindControl("lblUOM1");
                                Label lblAvailableQty1 = (Label)lvProductdetails.Items[i].FindControl("lblAvailableQty1");

                                DropDownList dllPackStyle = (DropDownList)lvProductdetails.Items[i].FindControl("dllPackStyle");
                                TextBox txtDemandPack = (TextBox)lvProductdetails.Items[i].FindControl("txtDemandPack");
                                Label txtDemand1 = (Label)lvProductdetails.Items[i].FindControl("lblDemand");


                                string _itemCode = lblItemCode1.Text.Trim();
                                string _itemDesc = lblItemDesc1.Text.Trim();
                                string _Category = lblCategory1.Text.Trim();
                                string _UOM = lblUOM1.Text.Trim();
                                string _QTY = lblAvailableQty1.Text.Trim();
                                string _DEmandQty = txtDemand1.Text.Trim();
                                string _PackStyle = dllPackStyle.SelectedItem.ToString();
                                string _PackReq = txtDemandPack.Text.Trim();

                                double DEmandQty = double.Parse(txtDemand1.Text);
                                if (DEmandQty > 0)
                                {
                                    _Cls.CreateReservation(NewReservationID.Trim(), _itemCode, _itemDesc, _Category, _UOM,
                                        _DEmandQty, UserName, "", Customer, SalesOrder, DemandDate, SODate, _PackStyle, _PackReq);

                                    try
                                    {
                                        double ReqQTy = double.Parse(_DEmandQty);   //550

                                        DataTable dtStock = new DataTable();
                                        dtStock = _Cls.GetStockPackets(_itemCode, _DEmandQty, _PackStyle);
                                        if (dtStock != null)
                                        {
                                            if (dtStock.Rows.Count > 0)
                                            {
                                                foreach (System.Data.DataRow dtrrow in dtStock.Rows)
                                                {
                                                    string _Packetid = dtrrow["A_ASSETID"].ToString();
                                                    double _AvailQty = double.Parse(dtrrow["A_AVAILQTY"].ToString());
                                                    double _NewQty = 0;
                                                    double _Picked = 0;

                                                    if (ReqQTy > 0)
                                                    {

                                                        if (_AvailQty < ReqQTy)   //50 < 360
                                                        {
                                                            ReqQTy = ReqQTy - _AvailQty;   //310
                                                            _NewQty = 0;
                                                            _Picked = _AvailQty;
                                                            _Cls.DEductInventory(NewReservationID.Trim(), _Packetid, _itemCode, _Category, _PackStyle,
                                                                _DEmandQty, _AvailQty.ToString(), _Picked.ToString(), _NewQty.ToString(), UserName);

                                                        }
                                                        else if (_AvailQty == ReqQTy)   //360 = 360
                                                        {
                                                            ReqQTy = ReqQTy - _AvailQty;
                                                            _NewQty = 0;
                                                            _Picked = _AvailQty;
                                                            _Cls.DEductInventory(NewReservationID.Trim(), _Packetid, _itemCode, _Category, _PackStyle,
                                                                _DEmandQty, _AvailQty.ToString(), _Picked.ToString(), _NewQty.ToString(), UserName);

                                                        }
                                                        else if (_AvailQty > ReqQTy) // 100 > 30
                                                        {
                                                            _NewQty = _AvailQty - ReqQTy;
                                                            _Picked = ReqQTy;
                                                            ReqQTy = ReqQTy - _AvailQty;

                                                            _Cls.DEductInventory(NewReservationID.Trim(), _Packetid, _itemCode, _Category, _PackStyle,
                                                               _DEmandQty, _AvailQty.ToString(), _Picked.ToString(), _NewQty.ToString(), UserName);

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        lblErrorMsg.Text = "Error While inserting Data";
                                        return;
                                    }
                                }
                            }

                            lblErrorMsg.Text = "Reservation ID Generated : " + NewReservationID;

                            try
                            {
                                _Cls.EmailCreateReservation(NewReservationID.Trim());
                            }
                            catch (Exception ex)
                            {
                                lblErrorMsg.Text = "Reservation ID Generated successfully, Problem in sending Email";
                            }
                            //BindCartData();
                            DataTable dtNull = new DataTable();

                            txtItemCode.Text = string.Empty;
                            txtItemDesc.Text = string.Empty;
                            txtCategory.Text = string.Empty;
                            txtSalesOrder.Text = string.Empty;
                            txtCustomer.Text = string.Empty;
                            lvMatdetails.DataSource = dtNull;
                            lvMatdetails.DataBind();
                            lvProductdetails.DataSource = dtNull;
                            lvProductdetails.DataBind();

                        }
                        else
                        {
                            lblErrorMsg.Text = "Error in Generating Reservation ID";
                        }
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Please Add items in Cart";
                    return;
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }
        }
    }
}