using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BusinessServices
    {

        public BusinessServices()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Login
        public static DataTable Imaging_Login(string userName, string password)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_ImagingLogin";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@loginName";
                param.Value = userName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);
                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@password";
                param.Value = password;
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
        public static DataTable Imaging_forgotPassword_GetData(string UserLoginName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_ForgotPassword_GetData";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@userLoginName";
                param.Value = UserLoginName;
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
        public static bool Imaging_ForgotPassword_Insert(int userId, string email)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Imaging_ForgotPassword_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@email";
            param.Value = email;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@userID";
            param.Value = userId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static DataTable Imaging_LockScreen_GetPassword(string Password, Int32 ID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_LockScreen_GetPassword";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@password";
                param.Value = Password;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
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
        public static bool Imaging_UserID_CREATION_Insert(string UserName, string FullName, string Emailid, string UserType)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_USerName And Password_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@LoginName";
            param.Value = UserName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@FullName";
            param.Value = FullName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EmailID";
            param.Value = Emailid;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@UserType";
            param.Value = UserType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch(Exception ex)
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static DataTable Imaging_Admin_GetUserNameList_Active()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_GetActiveUsersList_DEa";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public static DataTable Imaging_Admin_GetUserNameList_DEActive()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_GetActiveUsersList";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static bool Imaging_Admin_passwordResetmailAlert(int userId, string UserType)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            comm.Parameters.Clear();
            // set the stored procedure name
            comm.CommandText = "USP_Pasword_Reset";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@userId";
            param.Value = userId;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@UserType";
            param.Value = UserType;
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
            return (result != -1);
        }
        public static bool Imaging_Admin_passwordReset(int userId, string UserType)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();

            comm.Parameters.Clear();
            // set the stored procedure name
            comm.CommandText = "USP_Imaging_admin_Password_REset";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@userId";
            param.Value = userId;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@UserType";
            param.Value = UserType;
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
            return (result != -1);
        }
        public static bool Imaging_Admin_ActivateUser(int userId)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Imaging_Admin_ActivateUser";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@userId";
            param.Value = userId;
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
        public static bool Imaging_Admin_DeActivateUser(int userId)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Imaging_Admin_DeActivateUser";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@userId";
            param.Value = userId;
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
        public static bool Login_ChangePassword(int userId, string oldPassword, string newPassword)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_Login_ChangePassword";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@userId";
            param.Value = userId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@oldPassword";
            param.Value = oldPassword;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@newPassword";
            param.Value = newPassword;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static DataTable BindUserType()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Bind_UserType";

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

        #region AdminCusSupTran
        //public static bool Imaging_Admin_CusSupTrans_Insert(string Name, Int32 Type, string contactName, string ContactNo, string Emailid, string Billing, string Shipping, int StateID, int CreatedBy)
        //{
        //    // get a configured DbCommand object
        //    DbCommand comm = DBLayer.CreateCommand();
        //    // set the stored procedure name
        //    comm.CommandText = "Imaging_CusSupTrans_Insert";
        //    // create a new parameter
        //    DbParameter param = comm.CreateParameter();
        //    param.ParameterName = "@Name";
        //    param.Value = Name;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);



        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@Type";
        //    param.Value = Type;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@contactName";
        //    param.Value = contactName;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@ContactNo";
        //    param.Value = ContactNo;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@Emailid";
        //    param.Value = Emailid;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@BillingAddress";
        //    param.Value = Billing;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@ShippingAdress";
        //    param.Value = Shipping;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = "@StateID";
        //    param.Value = StateID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = "@CreatedBy";
        //    param.Value = CreatedBy;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // result will represent the number of changed rows
        //    int result = -1;
        //    try
        //    {
        //        // execute the stored procedure
        //        result = DBLayer.ExecuteNonQuery(comm);
        //        //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
        //    }
        //    catch
        //    {
        //        // any errors are logged in DataAccess
        //    }
        //    return (result != -1);
        //}

        public static bool Imaging_Admin_CusSupTrans_Insert(string Name, Int32 Type, string contactName, string ContactNo, string Emailid, string Billing, string Shipping, string VATCST, string PAN, string ServiceTaxNumber, int StateID, int CreatedBy,int PaymentTerm, int ReverseCharge,int Vertical,int Representetive)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_CusSupTrans_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);



            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Type";
            param.Value = Type;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@contactName";
            param.Value = contactName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ContactNo";
            param.Value = ContactNo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Emailid";
            param.Value = Emailid;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BillingAddress";
            param.Value = Billing;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ShippingAdress";
            param.Value = Shipping;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //create VATCST 

            param = comm.CreateParameter();
            param.ParameterName = "@VATCST";
            param.Value = VATCST;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //Create  PAN

            param = comm.CreateParameter();
            param.ParameterName = "@PAN";
            param.Value = PAN;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //Create ServiceTaxNumber


            param = comm.CreateParameter();
            param.ParameterName = "@ServiceTaxNumber";
            param.Value = ServiceTaxNumber;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@StateID";
            param.Value = StateID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@CreatedBy";
            param.Value = CreatedBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PaymentTerm";
            param.Value = PaymentTerm;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //Added by kushal patil
            //Create ReverseCharge parameter

            param = comm.CreateParameter();
            param.ParameterName = "@ReverseCharge";
            param.Value = ReverseCharge;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Vertical";
            param.Value = Vertical;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Representetive";
            param.Value = Representetive;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static bool Imaging_Admin_CusSupTrans_update(Int32 ID, string Name, string contactName, string ContactNo, string Emailid, string Billing, string Shipping, string VATCST, string PAN, string ServiceTaxNumber, int StateID, int ModifiedBy,int PaymentTerm,int ReverseCharge,int VerticalId,int RepresentativeId)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_CusSupTrans_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@contactName";
            param.Value = contactName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ContactNo";
            param.Value = ContactNo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Emailid";
            param.Value = Emailid;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BillingAddress";
            param.Value = Billing;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ShippingAdress";
            param.Value = Shipping;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@VATCST";
            param.Value = VATCST;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PAN";
            param.Value = PAN;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ServiceTaxNumber";
            param.Value = ServiceTaxNumber;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@StateID";
            param.Value = StateID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ModifiedBy";
            param.Value = ModifiedBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PaymentTerm";
            param.Value = PaymentTerm;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //created Reverse charge
            param = comm.CreateParameter();
            param.ParameterName = "@ReverseCharge";
            param.Value = ReverseCharge;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@VerticalId";
            param.Value = VerticalId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@RepresentativeId";
            param.Value = RepresentativeId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        //public static bool Imaging_Admin_CusSupTrans_update(Int32 ID, string Name, string contactName, string ContactNo, string Emailid, string Billing, string Shipping, int StateID, int ModifiedBy)
        //{
        //    // get a configured DbCommand object
        //    DbCommand comm = DBLayer.CreateCommand();
        //    // set the stored procedure name
        //    comm.CommandText = "Imaging_CusSupTrans_Update";
        //    // create a new parameter
        //    DbParameter param = comm.CreateParameter();
        //    param.ParameterName = "@ID";
        //    param.Value = ID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);



        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@Name";
        //    param.Value = Name;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);


        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@contactName";
        //    param.Value = contactName;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@ContactNo";
        //    param.Value = ContactNo;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@Emailid";
        //    param.Value = Emailid;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@BillingAddress";
        //    param.Value = Billing;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@ShippingAdress";
        //    param.Value = Shipping;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = "@StateID";
        //    param.Value = StateID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = "@ModifiedBy";
        //    param.Value = ModifiedBy;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // result will represent the number of changed rows
        //    int result = -1;
        //    try
        //    {
        //        // execute the stored procedure
        //        result = DBLayer.ExecuteNonQuery(comm);
        //        //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
        //    }
        //    catch
        //    {
        //        // any errors are logged in DataAccess
        //    }
        //    return (result != -1);
        //}
        public static bool Imaging_Admin_CusSupTrans_delete(Int32 ID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_CusSupTrans_delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static DataTable Imaging_Admin_Location()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_GetLocation";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Imaging_Admin_Type()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_Gettype";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

       //commented by Gopinath

        //public static DataTable Imaging_Admin_CusSupTran(String Customer)
        //{
        //    DataTable table = null;
        //    try
        //    {
        //        // get a configured DbCommand object
        //        DbCommand comm = DBLayer.CreateCommand();
        //        // set the stored procedure name
        //        comm.CommandText = "USB_Admin_Get_CusSupTrans";

        //        DbParameter param = comm.CreateParameter();
        //        param.ParameterName = "@Customer";
        //        param.Value = Customer;
        //        param.DbType = DbType.String;
        //        comm.Parameters.Add(param);
        //        // execute the stored procedure and save the results in a DataTable
        //        table = DBLayer.ExecuteSelectCommand(comm);
        //        return table;
        //    }
        //    finally
        //    {
        //        table.Dispose();
        //    }
        //}
        #endregion

        #region AdminCatergory
        public static DataTable Imaging_Admin_Category(string Category)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_Category";
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Category_Name";
                param.Value = Category;
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
        public static bool Imaging_Admin_category_Insert(string category,int MainCategoryId)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Category_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@category";
            param.Value = category;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@MainCategoryId";
            param.Value = MainCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_category_update(Int32 ID, string category)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Category_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);



            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = category;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_Category_delete(Int32 ID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_category_delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        


        #endregion

        #region AdminDispatch
        public static DataTable Imaging_Admin_Dispatch()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_dispatch";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static bool Imaging_Admin_Dispatch_Insert(string category)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_dispatch_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@category";
            param.Value = category;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);






            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_Dispatch_update(Int32 ID, string category)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_dispatch_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);



            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = category;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_Dispatch_delete(Int32 ID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_dispatch_delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        #endregion

        #region AdminVertical
        public static DataTable Imaging_Admin_Vertical()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_vertical";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                
            }
            catch(Exception ex)
            {
               
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
        public static bool Imaging_Admin_Vertical_Insert(string category)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_vertical_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@category";
            param.Value = category;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);






            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_Vertical_update(Int32 ID, string category)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_vertical_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);



            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = category;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_Vertical_delete(Int32 ID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_vertical_delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        #endregion

        #region AdminProduct
        public static bool Imaging_Admin_Product_Insert(int SuppilerID, int MainCategoryId, int SubCategoryID, string ProductCode, string Name, int Reorder_level, int Min_Qty, int Max_Qty)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Product_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@SuppilerID";
            param.Value = SuppilerID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@MainCategoryID";
            param.Value = MainCategoryId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@SubCategoryID";
            param.Value = SubCategoryID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@ProductCode";
            param.Value = ProductCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);



            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //Added by kushal patil 
            //For record level
            param = comm.CreateParameter();
            param.ParameterName = "@Reorder_level";
            param.Value = Reorder_level;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //For min qty

            param = comm.CreateParameter();
            param.ParameterName = "@Min_Qty";
            param.Value = Min_Qty;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //for max qty

            param = comm.CreateParameter();
            param.ParameterName = "@Max_Qty";
            param.Value = Max_Qty;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static bool Imaging_Admin_Product_update(Int32 ID, string Name, string ProductCode, Int32 RECORD, Int32 MIN, Int32 MAX)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();

            // set the stored procedure name
            comm.CommandText = "Imaging_Product_Update";

            // create a new parameter

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter

            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductCode";
            param.Value = ProductCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //RECORD
            param = comm.CreateParameter();
            param.ParameterName = "@record_level";
            param.Value = RECORD;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //
            param = comm.CreateParameter();
            param.ParameterName = "@MIN";
            param.Value = MIN;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //param = comm.CreateParameter();
            param = comm.CreateParameter();
            param.ParameterName = "@MAX";
            param.Value = MAX;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_Product_delete(Int32 ID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Product_delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static DataTable Imaging_Admin_CAtegory()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_Getcatergory";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Imaging_Admin_Product(string Product)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_Product";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Product";
                param.Value = Product;
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
        #endregion

        #region AdminLocation
        public static bool Imaging_Admin_Location_Insert(string Name, string contactName, string ContactNo, int State, string Type, int Status, string BillingAddress, string ShippingAdress)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Locatiom_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@contactName";
            param.Value = contactName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ContactNo";
            param.Value = ContactNo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@State";
            param.Value = State;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Type";
            param.Value = Type;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BillingAddress";
            param.Value = BillingAddress;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ShippingAdress";
            param.Value = ShippingAdress;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_Location_update(Int32 ID, string Name, string contactName, string ContactNo, int State, string BillingAddress, string ShippingAddress, int Status, string Type)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Location_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@contactName";
            param.Value = contactName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ContactNo";
            param.Value = ContactNo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@State";
            param.Value = State;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BillingAddress";
            param.Value = BillingAddress;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ShippingAddress";
            param.Value = ShippingAddress;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Type";
            param.Value = Type;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_Location_delete(Int32 ID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_location_delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static DataTable BindState()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Bind_State";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public static DataTable Imaging_Admin__LLocation(string ShotName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_Location";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ShotName";
                param.Value = ShotName;
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
        #endregion

        #region AdminTax
        public static bool Imaging_Admin_Tax_Insert(string Tax_Type, string Tax_Desc, Int32 Tax_LocationID, string Tax_Percentage, string Tax_con_Value)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Tax_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Tax_Type";
            param.Value = Tax_Type;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);



            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_Desc";
            param.Value = Tax_Desc;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_LocationID";
            param.Value = Tax_LocationID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_Percentage";
            param.Value = Tax_Percentage;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_con_Value";
            param.Value = Tax_con_Value;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static bool Imaging_Admin_Tax_Insert_withoutconvalue(string Tax_Type, string Tax_Desc, Int32 Tax_LocationID, string Tax_Percentage)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Tax_Insert_without_convalue";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Tax_Type";
            param.Value = Tax_Type;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);



            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_Desc";
            param.Value = Tax_Desc;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_LocationID";
            param.Value = Tax_LocationID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_Percentage";
            param.Value = Tax_Percentage;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_tax_update(Int32 ID, string Tax_Desc, string Tax_Percentage, string Tax_con_Value)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Tax_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_Desc";
            param.Value = Tax_Desc;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);



            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_Percentage";
            param.Value = Tax_Percentage;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_con_Value";
            param.Value = Tax_con_Value;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_tax_delete(Int32 ID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Tax_delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static DataTable Imaging_Admin_Tax_Location()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_GetLocation";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Imaging_Admin_taxType()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_Gettaxtype";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Imaging_Admin_Tax()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_Tax";

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

        #region AdminAdress
        public static bool Imaging_Admin_address_Insert(string Name, string Address, string Address1, string Address2, string Address3, string vattin, string cst, string Category, string type)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_address_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = Address;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Address1";
            param.Value = Address1;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Address2";
            param.Value = Address2;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Address3";
            param.Value = Address3;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@vattin";
            param.Value = vattin;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@cst";
            param.Value = cst;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@addresstype";
            param.Value = Category;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@type";
            param.Value = type;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_address_update(Int32 ID, string Name, Int32 Product_Stock)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_Product_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);



            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);




            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Product_Stock";
            param.Value = Product_Stock;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);


            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool Imaging_Admin_address_delete(Int32 ID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Imaging_address_delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);





            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static DataTable Imaging_Admin_address_type()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_Getaddress_type";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Imaging_Admin_address()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_Address";

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
        #region by sita

        #region for checking category already exists in DB
        public static DataTable Imaging_Category_Exists(string CategoryName,int MainCategoryID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Category_Exists";


                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Name";
                param.Value = CategoryName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@MainCategoryID";
                param.Value = MainCategoryID;
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

        #region for checking category already exists for update in DB
        public static DataTable Imaging_Category_ExistsforUpdate(int CategoryID, string CategoryName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Category_ExistsfroUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Category_ID";
                param.Value = CategoryID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Name";
                param.Value = CategoryName;
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
        #endregion
        #region for checking any products are there under the category
        public static DataTable GetProduct_UnderCategory(int CategoryID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetProduct_UnderCategory";

                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@Category_ID";
                param.Value = CategoryID;
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

        #region for checking Customer already exists in DB
        public static DataTable Imaging_Customer_Exists(string Customer, int Type,int VerticalId,int StateId)//,int StateID
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Customer_Exists";


                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Name";
                param.Value = Customer;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Type";
                param.Value = Type;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@VerticalId";
                param.Value = VerticalId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@StateId";
                param.Value = StateId;
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

        public static DataTable Imaging_Customer_ExistsforUpdate(int ID, string Customer, string Type,int VerticalId,int StateId,int RepresentativeId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Customer_ExistsforUpdate";


                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);
                param = comm.CreateParameter();
                param.ParameterName = "@Name";
                param.Value = Customer;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);
                param = comm.CreateParameter();
                param.ParameterName = "@Type";
                param.Value = Type;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);
                param = comm.CreateParameter();
                param.ParameterName = "@VerticalId";
                param.Value = VerticalId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);
                param = comm.CreateParameter();
                param.ParameterName = "@StateId";
                param.Value = StateId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);
                param = comm.CreateParameter();
                param.ParameterName = "@RepresentativeId";
                param.Value = RepresentativeId;
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
        #region for checking Product already exists in DB in the selected category
        public static DataTable Imaging_Product_Exists(int SuppilerID, int MainCategoryId, int SubCategoryID, string ProductCode)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Product_Exists";


                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SuppilerID";
                param.Value = SuppilerID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@MainCategoryID";
                param.Value = MainCategoryId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);


                param = comm.CreateParameter();
                param.ParameterName = "@SubCategoryID";
                param.Value = SubCategoryID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);


                param = comm.CreateParameter();
                param.ParameterName = "@ProductCode";
                param.Value = ProductCode;
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
        #endregion
        #region for checking Product already exists for update in DB
        public static DataTable Imaging_Product_Existsforupdate(int ProductId,string ProductCode, string ProductName, int SuplierId, int MainCatId, int SubcatId, int REORDER, int MIN_VALUE, int MAX_VALUE)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Product_ExistsforUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ProductId";
                param.Value = ProductId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@ProductCode";
                param.Value = ProductCode;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@ProductName";
                param.Value = ProductName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@SuppilerID";
                param.Value = SuplierId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@MainCategoryID";
                param.Value = MainCatId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@SubCategoryID";
                param.Value = SubcatId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@REORDER";
                param.Value = REORDER;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@MIN_VALUE";
                param.Value = MIN_VALUE;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@MAX_VALUE";
                param.Value = MAX_VALUE;
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

        #region getting billing and shipping address of selcted customer
        public static DataTable Imaging_GetBillShipAddCustomer(int CustID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetBillShippAddCustomer";

                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@CustomerId";
                param.Value = CustID;
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

        #region getting CreditPeriod
        public static DataTable Imaging_GetCreditperiod()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetCreditPeriod";
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
        #region getting Warranty
        public static DataTable Imaging_GetWarranty()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetWarranty";
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
        #region by sita for getting sales type
        public static DataTable Imaging_GetSalesType()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetSalesType";
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
        #region getting Location Based on State
        public static DataTable Imaging_GetLocationOnState(int StateId, string Type)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetLocationBasedonState";

                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@StateID";
                param.Value = StateId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();

                param.ParameterName = "@Type";
                param.Value = Type;
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
        #endregion
        #region for getting active category name and id 
        public static DataTable Imaging_Get_Category()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_Category";

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
        #region for inserting TaxStructure
        public static bool Imaging_Insert_TAxStructure(string TaxStructure, int CreatedBy, int ActiveStatus)//string TYPE, int StateID, int LocationID, int CategoryID, int SalesType, int PurchaseType,
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_InsertTaxStructure";
            // create a new parameter

            //    param = comm.CreateParameter();
            //param.ParameterName = "@TYPE";
            //param.Value = TYPE;
            //param.DbType = DbType.String;
            //comm.Parameters.Add(param);

            //  // create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@StateID";
            //param.Value = StateID;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);


            //  // create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@LocationID";
            //param.Value = LocationID;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);

            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@CategoryID";
            //param.Value = CategoryID;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@TaxStructure";
            param.Value = TaxStructure;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@SalesType";
            //param.Value = SalesType;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);

            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@PurchaseType";
            //param.Value = PurchaseType;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@CreatedBy";
            param.Value = CreatedBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }
        #endregion
        #region for getting Tax Sturucture  
        public static DataTable Imaging_Get_TaxStrusture(string TaxStructure)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTaxStrusture";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxStructure";
                param.Value = TaxStructure;
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
        #endregion
        #region for inserting TaxStructure
        public static bool Imaging_Update_TAxStructure(int ID, string TaxStructure, int ModifiedBy, int ActiveStatus)//string TYPE, int StateID, int LocationID, int CategoryID, int SalesType, int PurchaseType,
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_UpdateTaxStructure";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@TYPE";
            //param.Value = TYPE;
            //param.DbType = DbType.String;
            //comm.Parameters.Add(param);

            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@StateID";
            //param.Value = StateID;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);


            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@LocationID";
            //param.Value = LocationID;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);

            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@CategoryID";
            //param.Value = CategoryID;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@TaxStructure";
            param.Value = TaxStructure;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@SalesType";
            //param.Value = SalesType;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);

            //// create a new parameter
            //param = comm.CreateParameter();
            //param.ParameterName = "@PurchaseType";
            //param.Value = PurchaseType;
            //param.DbType = DbType.Int32;
            //comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "@ModifiedBy";
            param.Value = ModifiedBy;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }
        #endregion
        #region for Checkign Tax Sturucture already Exists  
        public static DataTable Imaging_TaxStrusture_Exists(string TaxStructure)//,string Type,int StateID,int LocationID,int CategoryID,int SalesType,int PurchaseType
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckTaxStrustureExists";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxStructure";
                param.Value = TaxStructure;
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
        #endregion
        #region for Checkign Tax Sturucture already Exists for update  
        public static DataTable Imaging_TaxStrusture_Existsupdate(int ID, string TaxStructure)//, string Type, int StateID, int LocationID, int CategoryID, int SalesType, int PurchaseType
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckTaxStrustureExists_ForUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@TaxStructure";
                param.Value = TaxStructure;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                //// create a new parameter
                //param = comm.CreateParameter();
                //param.ParameterName = "@Type";
                //param.Value = Type;
                //param.DbType = DbType.String;
                //comm.Parameters.Add(param);

                //// create a new parameter
                //param = comm.CreateParameter();
                //param.ParameterName = "@StateID";
                //param.Value = StateID;
                //param.DbType = DbType.Int32;
                //comm.Parameters.Add(param);


                //// create a new parameter
                //param = comm.CreateParameter();
                //param.ParameterName = "@LocationID";
                //param.Value = LocationID;
                //param.DbType = DbType.Int32;
                //comm.Parameters.Add(param);

                //// create a new parameter
                //param = comm.CreateParameter();
                //param.ParameterName = "@CategoryID";
                //param.Value = CategoryID;
                //param.DbType = DbType.Int32;
                //comm.Parameters.Add(param);

                //// create a new parameter
                //param = comm.CreateParameter();
                //param.ParameterName = "@SalesType";
                //param.Value = SalesType;
                //param.DbType = DbType.Int32;
                //comm.Parameters.Add(param);

                //// create a new parameter
                //param = comm.CreateParameter();
                //param.ParameterName = "@PurchaseType";
                //param.Value = PurchaseType;
                //param.DbType = DbType.Int32;
                //comm.Parameters.Add(param);


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
        #region for getting Tax names for mapping to checklist
        public static DataTable Imaging_Get_Taxnamesformapping()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTaxNames";

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
        #region for getting Tax Structure for Biding to dropdown
        public static DataTable Imaging_GetTaxStructureforBind()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTaxStructureforBind";

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
        #region for getting Tax Structure for Biding to dropdown based on selection
        public static DataTable Imaging_GetTaxStructurebasedonselection(string TypeID, int StateID, int LocationID, int SalesType, int PurchaseType, int CategoryID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTaxStructure";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TypeID";
                param.Value = TypeID;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@StateID";
                param.Value = StateID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@LocationID";
                param.Value = LocationID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@PurchaseType";
                param.Value = PurchaseType;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@SalesType";
                param.Value = SalesType;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@CategoryID";
                param.Value = CategoryID;
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
        #region for getting product on category
        public static DataTable GetProductOnCategory(int TypeID, int CategoryID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetProudctOnCategory";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@MainCAtegoryID";
                param.Value = TypeID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@CategoryID";
                param.Value = CategoryID;
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
        #region for checking duplicate Tax Structure mapping
        public static DataTable Imaging_CheckDuplicateTaxMapping(string TypeID, int StateID, int LocationID, int CategoryID, int TaxStructureID, int SalesType, int PurchaseType)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckDuplicateTAxMapping";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TypeID";
                param.Value = TypeID;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@StateID";
                param.Value = StateID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@LocationID";
                param.Value = LocationID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@CategoryID";
                param.Value = CategoryID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);


                param = comm.CreateParameter();
                param.ParameterName = "@TaxStructureID";
                param.Value = TaxStructureID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@SalesType";
                param.Value = SalesType;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@PurchaseType";
                param.Value = PurchaseType;
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
        #region for checking duplicate Tax Structure mapping for update
        public static DataTable Imaging_CheckDuplicateTaxMappingUpdate(int TaxMapId, string TypeID, int StateID, int LocationID, int CategoryID, int TaxStructureID, int SalesType, int PurchaseType)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckDuplicateTAxMappingforUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxMapId";
                param.Value = TaxMapId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);


                param = comm.CreateParameter();
                param.ParameterName = "@TypeID";
                param.Value = TypeID;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@StateID";
                param.Value = StateID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@LocationID";
                param.Value = LocationID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@CategoryID";
                param.Value = CategoryID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);


                param = comm.CreateParameter();
                param.ParameterName = "@TaxStructureID";
                param.Value = TaxStructureID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@SalesType";
                param.Value = SalesType;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@PurchaseType";
                param.Value = PurchaseType;
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
        #region for checking duplicate Location and Client
        public static DataTable Imaging_CheckDuplicateLocClient(string Location_Name, int Location_StateID, string Location_Company, string Type)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Check_Duplicate_LocClient";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Location_Name";
                param.Value = Location_Name;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);


                param = comm.CreateParameter();
                param.ParameterName = "@Location_StateID";
                param.Value = Location_StateID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Location_Company";
                param.Value = Location_Company;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Type";
                param.Value = Type;
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
        #endregion
        #region for checking duplicate Location and Client for update
        public static DataTable Imaging_CheckDuplicateLocClientUpdate(int Location_ID, string Location_Name, int Location_StateID, string Location_Company, string Type)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Check_Duplicate_LocClient_Update";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Location_ID";
                param.Value = Location_ID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Location_Name";
                param.Value = Location_Name;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);


                param = comm.CreateParameter();
                param.ParameterName = "@Location_StateID";
                param.Value = Location_StateID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Location_Company";
                param.Value = Location_Company;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Type";
                param.Value = Type;
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
        #endregion
        #region for getting Tax Rate and Base Value for Tax Calculation
        public static DataTable GetTaxRateBaseValue(int TaxMapID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTaxRate_BaseValue";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxMapID";
                param.Value = TaxMapID;
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
        #region getting Representative Based on Location
        public static DataTable GetRepresentativeonLoc()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetRepresentativeonLocation";

                //DbParameter param = comm.CreateParameter();

                //param.ParameterName = "@LocID";
                //param.Value = LocID;
                //param.DbType = DbType.Int32;
                //comm.Parameters.Add(param);

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
        #region Checking Duplicate Dispatch Details Name
        public static DataTable CheckDupDispatch(string  Dispatch)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Get_Dup_Dispatch";

                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@Name";
                param.Value = Dispatch;
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
        #endregion
        #region Checking Duplicate Dispatch Details Name for update
        public static DataTable CheckDupDispatchUpdate(int ID,string Dispatch)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Get_Dup_DispatchforUpdate";

                DbParameter param = comm.CreateParameter();

                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);
                param = comm.CreateParameter();

                param.ParameterName = "@Name";
                param.Value = Dispatch;
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
        #endregion
        #endregion
        #region by gopi 
        public static DataTable PreventDublicate(string category)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_vertical_InserCheck";
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Vertical ";
                param.Value = category;
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
        public static DataTable Imaging_Admin_Vertical_Get(String vertical)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_VerticalDetails";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Vertical";
                param.Value = vertical;
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

        #endregion
        #region by narendar
        //narender added below 4 methods
        public static DataTable BindUserDetails(string SearchName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name                             
                comm.CommandText = "Usp_Bind_UserDetails";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SearchName";
                param.Value = SearchName;
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
        public static DataTable GetUserDetails(int Id)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name                             
                comm.CommandText = "Usp_Get_UserDetails";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Id";
                param.Value = Id;
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
        public static bool UpdateUserDetails(int Id, string Fullname, string userType, string Email)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name                             
            comm.CommandText = "Usp_Update_UserDetails";

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Fullname";
            param.Value = Fullname;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@userType";
            param.Value = userType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Email";
            param.Value = Email;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);

        }
        public static DataTable GetUserName(String Loginname)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name                             
                comm.CommandText = "Usp_Get_UserDetails";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Loginname";
                param.Value = Loginname;
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

        #region User creation
        public static DataTable CheckExistUserLoginNameForInsert(string FullName, string Email, string UserTypeId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckExist_UaserLoginnameForInsert";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@FullName";
                param.Value = FullName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Email";
                param.Value = Email;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@UserTypeId";
                param.Value = UserTypeId;
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
        public static DataTable BindUserNameDetails(string SearchUserName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name                             
                comm.CommandText = "USP_Bind_UserNameDetails";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SearchUserName";
                param.Value = SearchUserName;
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

        public static DataTable GetUserNameDetails(int Id)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_UserNameDetails";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@id";
                param.Value = Id;
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

        public static DataTable CheckExistUserLoginNameForUpdate(int Id,string FullName, string Email, string UserTypeId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckExist_UaserLoginnameForUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Id";
                param.Value = Id;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@FullName";
                param.Value = FullName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Email";
                param.Value = Email;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@UserTypeId";
                param.Value = UserTypeId;
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

        public static bool Imaging_UserID_CREATION_Update(int Id ,string UserName, string FullName, string Emailid, string UserType)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Usp_UserNameDetails_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@LoginName";
            param.Value = UserName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@FullName";
            param.Value = FullName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@EmailID";
            param.Value = Emailid;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@UserType";
            param.Value = UserType;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        #endregion

        #region Tax Name
        public static bool InsertTaxName(string TaxName, int Status,int Rank)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Usp_Insert_TaxName";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@TaxName";
            param.Value = TaxName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Rank";
            param.Value = Rank;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static DataTable ExistingTaxName(string TaxName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Exist_TaxName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxName";
                param.Value = TaxName;
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

        public static DataTable ExistingTaxNameForUpdate(int Id, string TaxName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_TaxNameExists_ForUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = Id;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@TaxName";
                param.Value = TaxName;
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
        public static DataTable BindTaxName(string SearchTaxName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Bind_TaxName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SearchTaxName";
                param.Value = SearchTaxName;
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
        public static DataTable GetTaxName(int Id)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_TaxName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@id";
                param.Value = Id;
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
        public static bool UpdateTaxName(int Id, string TaxName, int Status,int Rank)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Usp_Update_TaxName";

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@TaxName";
            param.Value = TaxName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Rank";
            param.Value = Rank;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        public static bool DeleteTaxName(int Id)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Usp_Delete_TaxName";

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        #endregion

        #region  Regionalrepresentative
        public static bool InsertRepresentativeName(int LocationId, string Name, string Designation, string Email, int Status)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Usp_Insert_RepresentativeName";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@LocationId";
            param.Value = LocationId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Designation";
            param.Value = Designation;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Email";
            param.Value = Email;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static DataTable ExistingRepresentativeName(int LocationId, string Name)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Exist_RepresentativeName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@LocationId";
                param.Value = LocationId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Name";
                param.Value = Name;
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

        public static DataTable BindRepresentativeName(string SearchTaxName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Bind_RepresentativeName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SearchTaxName";
                param.Value = SearchTaxName;
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

        public static DataTable GetRepresentativeName(int Id)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_RepresentativeName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@id";
                param.Value = Id;
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

        public static bool DeleteRepresentativeName(int Id)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Usp_Delete_RepresentativeName";

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static bool UpdateRepresentativeName(int Id, int Location, string Name, string Designation, string Email, int Status)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "Usp_Update_RepresentativeName";

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Location";
            param.Value = Location;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = Name;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Designation";
            param.Value = Designation;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Email";
            param.Value = Email;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }
        #endregion
        #region Tax Rate
        public static DataTable BindTaxName_TaxRate()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Get_TaxName_TaxRate";

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        //public static bool Insert_TaxRate(string TYPE, int StateID, int LocationID, int CategoryID, int TaxName, int SalesType, int PurchaseType,decimal TaxRate,decimal BaseValue,int ActiveStatus)
        //{
        //    // get a configured DbCommand object
        //    DbCommand comm = DBLayer.CreateCommand();
        //    // set the stored procedure name
        //    comm.CommandText = "USP_InsertTaxRate";
        //    // create a new parameter
        //    DbParameter param = comm.CreateParameter();
        //    param.ParameterName = "@TYPE";
        //    param.Value = TYPE;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@StateID";
        //    param.Value = StateID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);


        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@LocationID";
        //    param.Value = LocationID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@CategoryID";
        //    param.Value = CategoryID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@TaxName";
        //    param.Value = TaxName;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@SalesType";
        //    param.Value = SalesType;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@PurchaseType";
        //    param.Value = PurchaseType;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@TaxRate";
        //    param.Value = TaxRate;
        //    param.DbType = DbType.Decimal;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = "@BaseValue";
        //    param.Value = BaseValue;
        //    param.DbType = DbType.Decimal;
        //    comm.Parameters.Add(param);
        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@ActiveStatus";
        //    param.Value = ActiveStatus;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // result will represent the number of changed rows
        //    int result = -1;
        //    try
        //    {
        //        // execute the stored procedure
        //        result = DBLayer.ExecuteNonQuery(comm);

        //    }
        //    catch
        //    {
        //        // any errors are logged in DataAccess
        //    }
        //    return (result != -1);
        //}

        //public static DataTable TaxRate_Exists(string TYPE, int StateID, int LocationID, int CategoryID, int TaxName, int SalesType, int PurchaseType, decimal TaxRate, decimal BaseValue, int ActiveStatus)
        //{
        //    DataTable table = null;
        //    try
        //    {
        //        // get a configured DbCommand object
        //        DbCommand comm = DBLayer.CreateCommand();
        //        // set the stored procedure name
        //        comm.CommandText = "USP_CheckTaxRateExists";              

        //        // create a new parameter
        //        DbParameter param = comm.CreateParameter();
        //        param.ParameterName = "@TYPE";
        //        param.Value = TYPE;
        //        param.DbType = DbType.String;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@StateID";
        //        param.Value = StateID;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);


        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@LocationID";
        //        param.Value = LocationID;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@CategoryID";
        //        param.Value = CategoryID;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@TaxName";
        //        param.Value = TaxName;
        //        param.DbType = DbType.String;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@SalesType";
        //        param.Value = SalesType;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@PurchaseType";
        //        param.Value = PurchaseType;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@TaxRate";
        //        param.Value = TaxRate;
        //        param.DbType = DbType.Decimal;
        //        comm.Parameters.Add(param);

        //        param = comm.CreateParameter();
        //        param.ParameterName = "@BaseValue";
        //        param.Value = BaseValue;
        //        param.DbType = DbType.Decimal;
        //        comm.Parameters.Add(param);
        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@ActiveStatus";
        //        param.Value = ActiveStatus;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);


        //        // execute the stored procedure and save the results in a DataTable
        //        table = DBLayer.ExecuteSelectCommand(comm);
        //        return table;
        //    }
        //    finally
        //    {
        //        table.Dispose();
        //    }
        //}

        public static bool Insert_TaxRate(int TaxName, decimal TaxRate, decimal BaseValue, int ActiveStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_InsertTaxRate";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@TaxName";
            param.Value = TaxName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@TaxRate";
            param.Value = TaxRate;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@BaseValue";
            param.Value = BaseValue;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }
        public static DataTable TaxRate_Exists(int TaxName, int ActiveStatus)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckTaxRateExists";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxName";
                param.Value = TaxName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@ActiveStatus";
                param.Value = ActiveStatus;
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
        public static DataTable BindGridTaxRate(string TaxName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_BindGridTaxRate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxName";
                param.Value = TaxName;
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

        public static DataTable GetTaxRateDetailsBasedonID(int TaxRateID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetTaxRateDetailsBasedonID";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxRateID";
                param.Value = TaxRateID;
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

        //public static DataTable TaxRate_ExistsForUpdate(int TaxRateId,string TYPE, int StateID, int LocationID, int CategoryID, int TaxName, int SalesType, int PurchaseType, decimal TaxRate, decimal BaseValue, int ActiveStatus)
        //{
        //    DataTable table = null;
        //    try
        //    {
        //        // get a configured DbCommand object
        //        DbCommand comm = DBLayer.CreateCommand();
        //        // set the stored procedure name
        //        comm.CommandText = "USP_CheckTaxRateExistsForUpdate";

        //        // create a new parameter
        //        DbParameter param = comm.CreateParameter();
        //        param.ParameterName = "@TaxRateId";
        //        param.Value = TaxRateId;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@TYPE";
        //        param.Value = TYPE;
        //        param.DbType = DbType.String;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@StateID";
        //        param.Value = StateID;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);


        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@LocationID";
        //        param.Value = LocationID;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@CategoryID";
        //        param.Value = CategoryID;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@TaxName";
        //        param.Value = TaxName;
        //        param.DbType = DbType.String;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@SalesType";
        //        param.Value = SalesType;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@PurchaseType";
        //        param.Value = PurchaseType;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);

        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@TaxRate";
        //        param.Value = TaxRate;
        //        param.DbType = DbType.Decimal;
        //        comm.Parameters.Add(param);

        //        param = comm.CreateParameter();
        //        param.ParameterName = "@BaseValue";
        //        param.Value = BaseValue;
        //        param.DbType = DbType.Decimal;
        //        comm.Parameters.Add(param);
        //        // create a new parameter
        //        param = comm.CreateParameter();
        //        param.ParameterName = "@ActiveStatus";
        //        param.Value = ActiveStatus;
        //        param.DbType = DbType.Int32;
        //        comm.Parameters.Add(param);


        //        // execute the stored procedure and save the results in a DataTable
        //        table = DBLayer.ExecuteSelectCommand(comm);
        //        return table;
        //    }
        //    finally
        //    {
        //        table.Dispose();
        //    }
        //}

        public static DataTable TaxRate_ExistsForUpdate(int TaxRateId, int TaxName, int ActiveStatus)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckTaxRateExistsForUpdate";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxRateId";
                param.Value = TaxRateId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@TaxName";
                param.Value = TaxName;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                // create a new parameter
                param = comm.CreateParameter();
                param.ParameterName = "@ActiveStatus";
                param.Value = ActiveStatus;
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

        //public static bool Update_TaxRate(int TaxRateId, string TYPE, int StateID, int LocationID, int CategoryID, int TaxName, int SalesType, int PurchaseType, decimal TaxRate, decimal BaseValue, int ActiveStatus)
        //{
        //    // get a configured DbCommand object
        //    DbCommand comm = DBLayer.CreateCommand();
        //    // set the stored procedure name
        //    comm.CommandText = "USP_TaxRateUpdate";

        //    // create a new parameter
        //    DbParameter param = comm.CreateParameter();
        //    param.ParameterName = "@TaxRateId";
        //    param.Value = TaxRateId;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@TYPE";
        //    param.Value = TYPE;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@StateID";
        //    param.Value = StateID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);


        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@LocationID";
        //    param.Value = LocationID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@CategoryID";
        //    param.Value = CategoryID;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@TaxName";
        //    param.Value = TaxName;
        //    param.DbType = DbType.String;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@SalesType";
        //    param.Value = SalesType;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@PurchaseType";
        //    param.Value = PurchaseType;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@TaxRate";
        //    param.Value = TaxRate;
        //    param.DbType = DbType.Decimal;
        //    comm.Parameters.Add(param);

        //    param = comm.CreateParameter();
        //    param.ParameterName = "@BaseValue";
        //    param.Value = BaseValue;
        //    param.DbType = DbType.Decimal;
        //    comm.Parameters.Add(param);
        //    // create a new parameter
        //    param = comm.CreateParameter();
        //    param.ParameterName = "@ActiveStatus";
        //    param.Value = ActiveStatus;
        //    param.DbType = DbType.Int32;
        //    comm.Parameters.Add(param);

        //    // result will represent the number of changed rows
        //    int result = -1;
        //    try
        //    {
        //        // execute the stored procedure
        //        result = DBLayer.ExecuteNonQuery(comm);
        //    }
        //    catch
        //    {
        //        // any errors are logged in DataAccess
        //    }
        //    return (result != -1);
        //}

        public static bool Update_TaxRate(int TaxRateId, int TaxName, decimal TaxRate, decimal BaseValue, int ActiveStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_TaxRateUpdate";

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@TaxRateId";
            param.Value = TaxRateId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@TaxName";
            param.Value = TaxName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@TaxRate";
            param.Value = TaxRate;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@BaseValue";
            param.Value = BaseValue;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }

        #endregion

        #region Tax Mapping
        public static bool TaxRateMappingMain_Insert(string Tax_TypeID, int Tax_StateID, int Tax_LocationID, int Tax_CategoryID, int Tax_StructureID, int Status, int PurcahseType, int SalesType)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_TaxRateMapping_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Tax_TypeID";
            param.Value = Tax_TypeID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_StateID";
            param.Value = Tax_StateID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_LocationID";
            param.Value = Tax_LocationID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_CategoryID";
            param.Value = Tax_CategoryID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_StructureID";
            param.Value = Tax_StructureID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PurcahseType";
            param.Value = PurcahseType;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@SalesType";
            param.Value = SalesType;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch (Exception ex)
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static bool TaxRateMappingChield_Insert(int Tax_RateID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_TaxRateMappingChield_Insert";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Tax_RateID";
            param.Value = Tax_RateID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static DataTable BindTaxRateMapping(string SearchTaxName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Bind_TaxRateMapping";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SearchTaxName";
                param.Value = SearchTaxName;
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

        public static DataTable BindTaxRateMappingMain(int TaxMapID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_TaxRateMappingMainDetails";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxMapID";
                param.Value = TaxMapID;
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

        public static DataTable BindTaxRateMappingChield(int TaxMapID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_TaxRateMappingChieldDetails";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TaxMapID";
                param.Value = TaxMapID;
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

        public static bool TaxRateMappingMain_Update(int TaxMapID, string Tax_TypeID, int Tax_StateID, int Tax_LocationID, int Tax_CategoryID, int Tax_StructureID, int Status, int PurcahseType, int SalesType)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_TaxRateMappingMain_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@TaxMapID";
            param.Value = TaxMapID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Tax_TypeID";
            param.Value = Tax_TypeID;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_StateID";
            param.Value = Tax_StateID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_LocationID";
            param.Value = Tax_LocationID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_CategoryID";
            param.Value = Tax_CategoryID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Tax_StructureID";
            param.Value = Tax_StructureID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PurcahseType";
            param.Value = PurcahseType;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@SalesType";
            param.Value = SalesType;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch (Exception ex)
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        public static bool TaxRateMappingChield_delete(int TaxMapID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_TaxRateMappingChield_Delete";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param = comm.CreateParameter();
            param.ParameterName = "@TaxMapID";
            param.Value = TaxMapID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch (Exception ex)
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        #endregion

        public static bool TaxRateMappingChield_Update(int Tax_RateID, int TxtMapID)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_TaxRateMappingChield_Update";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Tax_RateID";
            param.Value = Tax_RateID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@TxtMapID";
            param.Value = TxtMapID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = DBLayer.ExecuteNonQuery(comm);
                //newUserID = Int32.Parse(comm.Parameters["@NewUserID"].Value.ToString());
            }
            catch
            {
                // any errors are logged in DataAccess
            }
            return (result != -1);
        }

        //Narender added new Method for Geting the Main Categories
        public static DataTable Get_Admin_MainCategory()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Get_MainCategory";
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        //for checking product stock before placing sales order
        public static DataTable Get_ProductStock( string MainLocation,int ProductId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckingStock";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@MainLocation";
                param.Value = MainLocation;
                param.DbType = DbType.String;
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
            finally
            {
                table.Dispose();
            }
        }

        #region  Narender 25-Mar-2017

        public static DataTable Check_VendorName_Exists(string VendorName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Exist_VendorName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@VendorName";
                param.Value = VendorName;
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

        public static bool Insert_VendorName(string VendorName, int ActiveStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_InsertVendorName";
           
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@VendorName";
            param.Value = VendorName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);           

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }

        public static DataTable Get_VendorName(string VendorName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetVendorName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@VendorName";
                param.Value = VendorName;
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

        public static DataTable VendorName_Existsupdate(int ID, string VendorName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckVendorNAMEExists_ForUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@VendorName";
                param.Value = VendorName;
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

        public static bool Update_VedorName(int ID, string VendorName , int ActiveStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_UpdateVendorName";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);            

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@VendorName";
            param.Value = VendorName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);                  
                       
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }

        public static DataTable Get_PO_ProductOnCategory(int SuplId ,int TypeID, int CategoryID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_PO_ProudctOnCategory";

                DbParameter param = comm.CreateParameter();
                param = comm.CreateParameter();
                param.ParameterName = "@SuplId";
                param.Value = SuplId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@TypeID";
                param.Value = TypeID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@SubCategoryID";
                param.Value = CategoryID;
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

        #region 05Jun2017
        public static DataTable BindPaymentTerms()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_GetPaymentTerms";
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }

        public static DataTable BindSuppliersDet(int SupId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_Supplier_Details";
                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SupId";
                param.Value = SupId;
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

        #endregion

        public static DataTable Get_GRNdataFor_PDF(int GRNID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_GRNdataFor_PDF";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@GRNID";
                param.Value = GRNID;
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

        public static DataTable Get_GRNDetailsdata_ForPDF(int GRNID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_Get_GRNDetailsdata_ForPDF";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@GRNID";
                param.Value = GRNID;
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

        public static DataTable Check_SPANumberExists(string SPANumber)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckingSPANumberExistsOrNot";

                // create a new parameter
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
        public static DataTable Get_SPANumber_Data(string SPANumber,int MaincategoryId,int categoryId,int Productid)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Get_SPANumber_Data";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SPANumber";
                param.Value = SPANumber;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@MaincategoryId";
                param.Value = MaincategoryId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@categoryId";
                param.Value = categoryId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Productid";
                param.Value = Productid;
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

        public static DataTable Imaging_Admin_GetUserNameList(string UserType)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Imaging_Admin_GetActiveUsersList_Basedon_UserType";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@UserType";
                param.Value = UserType;
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

        public static DataTable GetGSTNumBasedOnState(int StateId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetGSTNumBasedOnState";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@StateId";
                param.Value = StateId;
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

        public static DataTable GetSOInvoicedataForPdf(int SOInvoiceId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "Usp_GetSOInvoicedataForPdf";

                // create a new parameter
                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@SoInvoiceId";
                param.Value = SOInvoiceId;
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

        #region Gopinath
        public static DataTable Imaging_VATCST_Exists(string VATCST,int TypeId,string Name)//,int StateID
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_VATCST_Exists";


                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@VATCST";
                param.Value = VATCST;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@TypeId";
                param.Value = TypeId;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@Name";
                param.Value = Name;
                param.DbType = DbType.String;
                comm.Parameters.Add(param);

                //param = comm.CreateParameter();
                //param.ParameterName = "@StateID";
                //param.Value = StateID;
                //param.DbType = DbType.Int32;
                //comm.Parameters.Add(param);

                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Imaging_Admin_CusSupTran(String Customer)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USB_Admin_Get_CusSupTrans";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@Customer";
                param.Value = Customer;
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

        #endregion

        //added by Kushal 12Jul2017
        public static DataTable selecting_reversecharge()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "selecting_Reversecharge";
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        #region by sita 26-07-2017        
        public static DataTable GetSalTypeonStrID(int TxStID)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetSalTypeonStrID";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@TxStID";
                param.Value = TxStID;
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
        #endregion
        #region by sita 26-07-2017
        public static DataTable GetCustOnVertical(int VerticalId)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetCustOnvertical";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@VerticalId";
                param.Value = VerticalId;
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

        #endregion

        #region By Narender 09Nov2017
        public static DataTable GetCustNames()
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetCustNames";
                //DbParameter param = comm.CreateParameter();
                //param.ParameterName = "@VerticalId";
                //param.Value = VerticalId;
                //param.DbType = DbType.String;
                //comm.Parameters.Add(param);
                // execute the stored procedure and save the results in a DataTable
                table = DBLayer.ExecuteSelectCommand(comm);
                return table;
            }
            finally
            {
                table.Dispose();
            }
        }
        public static DataTable Get_WarrantyName(string WarrantyName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetWarrantyName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@WarrantyName";
                param.Value = WarrantyName;
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
        public static DataTable Check_WarrantyName_Exists(string WarrantyName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Exist_WarrantyName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@WarrantyName";
                param.Value = WarrantyName;
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
        public static bool Insert_WarrantyName(string WarrantyName, int ActiveStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_InsertWarrantyName";

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@WarrantyName";
            param.Value = WarrantyName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }
        public static DataTable WarrantyName_Existsupdate(int ID, string WarrantyName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckWarrantyNAMEExists_ForUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@WarrantyName";
                param.Value = WarrantyName;
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
        public static bool Update_WarrantyName(int ID, string WarrantyName, int ActiveStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_UpdateWarrantyName";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@WarrantyName";
            param.Value = WarrantyName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }
        public static DataTable Get_PaymentTerms(string PaymentTermName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_GetPaymentTermsName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@PaymentTermName";
                param.Value = PaymentTermName;
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
        public static DataTable Check_PaymentTermsName_Exists(string PaymentTermsName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_Exist_PaymentTermName";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@PaymentTermsName";
                param.Value = PaymentTermsName;
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
        public static bool Insert_PaymentTermsName(string PaymentTermsName, int ActiveStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_InsertPaymentTermName";

            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PaymentTermsName";
            param.Value = PaymentTermsName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }
        public static DataTable PaymentTermsName_Existsupdate(int ID, string PaymentTermsName)
        {
            DataTable table = null;
            try
            {
                // get a configured DbCommand object
                DbCommand comm = DBLayer.CreateCommand();
                // set the stored procedure name
                comm.CommandText = "USP_CheckPaymentTermNameExists_ForUpdate";

                DbParameter param = comm.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = ID;
                param.DbType = DbType.Int32;
                comm.Parameters.Add(param);

                param = comm.CreateParameter();
                param.ParameterName = "@PaymentTermsName";
                param.Value = PaymentTermsName;
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
        public static bool Update_PaymentTermsName(int ID, string PaymentTermsName, int ActiveStatus)
        {
            // get a configured DbCommand object
            DbCommand comm = DBLayer.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "USP_UpdatePaymentTermName";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PaymentTermsName";
            param.Value = PaymentTermsName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = ActiveStatus;
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
            return (result != -1);
        }
        #endregion
    }
}
