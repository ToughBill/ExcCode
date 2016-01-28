using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nan.Database;
using Biggy.Data.Json;
using Biggy.Core;

namespace Nan.BusinessObjects
{
    public class BusinessObject
    {
        protected BOIDEnum m_boId;
        protected NanDataBase m_dbConn;

        public virtual List<ValidValue> GetValieValue(string keyField, string descField)
        {
            return new List<ValidValue>();
        }

        public BusinessObject()
        {
            m_dbConn = NanDataBase.GetInstance();
        }

        public virtual int GetNextID()
        {
            string tableName = GetEnumDescription(m_boId);

            if(!m_dbConn.TableExists(tableName))
            {
                return 1;
            }
            JsonStore<BOSequence> tbID = (JsonStore<BOSequence>)m_dbConn.CreateStoreFor<BOSequence>();
            var boIdList = new BiggyList<BOSequence>(tbID);
            var boid = boIdList.Find(x => x.BOID == (int)m_boId);
            if (boid != null)
            {
                return boid.NextID;
            }
            else
            {
                return 1;
            }
        }

        public string GetEnumDescription(Enum enumValue)
        {
            string str = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            System.ComponentModel.DescriptionAttribute da = (System.ComponentModel.DescriptionAttribute)objs[0];
            return da.Description;
        }
    }

    public class ValidValue
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
