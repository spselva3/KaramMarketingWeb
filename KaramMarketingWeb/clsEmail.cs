using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaramMarketingWeb
{
    public class clsEmail
    {
        public  DataTable GellAllEmail(string Module)
        {
            try
            {
                string strProcedureName = "SP_GetAllEmail_Web";
                SqlParameter Type = CommonDL.CreateParameter("@Module", DbType.String, Module);
                SqlParameter[] par = { Type };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  DataTable GetEmailName()
        {
            try
            {
                string strProcedureName = "SP_GetEmailName_Web";
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  DataTable GetEmailByName(string Name)
        {
            try
            {
                string strProcedureName = "SP_GetSpecificEmailbyName_Web";
                SqlParameter Type = CommonDL.CreateParameter("@Name", DbType.String, Name);
                SqlParameter[] par = { Type };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public  void InsertEmail(string Module, string Name, string Email, string Location, string Status, string User)
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


    }
}