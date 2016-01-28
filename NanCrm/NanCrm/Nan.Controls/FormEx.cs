using System;
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
    public partial class FormEx : Form
    {
        private BOIDEnum m_boId;
        private BusinessObject m_bo;
        public BusinessObject BO
        {
            get { return m_bo; }
            set { m_bo = value; }
        } 

        private FormMode m_formMode;
        public FormMode FormMode
        {
            get { return m_formMode; }
            set { m_formMode = value; }
        }

        public FormEx()
        {
            InitializeComponent();
            m_boId = BOIDEnum.Invalid;
            m_bo = null;
            m_formMode = FormMode.Ok;
        }

        public FormEx(BOIDEnum boId)
        {
            InitializeComponent();
            m_boId = boId;
            m_bo = BOFactory.GetBO(m_boId);
            m_formMode = FormMode.Ok;
        }

        private string m_tableSource;
        public string TableSource
        {
            get { return m_tableSource; }
            set
            {
                m_tableSource = value;
                ChangeComponentSource();
            }
        }

        protected void ChangeComponentSource()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBoxEx)
                {
                    ComboBoxEx comb = (ComboBoxEx)ctrl;
                    comb.BOID = m_boId;
                }
                else if (ctrl is TextBoxEx)
                {
                    TextBoxEx txt = (TextBoxEx)ctrl;
                    txt.TableSource = m_tableSource;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBoxEx)
                {
                    ComboBoxEx comb = (ComboBoxEx)ctrl;
                    comb.InitSource();
                }
            }

            base.OnLoad(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            m_formMode = FormMode.Update;
            btnOk.Text = "更新";
            base.OnKeyDown(e);
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void btnOk_Click(object sender, EventArgs e)
        {
            if (m_formMode == FormMode.Ok)
            {
                this.Close();
            }
            else if (m_formMode == FormMode.Update)
            {
                m_bo.Update();
            }
        }
    }

    public enum FormMode
    {
        Ok,
        Update
    }
}
