using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nan.Controls
{
    public delegate bool ClickingEvent(object sender, EventArgs e);
    public delegate bool ClickedEvent(object sender, ClickedEventArgs e);
    public partial class ButtonEx : Button
    {
        public event ClickingEvent Clicking;
        public event ClickedEvent Clicked;
        public ButtonEx()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            //base.OnClick(e);
            bool ret = true;
            if (Clicking != null)
            {
                ret = Clicking(this, e);
            }
            if (Clicked !=null)
            {
                Clicked(this,new ClickedEventArgs(ret));
            }
        }
    }

    public class ClickedEventArgs : EventArgs
    {
        public bool Result { get; set; }
        public ClickedEventArgs(bool ret)
        {
            Result = ret;
        }
    }
}
