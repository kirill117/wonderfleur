using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WonderFleur9
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Language != -1)
            {
                Custom.Settings.UserLanguage = this.Language == 1 ? Custom.Settings.Language.English : Custom.Settings.Language.Russian;
                this.Response.Redirect("~/Main.aspx", true);
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View || this.Login.LoginOk)
            {
                Custom.Settings.UserLanguage = Custom.Settings.Language.Russian;
                this.Response.Redirect("~/Main.aspx", true);
            }
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View || this.Login.LoginOk)
            {
                Custom.Settings.UserLanguage = Custom.Settings.Language.English;
                this.Response.Redirect("~/Main.aspx", true);
            }
        }

        private int Language
        {
            get
            {
                int num;
                return (int.TryParse(base.Request.QueryString["lang"], out num) ? num : -1);
            }
        }
    }
}
