using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class ClsSalesRegister
   {
       public static DataTable Get_SalesOrderforApproval(Int64 SOID)
       {
           DataTable table = null;
           try
           {

               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               DbParameter param = comm.CreateParameter();
               // set the stored procedure name
               comm.CommandText = "USB_Get_SoDetails";

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
       public static DataTable Get_SalesOrderforInvocie(Int64 SOID)
       {
           DataTable table = null;
           try
           {

               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               DbParameter param = comm.CreateParameter();
               // set the stored procedure name
               comm.CommandText = "USB_Get_SoDetailsForInvoice";

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
       public static DataTable Get_SalesOrderForSaleRegister(DateTime StartDate, DateTime EndDate)
       {
           DataTable table = null;
           try
           {
               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               // set the stored procedure name
               comm.CommandText = "USB_Get_SO_For_SaleRegister";


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

    

         public static bool InsertSalesInvoice(Int32 SoID, DateTime InvoiceDate, string InvoiceNo, 
          double taxAmount, double totalAmount,
          string Catagory, string Product,Int32 InQuantity,double InPrice, int EnterBy)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_So_InvoiceDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Po_ID";
            param.Value = SoID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@invoiceDate";
            param.Value = InvoiceDate;
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
            param.ParameterName = "@taxamount";
            param.Value = taxAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@totalAmount";
            param.Value = totalAmount;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Catagory";
            param.Value = Catagory;
            param.DbType = DbType.String ;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Product";
            param.Value = Product;
            param.DbType = DbType.String;
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
            param.ParameterName = "@EnteredBy";
            param.Value = EnterBy;
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

         #region
         public static DataTable Get_SalesOrderForSalesInvoice(DateTime StartDate, DateTime EndDate)
         {
             DataTable table = null;
             try
             {
                 // get a configured DbCommand object
                 DbCommand comm = DBLayer.CreateCommand();
                 // set the stored procedure name
                 comm.CommandText = "USB_Get_SO_For_SalesInvoice";


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
         public static DataTable Get_SalesOrderForInvoice(Int64 SOID)
         {
             DataTable table = null;
             try
             {

                 // get a configured DbCommand object
                 DbCommand comm = DBLayer.CreateCommand();
                 DbParameter param = comm.CreateParameter();
                 // set the stored procedure name
                 comm.CommandText = "USB_Get_SoDetails";

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

         public static bool InsertSalesInvoicedetails(Int32 Invoiceid, Int32 PoID, Int32 Catagory, Int32 Product,
          Int32 POQuantity, double POPrice, double POtax, double POtotalAmount,
          Int32 InQuantity, double InPrice, string Intax, double INtotalAmount, Int32 EnterBy, string loaction, string LblProduct, DateTime InvoiceDate)
         {
             // get a configured DbCommand object
             DbCommand comm = DBLayer.CreateCommand();
             // set the stored procedure name
             comm.CommandText = "USB_Insert_So_InvoiceDetails";
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



         public static bool InsertSalesInvoice(out int invoiceID, Int32 PoID, string PONo, DateTime PODate,
                   string InvoiceNo, DateTime InvoiceDate, double totalAmount, int EnterBy)
         {
             // get a configured DbCommand object
             DbCommand comm = DBLayer.CreateCommand();
             // set the stored procedure name
             comm.CommandText = "USB_Insert_So_Invoice";
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










         #endregion



    }
    
   
}
