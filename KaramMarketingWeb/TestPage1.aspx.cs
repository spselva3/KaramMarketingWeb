using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class TestPage1 : System.Web.UI.Page
    {
        clsReport _Cls = new clsReport();
        string UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReserveReport();
        }

        public void GetReserveReport()
        {
            try
            {
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GetReservationDashBoard("", "", "","" ,"All");
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
               // lblErrorMsg.Text = exe.Message;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ErrorMsg.Style.Value = "display:none";
            lblMessage.Text = "please Select any Value";
        }
    }
}