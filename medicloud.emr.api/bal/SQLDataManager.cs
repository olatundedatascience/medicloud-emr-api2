using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;


public class SQLDataManager : IDisposable
{

    SqlCommand sqlCmd;          // holds the command
    SqlConnection sqlConn;       // holds the connection
    SqlTransaction sqlTrans;   // holds the transaction

    public SQLDataManager()
    {

    }
    public bool testConnection()
    {
        return false;
    }

    public SQLDataManager(bool IsTransaction)
    {
        // setup the connection object
        sqlConn = new SqlConnection();

        sqlConn = PortalDAO.getNewConnection();

        // open the connection
        OpenConnection();

        // begin the transaction (if required)
        if (IsTransaction == true)
        {
            sqlTrans = sqlConn.BeginTransaction();
        }

        // reset the state of the object
        Reset();
    }
    public void ClosedbConnection()
    {
        sqlCmd.Dispose();
        CloseConnection();
    }

    private void OpenConnection()
    {
        if (sqlConn.State == ConnectionState.Closed)
        {
            try
            {
                sqlConn.Open();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
    public void Reset()
    {
        // setup the command object
        sqlCmd = new SqlCommand();
        sqlCmd.Connection = sqlConn;

        // add the transaction if we need to
        if (sqlTrans != null)
        {
            sqlCmd.Transaction = sqlTrans;
        }
    }

    public void CommitTransaction()
    {
        sqlTrans.Commit();
    }


    public void RollbackTransaction()
    {
        sqlTrans.Rollback();
    }
    private void CloseConnection()
    {
        if (sqlConn.State == ConnectionState.Open)
        {
            sqlConn.Close();
        }
    }

    public void AddParamAndValue(string param, object value)
    {
        sqlCmd.Parameters.AddWithValue(param, value);
    }

    public void ExecuteStoredProcedure(string procedureName, out SqlDataReader reader)
    {
        var _readerObject = ExecuteDataReader(procedureName, CommandType.StoredProcedure);
        reader = _readerObject;
        
    }

    public object GetOutputParameter(SqlParameter output)
    {
        object obj = output.Value;
        return obj;
    }

    public void RemoveParameter(string strName)
    {

        sqlCmd.Parameters.RemoveAt(sqlCmd.Parameters.IndexOf(strName));


    }
    public SqlDataAdapter ExecuteAdapter(string strCommand, CommandType objType)
    {
        // set the properties correctly
        sqlCmd.CommandText = strCommand;
        sqlCmd.CommandType = objType;
        sqlCmd.CommandTimeout = 500;

        // create the data adapater object
        SqlDataAdapter objAdapter = new SqlDataAdapter(sqlCmd);

        // return the adapter
        return (objAdapter);
    }

    public SqlDataReader ExecuteDataReader(string command, CommandType commandType)
    {
        sqlCmd = new SqlCommand(command);
        sqlCmd.CommandType = commandType;
        sqlCmd.Connection = sqlConn;
        SqlDataReader _reader = sqlCmd.ExecuteReader();

        return _reader;
    }

    public DataSet GetDataset(string sqlCommand, CommandType objType)
    {
        SqlDataAdapter adapter = ExecuteAdapter(sqlCommand, objType);

        DataSet ds = new DataSet();
        adapter.Fill(ds);
        return ds;
    }
    public int ExecuteNonQuery(string strCommand, CommandType objType)
    {
        int intReturn = -1;

        sqlCmd.CommandText = strCommand;
        sqlCmd.CommandType = objType;
        sqlCmd.CommandTimeout = 1000;
        intReturn = sqlCmd.ExecuteNonQuery();

        return (intReturn);
    }

    public string ExecuteScalar(string strCommand, CommandType objType)
    {
        string ret = "";

        sqlCmd.CommandText = strCommand;
        sqlCmd.CommandType = objType;
        ret = sqlCmd.ExecuteScalar().ToString();

        return ret;
    }

    public void Dispose()
    {
        ClosedbConnection();
    }
}

