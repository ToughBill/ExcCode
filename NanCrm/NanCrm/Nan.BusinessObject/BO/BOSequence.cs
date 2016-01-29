using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biggy.Core;

namespace Nan.BusinessObjects.BO
{
    public class BOSequence : BusinessObject
    {
        [PrimaryKeyAttribute(false)]
        public int BOID { get; set; }
        public int NextID { get; set; }
    }
}
