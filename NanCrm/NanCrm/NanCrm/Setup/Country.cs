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
            ctybos.Add(new BOCountry());
            objList.SetObjects(ctybos);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<BOCountry> obj = (List<BOCountry>)objList.Objects;
            BOCountry objCty = (BOCountry)m_bo;
            objCty.SetDataList(obj);
            objCty.Update();
        }
    }
}
