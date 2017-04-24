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
using Custom.Data;
using Custom;

namespace WonderFleur9.Controls
{
    public partial class UserContext : System.Web.UI.UserControl
    {
        protected int contextId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.BindContext();
            }
        }

        public void BindContext()
        {
            string str = DataProvider.GetUserContextValue(ContextId, Custom.Settings.UserLanguage);
            if (Settings.isAdmin)
            {
                this.HtmlEditor.Html = str;
                this.HtmlEditor.Height = Unit.Pixel(1500);
            }
            else
            {
                this.plhContent.Controls.Clear();
                LiteralControl ctl = new LiteralControl(str);
                this.plhContent.Controls.Add(ctl);
            }
            this.plhContent.Visible = !Settings.isAdmin;
            this.Panel1.Visible = Settings.isAdmin;
        }

        public int ContextId
        {
            get
            {
                int ret = 0;
                if (!int.TryParse(this.Page.Request.QueryString["ContextId"], out ret))
                    ret = this.contextId;
                return ret;
            }
            set { this.contextId = value; }
        }

        protected void cmbSave_Click(object sender, EventArgs e)
        {
            DataProvider.SaveUserContextValue(ContextId, this.HtmlEditor.Html);
        }
    }
}