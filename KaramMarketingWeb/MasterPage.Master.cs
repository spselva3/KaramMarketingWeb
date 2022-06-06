using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        clsBusinesslayer objclsbusinesslayer = new clsBusinesslayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                if (!IsPostBack)
                {
                    lblUserName.Text = Session["UserName"].ToString();
                    GetDataSource();
                }
                
            }
            else
            {
              //  Response.Redirect("frmSessionOut.aspx");
            }
        }
        private void GetDataSource()
        {
            pnlCategories.Visible = false;
            pnlMarketing.Visible = false;
            pnlLogistic.Visible = false;
            pnlWH.Visible = false;
            pnlEmail.Visible = false;
            pnlProduction.Visible = false;

            string _rolename = "";
            _rolename = Session["RoleName"].ToString();
            DataTable dtmenus = new DataTable();
            dtmenus = objclsbusinesslayer.spGetAllAssignedModules_NEW_RM(0, _rolename, "", "WEB");
            if (dtmenus != null)
            {
                if (dtmenus.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtmenus.Rows)
                    {
                        string _MODULEVALUE = "";
                        _MODULEVALUE = dr["Module"].ToString();

                        if (_MODULEVALUE.Trim().ToUpper() == "CATEG")
                        {
                            pnlCategories.Visible = true;
                        }
                        if (_MODULEVALUE.Trim().ToUpper() == "RESERVATION")
                        {
                            pnlMarketing.Visible = true;
                        }
                        if (_MODULEVALUE.Trim().ToUpper() == "LOGISTIC")
                        {
                            pnlLogistic.Visible = true;
                        }
                        if (_MODULEVALUE.Trim().ToUpper() == "WH")
                        {
                            pnlWH.Visible = true;
                        }
                        if (_MODULEVALUE.Trim().ToUpper() == "EMAIL")
                        {
                            pnlEmail.Visible = true;
                        }
                        if (_MODULEVALUE.Trim().ToUpper() == "PROD")
                        {
                            pnlProduction.Visible = true;
                        }

                    }
                }
            }
        }
    }
}