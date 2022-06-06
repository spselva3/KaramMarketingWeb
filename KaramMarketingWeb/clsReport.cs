using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaramMarketingWeb
{
    public class clsReport
    {
        public DataTable GetReservationDashBoard(object Username , string From , string To , string Status)
        {
            try
            {
                string strProcedureName = "SP_GetReserveReport_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName , parUserFrom  , parUserTo , parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReserveItems(string ReserveID)
        {
            try
            {
                string strProcedureName = "SP_GetReserveItemReport_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@ReserveID", ReserveID);
                SqlParameter[] par = { parUserName};
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReserveItemsWareHouse(string ReserveID)
        {
            try
            {
                string strProcedureName = "SP_GetReserveItemReport_WH_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@ReserveID", ReserveID);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetLogisticReport(object Username, string From, string To)
        {
            try
            {
                string strProcedureName = "SP_GetLogisticReport_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetWHReport(object Username, string From, string To)
        {
            try
            {
                string strProcedureName = "SP_GetWHReport_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DashBoardCount(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "sp_GetDbCount_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GraphReserve()
        {
            try
            {
                string strProcedureName = "Chart_ReservedItems";
                SqlParameter[] par = { };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GraphReserveCancellation()
        {
            try
            {
                string strProcedureName = "Chart_CancelledItems";
                SqlParameter[] par = { };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetWareHouseStock(string ValueType)
        {
            try
            {
                string strProcedureName = "XXK_Warehouse_Stock_Report_New";
                SqlParameter parValueType = CommonDL.CreateParameter("@Statement", ValueType);
                SqlParameter[] par = { parValueType };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDeadStock(string ValueType)
        {
            try
            {
                string strProcedureName = "XXK_Dead_SlowMoving_Stock_Report_New";
                SqlParameter parValueType = CommonDL.CreateParameter("@Statement", ValueType);
                SqlParameter[] par = { parValueType };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LogisticDashBoard(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetLogisticReport_New_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable ConsolidatedDashBoard(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetConsolidatedReport_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable WareHouseReport(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetWHReportNew_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ProductionDashBoard(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetProductionReportNew_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProduction(string ProductionID, string SalesOrder, string ItemCode , string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateProductionStatus_Web";
                SqlParameter parProductionID = CommonDL.CreateParameter("@ProductionID", DbType.String, ProductionID);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", DbType.String, SalesOrder);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parProductionID, parSalesOrder, parItemCode, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable productionReport(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetProductionReport_Web";     
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ProductionDashBoardNew(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_ProductionReportDataGrid_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable ProductionDashBoardCount(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetProductionCount_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LogisticDashBoardNew(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_LogisticReportDataGrid_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LogisticDashBoardCount(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetLogisticCount_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable WareHouseDashBoardNew(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_WareHouseReportDataGrid_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable WareHouseDashBoardCount(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetWHCount_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@User", Username);
                SqlParameter parUserFrom = CommonDL.CreateParameter("@FromDate", From);
                SqlParameter parUserTo = CommonDL.CreateParameter("@Todate", To);
                SqlParameter parStatus = CommonDL.CreateParameter("@Status", Status);
                SqlParameter[] par = { parUserName, parUserFrom, parUserTo, parStatus };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}