using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaramMarketingWeb
{
    public class clsUser
    {
        public DataTable GetAllUser(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetUserReport_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetAllRolesReport(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetRoleReport_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetHHTModule(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetHhtModule_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetWebModule(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetWebModule_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable spGetAllAssignedModules_WEB_RM(object roleid, object Type)
        {
            try
            {
                string strProcedureName = "SP_GetAllAssignedModules_Web";
                SqlParameter parroleid = CommonDL.CreateParameter("@RoleID", DbType.Int32, roleid);
                SqlParameter partype = CommonDL.CreateParameter("@TYPE", DbType.String, Type);
                SqlParameter[] par = { parroleid, partype };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable spRoledetailsINSUPD_web_RM(object Roleid, object Rolename, object Roledesc, object status, object Crby)
        {
            try
            {
                string strProcedureName = "SP_RoleDetailInsertUpd_Web";
                SqlParameter parroleid = CommonDL.CreateParameter("@Roleid", DbType.Int32, Roleid);
                SqlParameter parRolename = CommonDL.CreateParameter("@Rolename", DbType.String, Rolename);
                SqlParameter parroledesc = CommonDL.CreateParameter("@RoleDes", DbType.String, Roledesc);
                SqlParameter parstatus = CommonDL.CreateParameter("@Status", DbType.String, status);
                SqlParameter parcrby = CommonDL.CreateParameter("@Crby", DbType.String, Crby);
                SqlParameter[] par = { parroleid, parRolename, parroledesc, parstatus, parcrby };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void spDeleteAllMenuDetails_web_RM(object Roleid)
        {
            try
            {
                string strProcedureName = "spDeleteAllMenuDetails_web_RM";
                SqlParameter parroleid = CommonDL.CreateParameter("@Roleid", DbType.String, Roleid);
                SqlParameter[] par = { parroleid };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void spInsertAllMenusDetails_Web_RM(object Roleid, object Rolename, object modulename, object ModuleValue, object crby, object type)
        {
            try
            {
                string strProcedureName = "SP_InsertAllMenusDetails_Web";
                SqlParameter parroleid = CommonDL.CreateParameter("@Roleid", DbType.String, Roleid);
                SqlParameter parrolename = CommonDL.CreateParameter("@RoleName", DbType.String, Rolename);
                SqlParameter parmodulename = CommonDL.CreateParameter("@Modulename", DbType.String, modulename);
                SqlParameter parmoduleid = CommonDL.CreateParameter("@MODULEVALUE", DbType.String, ModuleValue);
                SqlParameter parcrby = CommonDL.CreateParameter("@Createdby", DbType.String, crby);
                SqlParameter partype = CommonDL.CreateParameter("@Type", DbType.String, type);

                SqlParameter[] par = { parroleid, parrolename, parmodulename, parmoduleid, parcrby, partype };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetroleDetail(object UserID, object Process)
        {
            try
            {
                string strProcedureName = "SP_GetRoleID_Web";

                SqlParameter parUserid = CommonDL.CreateParameter("@USERID", UserID);
                SqlParameter parprocess = CommonDL.CreateParameter("@PROCESS", Process);

                SqlParameter[] par = { parUserid, parprocess };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}