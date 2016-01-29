using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.BusinessObjects;
using Nan.BusinessObjects.BO;

namespace Nan.Controls
{
    public partial class ComboBoxEx : ComboBox
    {
        public ComboBoxEx()
        {
            InitializeComponent();
            m_vv = new List<ValidValue>();
        }

        public BOIDEnum BOID { get; set; }
        public string DesField { get; set; }
        public string KeyField { get; set; }
        public bool AddEmptyRow { get; set; }
        public bool AddDefineNew { get; set; }
        private List<ValidValue> m_vv;

        public void InitSource()
        {
            if (BOID == BOIDEnum.Invalid)
            {
                return;
            }
            BusinessObject bo = BOFactory.GetBO(BOID);
            m_vv = bo.GetValieValue(KeyField, DesField);
            if (AddEmptyRow)
            {
                m_vv.Insert(0, new ValidValue("ER", ""));
            }
            if (AddDefineNew)
            {
                m_vv.Insert(m_vv.Count, new ValidValue("DE", "---添加新项---"));
            }
            this.DataSource = m_vv;
            this.ValueMember = "Value";
            this.DisplayMember = "Description";
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!AddDefineNew)
            {
                base.OnSelectedIndexChanged(e);
                return;
            }
            if (SelectedIndex == m_vv.Count-1)
            {

            }
        }
    }
}
