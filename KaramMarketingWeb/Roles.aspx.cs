using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{

    public partial class Roles : System.Web.UI.Page
    {
        clsUser _Cls = new clsUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    if (!IsPostBack)
                    {
                        spGetallRoles_Web();
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
        protected void spGetallRoles_Web()
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                DataTable dtroles = new DataTable();
                dtroles = _Cls.GetAllRolesReport("");
                if (dtroles != null)
                {
                    if (dtroles.Rows.Count > 0)
                    {
                        lvRoeles.DataSource = dtroles;
                        lvRoeles.DataBind();
                    }
                    else
                    {
                        lvRoeles.DataSource = dtroles;
                        lvRoeles.DataBind();
                    }
                }
                else
                {
                    lvRoeles.DataSource = dtroles;
                    lvRoeles.DataBind();
                }
               
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void btnSaveRole_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMsg.Style.Value = "display:none";
                lblMessage.Text = "";
                if (string.IsNullOrEmpty(txtrolemp.Text))
                {
                    lblErrorrmsgpopup.Text = "Please enter Role";
                    txtrolemp.Focus();
                   // ModalPopupExtender1.Show();
                    return;
                }

                int _Roleid = 0;
                _Roleid = Convert.ToInt32(hdnroleID.Value);
                string Crby = Session["UserName"].ToString();
                DataTable dtrole = new DataTable();
                dtrole = _Cls.spRoledetailsINSUPD_web_RM(_Roleid, txtrolemp.Text, txtroledesmp.Text, 1, Crby);
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
                        _Cls.spInsertAllMenusDetails_Web_RM(_roleid, txtrolemp.Text, item.Text, item.Value,
                            Crby, "HHT");
                    }
                }
                foreach (ListItem itemweb in chkWEBModules.Items)
                {
                    if (itemweb.Selected)
                    {
                        _Cls.spInsertAllMenusDetails_Web_RM(_roleid, txtrolemp.Text, itemweb.Text, itemweb.Value,
                            Crby, "WEB");
                    }
                }
                if (_Roleid > 0)
                {
                   // lblErrorMsg.Text = "<b><font color=green>" + "Role Updated Successfully !!!!" + "</font></b>";
                }
                else
                {
                  //  lblErrorMsg.Text = "<b><font color=green>" + "Role Created Successfully !!!!" + "</font></b>";
                }

                spGetallRoles_Web();

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        protected void lvRoeles_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
           
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/CreateRole.aspx", false);
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
           
        }
        
    }
}