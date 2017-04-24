using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WonderFleur9.Controls
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ASPxRoundPanel1.Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design;
        }

        public bool LoginOk
        {
            get
            {
                return this.ASPxTextBox1.Text.Trim() == "12345";
            }
        }
    }
}