using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects
{
    public class BOPSHistory : BusinessObject
    {
        public int      ID { get; set; }
        public int      PSPId { get; set; }
        public string   Product { get; set; }
        public string   Link { get; set; }
        public int?     Plantf { get; set; }
        public string   KeyWord { get; set; }
        public int?     KWLst { get; set; }
    }
}
