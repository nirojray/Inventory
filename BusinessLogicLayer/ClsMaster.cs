using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ClsMaster
    {
        public DataTable GetMaster(string Type, string Userid)
        {
            DataTable DT = new DataTable();
            DbCommand comm = DBLayer.CreateCommand();
            comm.CommandText = "USP_Get_Master";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@TYPE";
            param.Value = Type;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@USERID";
            param.Value = Userid;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            DT = DBLayer.ExecuteSelectCommand(comm);
            return DT;
        }

        public static DataTable GetPONumber()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetPOnumber";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public DataTable GetMainCategory()
        {
            try
            {
                DataTable table = null;
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Get_MainCategory";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable GetSubCategory(int MainCategoryID)
        {
            try
            {
                DataTable table = null;
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Get_SubCategory";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@MainCategoryID";
                param.Value = MainCategoryID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #region by sita
        //getting approved sales order numbers
        public static DataTable GetSONumberApproved()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetSOnumberApproved";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Get_SalesSummary(Int32 SO_ID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetSOsummary";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SO_ID";
                param.Value = SO_ID;
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
        public static DataTable Get_Salesdetails(Int64 SOID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_SoDetailsforInv";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = SOID;
                param.DbType = DbType.Int64;
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
        public static DataTable Get_SalesTaxdetails(Int64 SOID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USP_Get_SoTaxDetailsforInv";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@SO_ID";
                param.Value = SOID;
                param.DbType = DbType.Int64;
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
        #endregion
        #region Narender 25-Mar-2017
        public DataTable BindVenderName()
        {
            try
            {
                DataTable table = null;
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_BindVendorName";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //added on 31Jul2017
        public static DataTable GetSalesInvoiceDetailsForPDF(Int64 SOInvcID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "Usp_GetSalesInvoiceDetails";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@SOInvoiceID";
                param.Value = SOInvcID;
                param.DbType = DbType.Int64;
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
        public static DataTable GetSalesInvoiceIGSTDetailsForPDF(Int64 SOInvcID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "Usp_GetSalesInvoiceDetailsForIGST";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@SOInvoiceID";
                param.Value = SOInvcID;
                param.DbType = DbType.Int64;
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

        public static DataTable GetGRNNumbers()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetGRNnumber";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        #endregion
        public static DataTable GetMaster_purchasetype_dropdown()
        {
            DataTable DT = new DataTable();
            DbCommand comm = DBLayer.CreateCommand();
            comm.CommandText = "USP_purchase_taxtmapping_dropdown";

            DbParameter param = comm.CreateParameter();

            DT = DBLayer.ExecuteSelectCommand(comm);
            return DT;
        }
        public DataTable GetMainCategoryforSPA()
        {
            try
            {
                DataTable table = null;
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Get_MainCategoryforSpa";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //getting CreditNote sales Invoice numbers
        public static DataTable GetCreditNoteSINumber()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_SalesInvoiceOfCreditNote";

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
