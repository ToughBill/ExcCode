using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApplication2
{
    class DBConnector
    {
        private string m_connStr;
        private OleDbConnection m_conn;

        

        public DBConnector(string connStr)
        {
            m_connStr = connStr;
        }

        public void GetData(string table, string desField, string keyField)
        {
            if (m_conn == null || m_conn.State != ConnectionState.Open)
            {
                m_conn = new OleDbConnection(m_connStr);
                m_conn.Open();
            }

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = m_conn;
            cmd.CommandText = "select " + keyField + ", " + desField + " from " + table;
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

            }
        }
    }
}
