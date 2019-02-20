using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public  class ClsCheck
    {
        public static DataTable Get_PurchaseCheck(string pono,Int32 productID,Int32 SubCategoryId)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                
                // set the stored procedure name
                comm.CommandText = "USP_PURCHASEORDE_CHECK";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@PONO";
                param.Value = pono;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@PRODUCTID";
                param.Value = productID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@SubCategoryId";
                param.Value = SubCategoryId;
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
        public static DataTable Get_Purchase_apr_pending_count()
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();

                // set the stored procedure name
                comm.CommandText = "USB_get_Purchase_approval_Pending_Count";


                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Get_sales_apr_pending_count()
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();

                // set the stored procedure name
                comm.CommandText = "USB_get_sale_approval_Pending_Count";


                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public static DataTable Get_SalesCheck(string pono, Int32 productName)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();

                // set the stored procedure name
                comm.CommandText = "USP_SalesORDER_CHECK";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SONO";
                param.Value = pono;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@PRODUCTID";
                param.Value = productName;
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
