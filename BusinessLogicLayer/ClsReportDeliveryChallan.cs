﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;

namespace BusinessLogicLayer
{
  public  class ClsReportDeliveryChallan
    {
      public static DataTable Report_DeliveryChallan(DateTime StartDate, DateTime EndDate)
      {
          DataTable table = null;
          try
          {
              // get a configured DbCommand object
              DbCommand comm = DBLayer.CreateCommand();
              // set the stored procedure name
              comm.CommandText = "USB_Report_DeliveryChallan";
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
