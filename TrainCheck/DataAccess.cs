using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace TrainCheck
{
    public class DataAccess
    {
        private static SqlCeConnection _cnn = null;
        public static SqlCeConnection Connection
        {
            get
            {
                if (_cnn == null)
                {
                    String connectionString = ("Data Source ="
                        + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\dbtraincheck.sdf;"));
                    _cnn = new SqlCeConnection(connectionString);

                }
                return _cnn;
            }
        }
        public static int ExecuteNonQuery(String sqlstring)
        {
            SqlCeCommand command = Connection.CreateCommand();
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
            SqlCeCommand command = Connection.CreateCommand();
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
            SqlCeCommand command = Connection.CreateCommand();
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
        public static SqlCeResultSet ExecuteScalar(String sqlstring,ResultSetOptions rsopts)
        {
            SqlCeCommand command = Connection.CreateCommand();
            command.CommandText = sqlstring;
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                SqlCeResultSet result = command.ExecuteResultSet(rsopts);
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
            SqlCeDataAdapter ada = new SqlCeDataAdapter(sqlstring, Connection);
            try
            {
                DataSet result = new DataSet();
                ada.Fill(result);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ExecuteDataTable(String sqlstring)
        {
            return ExecuteDataSet(sqlstring).Tables[0];
        }
        public static DataTable ExecuteDataTable(String sqlstring,String tableName)
        {
            SqlCeDataAdapter ada = new SqlCeDataAdapter(sqlstring, Connection);
            try
            {
                DataSet result = new DataSet();
                ada.Fill(result,tableName);
                return result.Tables[tableName];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet ExecuteDataSet(String sqlstring,DataSet result)
        {
            SqlCeDataAdapter ada = new SqlCeDataAdapter(sqlstring, Connection);
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
}
