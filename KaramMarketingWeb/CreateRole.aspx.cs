using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class CreateRole : System.Web.UI.Page
    {
        clsUser _Cls = new clsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                if (!IsPostBack)
                {
                    spGetHHTModules_RM();
                    spGetWEBModules_RM();

                    if (Request.QueryString.AllKeys.Contains("UID"))
                    {
                        hdnUSERID.Value = Request.QueryString["UID"].ToString();
                    }
                    if(!string.IsNullOrEmpty(hdnUSERID.Value.Trim()))
                    { 
                        spGetUserdetailbyUID(hdnUSERID.Value);

                        DataTable dsassignedmodulesHHT = new DataTable();
                        dsassignedmodulesHHT = _Cls.spGetAllAssignedModules_WEB_RM(Convert.ToInt32(hdnUSERID.Value), "HHT");
                        if (dsassignedmodulesHHT != null)
                        {
                            foreach (DataRow dr in dsassignedmodulesHHT.Rows)
                            {
                                string _MODULENAME = dr["ModuleValue"].ToString();

                                for (int i = 0; i < chkHHTModules.Items.Count; i++)
                                {
                                    if (chkHHTModules.Items[i].Value == _MODULENAME)
                                    {
                                        chkHHTModules.Items[i].Selected = true;
                                        break;
                                    }
                                }
                            }
                        }

                        DataTable dsassignedmodulesWEB = new DataTable();
                        dsassignedmodulesWEB = _Cls.spGetAllAssignedModules_WEB_RM(Convert.ToInt32(hdnUSERID.Value), "WEB");

                        if (dsassignedmodulesWEB != null)
                        {
                            foreach (DataRow dr in dsassignedmodulesWEB.Rows)
                            {
                                string _MODULENAME = dr["ModuleValue"].ToString();

                                for (int i = 0; i < chkWEBModules.Items.Count; i++)
                                {
                                    if (chkWEBModules.Items[i].Value == _MODULENAME)
                                    {
                                        chkWEBModules.Items[i].Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                        txtrolemp.Disabled = true;
                        lblHeading.Text = "Update Role";
                        btnCreate.Text = "Update";

                    }
                    else
                    {
                        lblHeading.Text = "Create Role";
                        btnCreate.Text = "Create";
                    }

                }
            }
            else
            {
                Response.Redirect("frmSessionOut.aspx");
            }
        }
        public void spGetUserdetailbyUID(object Userid)
        {
            try
            {
                DataTable dtUserdetails = new DataTable();
                dtUserdetails = _Cls.GetroleDetail(Userid, "");
                if (dtUserdetails != null)
                {
                    if (dtUserdetails.Rows.Count > 0)
                    {
                        txtrolemp.Disabled = true;
                        txtrolemp.Value = dtUserdetails.Rows[0]["RL_ROLENAME"].ToString();
                        txtroledesmp.Value = dtUserdetails.Rows[0]["RL_Des"].ToString();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                if (string.IsNullOrEmpty(txtrolemp.Value))
                {
                    return;
                }
                int _Roleid = 0;
                if (!string.IsNullOrEmpty(hdnUSERID.Value))
                {
                    _Roleid = Convert.ToInt32(hdnUSERID.Value);
                }
                string Crby = Session["UserName"].ToString();
                DataTable dtrole = new DataTable();
                dtrole = _Cls.spRoledetailsINSUPD_web_RM(_Roleid, txtrolemp.Value.ToString(), txtroledesmp.Value.ToString(), 1, Crby);
                int _roleid = 0;
                if (dtrole != null)
                {
                    if (dtrole.Rows.Count > 0)
                    {
                        _roleid = Convert.ToInt32(dtrole.Rows[0]["Roleid"].ToString());
                    }
                }
                _Cls.spDeleteAllMenuDetails_web_RM(_roleid);
                foreach (ListItem item in chkHHTModules.Items)
                {
                    if (item.Selected)
                    {
                        _Cls.spInsertAllMenusDetails_Web_RM(_roleid, txtrolemp.Value.ToString(), item.Text, item.Value,
                            Crby, "HHT");
                    }
                }
                foreach (ListItem itemweb in chkWEBModules.Items)
                {
                    if (itemweb.Selected)
                    {
                        _Cls.spInsertAllMenusDetails_Web_RM(_roleid, txtrolemp.Value.ToString(), itemweb.Text, itemweb.Value,
                            Crby, "WEB");
                    }
                }
                if (_Roleid > 0)
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "<b><font color=white>" + "Role Updated Successfully !!!!" + "</font></b>";
                    
                }
                else
                {
                    ErrorMsg.Style.Value = "display:block";
                    lblMessage.Text = "<b><font color=white>" + "Role Created Successfully !!!!" + "</font></b>";
                }
                Cleardata();


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
                Cleardata();
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
                Response.Redirect("~/Roles.aspx", false);
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }

        private void spGetHHTModules_RM()
        {
            try
            {
                DataTable dtHHTModules = _Cls.GetHHTModule("");
                if (dtHHTModules != null)
                {
                    if (dtHHTModules.Rows.Count > 0)
                    {
                        chkHHTModules.DataSource = dtHHTModules;
                        chkHHTModules.DataValueField = "ModuleValue";
                        chkHHTModules.DataTextField = "ModuleName";
                        chkHHTModules.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }

        private void spGetWEBModules_RM()
        {
            try
            {
                DataTable dtWEBModules = _Cls.GetWebModule("");
                if (dtWEBModules != null)
                {
                    if (dtWEBModules.Rows.Count > 0)
                    {
                        chkWEBModules.DataSource = dtWEBModules;
                        chkWEBModules.DataValueField = "ModuleValue";
                        chkWEBModules.DataTextField = "ModuleName";
                        chkWEBModules.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = ex.Message;
            }
        }
        public void Cleardata()
        {
            try
            {
                txtrolemp.Value = string.Empty;
                txtrolemp.Disabled = true;
                txtroledesmp.Value = string.Empty;
                hdnroleID.Value = "0";

                foreach (ListItem li in chkHHTModules.Items)
                {
                    li.Selected = false;
                }
                foreach (ListItem li in chkWEBModules.Items)
                {
                    li.Selected = false;
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