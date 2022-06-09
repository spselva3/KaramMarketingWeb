using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class CreateUser : System.Web.UI.Page
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
                    Bindroles();
                    BindFloors();
                    BindRegion();
                    pnlFloor.Visible = false;

                    pnlRegion.Visible = false;

                    if (Request.QueryString.AllKeys.Contains("UID"))
                    {
                        hdnUSERID.Value = Request.QueryString["UID"].ToString();
                    }
                    if (hdnUSERID.Value == "0" || hdnUSERID.Value == "")
                    {
                        lblHeading.Text = "Create User";
                        return;
                    }
                    if (hdnUSERID.Value != "0")
                    {
                        spGetUserdetailbyUID(hdnUSERID.Value);
                        lblHeading.Text = "Update User";
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
        public void spGetUserdetailbyUID(object Userid)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                DataTable dtUserdetails = new DataTable();
                dtUserdetails = objbusinesslayer.spGetUserdetailbyUID_RM(Userid, "");
                if (dtUserdetails != null)
                {
                    if (dtUserdetails.Rows.Count > 0)
                    {
                        txtUname.Value = dtUserdetails.Rows[0]["USERNAME"].ToString();
                        txtPswd.Value = dtUserdetails.Rows[0]["USERPASSWORD"].ToString();
                        txtPswd.Attributes.Add("value", dtUserdetails.Rows[0]["USERPASSWORD"].ToString());

                        txtFName.Value = dtUserdetails.Rows[0]["FIRSTNAME"].ToString();
                        txtMName.Value = dtUserdetails.Rows[0]["LASTNAME"].ToString();
                        txtEmail.Value = dtUserdetails.Rows[0]["EMAIL"].ToString();
                        txtMobile.Value = dtUserdetails.Rows[0]["PHONE"].ToString();
                        int RoleID = 0;
                        string _UserStatus = "";

                        RoleID = Convert.ToInt32(dtUserdetails.Rows[0]["RoleID"].ToString());
                        _UserStatus = dtUserdetails.Rows[0]["USERSTATUS"].ToString();
                        if (ddlRole.Items.Contains(ddlRole.Items.FindByValue(RoleID.ToString())))
                        {
                            ddlRole.SelectedValue = RoleID.ToString();
                        }
                        if (ddlStatus.Items.Contains(ddlStatus.Items.FindByValue(_UserStatus)))
                        {
                            ddlStatus.SelectedValue = _UserStatus;
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }


        public void Bindroles()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if (ddlRole.Items.Count > 0)
                {
                    ddlRole.Items.Clear();
                }
                DataTable dtroles = new DataTable();
                dtroles = objbusinesslayer.spGetRoles_Web_RM();
                if (dtroles != null)
                {
                    if (dtroles.Rows.Count > 0)
                    {
                        ddlRole.DataSource = dtroles;
                        ddlRole.DataValueField = "Roleid";
                        ddlRole.DataTextField = "Rolename";
                        ddlRole.DataBind();
                    }
                }
                ddlRole.Items.Insert(0, "Please Select");
                ddlRole.Items[0].Value = "-1";
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }


        public void BindFloors()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if (ddlFloor.Items.Count > 0)
                {
                    ddlFloor.Items.Clear();
                }
                DataTable dtroles = new DataTable();
                dtroles = objbusinesslayer.spGetFloors_Web();
                if (dtroles != null)
                {
                    if (dtroles.Rows.Count > 0)
                    {
                        ddlFloor.DataSource = dtroles;
                        ddlFloor.DataValueField = "ProductionFloor";
                        ddlFloor.DataTextField = "ProductionFloor";
                        ddlFloor.DataBind();
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }


        public void BindRegion()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                if (ddlRegion.Items.Count > 0)
                {
                    ddlRegion.Items.Clear();
                }
                DataTable dtroles = new DataTable();
                dtroles = objbusinesslayer.spGetRegions_Web();
                if (dtroles != null)
                {
                    if (dtroles.Rows.Count > 0)
                    {
                        ddlRegion.DataSource = dtroles;
                        ddlRegion.DataValueField = "Region";
                        ddlRegion.DataTextField = "Region";
                        ddlRegion.DataBind();
                    }
                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }


        public void clearAll()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                txtUname.Value = "";
                txtPswd.Value = "";
                txtPswd.Attributes.Add("value", "");
                txtFName.Value= "";
                txtMName.Value = "";
                txtEmail.Value = "";
                txtMobile.Value = "";
                ddlRole.SelectedIndex = -1;
                ddlStatus.SelectedIndex = -1;
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
                if(string.IsNullOrEmpty(txtFName.Value.ToString()))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Enter the Name";
                    return;
                }
                if (string.IsNullOrEmpty(txtUname.Value.ToString()))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Enter the User Name";
                    return;
                }
                if (string.IsNullOrEmpty(txtPswd.Value.ToString()))
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Enter the Password";
                    return;
                }
                if (ddlStatus.SelectedIndex < 1)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Select the Status";
                    return;
                }
                if (ddlRole.SelectedIndex < 0)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "Please Select the Role";
                    return;
                }
                //if (ddlRegion.SelectedIndex < 0)
                //{
                //    ErrorMsg.Style.Value = "display:block";
                //    lblMessage.Text = "Please Select the Region";
                //    return;
                //}

                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                string Region = "";
                string Floor = "";

                if (pnlFloor.Visible == true)
                {
                    Floor = ddlFloor.SelectedValue.ToString();
                }
                if (pnlRegion.Visible == true)
                {
                     Region = ddlRegion.SelectedValue.ToString();
                }

                objbusinesslayer.InsertUser_RM(txtFName.Value.ToString(), txtMName.Value.ToString(), txtUname.Value.ToString(), txtPswd.Value.ToString(), txtEmail.Value.ToString(),
                    txtMobile.Value.ToString(), ddlStatus.SelectedValue, ddlRole.SelectedItem.Value, ddlRole.SelectedItem.Text.ToString(), 
                    hdnUSERID.Value, Session["UserName"].ToString() , Floor , Region);
                
                clearAll();

                if (hdnUSERID.Value != "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User updated successfully.')", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User created successfully.')", true);
                }
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Users.aspx", false);
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearAll();
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";

                string Role = ddlRole.SelectedItem.Text;

                    

                if(Role.ToUpper() == "PRODUCTION")
                {
                    pnlFloor.Visible = true;
                    pnlRegion.Visible = false;
                }
                else if(Role.ToUpper() == "MARKETING")
                {
                    pnlRegion.Visible = true;
                    pnlFloor.Visible = false;
                }
                else
                {
                    pnlRegion.Visible = false;
                    pnlFloor.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }
    }
}