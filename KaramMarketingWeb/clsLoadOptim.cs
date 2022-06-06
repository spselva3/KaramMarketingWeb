using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaramMarketingWeb
{
    public class clsLoadOptim
    {

        public DataTable GetLoadWithSalesOrder(string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_GetLoadProduct_SO_Web";
                SqlParameter Type = CommonDL.CreateParameter("@SalesOrder", DbType.String, SalesOrder);
                SqlParameter[] par = { Type };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetTruckList(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetTruckDetail_Web";
                SqlParameter Type = CommonDL.CreateParameter("@Process", DbType.String, Process);
                SqlParameter[] par = { Type };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable getSpecificTruckDetail(string TruckType)
        {
            try
            {
                string strProcedureName = "SP_GetSpecificTruck_Web";
                SqlParameter Type = CommonDL.CreateParameter("@TruckType", DbType.String, TruckType);
                SqlParameter[] par = { Type };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPackDetails_LoadOptim(string ItemCode  , string PackID)
        {
            try
            {
                string strProcedureName = "SP_GetPackDetails_Load_Web";
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parPackID = CommonDL.CreateParameter("@PackID", DbType.String, PackID);
                SqlParameter[] par = { parItemCode , parPackID };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}