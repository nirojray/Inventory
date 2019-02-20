using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ClsAR
    {
        public static DataTable Get_SalesOrderForAR(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Get_SO_AR";


                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@StartDate";
                param.Value = StartDate;
                param.DbType = DbType.Date;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@EndDate";
                param.Value = EndDate;
                param.DbType = DbType.Date;
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

        public static bool Insert_AR_Details(Int32 SOID, 
                                             DateTime invoiceDate, 
                                             string InvoiceNo, 
            string NameOfTheCustomer, Decimal InvocieAmount, Decimal AmountRecevied, Decimal BalanceForCollection, string CreditPeriod, Int32 Days, Int32 EnteredBy)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_AR_Details";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@So_ID";
            param.Value = SOID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@invoiceDate";
            param.Value = invoiceDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceNo";
            param.Value = InvoiceNo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@NameOfTheCustomer";
            param.Value = NameOfTheCustomer;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InvocieAmount";
            param.Value = InvocieAmount;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@AmountRecevied";
            param.Value = AmountRecevied;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BalanceForCollection";
            param.Value = BalanceForCollection;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@CreditPeriod";
            param.Value = CreditPeriod;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Days";
            param.Value = Days;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnteredBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public static DataTable Get_ARDetails(Int64 SOID, string SoInvoiceNum)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_ArDetails";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@So_ID";
                param.Value = SOID;
                param.DbType = DbType.Int64;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@SoInvoiceNum";
                param.Value = SoInvoiceNum;
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
    }
}
