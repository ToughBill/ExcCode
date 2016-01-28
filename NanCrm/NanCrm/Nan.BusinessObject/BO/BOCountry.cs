using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Data.Json;
using Biggy.Core;
using System.Collections;

namespace Nan.BusinessObjects
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
            ID = GetNextID();
            //m_tbCty = new JsonStore<BOCountry>(m_dbConn);
            //m_tbCtyList = new BiggyList<BOCountry>(m_tbCty);
        }

        public void SetDataList(List<BOCountry> list)
        {
            CountryList.SetList(list);
        }

        public override bool Add()
        {
            JsonStore<BOCountry> tbID = (JsonStore<BOCountry>)m_dbConn.CreateStoreFor<BOCountry>();
            var boIdList = new BiggyList<BOCountry>(tbID);

            return base.Add();
        }
        public override bool Update()
        {
            return TableCountry.FlushToDisk();
        }
    }
}
