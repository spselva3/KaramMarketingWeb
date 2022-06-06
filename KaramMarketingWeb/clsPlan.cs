using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaramMarketingWeb
{
    public class clsPlan
    {
        public DataTable GetDeliveryPlan(object Username, string From, string To, string Status)
        {
            try
            {
                string strProcedureName = "SP_GetRDeliveryPlanReport_Web";
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