using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;
using Biggy.Core;
using System.Collections;
using Nan.BusinessObjects.Database;

namespace Nan.BusinessObjects.BO
{
    public class BusinessObject
    {
        protected BOIDEnum m_boId;
        protected NanDataBase m_dbConn;
        protected List<BOIDEnum> m_relatedBO;

        public virtual List<ValidValue> GetValieValue(string keyField, string descField)
        {
            return new List<ValidValue>();
        }

        public BusinessObject()
        {
            m_dbConn = NanDataBase.GetInstance();
            m_relatedBO = new List<BOIDEnum>() { BOIDEnum.BOSequence};
        }

        public virtual bool Init()
        {
            return true;
        }

        public virtual int GetNextID()
        {
            //string tableName = GetEnumDescription(m_boId);

            //if(!m_dbConn.TableExists(tableName))
            //{
            //    return 1;
            //}
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

        public virtual bool Add()
        {
            return true;
        }
        public virtual bool Update()
        {

            return true;
        }
        public virtual bool SetNextID(int id)
        {
            JsonStore<BOSequence> tbID = (JsonStore<BOSequence>)m_dbConn.CreateStoreFor<BOSequence>();
            var boIdList = new BiggyList<BOSequence>(tbID);
            BOSequence objId = boIdList.Find(x => { return x.BOID == (int)m_boId; });
            if (objId == null)
            {
                boIdList.Add(new BOSequence() { BOID = (int)m_boId, NextID = id + 1 });
            }
            else
            {
                objId.NextID = id;
                boIdList.Update(objId);
            }
            return true;
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

        public virtual List<T> GetDataList<T>() where T : new()
        {
            JsonStore<T> tbObj = new JsonStore<T>(m_dbConn);
            var objList = new BiggyList<T>(tbObj);

            return objList.GetList();
        }
    }

    public class ValidValue
    {
        public string Value { get; set; }
        public string Description { get; set; }

        public ValidValue(string value, string desc)
        {
            Value = value;
            Description = desc;
        }
    }
}
