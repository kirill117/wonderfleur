using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Custom;

namespace WonderFleur9.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ifExit)
            {
                Settings.isAdmin = false;
                Settings.CurrentUser.Mode = Settings.UserMode.View;
            }
            else
            {
                Settings.isAdmin = true;
                Settings.CurrentUser.Mode = Settings.UserMode.Design;
            }
            this.Response.Redirect("~/", true);
        }

        private bool ifExit
        {
            get
            {
                int i;
                return (int.TryParse((Page.Request.QueryString["Exit"]), out i) && i == 1);
            }
        }
    }
}
