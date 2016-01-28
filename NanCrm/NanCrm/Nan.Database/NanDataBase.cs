using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;

namespace Nan.Database
{
    public class NanDataBase : JsonDbCore
    {
        private string m_dbPath;
        private string m_dbName;

        private static NanDataBase m_gNanDBConn = null;
        private static readonly object lockHelper = new object();

        public NanDataBase(string dbPath, string dbName):base(dbPath,dbName)
        {
            m_dbPath = dbPath;
            m_dbName = dbName;
        }

        public bool IsTableExist(BOIDEnum )
        {

        }

        public static NanDataBase GetInstance()
        {
            return m_gNanDBConn;
        }
        public static void InitDatabase(string dbPath, string dbName)
        {
            m_gNanDBConn = new NanDataBase(dbPath, dbName);
        }
    }
}
