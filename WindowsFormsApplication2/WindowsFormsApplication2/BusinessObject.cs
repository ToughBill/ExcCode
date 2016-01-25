using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;

namespace WindowsFormsApplication2
{
    public class BusinessObject
    {
        //private string m_pTb;
        //public BusinessObject(string table)
        //{
        //    m_pTb = table;
        //}

        public virtual List<ValidValue> GetValieValue(string keyField, string descField)
        {
            return new List<ValidValue>();;
        }
    }
}
