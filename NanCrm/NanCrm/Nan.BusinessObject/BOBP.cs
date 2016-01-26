using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects
{
    public class BOBP : BusinessObject
    {
        public int      ID { get; set; }
        public string   Code { get; set; }
        public string   Name { get; set; }
        public string   Country { get; set; }
        public string   Site { get; set; }
        public string   Email { get; set; }
        public string   CtPeson { get; set; }
        public string   Phone { get; set; }
        public int      Level { get; set; }
        public string   Remark { get; set; }
        public BPType   Type { get; set; }
    }

    public enum BPType
    {
        Potential,
        Customer,
        Vendor
    }
}
