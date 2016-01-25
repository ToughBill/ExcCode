using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObject
{
    public class BusinessObject
    {
        public virtual List<ValidValue> GetValieValue(string keyField, string descField)
        {
            return new List<ValidValue>(); ;
        }
    }

    public class ValidValue
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
