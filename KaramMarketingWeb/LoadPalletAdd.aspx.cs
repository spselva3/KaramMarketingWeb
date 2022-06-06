using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class LoadPalletAdd : System.Web.UI.Page
    {

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
                        string So = Request.QueryString["Id"];
                        // string So = Request.QueryString["So"];
                        string SalesOrder = So.Trim();

                        GetBoxDetail(SalesOrder);
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

        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {

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

        protected void lnkclose_Click(object sender, EventArgs e)
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
                    if(dtUserDetails.Rows.Count > 0)
                    {
                        txtLength.Value = dtUserDetails.Rows[0]["Length"].ToString();
                        txtWidth.Value = dtUserDetails.Rows[0]["Width"].ToString();
                        txtHeight.Value = dtUserDetails.Rows[0]["Height"].ToString();
                        txtWeight.Value = dtUserDetails.Rows[0]["Capacity"].ToString();
                        txtCount.Value ="1";
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

        List<clstruck> objlistrucks = new List<clstruck>();

        protected void btnTruckNext_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if(lvPalletAdd.Items.Count == 0)
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
                    Label lblQty = (Label)lvPalletAdd.Items[i].FindControl("lblQty");

                    double Length = double.Parse(lblLength.Text);
                    double Width = double.Parse(lblWidth.Text);
                    double Height = double.Parse(lblHeight.Text);
                    double Wt = double.Parse(lblPwt.Text);
                    // double Qty = double.Parse(lblQty.Text);
                    double Qty = double.Parse("10000");

                    double Volume = Length * Width * Height;
                    double ProductVolume = Volume * Qty;

                    TotalVolume = Math.Round(TotalVolume + ProductVolume);     //10
                    TotalboxCount = TotalboxCount + Qty;
                }


                double TruckLength = double.Parse(txtLength.Value);
                double TruckHeight = double.Parse(txtHeight.Value);
                double TruckWidth = double.Parse(txtWidth.Value);
                double TruckMaxWt = double.Parse(txtWeight.Value);

                double TruckVolume = Math.Round(TruckLength * TruckHeight * TruckWidth);   

                int TruckReq = 0;
                if(TotalVolume > TruckVolume)
                {
                    int Diff = Convert.ToInt32(TotalVolume  % TruckVolume);
                    if(Diff == 0)
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
                            objtr.CargoVolume = Math.Abs(_PartialTruck).ToString() ;
                            objtr.VolumePercent = Math.Round(_VolPer, 3).ToString().Replace("-","") + " %";
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
                            objtr.TruckLoad ="FTL";
                            objlistrucks.Add(objtr);
                        }
                    }

                    LvTruckList.DataSource = objlistrucks;
                    LvTruckList.DataBind();


                }
                else if (TotalVolume == TruckVolume)
                {
                    TruckReq = 1;
                }
                else
                {
                    TruckReq = 1;
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        public class clstruck
        {
            public string Truckid { get; set; }
            public string ProdCnt { get; set; }
            public string CargoVolume { get; set; }
            public string VolumePercent { get; set; }
            public string CargoWeight { get; set; }
            public string WeightPercent { get; set; }

            public string TruckLoad { get; set; }
        }

        protected void btnTruckClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnTruckClose_Click(object sender, EventArgs e)
        {

        }
    }
}