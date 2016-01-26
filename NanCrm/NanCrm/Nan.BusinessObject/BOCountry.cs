﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nan.BusinessObjects
{
    public class BOCountry : BusinessObject
    {
        public int      ID { get; set; }
        public string   Name { get; set; }
        public string   Alias { get; set; }
        public string   Capital { get; set; }
    }
}
