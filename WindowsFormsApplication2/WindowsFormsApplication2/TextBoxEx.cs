using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class TextBoxEx : UserControl
    {
        private bool m_showLink;
        public bool ShowLink 
        { 
            get {return m_showLink;} 
            set {m_showLink = value; btnLink.Visible=value;}
        }
        private bool m_showChoose;
        public bool ShowChoose
        {
            get { return m_showChoose; }
            set { m_showChoose = value; btnChoose.Visible = value; }
        }

        public string Text
        {
            get { return txtBox.Text; }
            set { txtBox.Text = value; }
        }

        public TextBoxEx()
        {
            InitializeComponent();
            m_showLink = true;
            m_showChoose = true;
        }

        private void TextBoxEx_SizeChanged(object sender, EventArgs e)
        {
            btnLink.Left = 0;
            btnLink.Top = (this.Height - btnLink.Size.Height) / 2;

            btnChoose.Left = this.Width - btnChoose.Width;
            btnChoose.Top = (this.Height - btnChoose.Height) / 2;

            txtBox.Left = ShowLink ? btnLink.Width : 0;
            txtBox.Top = 0;
            txtBox.Width = this.Width - btnLink.Width - btnChoose.Width;
        }

        public event PickerClickHandler LinkClick;
        public event PickerClickHandler ChooseClick;

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (LinkClick != null)
            {
                PickerClickArgs args = new PickerClickArgs(this, TextBoxElem.Link);
                LinkClick(this, args);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (ChooseClick != null)
            {
                PickerClickArgs args = new PickerClickArgs(this, TextBoxElem.Choose);
                ChooseClick(this, args);
            }

        }
    }
}
