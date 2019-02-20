using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    //Created by sita for Purchase outstanding reprot
    public class ClsPurchaseOutstandingRpt
    {
        //Getting Purchase outstanding data between given range
        public DataTable Get_Purchaseoutstanding(DateTime FromDate, DateTime ToDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetPurchaseOutStanding";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@FromDate";
                param.Value = FromDate;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);
                // create a new parameter
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
