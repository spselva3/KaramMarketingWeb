using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class Login : System.Web.UI.Page
    {
        clsBusinesslayer objclsbusinesslayer = new clsBusinesslayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtUsername.Focus();
            }
        }

    

        protected void btnLoginUser_Click(object sender, EventArgs e)
        {
            string User = txtusername.Value.ToString();
            string Password = txtpassword.Value.ToString();

           // Response.Redirect("~/TestPage1.aspx", false);
            try
            {
                if (txtusername.Value.ToString() == string.Empty)
                {
                    return;
                }
                if (txtpassword.Value.ToString() == string.Empty)
                {
                    return;
                }
                DataTable dtLogin = new DataTable();
                dtLogin = objclsbusinesslayer.CheckUser(User.Trim(), Password.Trim());
                if (dtLogin.Rows.Count > 0)
                {
                    Session["UserName"] = dtLogin.Rows[0]["UserName"].ToString();
                    Session["UserID"] = dtLogin.Rows[0]["UserID"].ToString();
                    Session["RoleID"] = dtLogin.Rows[0]["RoleID"].ToString();
                    Session["Rolename"] = dtLogin.Rows[0]["RoleName"].ToString();

                    Response.Redirect("~/MainPage.aspx", false);
                    // Response.Redirect("~/Inventory.aspx", false);
                }
                else
                {
                    lblError.Text = "Wrong Credentials";
                    txtusername.Value = string.Empty;
                    txtpassword.Value = string.Empty;
                    
                    return;
                }
            }
            catch (Exception exe)
            {
                lblError.Text = exe.Message;
            }
        }
    }
}