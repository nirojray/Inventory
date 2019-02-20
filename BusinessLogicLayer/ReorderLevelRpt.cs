using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;

namespace BusinessLogicLayer
{ //Created by sita for Reorder Level reprot
    public class ReorderLevelRpt
    {
        public DataTable Get_ReorderLevel()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_ReOrderLevelRpt";
                // create a new parameter
                //DbParameter param = comm.CreateParameter();
                //param.ParameterName = "@FromDate";
                //param.Value = FromDate;
                //param.DbType = DbType.DateTime;
                //comm.Parameters.Add(param);
                //// create a new parameter
                //param = comm.CreateParameter();
                //param.ParameterName = "@ToDate";
                //param.Value = ToDate;
                //param.DbType = DbType.DateTime;
                //comm.Parameters.Add(param);
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
