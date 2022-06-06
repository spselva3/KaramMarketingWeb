using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaramMarketingWeb
{
    public class clsDashBoard
    {
        public DataTable GetReservationDashBoard(object Username)
        {
            try
            {
                string strProcedureName = "SP_GetReserveDashBoard_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public DataTable GetLogisticDashBoard(object Username)
        {
            try
            {
                string strProcedureName = "SP_GetLogisticDashBoard_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetWHDashBoard(object Username)
        {
            try
            {
                string strProcedureName = "SP_GetWHDashBoard_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetProductionDashBoard(object Username)
        {
            try
            {
                string strProcedureName = "SP_GetProductionDashBoard_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}