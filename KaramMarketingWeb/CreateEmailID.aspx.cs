using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class CreateEmailID : System.Web.UI.Page
    {
        clsBusinesslayer objbusinesslayer = new clsBusinesslayer();
        string UserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                if (!IsPostBack)
                {
                    string hdnModule = "";
                    string hdnName = "";
                    // Bindroles();
                    if (Request.QueryString.AllKeys.Contains("UID"))
                    {
                        hdnUSERID.Value = Request.QueryString["UID"].ToString();
                        hdnModule = Request.QueryString["UID"].ToString();
                        hdnName = Request.QueryString["NAME"].ToString();
                    }
                    if (!string.IsNullOrEmpty(hdnUSERID.Value))
                    {
                        GetEmailDetails(hdnModule.ToString(), hdnName.ToString());
                        lblHeading.Text = "Update Email";
                       // ddlModule.Enabled = false;
                        btnCreate.Text = "Update";


                    }
                    else
                    {
                        lblHeading.Text = "Create Email";
                        btnCreate.Text = "Create";
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
                if (string.IsNullOrEmpty(txtName.Value))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please enter the Name";
                }
                if (string.IsNullOrEmpty(txtEmail.Value))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Enter the Email";
                }
                if (ddlModule.SelectedIndex < 1)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please selected the Module";
                }
                if (Request.QueryString.AllKeys.Contains("UID"))
                {
                    string hdnModule = "";
                    string hdnName = "";
                    hdnUSERID.Value = Request.QueryString["UID"].ToString();
                    hdnModule = Request.QueryString["UID"].ToString();
                    hdnName = Request.QueryString["NAME"].ToString();
                    objbusinesslayer.UpdateEmail(ddlModule.SelectedValue, txtName.Value.Trim(), txtEmail.Value.Trim(),
                        "Karam", ddlStatus.SelectedValue, Session["USERNAME"].ToString() , hdnModule.Trim(), hdnName.Trim());

                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Updated Successfully";
                }
                else
                {
                    objbusinesslayer.InsertEmail(ddlModule.SelectedValue, txtName.Value.Trim(), txtEmail.Value.Trim(),
                        "Karam", ddlStatus.SelectedValue, Session["USERNAME"].ToString());
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Created Successfully";
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
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                txtEmail.Value = "";


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

                Response.Redirect("~/frmEmail.aspx", false);

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        public void GetEmailDetails(string Module, string Name)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                DataTable dtEmail = new DataTable();
                dtEmail = objbusinesslayer.GetEmailDeatils(Module.Trim(), Name.Trim());
                if (dtEmail != null)
                {
                    if (dtEmail.Rows.Count > 0)
                    {
                        string _Module = dtEmail.Rows[0]["Module"].ToString();
                        string _Name = dtEmail.Rows[0]["UName"].ToString();
                        string _Email = dtEmail.Rows[0]["Email"].ToString();
                        string _Status = dtEmail.Rows[0]["RowStatus"].ToString();

                        ddlModule.SelectedValue = _Module;
                        ddlStatus.SelectedValue = _Status;
                        txtEmail.Value = _Email;
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