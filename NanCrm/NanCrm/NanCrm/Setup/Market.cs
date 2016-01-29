using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.Controls;
using Nan.BusinessObjects;
using Nan.BusinessObjects.BO;

namespace NanCrm.Setup
{
    public partial class Market : FormEx
    {
        public Market(BOIDEnum boid):base(boid)
        {
            InitializeComponent();
        }
    }
}
