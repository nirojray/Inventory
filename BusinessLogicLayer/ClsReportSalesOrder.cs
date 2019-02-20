using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public  class ClsReportSalesOrder
    {

       public static DataTable Report_SalesOrderDetails(DateTime StartDate, DateTime EndDate)
       {
           DataTable table = null;
           try
           {
               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               // set the stored procedure name
               comm.CommandText = "USB_Report_SalesOrderDetails";
               // create a new parameter
               DbParameter param = comm.CreateParameter();
               param.ParameterName = "@StartDate";
               param.Value = StartDate;
               param.DbType = DbType.DateTime;
               comm.Parameters.Add(param);
               // create a new parameter
               param = comm.CreateParameter();
               param.ParameterName = "@EndDate";
               param.Value = EndDate;
               param.DbType = DbType.DateTime;
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

       public static DataTable Report_SalesOrderSummary(DateTime StartDate, DateTime EndDate)
       {
           DataTable table = null;
           try
           {
               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               // set the stored procedure name
               comm.CommandText = "USB_Report_SalesOrderSummary";
               // create a new parameter
               DbParameter param = comm.CreateParameter();
               param.ParameterName = "@StartDate";
               param.Value = StartDate;
               param.DbType = DbType.DateTime;
               comm.Parameters.Add(param);
               // create a new parameter
               param = comm.CreateParameter();
               param.ParameterName = "@EndDate";
               param.Value = EndDate;
               param.DbType = DbType.DateTime;
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


       public static DataTable Report_PurchaseOrderDetails(DateTime StartDate, DateTime EndDate)
       {
           DataTable table = null;
           try
           {
               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               // set the stored procedure name
               comm.CommandText = "USB_Report_PurchaseOrderDetails";
               // create a new parameter
               DbParameter param = comm.CreateParameter();
               param.ParameterName = "@StartDate";
               param.Value = StartDate;
               param.DbType = DbType.DateTime;
               comm.Parameters.Add(param);
               // create a new parameter
               param = comm.CreateParameter();
               param.ParameterName = "@EndDate";
               param.Value = EndDate;
               param.DbType = DbType.DateTime;
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

       public static DataTable Report_PurchaseOrderSummary(DateTime StartDate, DateTime EndDate)
       {
           DataTable table = null;
           try
           {
               // get a configured DbCommand object
               DbCommand comm = DBLayer.CreateCommand();
               // set the stored procedure name
               comm.CommandText = "USB_Report_PurchaseOrderSummary";
               // create a new parameter
               DbParameter param = comm.CreateParameter();
               param.ParameterName = "@StartDate";
               param.Value = StartDate;
               param.DbType = DbType.DateTime;
               comm.Parameters.Add(param);
               // create a new parameter
               param = comm.CreateParameter();
               param.ParameterName = "@EndDate";
               param.Value = EndDate;
               param.DbType = DbType.DateTime;
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
