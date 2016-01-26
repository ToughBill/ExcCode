﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.BusinessObjects;

namespace Nan.Controls
{
    public partial class ComboBoxEx : ComboBox
    {
        public ComboBoxEx()
        {
            InitializeComponent();
            m_vv = new List<ValidValue>();
        }

        public string TableSource { get; set; }
        public string DesField { get; set; }
        public string KeyField { get; set; }
        private List<ValidValue> m_vv;

        public void InitSource()
        {
            if (TableSource == null || TableSource.Length <= 0)
            {
                return;
            }
            BusinessObject bo = BOFactory.GetBO(TableSource);

            this.DataSource = bo.GetValieValue(KeyField, DesField);
            this.ValueMember = "Value";
            this.DisplayMember = "Description";

        }
    }

    public class ValidValue
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
