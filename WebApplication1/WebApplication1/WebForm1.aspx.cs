using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
             
            }
        }

        protected void CtrlChanged(Object sender, EventArgs e)
        {
            string ctrlName = ((Control)sender).ID;
            lstEvents.Items.Add(ctrlName + " changed.");

            lstEvents.SelectedIndex = lstEvents.Items.Count - 1;
        }
    }
}