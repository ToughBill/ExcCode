using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.Controls;
using BrightIdeasSoftware;
using Nan.BusinessObjects;

namespace NanCrm.Setup
{
    public partial class Country : FormEx
    {
        public Country()
        {
            InitializeComponent();
        }

        private void Country_Load(object sender, EventArgs e)
        {
            LoadGridData(this, objList);
        }

        public void LoadGridData(FormEx form, ObjectListView objList)
        {
            List<BOCountry> ctybos = new List<BOCountry>();
            objList.SetObjects(ctybos);
        }
    }
}
