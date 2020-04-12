using System;
using System.Data.SqlClient;

namespace GiaiNganAPI.DAL.Core
{ 
    public abstract class dapperDAL 
    {
        protected SqlConnection myConn;
        protected SqlCommand myCommand;
        protected SqlParameter myPar;
        protected SqlTransaction myTran;
        protected string connectionString = string.Empty;

        protected void initConnect(string dbType = null)
        {
            try
            {
                ConfigSettings.Instance.AppSettings(dbType);
                connectionString = ConfigSettings.connectString;
                myConn = new SqlConnection(connectionString);
                myCommand = new SqlCommand("", myConn);
                myCommand.CommandText = "set names utf8";
                myPar = new SqlParameter();
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
            }
        }

        protected void connection(string dbType = null)
        {
            initConnect(dbType);
        }

        protected SqlConnection openConnection()
        {
            connection();
            return myConn;
        }

    }
}

