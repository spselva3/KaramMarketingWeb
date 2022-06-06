using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class CreateEmail : System.Web.UI.Page
    {
        clsBusinesslayer objbusinesslayer = new clsBusinesslayer();
        string UserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

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
                if(string.IsNullOrEmpty(txtName.Value))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please enter the Name";
                }
               
                if(ddlModule.SelectedIndex < 1)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please selected the Module";
                }

                objbusinesslayer.InsertEmail(ddlModule.SelectedValue, txtName.Value.Trim(), "", "Karam", ddlModule.SelectedValue, Session["USERNAME"].ToString());


            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

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
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        public void GetEmailDetails(string Module , string Name)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                DataTable dtEmail = new DataTable();
                dtEmail = objbusinesslayer.GetEmailDeatils(Module.Trim() , Name.Trim());
                if (dtEmail != null)
                {
                    if (dtEmail.Rows.Count > 0)
                    {
                        string _Module = dtEmail.Rows[0]["Module"].ToString();
                        string _Name =   dtEmail.Rows[0]["UName"].ToString();
                        string _Email = dtEmail.Rows[0]["Email"].ToString();
                        string _Status = dtEmail.Rows[0]["RowStatus"].ToString();

                        ddlModule.SelectedValue = _Module;
                        ddlStatus.SelectedValue = _Status;
                       
                        txtName.Value = _Name;
                    }
                }

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }

        }
    }
}