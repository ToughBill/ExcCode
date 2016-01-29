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
    public partial class FormEx : Form
    {
        protected BOIDEnum m_boId;
        protected BusinessObject m_bo;
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

        protected virtual bool btnCancel_Clicked(object sender, ClickedEventArgs e)
        {
            this.Close();
            return true;
        }

        private bool btnOk_Clicked(object sender, ClickedEventArgs e)
        {
            if (e.Result)
            {
                m_formMode = FormMode.Ok;
                btnOk.Text = "确定";
            }
            else
            {

            }
            return true;
        }

    }

    public enum FormMode
    {
        Ok,
        Update,
        Find
    }
}
