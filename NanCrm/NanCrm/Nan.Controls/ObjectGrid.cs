using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Nan.BusinessObjects;
using System.Collections;

namespace Nan.Controls
{
    public partial class ObjectGrid : ObjectListView
    {

        private BOIDEnum m_boId;
        /// <summary>
        /// Business Object Id
        /// </summary>
        public BOIDEnum BOID
        {
            get { return m_boId; }
            set { m_boId = value; }
        }

        public ObjectGrid()
        {
            InitializeComponent();
        }

    }
}
