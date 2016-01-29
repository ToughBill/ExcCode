using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class MktDetail : BusinessObject
    {
        public int      ID { get; set; }
        public string   MktId { get; set; }
        public string   CotryId { get; set; }
    }
}
