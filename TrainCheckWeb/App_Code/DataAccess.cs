using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    private static SqlConnection _cnn = null;
    public static SqlConnection Connection
    {
        get
        {
            if (_cnn == null)
            {
                String connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                _cnn = new SqlConnection(connectionString);
            }
            return _cnn;
        }
    }
    public static int ExecuteNonQuery(String sqlstring)
    {
        SqlCommand command = Connection.CreateCommand();
        command.CommandText = sqlstring;
        command.CommandType = System.Data.CommandType.Text;
        try
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            int result = command.ExecuteNonQuery();

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Connection.Close();
        }
    }
    public static IDataReader ExecuteReader(String sqlstring)
    {
        SqlCommand command = Connection.CreateCommand();
        command.CommandText = sqlstring;
        command.CommandType = System.Data.CommandType.Text;
        try
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            IDataReader result = command.ExecuteReader();

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //Connection.Close();
        }
    }
    public static Object ExecuteScalar(String sqlstring)
    {
        SqlCommand command = new SqlCommand();
        command.Connection = Connection;
        command.CommandText = sqlstring;
        command.CommandType = System.Data.CommandType.Text;
        try
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            Object result = command.ExecuteScalar();

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Connection.Close();
        }
    }
    
    public static DataSet ExecuteDataSet(String sqlstring)
    {
       
        SqlCommand cmd = Connection.CreateCommand();
        cmd.CommandText = sqlstring;
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter ada = new SqlDataAdapter(cmd);
        try
        {
            DataSet result = new DataSet();
            ada.Fill(result);
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static DataTable ExecuteDataTable(String sqlstring)
    {
        return ExecuteDataSet(sqlstring).Tables[0];
    }
    public static DataTable ExecuteDataTable(String sqlstring, String tableName)
    {
        SqlCommand cmd = Connection.CreateCommand();
        cmd.CommandText = sqlstring;
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter ada = new SqlDataAdapter(cmd);
        try
        {
            DataSet result = new DataSet();
            ada.Fill(result, tableName);
            return result.Tables[tableName];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static DataSet ExecuteDataSet(String sqlstring, DataSet result)
    {
        SqlCommand cmd = Connection.CreateCommand();
        cmd.CommandText = sqlstring;
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter ada = new SqlDataAdapter(cmd);
        try
        {
            ada.Fill(result);
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}