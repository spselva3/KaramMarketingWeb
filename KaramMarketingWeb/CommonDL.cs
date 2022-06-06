using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaramMarketingWeb
{
    public class CommonDL
    {
        public static string ConnectionString
        {
            get { return ConfigurationSettings.AppSettings["DbConnStr"].ToString(); }

        }

        public static SqlParameter CreateParameter(string ParameterName, DbType type, object value)
        {
            SqlParameter par = new SqlParameter();
            par.ParameterName = ParameterName;
            par.DbType = type;
            par.Value = value;

            return par;
        }

        public static SqlParameter CreateParameter(string ParameterName, object value)
        {
            SqlParameter par = new SqlParameter();
            par.ParameterName = ParameterName;
            par.Value = value;

            return par;
        }    
       


    }


}