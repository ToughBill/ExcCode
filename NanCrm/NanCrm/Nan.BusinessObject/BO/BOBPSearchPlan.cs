using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class BOBPSearchPlan : BusinessObject
    {
        public int          ID { get; set; }
        public DateTime?    SDate { get; set; }
        public DateTime?    EDate { get; set; }
        public int          Status { get; set; }
        public int?         SerPlantf { get; set; }
        public string       KeyWord { get; set; }
        public int?         KWLst { get; set; }
        public string       Comment { get; set; }
    }

}
