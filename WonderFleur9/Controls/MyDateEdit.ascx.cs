using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WonderFleur9.Controls
{
    public partial class MyDateEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string Value
        {
            get
            {
                return this.DateEdit1.Text;
            }
            set
            {
                this.DateEdit1.Text = value;
            }
        }
    }
}