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
        public FormEx()
        {
            InitializeComponent();
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

        private BusinessObject m_bo;
        public BusinessObject BO
        {
            get { return m_bo; }
            set { m_bo = value; }
        } 

        protected void ChangeComponentSource()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBoxEx)
                {
                    ComboBoxEx comb = (ComboBoxEx)ctrl;
                    comb.TableSource = m_tableSource;
                }
                else if (ctrl is TextBoxEx)
                {
                    TextBoxEx txt = (TextBoxEx)ctrl;
                    txt.TableSource = m_tableSource;
                }
            }
        }
    }
}
