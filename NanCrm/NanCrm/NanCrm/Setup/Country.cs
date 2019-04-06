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
using Nan.BusinessObjects.BO;
using System.Collections;

namespace NanCrm.Setup
{
    public partial class Country : FormEx
    {
        public Country(BOIDEnum boId)
            : base(boId)
        {
            InitializeComponent();
        }

        private void Country_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        public void LoadGridData()
        {
            List<BOCountry> ctybos = m_bo.GetDataList<BOCountry>();
            ctybos.Add((BOCountry)BOFactory.GetBO(m_boId));
            objList.SetObjects(ctybos);
        }

        private bool btnOk_Clicking(object sender, EventArgs e)
        {
            List<BOCountry> obj = (List<BOCountry>)objList.Objects;
            BOCountry objCty = (BOCountry)m_bo;
            objCty.SetDataList(obj);
            return objCty.Update();
        }

        private void objList_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if (e.SubItemIndex != 1 || e.ListViewItem.Index == e.ListViewItem.ListView.Items.Count-1)
            {
                return;
            }
            if (string.IsNullOrEmpty((string)e.NewValue))
            {
                e.Cancel = true;
                MessageBox.Show("input error!");
            }
        }

    }
}
