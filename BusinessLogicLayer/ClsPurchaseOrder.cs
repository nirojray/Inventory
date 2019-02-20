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
    public class ClsPurchaseOrder
    {
        public static DataTable getTax(Int64 tax)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GET_TAX_VALUE";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TAXID";
                param.Value = tax;
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
        public static DataTable getConValueTax(Int64 tax)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GET_TAX_CON_VALUE";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TAXID";
                param.Value = tax;
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
        public int InsertPurchaseOrder(DateTime PODATE, DataTable PurchaseSum, DataTable PurchaseDet, string SuplierState, string PurchaseType,string SPANum)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_INSERT_PURCHASE_ORDER";
            command.CommandType = CommandType.StoredProcedure;
            DbParameter param = command.CreateParameter();
            param.ParameterName = "@PODATE";
            param.Value = PODATE;
            param.DbType = DbType.DateTime;
            command.Parameters.Add(param);
            command.Parameters.AddWithValue("@PurchaseSummary", PurchaseSum);
            command.Parameters["@PurchaseSummary"].TypeName = "PurchaseOrder_Summary_New";
            command.Parameters.AddWithValue("@PurchaseDetails", PurchaseDet);
            command.Parameters["@PurchaseDetails"].TypeName = "Purchase_Details_New";
            command.Parameters.AddWithValue("@SuplierState", SuplierState);
            command.Parameters.AddWithValue("@PurchaseType", PurchaseType);
            command.Parameters.AddWithValue("@SPANum", SPANum);
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }
        public DataTable getBSAddres(Int32 LocID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetBillingShippingAddress";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@LocID";
                param.Value = LocID;
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

        public int InsertPurchaseOrderTax(int CategoryId, int ProductId, int TaxMapId, int TaxNameId, double TaxRate, double BaseValue, double TaxAmount)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_InsertPurchaseOrderTax";
            command.CommandType = CommandType.StoredProcedure;

            DbParameter param = command.CreateParameter();
            param.ParameterName = "@CategoryId";
            param.Value = CategoryId;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@ProductId";
            param.Value = ProductId;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@TaxMapID";
            param.Value = TaxMapId;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@TaxNameId";
            param.Value = TaxNameId;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@TaxRate";
            param.Value = TaxRate;
            param.DbType = DbType.Double;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@BaseValue";
            param.Value = BaseValue;
            param.DbType = DbType.Double;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@TaxAmount";
            param.Value = TaxAmount;
            param.DbType = DbType.Double;
            command.Parameters.Add(param);
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }

        #region Added by Narender FROM 30Jun2017 
        public static DataTable Get_PurchaseOrderRejectDet(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Get_PO_RejectedData";


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
        public static DataTable Get_Rejecteddata_PoDetails(Int64 POID)
        {
            DataTable table = null;
            try
            {

                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                DbParameter param = comm.CreateParameter();
                // set the stored procedure name
                comm.CommandText = "USP_Get_Rejecteddata_PoDetails";

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

        public int Update_PurchaseOrder_Rejected_PO_Details(string PONumber, DateTime PODATE, DataTable PurchaseSum, DataTable PurchaseDet)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_INSERT_PO_Details_Modified_Rejected_PO_Details";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PO_Number", PONumber);
            DbParameter param = command.CreateParameter();
            param.ParameterName = "@PODATE";
            param.Value = PODATE;
            param.DbType = DbType.DateTime;
            command.Parameters.Add(param);
            command.Parameters.AddWithValue("@PurchaseSummary", PurchaseSum);
            command.Parameters["@PurchaseSummary"].TypeName = "Purchase_Summary_New1";
            command.Parameters.AddWithValue("@PurchaseDetails", PurchaseDet);
            command.Parameters["@PurchaseDetails"].TypeName = "Purchase_Details_New";
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }

        public int InsertPurchaseOrderTax_Rejected_PO_Details(string PONumber, int CategoryId, int ProductId, int TaxMapId, int TaxNameId, double TaxRate, double BaseValue, double TaxAmount)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_InsertPurchaseOrderTax_Modified_Rejected_PO_Details";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PO_Number", PONumber);

            DbParameter param = command.CreateParameter();
            param.ParameterName = "@CategoryId";
            param.Value = CategoryId;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@ProductId";
            param.Value = ProductId;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@TaxMapID";
            param.Value = TaxMapId;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@TaxNameId";
            param.Value = TaxNameId;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@TaxRate";
            param.Value = TaxRate;
            param.DbType = DbType.Double;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@BaseValue";
            param.Value = BaseValue;
            param.DbType = DbType.Double;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@TaxAmount";
            param.Value = TaxAmount;
            param.DbType = DbType.Double;
            command.Parameters.Add(param);
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }

        public int Delete_PurchaseOrderTax_for_Rejected_PO_Details(string PONumber)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "Usp_Delete_PurchaseOrderTax_for_RejectedPO";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PO_Number", PONumber);
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }

        public static DataTable GetPO_ApprovedDetails(DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetPO_ApprovedDetails";


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

        public int Generate_PurchaseOrder(int POID)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_Generate_PurchaseOrder";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PoId", POID);
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }

        #endregion

        #region added for Spa
        public static DataTable GetServiceAttachNumber()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_GetServiceAttachNumber";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public static DataTable BindServiceAttachApproval()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_BindServiceAttachforApprovaldata";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public static DataTable CheckExistSA_Number(string SA_Number)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_CheckExistSA_Number";
                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@SA_Number";
                param.Value = SA_Number;
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

        public int UpdateServiceAttachApprovalwithSignedDocument(string SANumber, ServiceAttachApproval objPop)
        {
            int Result;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_Update_ServiceAttachApprovalwithSignedDocument";
                command.CommandType = CommandType.StoredProcedure;

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@SA_Number";
                param.Value = SANumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SA_SignedFileName";
                param.Value = objPop.P_SASignedFilename;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SA_SignedFilePath";
                param.Value = objPop.P_SASignedFilePath;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWOutDcnt_Dstbtrprice";
                param.Value = objPop.P_UPSWOutDcnt_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWOutDcnt_Rsprice";
                param.Value = objPop.P_UPSWOutDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWOutDcnt_Euprice";
                param.Value = objPop.P_UPSWOutDcnt_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWDcnt_DstbtrPrice";
                param.Value = objPop.P_UPSWDcnt_DstbtrPrice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWDcnt_Rsprice";
                param.Value = objPop.P_UPSWDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWDcnt_Euprice";
                param.Value = objPop.P_UPSWDcnt_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWOutDcnt_Dstbtrprice";
                param.Value = objPop.P_USAWOutDcnt_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWOutDcnt_Rsprice";
                param.Value = objPop.P_USAWOutDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWOutDcnt_Euprice";
                param.Value = objPop.P_USAWOutDcnt_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWDcnt_DstbtrPrice";
                param.Value = objPop.P_USAWDcnt_DstbtrPrice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWDcnt_Rsprice";
                param.Value = objPop.P_USAWDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWDcnt_Euprice";
                param.Value = objPop.P_USAWDcnt_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                if (string.IsNullOrWhiteSpace(Convert.ToString(objPop.P_Warrenty)))
                {
                    param = command.CreateParameter();
                    param.ParameterName = "@Warrenty";
                    param.Value = DBNull.Value;
                    param.DbType = DbType.DateTime;
                    command.Parameters.Add(param);
                }
                else
                {
                    param = command.CreateParameter();
                    param.ParameterName = "@Warrenty";
                    param.Value = objPop.P_Warrenty;
                    param.DbType = DbType.DateTime;
                    command.Parameters.Add(param);
                }

                Result = DBLayer.ExecuteNonQuery(command);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int InsertServiceAttachApproval(ServiceAttachApproval objprop, string SAFileName, string SAFilePath)
        {
            int Result;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_InsertServiceAttachApproval";
                command.CommandType = CommandType.StoredProcedure;

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@Enduser_Name";
                param.Value = objprop.P_EnduserName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Reseller_Name";
                param.Value = objprop.P_ResellerName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Distributor_Name";
                param.Value = objprop.P_DistributorName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SupplierId";
                param.Value = objprop.P_Supplierid;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@TypeId";
                param.Value = objprop.P_MainTypeId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CategoryId";
                param.Value = objprop.P_CategoryId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@ProductId";
                param.Value = objprop.P_ProductId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@TotalQuantity";
                param.Value = objprop.P_Quantity;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@TotalPeriod";
                param.Value = objprop.P_TotalPeriod;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Competitor_Name";
                param.Value = objprop.P_CompetitorName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWOutDcnt_Dstbtrprice";
                param.Value = objprop.P_UPSWOutDcnt_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWOutDcnt_Rsprice";
                param.Value = objprop.P_UPSWOutDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWOutDcnt_Euprice";
                param.Value = objprop.P_UPSWOutDcnt_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWDcnt_DstbtrPrice";
                param.Value = objprop.P_UPSWDcnt_DstbtrPrice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWDcnt_Rsprice";
                param.Value = objprop.P_UPSWDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPSWDcnt_Euprice";
                param.Value = objprop.P_UPSWDcnt_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWOutDcnt_Dstbtrprice";
                param.Value = objprop.P_USAWOutDcnt_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWOutDcnt_Rsprice";
                param.Value = objprop.P_USAWOutDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWOutDcnt_Euprice";
                param.Value = objprop.P_USAWOutDcnt_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWDcnt_DstbtrPrice";
                param.Value = objprop.P_USAWDcnt_DstbtrPrice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWDcnt_Rsprice";
                param.Value = objprop.P_USAWDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@USAWDcnt_Euprice";
                param.Value = objprop.P_USAWDcnt_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                //if (string.IsNullOrWhiteSpace(Convert.ToString(objprop.P_Warrenty)))
                //{
                //    param = command.CreateParameter();
                //    param.ParameterName = "@Warrenty";
                //    param.Value = DBNull.Value;
                //    param.DbType = DbType.DateTime;
                //    command.Parameters.Add(param);
                //}
                //else
                //{
                //    param = command.CreateParameter();
                //    param.ParameterName = "@Warrenty";
                //    param.Value = objprop.P_Warrenty;
                //    param.DbType = DbType.DateTime;
                //    command.Parameters.Add(param);
                //}
                param = command.CreateParameter();
                param.ParameterName = "@SAFilename";
                param.Value = SAFileName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SAFilepath";
                param.Value = SAFilePath;
                param.DbType = DbType.String;
                command.Parameters.Add(param);
                param = command.CreateParameter();
                param.ParameterName = "@SPA";
                param.Value = objprop.P_SPA;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                Result = DBLayer.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public bool MAIL_FOR_ServiceAttchApprovalForDocFile()
        {
            try
            {

                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "USP_MAIL_FOR_ServiceAttchApprovalForDocFile";
                command.CommandType = CommandType.StoredProcedure;
                DBLayer.ExecuteNonQuery(command);
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool MAIL_FOR_ServiceAttchApprovalDocFile(string SA_Number)
        {
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "USP_MAIL_FOR_ServiceAttchApprovalDocFile";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@SA_Number";
                param.Value = SA_Number;
                param.DbType = DbType.String;
                command.Parameters.Add(param);
                DBLayer.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable GetServiceAttachNumberForSPA()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_GetServiceAttachNumberForSPA";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public static DataTable GetSADetailsForSPA(string SA_Number)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_GetSADetailsForSPA";
                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@SA_Number";
                param.Value = SA_Number;
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

        public int InsertSpecialPriceApproval(SpecialPriceApproval objprop,int VariationPercentage,int SUPPRequestStatus)
        {
            int Result;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_InsertSpecialPriceApproval";
                command.CommandType = CommandType.StoredProcedure;

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@EndUser_Name";
                param.Value = objprop.P_EnduserName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Reseller_Name";
                param.Value = objprop.P_ResellerName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Distributer_Name";
                param.Value = objprop.P_DistributorName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SupplierId";
                param.Value = objprop.P_Supplierid;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@TypeId";
                param.Value = objprop.P_MainTypeId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CategoryId";
                param.Value = objprop.P_CategoryId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@ProductId";
                param.Value = objprop.P_ProductId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@Quantity";
                param.Value = objprop.P_Quantity;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPPWOutDcnt_Dstbtrprice";
                param.Value = objprop.P_UPPWOutDcnt_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPPWOutDcnt_Rsprice";
                param.Value = objprop.P_UPPWOutDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPPWOutDcnt_EUprice";
                param.Value = objprop.P_UPPWOutDcnt_EUprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SUPReq_Dstbtrprice";
                param.Value = objprop.P_SUPReq_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SUPReq_Rsprice";
                param.Value = objprop.P_SUPReq_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SUPReq_Euprice";
                param.Value = objprop.P_SUPReq_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@AUP_Dstbtrprice";
                param.Value = objprop.P_AUP_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@AUP_Rsprice";
                param.Value = objprop.P_AUP_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@AUP_Euprice";
                param.Value = objprop.P_AUP_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@VSP_Dstbtrprice";
                param.Value = objprop.P_VSP_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@VSP_Rsprice";
                param.Value = objprop.P_VSP_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@VSP_Euprice";
                param.Value = objprop.P_VSP_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@ServiceAttach";
                param.Value = objprop.P_ServiceAttach;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SANumber";
                param.Value = objprop.P_SANumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SAAppend";
                param.Value = objprop.P_SAAppend;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                //if (string.IsNullOrWhiteSpace(Convert.ToString(objprop.P_ValidPOplacement)))
                //{
                //    param = command.CreateParameter();
                //    param.ParameterName = "@ValidPOplacement";
                //    param.Value = DBNull.Value;
                //    param.DbType = DbType.DateTime;
                //    command.Parameters.Add(param);
                //}
                //else
                //{
                //    param = command.CreateParameter();
                //    param.ParameterName = "@ValidPOplacement";
                //    param.Value = objprop.P_ValidPOplacement;
                //    param.DbType = DbType.DateTime;
                //    command.Parameters.Add(param);
                //}

                param = command.CreateParameter();
                param.ParameterName = "@CompUPP_Make1";
                param.Value = objprop.P_CUPMake1;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CompUPP_Model1";
                param.Value = objprop.P_CUPModel1;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPP_Dstbtrprice1";
                param.Value = objprop.P_CUPMake1_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPP_Rsprice1";
                param.Value = objprop.P_CUPMake1_Rsbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPP_Euprice1";
                param.Value = objprop.P_CUPMake1_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CompUPP_Make2";
                param.Value = objprop.P_CUPMake2;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CompUPP_Model2";
                param.Value = objprop.P_CUPModel2;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPP_Dstbtrprice2";
                param.Value = objprop.P_CUPMake2_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPP_Rsprice2";
                param.Value = objprop.P_CUPMake2_Rsbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPP_Euprice2";
                param.Value = objprop.P_CUPMake2_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SPAAttachFileName";
                param.Value = objprop.P_SPAAttachFileName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SPAAttachFilePath";
                param.Value = objprop.P_SPAAttachFilePath;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@VariationPercentage";
                param.Value = VariationPercentage;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SUPPRequestStatus";
                param.Value = SUPPRequestStatus;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                Result = DBLayer.ExecuteNonQuery(command);

            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public bool MAIL_FOR_SpecialPriceApprovalForDocFile()
        {
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "USP_MAIL_FOR_SpecialPriceApprovalForDocFile";
                command.CommandType = CommandType.StoredProcedure;
                DBLayer.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable BindSpecialPriceforApprovaldata()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_BindSpecialPriceforApprovaldata";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public int UpdateSpecialPriceApprovalwithSignedDocument(SpecialPriceApproval objPop, int SPAId, string SPANumber,int SUPPRequestStatus,string SPAPDFFile)
        {
            int Result;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_Update_SpecialPriceApprovalwithSignedDocument";
                command.CommandType = CommandType.StoredProcedure;

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@SPANumber";
                param.Value = SPANumber;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SPAAttachSignedFileName";
                param.Value = objPop.P_SPAAttachSignedFileName;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SPAAttcahSignedFilePath";
                param.Value = objPop.P_SPAAttcahSignedFilePath;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SPAId";
                param.Value = SPAId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPPWOutDcnt_Dstbtrprice";
                param.Value = objPop.P_UPPWOutDcnt_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPPWOutDcnt_Rsprice";
                param.Value = objPop.P_UPPWOutDcnt_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@UPPWOutDcnt_EUprice";
                param.Value = objPop.P_UPPWOutDcnt_EUprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SUPReq_Dstbtrprice";
                param.Value = objPop.P_SUPReq_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SUPReq_Rsprice";
                param.Value = objPop.P_SUPReq_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SUPReq_Euprice";
                param.Value = objPop.P_SUPReq_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@AUP_Dstbtrprice";
                param.Value = objPop.P_AUP_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@AUP_Rsprice";
                param.Value = objPop.P_AUP_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@AUP_Euprice";
                param.Value = objPop.P_AUP_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@VSP_Dstbtrprice";
                param.Value = objPop.P_VSP_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@VSP_Rsprice";
                param.Value = objPop.P_VSP_Rsprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@VSP_Euprice";
                param.Value = objPop.P_VSP_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPMake1_Dstbtrprice";
                param.Value = objPop.P_CUPMake1_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPMake1_Rsprice";
                param.Value = objPop.P_CUPMake1_Rsbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPMake1_Euprice";
                param.Value = objPop.P_CUPMake1_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPMake2_Dstbtrprice";
                param.Value = objPop.P_CUPMake2_Dstbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPMake2_Rsprice";
                param.Value = objPop.P_CUPMake2_Rsbtrprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@CUPMake2_Euprice";
                param.Value = objPop.P_CUPMake2_Euprice;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                if (string.IsNullOrWhiteSpace(Convert.ToString(objPop.P_ValidPOplacement)))
                {
                    param = command.CreateParameter();
                    param.ParameterName = "@ValidPOplacement";
                    param.Value = DBNull.Value;
                    param.DbType = DbType.DateTime;
                    command.Parameters.Add(param);
                }
                else
                {
                    param = command.CreateParameter();
                    param.ParameterName = "@ValidPOplacement";
                    param.Value = objPop.P_ValidPOplacement;
                    param.DbType = DbType.DateTime;
                    command.Parameters.Add(param);
                }
                param = command.CreateParameter();
                param.ParameterName = "@SUPPRequestStatus";
                param.Value = SUPPRequestStatus;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.ParameterName = "@SPAPDFFile";
                param.Value = SPAPDFFile;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                Result = DBLayer.ExecuteNonQuery(command);
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static DataTable Usp_GetServiceAttachforApprovaldata(int SAAId)
        {
            DataTable table = null;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_GetServiceAttachforApprovaldata";
                command.CommandType = CommandType.StoredProcedure;

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@SAAId";
                param.Value = SAAId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                table = DBLayer.ExecuteSelectCommand(command);
                return table;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetSpecialPriceforApprovaldata(int SPAId)
        {
            DataTable table = null;
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "Usp_GetSpecialPriceforApprovaldata";
                command.CommandType = CommandType.StoredProcedure;

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@SPAId";
                param.Value = SPAId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);

                table = DBLayer.ExecuteSelectCommand(command);
                return table;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool MAIL_FOR_SpecialPriceApprovalSignedDocFile(int SPAId)
        {
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "USP_MAIL_FOR_SpecialPriceApprovalSignedDocFile";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@SPAId";
                param.Value = SPAId;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);
                DBLayer.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable CheckSpaNumberExistsOrNot(string SPANumber)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_CheckSpaNumberExistsOrNot";
                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@SPANumber";
                param.Value = SPANumber;
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

        public bool MAIL_FOR_ServiceAttchApprovalForSignedDocFile(string SA_Number)
        {
            try
            {
                SqlCommand command = DBLayer.CreateSqlCommand();
                command.CommandText = "USP_MAIL_FOR_ServiceAttchApprovalForSignedDocFile";
                command.CommandType = CommandType.StoredProcedure;
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@SA_Number";
                param.Value = SA_Number;
                param.DbType = DbType.String;
                command.Parameters.Add(param);
                DBLayer.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable BindServiceAttachmentForSPA()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_ServiceAttachment_For_SPA";

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

        public static DataTable GetSPANum_For_PRN()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_GetSPANum_For_PO";           
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public int UpdateSPAQuantityForPendingQuantity(string SPANumber, int SPAQuantity)
        {
            int Result;
            SqlCommand command = DBLayer.CreateSqlCommand();
            command.CommandText = "USP_UpdateSPAQuantityForPendingQuantity";
            command.CommandType = CommandType.StoredProcedure;

            DbParameter param = command.CreateParameter();
            param.ParameterName = "@SPANumber";
            param.Value = SPANumber;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SPAQuantity";
            param.Value = SPAQuantity;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);
                      
            Result = DBLayer.ExecuteNonQuery(command);
            return Result;
        }
    }
}
