using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;

namespace BusinessLogicLayer
{
  public  class ClsDeliveryChallan
    {
        public static DataTable Get_SalesOrderForDC(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Get_SO_DC";


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

        public static bool Insert_DC_Details(Int32 SOID, string Dc_No, DateTime DC_Date, Int32 NameOfTheTransp, Int32 DispatchDetails, System.Data.SqlTypes.SqlDateTime DispatchDate, System.Data.SqlTypes.SqlDateTime DateOfDelivery, System.Data.SqlTypes.SqlDateTime DateOfInstallation, Int32 EnteredBy)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Insert_DC_Details";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@So_ID";
            param.Value = SOID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Dc_No";
            param.Value = Dc_No;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DC_Date";
            param.Value = DC_Date;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@NameOfTheTransp";
            param.Value = NameOfTheTransp;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DispatchDetails";
            param.Value = DispatchDetails;
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
            param.ParameterName = "@DateOfDelivery";
            param.Value = DateOfDelivery;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DateOfInstallation";
            param.Value = DateOfInstallation;
            param.DbType = DbType.DateTime;
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

        public static DataTable Get_DCDetails(Int64 SOID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_DcDetails";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@So_ID";
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

        public static DataTable Get_DC(Int64 ID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_Dc";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@So_ID";
                param.Value = ID;
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

        public static bool Update_DC_Details(Int64 DCID, Int32 SOID, string Dc_No, DateTime DC_Date, string NameOfTheTransp, Int32 DispatchDetails, System.Data.SqlTypes.SqlDateTime DispatchDate, System.Data.SqlTypes.SqlDateTime DateOfDelivery, System.Data.SqlTypes.SqlDateTime DateOfInstallation, Int32 EnteredBy)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USB_Update_DC_Details";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = DCID;
            param.DbType = DbType.Int64;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@So_ID";
            param.Value = SOID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Dc_No";
            param.Value = Dc_No;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DC_Date";
            param.Value = DC_Date;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@NameOfTheTransp";
            param.Value = NameOfTheTransp;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DispatchDetails";
            param.Value = DispatchDetails;
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
            param.ParameterName = "@DateOfDelivery";
            param.Value = DateOfDelivery;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DateOfInstallation";
            param.Value = DateOfInstallation;
            param.DbType = DbType.DateTime;
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

    }
}
