using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;
using Biggy.Core;
using System.Collections;

namespace Nan.BusinessObjects.BO
{
    public class BOCountry : BusinessObject
    {
        public int      ID { get; set; }
        public string   Name { get; set; }
        public string   ForeName { get; set; }
        public string   Alias { get; set; }
        public string   Capital { get; set; }

        JsonStore<BOCountry> m_tbCty;
        protected JsonStore<BOCountry> TableCountry
        {
            get 
            {
                if (m_tbCty == null)
                {
                    m_tbCty = new JsonStore<BOCountry>(m_dbConn);
                }
                return m_tbCty; 
            }
        }
        BiggyList<BOCountry> m_tbCtyList;
        protected BiggyList<BOCountry> CountryList
        {
            get 
            {
                if (m_tbCtyList == null)
                {
                    m_tbCtyList = new BiggyList<BOCountry>(m_tbCty);
                }
                return m_tbCtyList;
            }
        }

        List<BOCountry> m_newTbCtyList;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            BOCountry cty = (BOCountry)obj;
            return (cty.ID == this.ID
                    && cty.Name == this.Name
                    && cty.ForeName == this.ForeName
                    && cty.Alias == this.Alias
                    && cty.Capital == this.Capital);
        }

        public BOCountry()
        {
            base.m_boId = BOIDEnum.Country;
        }
        public override bool Init()
        {
            ID = GetNextID();

            return base.Init();
        }
        public void SetDataList(List<BOCountry> list)
        {
            m_newTbCtyList = list;
            //CountryList.SetList(list);
        }
        public override bool IsValid()
        {
            BOCountry findEle = m_newTbCtyList.Find(x => { return string.IsNullOrEmpty(x.Name); });
            if (findEle != null)
                return false;
            return true;
        }
        public override bool Add()
        {
            JsonStore<BOCountry> tbID = (JsonStore<BOCountry>)m_dbConn.CreateStoreFor<BOCountry>();
            var boIdList = new BiggyList<BOCountry>(tbID);

            return base.Add();
        }
        public override bool Update()
        {
            if (!IsValid())
            {
                return false;
            }
            int maxId = 1;
            m_newTbCtyList.ForEach(x => { if (x.ID > maxId) maxId = x.ID; });

            if(TableCountry.Update(m_newTbCtyList) == 1)
            {
                return base.SetNextID(maxId+1);
            }
            return base.Update();
        }
    }
}
