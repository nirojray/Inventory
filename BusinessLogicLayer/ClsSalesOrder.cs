using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class ClsSalesOrder
    {
        public int InsertSalesOrder(DataTable SalesSum, DataTable SalesDet, String ADID, DataTable SalesTax, string BillingAddress, string ShippingAddress, string TermsOfDelivery)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_INSERT_SALES_ORDER";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Salse_Summary", SalesSum);

            command.Parameters["@Salse_Summary"].TypeName = "Salse_Summary";

            command.Parameters.AddWithValue("@Sales_Details", SalesDet);

            command.Parameters["@Sales_Details"].TypeName = "Sales_Details_New";

            command.Parameters.AddWithValue("@IDListString", ADID);

            command.Parameters.AddWithValue("@Sales_Tax", SalesTax);

            command.Parameters["@Sales_Tax"].TypeName = "Sales_Tax";

            command.Parameters.AddWithValue("@BillingAddress", BillingAddress);
            command.Parameters.AddWithValue("@ShippingAddress", ShippingAddress);
            command.Parameters.AddWithValue("@TermsOfDelivery", TermsOfDelivery);

            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }
        public static DataTable GetAddress()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Get_Adress";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public int InsertCustomerAddress(int CustId,string BillingAddress, string ShippingAddress)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_Insert_Customer_Address";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CustId", CustId);
            command.Parameters.AddWithValue("@BillingAddress", BillingAddress);
            command.Parameters.AddWithValue("@ShippingAddress", ShippingAddress);
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }

        public static DataTable BindCusomerBillingAddress(int CustId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                SqlCommand comm = DBLayer.CreateSqlCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_BindCusomerBillingAddress";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@CustId", CustId);
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable BindCusomerShippingAddress(int CustId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                SqlCommand comm = DBLayer.CreateSqlCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_BindCusomerShippingAddress";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@CustId", CustId);
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        //Added by Narender on 12Jul2017 for Hsn_SAC Code..

        public static DataTable BindHSN_SAC_Code(int MainCatID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                SqlCommand comm = DBLayer.CreateSqlCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_GetHSN_SCA_Code";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@MainCatID", MainCatID);
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        //Added by Eliyas on 12Jul2017
        public static DataTable termsdeliver_dropdown()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                SqlCommand comm = DBLayer.CreateSqlCommand();
                // set the stored procedure name
                comm.CommandText = "Master_delevery";
                comm.CommandType = CommandType.StoredProcedure;

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public int Send_Mail_ZeroStock_So_ProductDetails(DataTable DtSODetailsMail,string State,string Location)
        {
            try
            {
                int Result;
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "USP_Send_Mail_ZeroStock_So_ProductDetails";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DtSODetailsMail", DtSODetailsMail);
                command.Parameters["@DtSODetailsMail"].TypeName = "UT_Mail_Sales_Details_For_Zero_Quantity";
                command.Parameters.AddWithValue("@State", State);
                command.Parameters.AddWithValue("@Location", Location);
                Result = DBLayer.ExecuteNonQuery(command);
                return Result;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int INSERT_SO_Details_Modified_Rejected_SO_Details(DataTable SalesSum, DataTable SalesDet, String ADID, DataTable SalesTax, string BillingAddress, string ShippingAddress, string TermsOfDelivery,string SONum)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_INSERT_SO_Details_Modified_Rejected_SO_Details";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Salse_Summary", SalesSum);

            command.Parameters["@Salse_Summary"].TypeName = "Salse_Summary";

            command.Parameters.AddWithValue("@Sales_Details", SalesDet);

            command.Parameters["@Sales_Details"].TypeName = "Sales_Details_New";

            command.Parameters.AddWithValue("@IDListString", ADID);

            command.Parameters.AddWithValue("@Sales_Tax", SalesTax);

            command.Parameters["@Sales_Tax"].TypeName = "Sales_Tax";

            command.Parameters.AddWithValue("@BillingAddress", BillingAddress);
            command.Parameters.AddWithValue("@ShippingAddress", ShippingAddress); 
            command.Parameters.AddWithValue("@TermsOfDelivery", TermsOfDelivery);
            command.Parameters.AddWithValue("@SO_Number", SONum);
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }

        public int Send_Mail_GRN_RecivedQuantity_Details(DataTable DtGRN)
        {
            try
            {
                int Result;
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "USP_Send_Mail_GRN_RCVD_Quantity_Details";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DtGRN_RCVD_Quantity_Details", DtGRN);
                command.Parameters["@DtGRN_RCVD_Quantity_Details"].TypeName = "UT_GRN_RCVD_Quantity_Details";
                Result = DBLayer.ExecuteNonQuery(command);
                return Result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SalesInvoiceCreditNote(string SalesInvoiceNum,int UserId)
        {
            try
            {
                int Result;
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "USP_SalesInvoiceCreditNote";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SalesInvoiceNum", SalesInvoiceNum);
                command.Parameters.AddWithValue("@UserId", UserId);
                Result = DBLayer.ExecuteNonQuery(command);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
