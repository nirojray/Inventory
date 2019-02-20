using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;
using System.Data.SqlClient;
namespace BusinessLogicLayer
{//Created by sita for stock transfer tage
    public class ClsStockTransfer
    {
        //Getting all locations for stock transfer
        public DataTable Get_AllLocationsforST()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetallLocationforST";
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        //Getting Main Categories except 3,4 and 6
        public DataTable Get_MainCategoryforSt()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Get_MainCategoryforSt";
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        //inserting stock transfer details
        public bool InsertStockTransferDetails(int St_Id, int Sub_Catg_ID, int Product_ID, int FAvailable_Stock,
             int T_Available_Stock, int Transferred_Stock)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Insert_Stock_Transfer_Details";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@St_Id";
            param.Value = St_Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Sub_Catg_ID";
            param.Value = Sub_Catg_ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Product_ID";
            param.Value = Product_ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@FAvailable_Stock";
            param.Value = FAvailable_Stock;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@T_Available_Stock";
            param.Value = T_Available_Stock;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Transferred_Stock";
            param.Value = Transferred_Stock;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in DataAccess
            }

            // result will be 1 in case of success       
            return (result != -1);
        }

        //inserting stock transfer main data
        public bool InsertStockTransfer(out int St_ID, int FromLocId, string FromLocName, int ToLocID,
             string ToLocName, int MainCatg_ID, int CreatedBy)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Insert_Stock_Transfer";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            param = comm.CreateParameter();
            param.ParameterName = "@St_ID";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@FromLocId";
            param.Value = FromLocId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@FromLocName";
            param.Value = FromLocName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ToLocID";
            param.Value = ToLocID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ToLocName";
            param.Value = ToLocName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@MainCatg_ID";
            param.Value = MainCatg_ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@CreatedBy";
            param.Value = CreatedBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
            }
            catch (Exception ex)
            {
                // any errors are logged in DataAccess
            }
            // result will be 1 in case of success
            St_ID = Int32.Parse(comm.Parameters["@St_ID"].Value.ToString());
            // result will be 1 in case of success       
            return (result != -1);
        }

    }
}
