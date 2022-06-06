using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class frmEmail : System.Web.UI.Page
    {
        clsEmail _Cls = new clsEmail();
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
                        GetDevice();
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
        public void GetDevice()
        {
            try
            {
                DataTable dtdetails = new DataTable();
                dtdetails = _Cls.GellAllEmail("");
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {
                        lvEmailDetail.DataSource = dtdetails;
                        lvEmailDetail.DataBind();
                    }
                    else
                    {
                        lvEmailDetail.DataSource = dtdetails;
                        lvEmailDetail.DataBind();
                    }
                }
            }
            catch (Exception exe)
            {

                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/CreateEmailID.aspx", false);
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
    }
}