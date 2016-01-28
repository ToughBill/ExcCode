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

namespace NanCrm
{
    public partial class BPMD : FormEx
    {
        private BOBP m_boBP;
 
        public BPMD(BOIDEnum boid):base(boid)
        {
            InitializeComponent();
            
        }
    }
}
