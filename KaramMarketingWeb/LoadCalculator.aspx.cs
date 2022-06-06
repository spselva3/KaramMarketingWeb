using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class LoadCalculator : System.Web.UI.Page
    {
        clsReserve _ClsReserve = new clsReserve();
        clsLoadOptim _Cls = new clsLoadOptim();
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
                        //string So = Request.QueryString["Id"];
                        //// string So = Request.QueryString["So"];
                        //string SalesOrder = So.Trim();

                      //  GetBoxDetail("");
                        panelContainer.Visible = false;

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
        private void GetBoxDetail(string SalesOrder)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                DataTable dtUserDetails = new DataTable();
                dtUserDetails = _Cls.GetLoadWithSalesOrder(SalesOrder);

                lvPalletAdd.DataSource = dtUserDetails;
                lvPalletAdd.DataBind();

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

      

        protected void brnClear_Click(object sender, EventArgs e)
        {

        }

        protected void lnkclose_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";


                var lb = (LinkButton)sender;
                var row = (ListViewItem)lb.NamingContainer;
                if (row != null)
                {
                    var lblMatcode = row.FindControl("lblMatcode") as Label;

                    if (ViewState["TruckList"] != null)
                    {

                        var dt = (List<clsProductList>)ViewState["TruckList"];
                        if (dt != null)
                        {
                            foreach (clsProductList data in dt.ToList())
                            {
                                ProductList.Add(new clsProductList()
                                {
                                    PackID = data.PackID,
                                    ItemCode = data.ItemCode,
                                    Length = data.Length,
                                    Height = data.Height,
                                    Width = data.Width,
                                    Weight = data.Weight,
                                    Count = data.Count,
                                });
                            }
                        }
                        ProductList.RemoveAll(s => s.ItemCode == lblMatcode.Text.Trim());

                        int i = 1;
                        foreach (clsProductList its in ProductList)
                        {
                            its.Serial = i;
                            i = i + 1;
                        }
                        lvPalletAdd.DataSource = ProductList;
                        lvPalletAdd.DataBind();
                        ViewState["TruckList"] = ProductList.ToList();
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
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                if (lvPalletAdd.Items.Count > 0)
                {
                    panelContainer.Visible = true;

                    DataTable dtUserDetails = new DataTable();
                    dtUserDetails = _Cls.GetTruckList("");

                    if (dtUserDetails.Rows.Count > 0)
                    {

                        ddlTruckType.DataSource = dtUserDetails;
                        ddlTruckType.DataValueField = "TruckType";
                        ddlTruckType.DataTextField = "TruckType";
                        ddlTruckType.DataBind();
                    }

                    ddlTruckType.Items.Insert(0, new ListItem("Please Select", "0"));

                }
                else
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please select the Items to Dispatch";
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

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void ddlTruckType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTruckType.SelectedIndex > 0)
                {
                    ErrorMsg.Style.Value = "display:none";
                    lblMessage.Text = "";

                    DataTable dtUserDetails = new DataTable();
                    dtUserDetails = _Cls.getSpecificTruckDetail(ddlTruckType.SelectedValue.ToString());
                    if (dtUserDetails.Rows.Count > 0)
                    {
                        txtLength.Value = dtUserDetails.Rows[0]["Length"].ToString();
                        txtWidth.Value = dtUserDetails.Rows[0]["Width"].ToString();
                        txtHeight.Value = dtUserDetails.Rows[0]["Height"].ToString();
                        txtWeight.Value = dtUserDetails.Rows[0]["Capacity"].ToString();
                        txtCount.Value = "1";
                    }

                }
                else
                {
                    txtLength.Value = "";
                    txtWidth.Value = "";
                    txtHeight.Value = "";
                    txtWeight.Value = "";
                    txtCount.Value = "0";
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
        public static List<string> GetPackID(string prefixText)
        {
            clsReserve cls = new clsReserve();
            DataTable dtt = cls.GetPackIDWeb(prefixText);
            List<string> Output = new List<string>();
            foreach (DataRow dtrow in dtt.Rows)
            {
                string str = dtrow["PackinglistID"].ToString();
                Output.Add(str);
            }
            return Output;
        }

        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                CheckBox chckheader = (CheckBox)lvPalletAdd.FindControl("chkHeader");
                for (int i = 0; i < lvPalletAdd.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)lvPalletAdd.Items[i].FindControl("chkSelect");
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

        protected void btnTruckNext_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if (lvPalletAdd.Items.Count == 0)
                {
                    return;

                }
                double TotalboxCount = 0;
                double TotalVolume = 0;
                for (int i = 0; i < lvPalletAdd.Items.Count; i++)
                {
                    Label lblMatcode = (Label)lvPalletAdd.Items[i].FindControl("lblMatcode");
                    Label lblLength = (Label)lvPalletAdd.Items[i].FindControl("lblLength");
                    Label lblWidth = (Label)lvPalletAdd.Items[i].FindControl("lblWidth");
                    Label lblHeight = (Label)lvPalletAdd.Items[i].FindControl("lblHeight");
                    Label lblPwt = (Label)lvPalletAdd.Items[i].FindControl("lblPwt");
                    TextBox lblQty = (TextBox)lvPalletAdd.Items[i].FindControl("txtDemandPack");
                    CheckBox chk = (CheckBox)lvPalletAdd.Items[i].FindControl("chkSelect");
                    if (chk.Checked == true)
                    {
                        double Length = double.Parse(lblLength.Text);
                        double Width = double.Parse(lblWidth.Text);
                        double Height = double.Parse(lblHeight.Text);
                        double Wt = double.Parse(lblPwt.Text);
                        double Qty = double.Parse(lblQty.Text);
                        double Volume = Length * Width * Height;
                        double ProductVolume = Volume * Qty;

                        TotalVolume = Math.Round(TotalVolume + ProductVolume);     
                        TotalboxCount = TotalboxCount + Qty;

                        clsMaterial _MatList = new clsMaterial();
                        _MatList.ItemCode = lblMatcode.Text;
                        _MatList.Length = Length ;
                        _MatList.Width = Width ;
                        _MatList.Height = Height ;
                        _MatList.Weight = Wt;
                        _MatList.Qty = Qty;
                        _MatList.Volume = ProductVolume;
                        MaterialList.Add(_MatList);



                    }
                    else
                    {

                    }
                }
                double TruckLength = double.Parse(txtLength.Value);
                double TruckHeight = double.Parse(txtHeight.Value);
                double TruckWidth = double.Parse(txtWidth.Value);
                double TruckMaxWt = double.Parse(txtWeight.Value);
                double TruckVolume = Math.Round(TruckLength * TruckHeight * TruckWidth);

                int TruckReq = 0;
                if (TotalVolume > TruckVolume)
                {
                    int Diff = Convert.ToInt32(TotalVolume % TruckVolume);
                    if (Diff == 0)
                    {
                        TruckReq = Convert.ToInt32(TotalVolume / TruckVolume);
                    }
                    else
                    {
                        TruckReq = Convert.ToInt32(TotalVolume / TruckVolume) + 1;
                    }

                    int _Prodcnt = 0;
                    _Prodcnt = Convert.ToInt32(TotalboxCount / TruckReq);
                    int _EachTruckVolume = 0;
                    _EachTruckVolume = Convert.ToInt32(TotalVolume / TruckReq);

                    double _Volumepercentage = 0;
                    _Volumepercentage = (_EachTruckVolume / TruckVolume) * 100;
                    for (int i = 1; i <= TruckReq; i++)
                    {
                        if (i == TruckReq)
                        {
                            double _PartialTruck = (TotalVolume - (TruckVolume * (TruckReq - 1)));

                            double _VolPer = 0;
                            _VolPer = (_PartialTruck / TruckVolume) * 100;

                            clstruck objtr = new clstruck();
                            objtr.Truckid = "Truck-" + i.ToString();
                            objtr.ProdCnt = _Prodcnt.ToString();
                            objtr.CargoVolume = Math.Abs(_PartialTruck).ToString();
                            objtr.VolumePercent = Math.Round(_VolPer, 3).ToString().Replace("-", "") + " %";
                            objtr.TruckLoad = "PTL";

                            objlistrucks.Add(objtr);

                        }
                        else
                        {
                            clstruck objtr = new clstruck();
                            objtr.Truckid = "Truck-" + i.ToString();
                            objtr.ProdCnt = _Prodcnt.ToString();
                            objtr.CargoVolume = Math.Round(TruckVolume).ToString();
                            objtr.VolumePercent = "100 % ";
                            objtr.TruckLoad = "FTL";
                            objlistrucks.Add(objtr);
                        }
                    }

                    LvTruckList.DataSource = objlistrucks;
                    LvTruckList.DataBind();


                }
                else if (TotalVolume == TruckVolume)
                {
                    TruckReq = 1;
                    int _Prodcnt = 0;
                    _Prodcnt = Convert.ToInt32(TotalboxCount / TruckReq);

                    clstruck objtr = new clstruck();
                    objtr.Truckid = "Truck-1" ;
                    objtr.ProdCnt = _Prodcnt.ToString();
                    objtr.CargoVolume = Math.Round(TruckVolume).ToString();
                    objtr.VolumePercent = "100 % ";
                    objtr.TruckLoad = "FTL";
                    objlistrucks.Add(objtr);

                    LvTruckList.DataSource = objlistrucks;
                    LvTruckList.DataBind();
                }
                else
                {
                    TruckReq = 1;

                    double _PartialTruck = (TotalVolume - (TruckVolume * (TruckReq - 1)));
                    double _VolPer = 0;
                    _VolPer = (_PartialTruck / TruckVolume) * 100;

                    int _Prodcnt = 0;
                    _Prodcnt = Convert.ToInt32(TotalboxCount / TruckReq);

                    clstruck objtr = new clstruck();
                    objtr.Truckid = "Truck-1";
                    objtr.ProdCnt = _Prodcnt.ToString();
                    objtr.CargoVolume = Math.Abs(_PartialTruck).ToString();
                    objtr.VolumePercent = Math.Round(_VolPer, 3).ToString().Replace("-", "") + " %";
                    objtr.TruckLoad = "PTL";
                    objlistrucks.Add(objtr);

                    LvTruckList.DataSource = objlistrucks;
                    LvTruckList.DataBind();
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        List<clstruck> objlistrucks = new List<clstruck>();
        public class clstruck
        {
            public string Truckid { get; set; }
            public string ProdCnt { get; set; }
            public string CargoVolume { get; set; }
            public string VolumePercent { get; set; }
            public string CargoWeight { get; set; }
            public string WeightPercent { get; set; }

            public string ProductCount { get; set; }
            public string TruckLoad { get; set; }
        }

        List<clsMaterial> MaterialList = new List<clsMaterial>();
        public class clsMaterial
        {
            public string ItemCode { get; set; }
            public double Length { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
            public double Weight { get; set; }
            public double Qty { get; set; }
            public double Volume { get; set; }
        }
        protected void btnTruckClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtItemCode.Text = string.Empty;
                txtPackID.Text = string.Empty;
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        private int GetProductCount(List<clsMaterial> clsMaterials, string ItemCode  , string Volume)
        {
            int Value= 4;
            return Value;
        }
        protected void btnTruckClose_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (lvPalletAdd.Items.Count > 0)
                //{
                //    for (int i = 0; i < lvPalletAdd.Items.Count; i++)
                //    {
                //        Label lblPackID = (Label)lvPalletAdd.Items[i].FindControl("lblPackID");
                //        Label lblMatcode = (Label)lvPalletAdd.Items[i].FindControl("lblMatcode");
                //        Label lblLength = (Label)lvPalletAdd.Items[i].FindControl("lblLength");
                //        Label lblWidth = (Label)lvPalletAdd.Items[i].FindControl("lblWidth");
                //        Label lblHeight = (Label)lvPalletAdd.Items[i].FindControl("lblHeight");
                //        Label lblPwt = (Label)lvPalletAdd.Items[i].FindControl("lblPwt");
                //        TextBox txtProductCount = (TextBox)lvPalletAdd.Items[i].FindControl("txtProductCount");
                //        Label lblPackStyle = (Label)lvPalletAdd.Items[i].FindControl("lblPackStyle");
                //        TextBox txtDemandPack = (TextBox)lvPalletAdd.Items[i].FindControl("txtDemandPack");

                //        ProductList.Add(new clsProductList()
                //        {
                //            PackID = lblPackID.Text,
                //            ItemCode = lblMatcode.Text,
                //            Length = lblLength.Text,
                //            Height = lblHeight.Text,
                //            Width = lblWidth.Text,
                //            Weight = lblPwt.Text,
                //            Count = txtProductCount.Text,
                //            PackType = lblPackStyle.Text,
                //            Boxes = txtDemandPack.Text,
                //        });

                //    }
                //}

                if (ViewState["TruckList"] != null)
                {
                    var dt = (List<clsProductList>)ViewState["TruckList"];
                    if (dt != null)
                    {
                        foreach (clsProductList data in dt.ToList())
                        {
                            ProductList.Add(new clsProductList()
                            {
                                PackID = data.PackID,
                                ItemCode = data.ItemCode,
                                Length = data.Length,
                                Height = data.Height,
                                Width = data.Width,
                                Weight = data.Weight,
                                Count = data.Count,
                                PackType = data.PackType,
                                Boxes = data.Boxes,
                            });
                        }
                    }
                }
                if (string.IsNullOrEmpty(txtItemCode.Text.ToString()) && string.IsNullOrEmpty(txtPackID.Text.ToString()))
                {
                    return;
                }
                string _ItemCode = "";
                string _PackID = "";

                if (!string.IsNullOrEmpty(txtItemCode.Text))
                {
                    _ItemCode = txtItemCode.Text.Trim();
                }
                if (!string.IsNullOrEmpty(txtPackID.Text))
                {
                    _PackID = txtPackID.Text.Trim();
                }

                DataTable dtUserDetails = new DataTable();
                dtUserDetails = _Cls.GetPackDetails_LoadOptim(_ItemCode, _PackID);

                if (dtUserDetails != null)
                {
                    string ItemCode = "";
                    string PackID = "";
                    string Lenght = "";
                    string Width = "";
                    string Height = "";
                    string Wt = "";
                    string TotalCount = "";
                    string PackStyle = "";
                    string CartonCount = "";
                    foreach (DataRow dtr in dtUserDetails.Rows)
                    {
                        ItemCode = dtr["MatCode"].ToString();
                        PackID = dtr["PackID"].ToString();
                        Lenght = dtr["l"].ToString();
                        Width = dtr["w"].ToString();
                        Height = dtr["h"].ToString();
                        Wt = dtr["pwt"].ToString();
                        TotalCount = dtr["TotalCount"].ToString();
                        PackStyle = dtr["PackStyle"].ToString();

                        if (!string.IsNullOrEmpty(ItemCode))
                        {

                            bool isExists = false;
                            foreach (clsProductList item in ProductList)
                            {
                                if (item.ItemCode.Trim() == ItemCode.Trim())
                                {
                                    isExists = true;
                                }
                            }
                            if (isExists == true)
                            {
                                return;
                            }
                            else
                            {
                                ProductList.Add(new clsProductList()
                                {
                                    PackID = PackID,
                                    ItemCode = ItemCode,
                                    Length = Lenght,
                                    Height = Height,
                                    Width = Width,
                                    Weight = Wt,
                                    Count = TotalCount,
                                    PackType = PackStyle,
                                    Boxes = "0",
                                }); 
                                int i = 1;
                                foreach (clsProductList its in ProductList)
                                {
                                    its.Serial = i;
                                    i = i + 1;
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                    }


                    lvPalletAdd.DataSource = ProductList;
                    lvPalletAdd.DataBind();
                    ViewState["TruckList"] = ProductList.ToList();
                    //  ViewState["TruckList"] = TruckList;


                    txtItemCode.Text = string.Empty;
                    txtPackID.Text = string.Empty;
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnClearItem_Click(object sender, EventArgs e)
        {

        }


        public List<clsProductList> ProductList = new List<clsProductList>();
        [Serializable]
        public class clsProductList
        {
            public int Serial { get; set; }
            public string PackID { get; set; }
            public string ItemCode { get; set; }
            public string Length { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public string Weight { get; set; }
            public string Count { get; set; }
            public string PackType { get; set; }
            public string Boxes { get; set; }

        }

        protected void txtProductCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem li in lvPalletAdd.Items)
                {
                    DropDownList dllPackStyle = (DropDownList)li.FindControl("dllPackStyle");
                    TextBox txtCartonBox = (TextBox)li.FindControl("txtDemandPack");
                    //Label lblDemand = (Label)li.FindControl("lblDemand");
                    TextBox txtQty = (TextBox)li.FindControl("txtProductCount");

                    double PackValue = 0;
                    double CartonReq = 0;
                    double AvailQty = 0;
                    if (!string.IsNullOrWhiteSpace(txtQty.Text))
                    {
                        AvailQty = double.Parse(txtQty.Text);
                        if (dllPackStyle.SelectedIndex > 0)
                        {
                            PackValue = double.Parse(dllPackStyle.SelectedValue.ToString());
                        }
                        double ModularValue = AvailQty % PackValue;
                        if(ModularValue > 0)
                        {
                            CartonReq = Math.Round(AvailQty / PackValue);
                            CartonReq = CartonReq + 1;
                        }
                        else
                        {
                            CartonReq = Math.Round(AvailQty / PackValue);
                        }

                        txtCartonBox.Text = CartonReq.ToString();
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        private void spGetRMRecvMatConditions_Masters_RM(DropDownList dlstConditions, string ItemCode, string PackStyle)
        {
            try
            {
                string PAckQty = "";
                DataTable dtRMMatConditions = new DataTable();
                dtRMMatConditions = _ClsReserve.GetPackStyle(ItemCode);

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
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void lvPalletAdd_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    Label lblItemCode = (Label)e.Item.FindControl("lblMatcode");
                    Label lblPackStyle = (Label)e.Item.FindControl("lblPackStyle");


                    string PackStyle = lblPackStyle.Text;
                    string _ItemCode = lblItemCode.Text;

                    DropDownList dllPackStyle = (DropDownList)e.Item.FindControl("dllPackStyle");
                    spGetRMRecvMatConditions_Masters_RM(dllPackStyle, _ItemCode.Trim(), PackStyle);

                    dllPackStyle.SelectedValue = PackStyle;
                }

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void txtProductCount_TextChanged1(object sender, EventArgs e)
        {

        }
    }
}