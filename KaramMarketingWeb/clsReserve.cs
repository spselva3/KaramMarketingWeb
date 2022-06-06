using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaramMarketingWeb
{
    public class clsReserve
    {
        public DataTable GetItemCode(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetReserveItemCode_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetItemDesc(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetReserveItemDescWeb";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetCategory(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetReserveCaegory_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable GetItemFiltersItems(string Itemcode , string ItemDesc , string Category)
        {
            try
            {
                string strProcedureName = "SP_NewGetAllStocks_Web";
                SqlParameter parItemcode = CommonDL.CreateParameter("@Itemcode", Itemcode);
                SqlParameter parItemDesc = CommonDL.CreateParameter("@ItemDesc", ItemDesc);
                SqlParameter parCategory = CommonDL.CreateParameter("@Category", Category);
                SqlParameter[] par = { parItemcode , parItemDesc, parCategory };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCartItems(string User)
        {
            try
            {
                string strProcedureName = "SP_GetCartItem_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@User", User);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertintoCart(string ItemCode,string ItemDesc , string Category , string UOM ,string DemandQty ,string User)
        {
            try
            {
                string strProcedureName = "SP_InsertItemCart_Web";
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parItemDesc = CommonDL.CreateParameter("@ItemDesc", DbType.String, ItemDesc);
                SqlParameter parCategory = CommonDL.CreateParameter("@Category", DbType.String, Category);
                SqlParameter parUOM = CommonDL.CreateParameter("@UOM", DbType.String, UOM);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parItemCode , parItemDesc, parCategory, parUOM, parDemandQty, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateSalesOrder(string ReserveID, string DemandDate  , string Customer, string SalesOrder, string Status,string SODate, string User , string Remarks)
        {
            try
            {
                string strProcedureName = "SP_UpdateSODetail_HMI";
                SqlParameter parReserve = CommonDL.CreateParameter("@ReservationID", DbType.String, ReserveID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@DemandDate", DbType.String, DemandDate);
                SqlParameter parItemDesc = CommonDL.CreateParameter("@Customer", DbType.String, Customer );
                SqlParameter parCategory = CommonDL.CreateParameter("@Status", DbType.String, Status);
                SqlParameter parUOM = CommonDL.CreateParameter("@SalesOrder", DbType.String, SalesOrder);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@SODate", DbType.String, SODate);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter parRemarks = CommonDL.CreateParameter("@Remarks", DbType.String, Remarks);
                SqlParameter[] par = { parReserve, parItemCode, parItemDesc, parCategory, parUOM, parDemandQty, parUser , parRemarks };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReservationID(string User)
        {
            try
            {
                string strProcedureName = "SP_GetReserverveID_HMI";
                SqlParameter parUser = CommonDL.CreateParameter("@User", User);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetSodetail_Auto(string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_GetSoDetailAuto_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@SO", SalesOrder);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReservationDetails(string Reservation)
        {
            try
            {
                string strProcedureName = "SP_GetReserveDetail_HHT";
                SqlParameter parUser = CommonDL.CreateParameter("@ReserveID", Reservation);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateReservation(string ReervationID, string ItemCode, string ItemDesc, string Category, string UOM,
            string DemandQty, string User, string UserRole, string Customer, string SalesOrder,
            string DEmandDate, string SODate, string PackStyle, string PackReq)
        {
            try
            {
                string strProcedureName = "SP_CreateReservationID";
                SqlParameter parReser = CommonDL.CreateParameter("@ReserveID", DbType.String, ReervationID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parItemDesc = CommonDL.CreateParameter("@ItemDesc", DbType.String, ItemDesc);
                SqlParameter parCategory = CommonDL.CreateParameter("@Category", DbType.String, Category);
                SqlParameter parUOM = CommonDL.CreateParameter("@UOM", DbType.String, UOM);
                SqlParameter parPackStyle = CommonDL.CreateParameter("@PackStyle", DbType.String, PackStyle);
                SqlParameter parPackReq = CommonDL.CreateParameter("@PackReq", DbType.String, PackReq);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter parUserRle = CommonDL.CreateParameter("@UserRole", DbType.String, UserRole);
                SqlParameter parCustomer = CommonDL.CreateParameter("@Customer", DbType.String, Customer);
                SqlParameter parSo = CommonDL.CreateParameter("@SalesOrder", DbType.String, SalesOrder);
                SqlParameter parDdate = CommonDL.CreateParameter("@DemandDate", DbType.String, DEmandDate);
                SqlParameter parSodate = CommonDL.CreateParameter("@SoDate", DbType.String, SODate);
                SqlParameter[] par = { parReser, parItemCode, parItemDesc, parCategory, parUOM, parPackStyle, parPackReq ,
                    parDemandQty, parUser , parUserRle
                ,parCustomer ,parSo , parDdate,parSodate };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DeleteCartItem(string ItemCode, string User)
        {
            try
            {
                string strProcedureName = "SP_DeleteCartItem_Web";
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parItemCode , parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetLogisticDetails(string Reserve)
        {
            try
            {
                string strProcedureName = "SP_GetReserveDetail_Log_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@ReserveID", Reserve);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetLogisticDetailsForSalesOrder(string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_GetReserveDetailSO_Log_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetLogisticData(string Reserve)
        {
            try
            {
                string strProcedureName = "SP_GetReserveItemReserved_Log_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@ReserveID", Reserve);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLogistic(string LogisticID ,string ReserveID , string Demandate , string ItemCode, string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateLogStatus_Web";
                SqlParameter parLogisticID = CommonDL.CreateParameter("@LogisticID", DbType.String, LogisticID);
                SqlParameter parReserveID = CommonDL.CreateParameter("@ReserveID", DbType.String, ReserveID);
                SqlParameter parDemandate = CommonDL.CreateParameter("@Demandate", DbType.String, Demandate);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parLogisticID , parReserveID, parDemandate, parItemCode,  parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateLogisticTDOD( string ReserveID, string DemandDate , string Remarks, string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateLogisticDate_Web";
                SqlParameter parLogisticID = CommonDL.CreateParameter("@ReserveID", DbType.String, ReserveID);
                SqlParameter parReserveID = CommonDL.CreateParameter("@DemandDate", DbType.String, DemandDate);
                SqlParameter parItemCode = CommonDL.CreateParameter("@Remarks", DbType.String, Remarks);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parLogisticID, parReserveID, parItemCode, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWHTDOD(string ReserveID, string DemandDate, string Remarks, string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateWHDate_Web";
                SqlParameter parLogisticID = CommonDL.CreateParameter("@ReserveID", DbType.String, ReserveID);
                SqlParameter parReserveID = CommonDL.CreateParameter("@DemandDate", DbType.String, DemandDate);
                SqlParameter parItemCode = CommonDL.CreateParameter("@Remarks", DbType.String, Remarks);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parLogisticID, parReserveID, parItemCode, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateProductionReviseTDOD(string ProductionID, string DemandDate, string Remarks, string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateProductionRevised_Web";
                SqlParameter parLogisticID = CommonDL.CreateParameter("@ProductionID", DbType.String, ProductionID);
                SqlParameter parReserveID = CommonDL.CreateParameter("@DemandDate", DbType.String, DemandDate);
                SqlParameter parItemCode = CommonDL.CreateParameter("@Remarks", DbType.String, Remarks);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parLogisticID, parReserveID, parItemCode, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWHResivedTDOD(string ReserveID, string DemandDate, string Remarks, string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateRevisedWHDate_Web";
                SqlParameter parLogisticID = CommonDL.CreateParameter("@ReserveID", DbType.String, ReserveID);
                SqlParameter parReserveID = CommonDL.CreateParameter("@DemandDate", DbType.String, DemandDate);
                SqlParameter parItemCode = CommonDL.CreateParameter("@Remarks", DbType.String, Remarks);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parLogisticID, parReserveID, parItemCode, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetLogisticID(string User)
        {
            try
            {
                string strProcedureName = "SP_UniqueGetLogisticID_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@User", User);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetWHDetails(string Reserve , string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_GetWHDetail_WH_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@ReserveID", Reserve);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter[] par = { parUser , parSalesOrder };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetProdDetails(string ProductionID, string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_GetProdDetail_Prod_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@ProductionID", ProductionID);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter[] par = { parUser, parSalesOrder };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetWHData(string Reserve , string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_GetWHItem_WH_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@ReserveID", Reserve);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter[] par = { parUser , parSalesOrder };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetWHData_UnReserve(string Reserve, string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_GetWHItem_WH_UNReserve_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@ReserveID", Reserve);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter[] par = { parUser, parSalesOrder };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetWHId(string User)
        {
            try
            {
                string strProcedureName = "SP_UniqueGetWHID_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@User", User);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateWHData(string WHID, string ReservationID, string ItemCode, string ItemDesc, string Category, string UOM, string DemandQty, string WHDate, string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateWHStatus_Web";
                SqlParameter parWHID = CommonDL.CreateParameter("@WHID", DbType.String, WHID);
                SqlParameter parReservationID = CommonDL.CreateParameter("@ReserveID", DbType.String, ReservationID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parItemDesc = CommonDL.CreateParameter("@ItemDesc", DbType.String, ItemDesc);
                SqlParameter parCategory = CommonDL.CreateParameter("@Category", DbType.String, Category);
                SqlParameter parUOM = CommonDL.CreateParameter("@UOM", DbType.String, UOM);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parWHDate = CommonDL.CreateParameter("@WHDate", DbType.String, WHDate);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parWHID, parReservationID, parItemCode, parItemDesc, parCategory, parUOM, parDemandQty, parWHDate, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetProdId(string User)
        {
            try
            {
                string strProcedureName = "SP_UniqueGetProdID_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@User", User);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateProductionData(string ProdID, string ReservationID, string ItemCode, string ItemDesc, string Category, string UOM, string DemandQty, string WHDate, string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateWHStatus_Web";
                SqlParameter parWHID = CommonDL.CreateParameter("@WHID", DbType.String, ProdID);
                SqlParameter parReservationID = CommonDL.CreateParameter("@ReserveID", DbType.String, ReservationID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parItemDesc = CommonDL.CreateParameter("@ItemDesc", DbType.String, ItemDesc);
                SqlParameter parCategory = CommonDL.CreateParameter("@Category", DbType.String, Category);
                SqlParameter parUOM = CommonDL.CreateParameter("@UOM", DbType.String, UOM);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parWHDate = CommonDL.CreateParameter("@WHDate", DbType.String, WHDate);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parWHID, parReservationID, parItemCode, parItemDesc, parCategory, parUOM, parDemandQty, parWHDate, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReservedItemsforEdit(string ReservationID ,string User)
        {
            try
            {
                string strProcedureName = "SP_GetReservationItem_HMI";
                SqlParameter parReserveID = CommonDL.CreateParameter("@ReservationID", ReservationID);
                SqlParameter parUser = CommonDL.CreateParameter("@User", User);
                SqlParameter[] par = { parReserveID ,parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteReserveItem(string ReservationID ,string ItemCode, string User)
        {
            try
            {
                string strProcedureName = "SP_DeleteReservationItem_HMI";
                SqlParameter parReservationID = CommonDL.CreateParameter("@ReservationID", DbType.String, ReservationID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parReservationID, parItemCode, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EditReserveItem(string ReservationID, string ItemCode, string DemandQty, string User, string PackStyle, string PackReq)
        {
            try
            {
                string strProcedureName = "SP_EditReserveItem_HMI";
                SqlParameter parReservationID = CommonDL.CreateParameter("@ReservationID", DbType.String, ReservationID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter parPackStyle = CommonDL.CreateParameter("@PackStyle", DbType.String, PackStyle);
                SqlParameter parPackReq = CommonDL.CreateParameter("@PackReq", DbType.String, PackReq);
                SqlParameter[] par = { parReservationID, parItemCode, parDemandQty, parPackStyle, parPackReq, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateToProduction(string WHID, string ReservationID, string ItemCode, string ItemDesc, string Category, string UOM, string DemandQty, string WHDate, string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateWHStatus_Web";
                SqlParameter parWHID = CommonDL.CreateParameter("@WHID", DbType.String, WHID);
                SqlParameter parReservationID = CommonDL.CreateParameter("@ReserveID", DbType.String, ReservationID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parItemDesc = CommonDL.CreateParameter("@ItemDesc", DbType.String, ItemDesc);
                SqlParameter parCategory = CommonDL.CreateParameter("@Category", DbType.String, Category);
                SqlParameter parUOM = CommonDL.CreateParameter("@UOM", DbType.String, UOM);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parWHDate = CommonDL.CreateParameter("@WHDate", DbType.String, WHDate);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parWHID, parReservationID, parItemCode, parItemDesc, parCategory, parUOM, parDemandQty, parWHDate, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EmailCreateReservation(string ReervationID)
        {
            try
            {
                string strProcedureName = "Email_ReservationCreation";
                SqlParameter parReser = CommonDL.CreateParameter("@ReservationID", DbType.String, ReervationID);
                
                SqlParameter[] par = { parReser  };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EmailUpdateReservation(string ReervationID)
        {
            try
            {
                string strProcedureName = "Email_ReservationUpdate";
                SqlParameter parReser = CommonDL.CreateParameter("@ReservationID", DbType.String, ReervationID);

                SqlParameter[] par = { parReser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPackStyle(string ItemCode)
        {
            try
            {
                string strProcedureName = "SP_GetPackStyle_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@ItemCode", ItemCode);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateCartItems(string ItemCode, string DemandQty, string User, string PackStyle, string PackReq)
        {
            try
            {
                string strProcedureName = "SP_UpdateCartItem_Web";
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter parPackStyle = CommonDL.CreateParameter("@PackStyle", DbType.String, PackStyle);
                SqlParameter parPackReq = CommonDL.CreateParameter("@PackReq", DbType.String, PackReq);
                SqlParameter[] par = { parItemCode, parDemandQty, parPackStyle, parPackReq, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CheckSalesOrderDetail(string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_SoGetSoDetailCheck_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetSo(string Process)
        {
            try
            {
                string strProcedureName = "SP_SoGetSofromRM_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetStockPackets(string ItemCode, string Qty, string PackStyle)
        {
            try
            {
                string strProcedureName = "SP_GetStockPackets_HMI";
                SqlParameter parUser = CommonDL.CreateParameter("@ItemCode", ItemCode);
                SqlParameter parQty = CommonDL.CreateParameter("@Qty", Qty);
                SqlParameter parPackStyle = CommonDL.CreateParameter("@PackStyle", PackStyle);
                SqlParameter[] par = { parUser, parQty, parPackStyle };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DEductInventory(string ReervationID, string AssetID, string ItemCode, string Category,
           string PackStyle, string DemandQty, string PreviousQty, string DeductQty, string NewQty,
              string User)
        {
            try
            {
                string strProcedureName = "SP_DeductInvQty_Web";
                SqlParameter parReser = CommonDL.CreateParameter("@ReserveID", DbType.String, ReervationID);
                SqlParameter parAssetID = CommonDL.CreateParameter("@AssetID", DbType.String, AssetID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parCategory = CommonDL.CreateParameter("@Category", DbType.String, Category);
                SqlParameter parPackStyle = CommonDL.CreateParameter("@PackStyle", DbType.String, PackStyle);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parPreviousQty = CommonDL.CreateParameter("@PreviousQty", DbType.String, PreviousQty);
                SqlParameter parDeductQty = CommonDL.CreateParameter("@DeductQty", DbType.String, DeductQty);
                SqlParameter parNewQty = CommonDL.CreateParameter("@NewQty", DbType.String, NewQty);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);

                SqlParameter[] par = { parReser, parAssetID ,parItemCode,  parCategory,  parPackStyle, parDemandQty ,
                    parPreviousQty, parDeductQty ,parNewQty ,parUser  };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RequestProduction(string WHID, string ReservationID, string ItemCode,
            string ItemDesc, string Category, string UOM, string DemandQty, string User , string SalesOrder , string WHDate)
        {
            try
            {
                string strProcedureName = "SP_RequestProduction_Web";
                SqlParameter parWHID = CommonDL.CreateParameter("@ProdID", DbType.String, WHID);
                SqlParameter parReservationID = CommonDL.CreateParameter("@ReserveID", DbType.String, ReservationID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parItemDesc = CommonDL.CreateParameter("@ItemDesc", DbType.String, ItemDesc);
                SqlParameter parCategory = CommonDL.CreateParameter("@Category", DbType.String, Category);
                SqlParameter parUOM = CommonDL.CreateParameter("@UOM", DbType.String, UOM);
                SqlParameter parDemandQty = CommonDL.CreateParameter("@DemandQty", DbType.String, DemandQty);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", DbType.String, SalesOrder);
                //SqlParameter parWHDate = CommonDL.CreateParameter("@WHDate", DbType.String, WHDate);
                SqlParameter[] par = { parWHID, parReservationID, parItemCode, parItemDesc, parCategory, parUOM, parDemandQty, parUser , parSalesOrder };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancellReserveItem(string ReservationID, string ItemCode, string User)
        {
            try
            {
                string strProcedureName = "SP_DeleteReservationItemCancelled_Web";
                SqlParameter parReservationID = CommonDL.CreateParameter("@ReservationID", DbType.String, ReservationID);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parReservationID, parItemCode, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateProdTDOD(string ProductionID , string SalesOrder, string ItemCode ,  string  TDOD,  string User)
        {
            try
            {
                string strProcedureName = "SP_UpdateProdTDOD_Prod_Web";
                SqlParameter parProductionID = CommonDL.CreateParameter("@ProductionID", DbType.String, ProductionID);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", DbType.String, SalesOrder);
                SqlParameter parItemCode = CommonDL.CreateParameter("@ItemCode", DbType.String, ItemCode);
                SqlParameter parTDOD = CommonDL.CreateParameter("@TDOD", DbType.String, TDOD);
                SqlParameter parUser = CommonDL.CreateParameter("@User", DbType.String, User);
                SqlParameter[] par = { parProductionID , parSalesOrder, parItemCode, parTDOD, parUser };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSalesOrderItem(string SalesOrder)
        {
            try
            {
                string strProcedureName = "SP_Sales_GetSalesList";
                SqlParameter parUser = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter[] par = { parUser };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AddSalesOrderWithReservation( string Reservation, string SalesOrder, string User , string DemandDate)
        {
            try
            {
                string strProcedureName = "SP_Sales_AddSalesWithReservation";
                SqlParameter parReservation = CommonDL.CreateParameter("@Reservation", Reservation);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter parUser = CommonDL.CreateParameter("@User", User);
                SqlParameter parDemandDate = CommonDL.CreateParameter("@DemandDate", DemandDate);
                SqlParameter[] par = { parReservation, parSalesOrder,  parUser  , parDemandDate };
                SqlHelper.ExecuteNonQuery(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetItemCodeLoadOptimisation(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetItemCode_Load_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPackIDWeb(string Process)
        {
            try
            {
                string strProcedureName = "SP_GetPackID_Load_Web";
                SqlParameter parUserName = CommonDL.CreateParameter("@Process", Process);
                SqlParameter[] par = { parUserName };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetProductionData(string ProductionID, string SalesOrder , string User)
        {
            try
            {
                string strProcedureName = "SP_GetProdData_Prod_Web";
                SqlParameter parUser = CommonDL.CreateParameter("@ProductionID", ProductionID);
                SqlParameter parSalesOrder = CommonDL.CreateParameter("@SalesOrder", SalesOrder);
                SqlParameter parUser1 = CommonDL.CreateParameter("@User", User);
                SqlParameter[] par = { parUser, parSalesOrder , parUser1 };
                return SqlHelper.ExecuteDataset(CommonDL.ConnectionString, CommandType.StoredProcedure, strProcedureName, par).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}