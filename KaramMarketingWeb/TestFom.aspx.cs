using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class TestFom : System.Web.UI.Page
    {
        clsReserve _Cls = new clsReserve();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtUsername.Focus();
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

        protected void btnSearchItem_Click(object sender, EventArgs e)
        {
            try
            {
                BinddataNew();
            }
            catch (Exception ex)
            {
                //  lblErrorMsg.Text = ex.Message;
            }
        }

        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void BinddataNew()
        {
            try
            {

                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetItemFiltersItems(txtItemCode.Text, txtItemCode.Text.Trim(), txtCategory.Text);
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
            catch (Exception ex)
            {
                // lblErrorMsg.Text = ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnLoadCart_Click(object sender, EventArgs e)
        {

        }

        protected void lvProductdetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }

        protected void txtDemandPack_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lnkclose_Click(object sender, EventArgs e)
        {

        }
    }
}