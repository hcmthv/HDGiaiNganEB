using System;
using Microsoft.Data.SqlClient;

namespace GiaiNganAPI.DAL.Core
{
    public abstract class dapperDAL
    {
        protected SqlConnection myConn;
        protected SqlCommand myCommand;
        protected SqlParameter myPar;
        protected SqlTransaction myTran;

        protected string connectionString =
            @"SERVER=52.78.132.235\mssqlserver2017, 1851;DATABASE=atmaneuler;UID=sa;PWD=Atmaneuler@0197;";
             //@"SERVER=192.168.0.210\mssqlserver2017, 53883;DATABASE=atmaneuler;UID=sa;PWD=sa123456;";

        protected void initConnect()
        {
            try
            {
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

        protected void connection()
        {
            initConnect();
        }

        protected SqlConnection openConnection()
        {
            connection();
            return myConn;
        }

    }
}
