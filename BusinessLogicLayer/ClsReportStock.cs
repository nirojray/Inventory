using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;


namespace BusinessLogicLayer
{
   public  class ClsReportStock
    {
        public static DataTable Report_Stock(DateTime FromDate,DateTime ToDate,string LocationName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Report_stock_statement";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@FromDate";
                param.Value = FromDate;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@ToDate";
                param.Value = ToDate;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@LocationName";
                param.Value = LocationName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);


                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public DataTable Cosolidated_Stock(DateTime FromDate, DateTime ToDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_StockConsolidated";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@FromDate";
                param.Value = FromDate;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@ToDate";
                param.Value = ToDate;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
    }
}
