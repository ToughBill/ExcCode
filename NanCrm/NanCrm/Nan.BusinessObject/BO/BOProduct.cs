using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects.BO
{
    public class BOProduct : BusinessObject
    {
        public int      ID { get; set; }
        public string   Code { get; set; }
        public string   Name { get; set; }
        public string   FName { get; set; }
        public int      Category { get; set; }
        public string   Refundrate { get; set; }
        public string   Remark { get; set; }
        public string   Length { get; set; }
        public string   Width { get; set; }
        public string   Height { get; set; }
        public string   Weight { get; set; }
        public string   Texture { get; set; }
    }
}
