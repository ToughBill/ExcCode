using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NanCrm
{
    public partial class frmMain : Form
    {
        private frmMainMenu m_frmMainMenu;
        public frmMain()
        {
            InitializeComponent();
            m_frmMainMenu = null;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitMainMenu();
        }

        private void InitMainMenu()
        {
            if (m_frmMainMenu == null)
            {
                m_frmMainMenu = new frmMainMenu();
                m_frmMainMenu.MdiParent = this;
                m_frmMainMenu.Show();
            }
        }
    }
}
