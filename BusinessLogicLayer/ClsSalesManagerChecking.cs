using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class ClsSalesManagerChecking
    {   

       public static DataTable Get_SalesOrder(DateTime StartDate, DateTime EndDate)
       {
           DataTable table = null;
           try
           {
               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               // set the stored procedure name
               comm.CommandText = "USB_Get_SO_SMChecking";


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

       public static bool Update_SO_AppReject(Int32 SOID, Int64 DrpAppRej, string Reason, Int32 AppRejectBy)
       {
           // get a configured DbCommand object
           DbCommand comm = DBLayer.CreateCommand();
           // set the stored procedure name
           comm.CommandText = "USB_Update_SO_AppReject";
           // create a new parameter
           DbParameter param = comm.CreateParameter();
           param.ParameterName = "@SoId";
           param.Value = SOID;
           param.DbType = DbType.Int32;
           comm.Parameters.Add(param);

           // create a new parameter
           param = comm.CreateParameter();
           param.ParameterName = "@AppStatus";
           param.Value = DrpAppRej;
           param.DbType = DbType.Int32;
           comm.Parameters.Add(param);


           // create a new parameter
           param = comm.CreateParameter();
           param.ParameterName = "@AppReason";
           param.Value = Reason;
           param.DbType = DbType.String;
           comm.Parameters.Add(param);


           // create a new parameter
           param = comm.CreateParameter();
           param.ParameterName = "@AppprovedBy";
           param.Value = AppRejectBy;
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
       public static DataTable Get_SalesOrderAddress(Int64 SOID)
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
       public static DataTable Get_PurchaseOrder(DateTime StartDate, DateTime EndDate)
       {
           DataTable table = null;
           try
           {
               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               // set the stored procedure name
               comm.CommandText = "USB_Get_po_SMChecking";


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

 public static bool Update_PO_AppReject(Int32 SOID, Int64 DrpAppRej, string Reason, Int32 AppRejectBy)
       {
           // get a configured DbCommand object
           DbCommand comm = DBLayer.CreateCommand();
           // set the stored procedure name
           comm.CommandText = "USB_Update_PO_AppReject";
           // create a new parameter
           DbParameter param = comm.CreateParameter();
           param.ParameterName = "@PoId";
           param.Value = SOID;
           param.DbType = DbType.Int32;
           comm.Parameters.Add(param);

           // create a new parameter
           param = comm.CreateParameter();
           param.ParameterName = "@AppStatus";
           param.Value = DrpAppRej;
           param.DbType = DbType.Int32;
           comm.Parameters.Add(param);


           // create a new parameter
           param = comm.CreateParameter();
           param.ParameterName = "@AppReason";
           param.Value = Reason;
           param.DbType = DbType.String;
           comm.Parameters.Add(param);


           // create a new parameter
           param = comm.CreateParameter();
           param.ParameterName = "@AppprovedBy";
           param.Value = AppRejectBy;
           param.DbType = DbType.Int32;
           comm.Parameters.Add(param);

           // result will represent the number of changed rows
           int result = -1;
           try
           {
               // execute the stored procedure
               result = DBLayer.ExecuteNonQuery(comm);
           }
           catch(Exception ex)
           {
               // any errors are logged in DataAccess
           }
           // result will be 1 in case of success
           return (result != -1);
       }

 public static DataTable get_address_ID(Int64 SOID)
 {
     DataTable table = null;
     try
     {
         // get a configured DbCommand object
         DbCommand comm = DBLayer.CreateCommand();
         // set the stored procedure name
         comm.CommandText = "USB_Get_SO_SMChecking_Address";

         // create a new parameter
         DbParameter param = comm.CreateParameter();
         param.ParameterName = "@SOID";

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
        #region by sita 
        //for getting approved and active so summary
        public static DataTable Get_SalesOrderApproved(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_SO_Material";


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
        //for getting dispatch details
        public static DataTable Get_DispatchDEtails()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetDispatchDetails";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        //for getting Transporter details
        public static DataTable Get_Transporterdetails()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTransaporterDetails";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        //for inserting material dispatch details
        public static bool InsertDispatchDetails(int DispatcDetails, DateTime DispatchDate, string AWBNumber, DateTime? DateOfDelivery, int NameOfTheTransporter, int EnteredBy,int SOID,int DCId)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_InsertMaterialDispatch";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DispatcDetails";
            param.Value = DispatcDetails;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DispatchDate";
            param.Value = DispatchDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@AWBNumber";
            param.Value = AWBNumber;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            if (string.IsNullOrWhiteSpace(Convert.ToString(DateOfDelivery)))
            {
                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@DateOfDelivery";
                param.Value = DBNull.Value;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);
            }
            else
            {
                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@DateOfDelivery";
                param.Value = DateOfDelivery;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);
            }

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@NameOfTheTransporter";
            param.Value = NameOfTheTransporter;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnteredBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@SOID";
            param.Value = SOID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DCId";
            param.Value = DCId;
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
        //for getting approved , active and material dispatch entered so summary
        public static DataTable Get_InvoiceDispatchSearch(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_InvoiceDispatch";


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
        //for inserting Invoice dispatch details
        public static bool InsertINVDispatchDetails(int DispatcDetails, DateTime DispatchDate, string AWBNumber, DateTime? DateOfDelivery, DateTime? DateofInst, int TransporterID, int EnteredBy, int SOID,int DCID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_InsertInvoiceDispatch";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DispatcDetails";
            param.Value = DispatcDetails;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DispatchDate";
            param.Value = DispatchDate;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@AWBNumber";
            param.Value = AWBNumber;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            if (string.IsNullOrWhiteSpace(Convert.ToString(DateOfDelivery)))
            {
                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@DateOfDelivery";
                param.Value = DBNull.Value;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);
            }
            else
            {
                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@DateOfDelivery";
                param.Value = DateOfDelivery;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(DateofInst)))
            {
                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@DateOfInstallation";
                param.Value = DBNull.Value;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);
            }
            else
            {
                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@DateOfInstallation";
                param.Value = DateofInst;
                param.DbType = DbType.DateTime;
                comm.Parameters.Add(param);
            }

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@TransporterID";
            param.Value = TransporterID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EnteredBy";
            param.Value = EnteredBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@SOID";
            param.Value = SOID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DCID";
            param.Value = DCID;
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
        #endregion

        #region by eliyas 
        public static DataTable get_reversecharges(int supplerid)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "getting_Reversecharges";


                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Supplier_Id";
                param.Value = supplerid;
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
        #endregion

        public static DataTable Get_SoDetailsFor_MaterialDispatch(Int64 SOID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_SoDetailsFor_MaterialDispatch";

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

        #region Written By Narender on 28Jul2017
        public static DataTable Get_SalesOrder_RejectedData(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Get_SO_Rejected_Data";


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
        #endregion
    }
}
