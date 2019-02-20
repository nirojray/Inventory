using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
  public class ClsGoodsReceiptNote
    {
        public static DataTable Get_PurchaseOrderForGRN(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_PO_For_GRN";


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

        public static DataTable Get_PurchaseOrderDetailsForGRN(Int64 POID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USB_Get_PoDetailsForGRN";

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = POID;
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

        public static bool InsertPurchaseGRN(out int GRNID, Int32 PoID, string PONo, DateTime PODate,
              DateTime GRNDate, double totalAmount, int EnterBy, string LorryReceiptNum,string VehicleNo,string AWBNumber)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Insert_Po_GRN";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            param = comm.CreateParameter();
            param.ParameterName = "@GRNID";
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
            param.ParameterName = "@GRNDate";
            param.Value = GRNDate;
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

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@VehicleNo";
            param.Value = VehicleNo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@AWBNumber";
            param.Value = AWBNumber;
            param.DbType = DbType.String;
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
            GRNID = Int32.Parse(comm.Parameters["@GRNID"].Value.ToString());
            // result will be 1 in case of success       
            return (result != -1);
        }

        //public static bool Insert_Po_GRN_Details(Int32 GRNID, Int32 PoID, Int32 Catagory, Int32 Product,
        //   Int32 POQuantity, double POPrice, double POtax, double POtotalAmount,
        //   Int32 InQuantity, double InPrice, string Intax, double INtotalAmount, Int32 EnterBy, 
        //   string loaction, string LblProduct, DateTime InvoiceDate, string MainLocation, int int_LocationId, Int64 PO_Det_Id)
        //{
        //    // get a configured DbCommand object
        //    DbCommand comm = DBLayer.CreateCommand();
        //    // set the stored procedure name
        //    comm.CommandText = "USP_Insert_Po_GRNDetails";
        //    // create a new parameter
        //    DbParameter param = comm.CreateParameter();

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@GRNID";
        //    param.Value = GRNID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@Po_ID";
        //    param.Value = PoID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@Catagory";
        //    param.Value = Catagory;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@Product";
        //    param.Value = Product;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@POQuantity";
        //    param.Value = POQuantity;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@POPrice";
        //    param.Value = POPrice;
        //    param.DbType = DbType.Double;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@POtax";
        //    param.Value = POtax;
        //    param.DbType = DbType.Double;
        //    comm.Parameters.Add(param);


        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@POtotalamoun";
        //    param.Value = POtotalAmount;
        //    param.DbType = DbType.Double;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@InQuantity";
        //    param.Value = InQuantity;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@InPrice";
        //    param.Value = InPrice;
        //    param.DbType = DbType.Double;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@INtax";
        //    param.Value = Intax;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);


        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@INtotalamount";
        //    param.Value = INtotalAmount;
        //    param.DbType = DbType.Double;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@EnteredBy";
        //    param.Value = EnterBy;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@loaction";
        //    param.Value = loaction;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@LblProduct";
        //    param.Value = LblProduct;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@invoiceDate";
        //    param.Value = InvoiceDate;
        //    param.DbType = DbType.DateTime;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@MainLocation";
        //    param.Value = MainLocation;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@int_LocationId";
        //    param.Value = int_LocationId;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@PO_Det_Id";
        //    param.Value = PO_Det_Id;
        //    param.DbType = DbType.Int64;
        //    comm.Parameters.Add(param);

        //    // result will represent the number of changed rows
        //    int result = -1;
        //    try
        //    {
        //        // execute the stored procedure
        //        result = DBLayer.ExecuteNonQuery(comm);
        //    }
        //    catch(Exception ex)
        //    {
        //        // any errors are logged in DataAccess
        //    }
        //    // result will be 1 in case of success
        //    return (result != -1);
        //}

        public static bool Insert_Po_GRN_Details(Int32 GRNID, Int32 PoID, Int32 Catagory, Int32 Product,
       Int32 POQuantity, double POPrice, double POtax, double POtotalAmount,
       Int32 InQuantity, double InPrice, string Intax, double INtotalAmount, Int32 EnterBy,
       string loaction, string LblProduct, DateTime InvoiceDate, string MainLocation, int int_LocationId, Int64 PO_Det_Id, string Sup_Ref_No, DateTime Sup_Ref_Date)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Insert_Po_GRNDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@GRNID";
            param.Value = GRNID;
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

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Sup_Ref_No";
            param.Value = Sup_Ref_No;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Sup_Ref_Date";
            param.Value = Sup_Ref_Date;
            param.DbType = DbType.DateTime;
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


        public static DataTable GetPartialdataBasedOnPONumForGRN(string PoNum)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USP_GetPartialdataBasedOnPONumForGRN";

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
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
