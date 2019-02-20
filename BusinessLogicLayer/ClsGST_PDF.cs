using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ClsGST_PDF
    {
        //Added by kushal patil (GST DC.)
        public DataTable Get_GST_DC_Number()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();

                // set the stored procedure name
                comm.CommandText = "USP_Get_GST_DCDetailsonID";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public DataTable Get_GST_DCDetailsonID(int ID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();

                // set the stored procedure name
                comm.CommandText = "USP_GetDCDetailsonID";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
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
        public DataTable Get_GST_DC_Product_DetailsonID(int ID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();

                // set the stored procedure name
                comm.CommandText = "USP_GetDCPrductDetailsonID";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
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
        public DataTable Get_GST_DC_TotAmt_onID(int ID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();

                // set the stored procedure name
                comm.CommandText = "USP_GetDCTotAmtonID";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
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
        public DataTable Get_GST_DC_Tax_onID(int ID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();

                // set the stored procedure name
                comm.CommandText = "USP_GetDCTaxID";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
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
