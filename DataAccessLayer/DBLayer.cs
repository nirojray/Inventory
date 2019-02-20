using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayer
{
   public class DBLayer
   {
       // executes a command and returns the results as a DataTable object
       public static DataTable ExecuteSelectCommand(DbCommand command)
       {
           // The DataTable to be returned 
           DataTable table = null;
           // Execute the command making sure the connection gets closed in the end
           try
           {
               // Open the data connection 
               command.Connection.Open();
               // Execute the command and save the results in a DataTable
               DbDataReader reader = command.ExecuteReader();
               table = new DataTable();
               table.Load(reader);

               // Close the reader 
               reader.Close();
               return table;
           }
           catch (Exception ex)
           {
               throw;
           }
           finally
           {
               // Close the connection
               command.Connection.Close();
               table.Dispose();
           }
           //return table;
       }

       // creates and prepares a new DbCommand object on a new connection
       public static DbCommand CreateCommand()
       {
           // Obtain the database provider name
           string dataProviderName = ConfigurationHelper.DbProviderName;
           // Obtain the database connection string
           string connectionString = ConfigurationHelper.DbConnectionString;
           // Create a new data provider factory
           DbProviderFactory factory = DbProviderFactories.
           GetFactory(dataProviderName);
           // Obtain a database specific connection object
           DbConnection conn = factory.CreateConnection();
           // Set the connection string
           conn.ConnectionString = connectionString;
           // Create a database specific command object
           DbCommand comm = conn.CreateCommand();
           // Set the command type to stored procedure
           comm.CommandType = CommandType.StoredProcedure;
           // Return the initialized command object
           return comm;
       }
       //Creates ans prepares a new DbCommand object on a new connection on given ConnectionString and Provider
       public static DbCommand CreateCommand(string DbProviderName, string DbConnectionString)
       {
           // Obtain the database provider name
           string dataProviderName = DbProviderName;
           // Obtain the database connection string
           string connectionString = DbConnectionString;
           // Create a new data provider factory
           DbProviderFactory factory = DbProviderFactories.
           GetFactory(dataProviderName);
           // Obtain a database specific connection object
           DbConnection conn = factory.CreateConnection();
           // Set the connection string
           conn.ConnectionString = connectionString;
           // Create a database specific command object
           DbCommand comm = conn.CreateCommand();
           // Set the command type to stored procedure
           comm.CommandType = CommandType.StoredProcedure;
           // Return the initialized command object
           return comm;
       }

       // execute an update, delete, or insert command 
       // and return the number of affected rows
       public static int ExecuteNonQuery(DbCommand command)
       {
           // The number of affected rows 
           int affectedRows = -1;
           // Execute the command making sure the connection gets closed in the end
           try
           {
               // Open the connection of the command
               command.Connection.Open();
               // Execute the command and get the number of affected rows
               affectedRows = command.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               throw;
           }
           finally
           {
               // Close the connection
               command.Connection.Close();
           }
           // return the number of affected rows
           return affectedRows;
       }

       // execute a select command and return a single result as a string
       public static string ExecuteScalar(DbCommand command)
       {
           // The value to be returned 
           string value = "";
           // Execute the command making sure the connection gets closed in the end
           try
           {

               // Open the connection of the command
               command.Connection.Open();
               // Execute the command and get the number of affected rows
               value = command.ExecuteScalar().ToString();
           }
           catch (Exception ex)
           {
               throw;
           }
           finally
           {
               // Close the connection
               command.Connection.Close();
           }
           // return the result
           return value;
       }

       public static SqlCommand CreateSqlCommand()
       {
           string dataProviderName = ConfigurationHelper.DbProviderName;
           string connectionString = ConfigurationHelper.DbConnectionString;
           SqlConnection Conn= new SqlConnection(connectionString);
           SqlCommand comm = new SqlCommand();
           comm.Connection = Conn;
           // Return the initialized command object
           return comm;
       }
        //public static string ExecuteUserDefinedDT(DbCommand command1)
        //{

        //    using (var command = new SqlCommand("InsertTable") { CommandType = CommandType.StoredProcedure })
        //    {
        //        var dt = new DataTable(); //create your own data table
        //        command.Parameters.Add(new SqlParameter("@myTableType", dt));
        //        SqlHelper.Exec(command);
        //    }

        //}
       

    }
}

