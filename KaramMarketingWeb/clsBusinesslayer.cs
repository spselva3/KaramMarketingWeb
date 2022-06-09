using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;


namespace KaramMarketingWeb
{
    public class clsBusinesslayer
    {
        ////// LOGINN

        public DataTable CheckUser(object Username, object Password)
        {
            try
            {
                string strProcedureName = "Sp_CheckUser_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@UserName", Username);
                SqlParameter parPassword = CommonDL.CreateParameter("@Password", Password);
                SqlParameter[] par = { parUserName, parPassword };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable spGetAllAssignedModules_NEW_RM(object RoleID, object Rolename, object Plant, object Type)
        {
            try
            {
                string strProcedureName = "spGetAllAssignedModules_NEW_RM";

                SqlParameter parroleid = CommonDL.CreateParameter("@RoleID", DbType.Int32, RoleID);
                SqlParameter parrolename = CommonDL.CreateParameter("@RoleName", DbType.String, Rolename);
                SqlParameter parPlant = CommonDL.CreateParameter("@PLANT", DbType.String, Plant);
                SqlParameter partype = CommonDL.CreateParameter("@TYPE", DbType.String, Type);

                SqlParameter[] par = { parroleid, parrolename, parPlant, partype };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable spGetUserdetailbyUID_RM(object UserID, object Process)
        {
            try
            {
                string strProcedureName = "SP_GetUserDetailsbyID_Web";

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


        public DataTable spGetRoles_Web_RM()
        {
            try
            {
                string strProcedureName = "SP_GetRoles_Web";
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable spGetFloors_Web()
        {
            try
            {
                string strProcedureName = "SP_GetFloor_Web";
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable spGetRegions_Web()
        {
            try
            {
                string strProcedureName = "SP_GetRegion_Web";
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable spGetRegionsReservation_Web()
        {
            try
            {
                string strProcedureName = "SP_GetRegionReservation_Web";
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InsertUser_RM(object Firstname, object Lastname, object Username, 
            object Password, object Email, object Phone,
          object Status, object RoleID, object Rolename, object USERID, 
          object CRBY , string Floor , string Region)
        {
            try
            {
                string strProcedureName = "InsertUser";

                SqlParameter parFirstname = CommonDL.CreateParameter("@Firstname", Firstname);
                SqlParameter parLastname = CommonDL.CreateParameter("@Lastname", Lastname);
                SqlParameter parUsername = CommonDL.CreateParameter("@Username", Username);
                SqlParameter parPassword = CommonDL.CreateParameter("@Password", Password);
                SqlParameter parEmail = CommonDL.CreateParameter("@Email", Email);
                SqlParameter parPhone = CommonDL.CreateParameter("@Phone", Phone);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter parRoleID = CommonDL.CreateParameter("@RoleID", RoleID);
                SqlParameter parRolename = CommonDL.CreateParameter("@Rolename", Rolename);
                SqlParameter paruserid = CommonDL.CreateParameter("@USERID", USERID);
                SqlParameter parcrby = CommonDL.CreateParameter("@CRBY", CRBY);
                SqlParameter parFloor = CommonDL.CreateParameter("@Floor", Floor);
                SqlParameter parRegion = CommonDL.CreateParameter("@Region", Region);

                SqlParameter[] par = { parFirstname, parLastname, parUsername,parPassword,parEmail,parPhone,parStatus,
                parRoleID,parRolename,paruserid,parcrby , parFloor , parRegion};
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetEmailDeatils( string Module, string Name)
        {
            try
            {
                string strProcedureName = "SP_GetEmailDetails_Web";
                SqlParameter parModule = CommonDL.CreateParameter("@Module", Module);
                SqlParameter parUser = CommonDL.CreateParameter("@Name", Name);
                SqlParameter[] par = { parModule, parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName , par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertEmail(string Module, string Name, string Email, string Location, string Status, string User)
        {
            try
            {
                string strProcedureName = "SP_InsertEmail_Web";
                SqlParameter Type = CommonDL.CreateParameter("@Module", DbType.String, Module);
                SqlParameter Cod = CommonDL.CreateParameter("@Name", DbType.String, Name);
                SqlParameter Ema = CommonDL.CreateParameter("@Email", DbType.String, Email);
                SqlParameter Loc = CommonDL.CreateParameter("@Location", DbType.String, Location);
                SqlParameter Stats = CommonDL.CreateParameter("@Status", DbType.String, Status);
                SqlParameter Us = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { Type, Cod, Ema, Loc, Stats, Us };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmail(string Module, string Name, string Email, string Location, string Status, string User , string OldModule , string OldName)
        {
            try
            {
                string strProcedureName = "SP_UpdateEmail_Web";
                SqlParameter Type = CommonDL.CreateParameter("@Module", DbType.String, Module);
                SqlParameter Cod = CommonDL.CreateParameter("@Name", DbType.String, Name);
                SqlParameter Ema = CommonDL.CreateParameter("@Email", DbType.String, Email);
                SqlParameter Loc = CommonDL.CreateParameter("@Location", DbType.String, Location);
                SqlParameter Stats = CommonDL.CreateParameter("@Status", DbType.String, Status);
                SqlParameter Us = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter UsOldModule = CommonDL.CreateParameter("@OldModule", DbType.String, OldModule);
                SqlParameter UsOldName = CommonDL.CreateParameter("@OldName", DbType.String, OldName);
                SqlParameter[] par = { Type, Cod, Ema, Loc, Stats, Us , UsOldModule , UsOldName };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}