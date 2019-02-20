using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class ClsPurchaseInvoice
    {
        public static DataTable Get_PurchaseOrderForPurchaseInvoice(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Get_PO_For_PurchaseInvoice";


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
        public static DataTable Get_PurchaseOrderForInvoice(Int64 SOID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_PoDetails";

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
        public static bool InsertPurchaseInvoice(out int invoiceID, Int32 PoID, string PONo, DateTime PODate,
              string InvoiceNo, DateTime InvoiceDate, double totalAmount, int EnterBy,string LorryReceiptNum)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_Po_Invoice";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceID";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Po_ID";
            param.Value = PoID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PONo";
            param.Value = PONo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PODate";
            param.Value = PODate;
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
            param.ParameterName = "@invoiceDate";
            param.Value = InvoiceDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@totalAmount";
            param.Value = totalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnterBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@LorryReceiptNum";
            param.Value = LorryReceiptNum;
            param.DbType = DbType.String;
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
            invoiceID = Int32.Parse(comm.Parameters["@InvoiceID"].Value.ToString());
            // result will be 1 in case of success       
            return (result != -1);
        }
        public static DataTable getTax(int Location)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTax";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@locationid";
                param.Value = Location;
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

        // this method for PurchaseOrderInvoiceApproval.aspx

        public static bool InsertPurchaseInvoicedetails1(Int32 Invoiceid, Int32 PoID, Int32 Catagory, Int32 Product,
       Int32 POQuantity, double POPrice, double POtax, double POtotalAmount,
       Int32 InQuantity, double InPrice, string Intax, double INtotalAmount, Int32 EnterBy, string loaction, string LblProduct, DateTime InvoiceDate, string MainLocation, int int_LocationId)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_Po_InvoiceDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InvocieID";
            param.Value = Invoiceid;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Po_ID";
            param.Value = PoID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Catagory";
            param.Value = Catagory;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Product";
            param.Value = Product;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@POQuantity";
            param.Value = POQuantity;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@POPrice";
            param.Value = POPrice;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@POtax";
            param.Value = POtax;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@POtotalamoun";
            param.Value = POtotalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InQuantity";
            param.Value = InQuantity;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InPrice";
            param.Value = InPrice;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@INtax";
            param.Value = Intax;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@INtotalamount";
            param.Value = INtotalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnterBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@loaction";
            param.Value = loaction;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@LblProduct";
            param.Value = LblProduct;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@invoiceDate";
            param.Value = InvoiceDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@MainLocation";
            param.Value = MainLocation;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@int_LocationId";
            param.Value = int_LocationId;
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

        //this Methos for PurchaseInvoice page
        public static bool InsertPurchaseInvoicedetails(Int32 Invoiceid, Int32 PoID, Int32 Catagory, Int32 Product,
            Int32 POQuantity, double POPrice, double POtax, double POtotalAmount,
            Int32 InQuantity, double InPrice, string Intax, double INtotalAmount, Int32 EnterBy, string loaction, string LblProduct, DateTime InvoiceDate,string MainLocation, int int_LocationId,Int64 PO_Det_Id)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_Po_InvoiceDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InvocieID";
            param.Value = Invoiceid;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Po_ID";
            param.Value = PoID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Catagory";
            param.Value = Catagory;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Product";
            param.Value = Product;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@POQuantity";
            param.Value = POQuantity;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@POPrice";
            param.Value = POPrice;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@POtax";
            param.Value = POtax;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@POtotalamoun";
            param.Value = POtotalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InQuantity";
            param.Value = InQuantity;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InPrice";
            param.Value = InPrice;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@INtax";
            param.Value = Intax;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@INtotalamount";
            param.Value = INtotalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnterBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@loaction";
            param.Value = loaction;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@LblProduct";
            param.Value = LblProduct;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@invoiceDate";
            param.Value = InvoiceDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@MainLocation";
            param.Value = MainLocation;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@int_LocationId";
            param.Value = int_LocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PO_Det_Id";
            param.Value = PO_Det_Id;
            param.DbType = DbType.Int64;
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

        public static DataTable Get_PurchaseOrderForInvoiceInInvoice(Int64 SOID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_PoDetailsForInvoice";

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

        public int PurchaseOrderInvoiceApprove_Reject(string PONumber, string Location, string PODATE, DataTable PurchaseInvoice)
        {
            int Result;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_Purchase_Invoice_Approval_Reject";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@PONumber";
                param.Value = PONumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Location";
                param.Value = Location;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@PODATE";
                param.Value = PODATE;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                command.Parameters.AddWithValue("@PurchaseInvoice", PurchaseInvoice);
                command.Parameters["@PurchaseInvoice"].TypeName = "PurchaseInvoice";
                Result = DBLayer.ExecuteNonQuery(command);
                return Result;
            }
            finally
            {
               
            }

        }

        public int InsertTEMPPurchaseInvoice(string PONumber, DateTime PODate, string Location, string Suplier, double TotalPoAmount,DateTime POEnterDate)
        {
            int Result;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_TEMPPurchaseorderInvoice";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@PONumber";
                param.Value = PONumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@PODate";
                param.Value = PODate;
                param.DbType = DbType.DateTime;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Location";
                param.Value = Location;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Suplier";
                param.Value = Suplier;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@TotalPoAmount";
                param.Value = TotalPoAmount;
                param.DbType = DbType.Double;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@POEnterDate";
                param.Value = POEnterDate;
                param.DbType = DbType.DateTime;
                command.Parameters.Add(param);

                Result = DBLayer.ExecuteNonQuery(command);
                return Result;
            }
            finally
            {

            }
        }


        public int InsertPurchaseInvoiceQuantity(string PONumber, int CategoryID, string category,int ProductID, string Product, int PO_Quantity, Double PO_Price,double PO_Tax,
            
            double POTotalPrice,int InvoiceQuantity,double InvoicePrice,double InvoiceTax,double InvoiceTotalAmount, DateTime PO_Date,string InvoiceNumber,DateTime Invoicedate)
        {
            int Result;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_PurchaseorderInvoiceQuantity";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@PO_Number";
                param.Value = PONumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CategoryID";
                param.Value = CategoryID;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@category";
                param.Value = category;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@ProductID";
                param.Value = ProductID;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Product";
                param.Value = Product;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@PO_Quantity";
                param.Value = PO_Quantity;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@PO_Price";
                param.Value = PO_Price;
                param.DbType = DbType.Double;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@PO_Tax";
                param.Value = PO_Tax;
                param.DbType = DbType.Double;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@POTotalPrice";
                param.Value = POTotalPrice;
                param.DbType = DbType.Double;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@InvoiceQuantity";
                param.Value = InvoiceQuantity;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@InvoicePrice";
                param.Value = InvoicePrice;
                param.DbType = DbType.Double;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@InvoiceTax";
                param.Value = InvoiceTax;
                param.DbType = DbType.Double;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@InvoiceTotalAmount";
                param.Value = InvoiceTotalAmount;
                param.DbType = DbType.Double;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@PO_Date";
                param.Value = PO_Date;
                param.DbType = DbType.DateTime;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@InvoiceNumber";
                param.Value = InvoiceNumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Invoicedate";
                param.Value = Invoicedate;
                param.DbType = DbType.DateTime;
                command.Parameters.Add(param);

                Result = DBLayer.ExecuteNonQuery(command);
                return Result;
            }
            finally
            {

            }
        }

        public static DataTable Get_PurchaseOrderForPurchaseInvoiceApproval(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Get_PO_For_PurchaseInvoiceApproval";


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
        public static DataTable Get_PurchaseOrderForInvoiceInInvoiceApproval(Int64 SOID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USP_Get_PoDetailsForInvoiceApproval";

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

        public static bool InsertPurchaseInvoiceFromInvoiceApproval(out int invoiceID, Int32 PoID, string PONo, DateTime PODate,
             string InvoiceNo, DateTime InvoiceDate, double totalAmount, int EnterBy,int InvoiceStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_Po_Invoice_From_InvoiceApproval";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceID";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Po_ID";
            param.Value = PoID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PONo";
            param.Value = PONo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PODate";
            param.Value = PODate;
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
            param.ParameterName = "@invoiceDate";
            param.Value = InvoiceDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@totalAmount";
            param.Value = totalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnterBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceStatus";
            param.Value = InvoiceStatus;
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
            invoiceID = Int32.Parse(comm.Parameters["@InvoiceID"].Value.ToString());
            // result will be 1 in case of success       
            return (result != -1);
        }

        public int PurchaseOrderInvoiceQuantityApproval_RejectStatusFromPOM(string PONumber, string Location, string PODATE, DataTable PurchaseInvoice,string Status,string InvoiceNumber)
        {
            int Result;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_PurchaseOrderInvoiceQuantity_Approval_RejectStatusFromPOM";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@PONumber";
                param.Value = PONumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Location";
                param.Value = Location;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@PODATE";
                param.Value = PODATE;
                param.DbType = DbType.String;
                command.Parameters.Add(param); 

                param = command.CreateParameter();
                param.ParameterName = "@Status";
                param.Value = Status;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@InvoiceNumber";
                param.Value = InvoiceNumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                command.Parameters.AddWithValue("@PurchaseInvoice", PurchaseInvoice);
                command.Parameters["@PurchaseInvoice"].TypeName = "PurchaseInvoice";
                Result = DBLayer.ExecuteNonQuery(command);
                return Result;
            }
            finally
            {

            }

        }

        public static bool PurchaseOrderInvoiceQuantityReject(Int32 PoID, string Status)
        {
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Po_InvoiceReject_From_InvoiceApproval";
            // create a new parameter
            DbParameter param = comm.CreateParameter();          

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Po_ID";
            param.Value = PoID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

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
            return (result != -1);
        }

        #region by narendar for getting Tax Rate and Base Value for Invioce Tax Calculation
        public static DataTable GetInvoiceTaxRateBaseValue(string PONumber,int CategoryId,int ProductId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTaxRate_InvoiceBaseValue";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@PONumber";
                param.Value = PONumber;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@CategoryId";
                param.Value = CategoryId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@ProductId";
                param.Value = ProductId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                table.Dispose();
            }
        }

        #endregion
        #region Narender Getting MainCategory BasedOn POID
        public static string Get_MainCategory_BasedOn_POID(Int64 PO_ID)
        {
            string MainCategory = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USP_Get_MainCategory_BasedOn_Po_Number";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@PO_ID";
                param.Value = PO_ID;
                param.DbType = DbType.Int64;
                comm.Parameters.Add(param);

                // execute the stored procedure and save the results in a DataTable
                MainCategory = DBLayer.ExecuteScalar(comm);
                return MainCategory;
            }
            finally
            {

            }
        }
        #endregion

        public static DataTable GetPartialdataBasedOnPONum(string PoNum)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USP_GetPartialdataBasedOnPONum";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@PoNum";
                param.Value = PoNum;
                param.DbType = DbType.String;
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

        public static DataTable Get_PurchaseOrderForInvoicePDF(Int64 SOID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_PoDetailsForPDF";

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

        public static bool InsertPurchaseGRNInvoice(out int invoiceID, Int32 GRNID, string GRNNo, DateTime GRNDate,
              string InvoiceNo, DateTime InvoiceDate, double totalAmount, int EnterBy, string LorryReceiptNum)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_Po_Invoice";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceID";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNID";
            param.Value = GRNID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNNo";
            param.Value = GRNNo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNDate";
            param.Value = GRNDate;
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
            param.ParameterName = "@invoiceDate";
            param.Value = InvoiceDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@totalAmount";
            param.Value = totalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnterBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@LorryReceiptNum";
            param.Value = LorryReceiptNum;
            param.DbType = DbType.String;
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
            invoiceID = Int32.Parse(comm.Parameters["@InvoiceID"].Value.ToString());
            // result will be 1 in case of success       
            return (result != -1);
        }

        public static bool InsertPurchaseGRNInvoicedetails(Int32 Invoiceid, Int32 GRNID, Int32 Catagory, Int32 Product,
          Int32 GRNQuantity, double GRNPrice, double GRNtax, double GRNtotalAmount,
          Int32 InQuantity, double InPrice, string Intax, double INtotalAmount, Int32 EnterBy, string loaction, string LblProduct, DateTime InvoiceDate, string MainLocation, int int_LocationId, Int64 PO_Det_Id)
        {           
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_Po_InvoiceDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InvocieID";
            param.Value = Invoiceid;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNID";
            param.Value = GRNID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Catagory";
            param.Value = Catagory;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Product";
            param.Value = Product;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNQuantity";
            param.Value = GRNQuantity;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNPrice";
            param.Value = GRNPrice;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNtax";
            param.Value = GRNtax;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNtotalAmount";
            param.Value = GRNtotalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InQuantity";
            param.Value = InQuantity;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@InPrice";
            param.Value = InPrice;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@INtax";
            param.Value = Intax;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@INtotalamount";
            param.Value = INtotalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnterBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@loaction";
            param.Value = loaction;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@LblProduct";
            param.Value = LblProduct;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@invoiceDate";
            param.Value = InvoiceDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@MainLocation";
            param.Value = MainLocation;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@int_LocationId";
            param.Value = int_LocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRN_Det_Id";
            param.Value = PO_Det_Id;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
            }
            catch(Exception EX)
            {
                // any errors are logged in DataAccess
            }
            // result will be 1 in case of success
            return (result != -1);
        }

    }
}
