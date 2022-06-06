using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class Users : System.Web.UI.Page
    {
        clsUser _Cls = new clsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                if (Session["UserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        spGetAllUsers_web();
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
        private void spGetAllUsers_web()
        {
            try
            {
                DataTable dtUserDetails = new DataTable();
                dtUserDetails = _Cls.GetAllUser("");
                lvRMGateinDetails.DataSource = dtUserDetails;
                lvRMGateinDetails.DataBind();

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
                Response.Redirect("~/CreateUser.aspx", false);
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
    }
}