using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects
{
    public class BOKWLDetail : BusinessObject
    {
        public int      ID { get; set; }
        public string   KWLId { get; set; }
        public string   KeyWord { get; set; }
        public string   Level { get; set; }
    }
}
