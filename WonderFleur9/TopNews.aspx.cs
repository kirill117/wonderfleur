using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Custom.Data;
using Custom.Objects;
using DevExpress.Web.ASPxNewsControl;

namespace WonderFleur9
{
    public partial class TopNews : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Control ctrl;
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
                ctrl = this.LoadControl("~/Controls/NewsCtrlEdit.ascx");
            else
                ctrl = this.LoadControl("~/Controls/NewsCtrlView.ascx");
            if (this.Mode == News.Type.News)
                Label1.Text = Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "News" : "Новости";
            else
                Label1.Text = Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Shows" : "Выставки";
            phContent.Controls.Add(ctrl);
        }

        public Custom.Objects.News.Type Mode
        {
            get
            {
                int i;
                if (!int.TryParse(this.Request.QueryString["Mode"], out i))
                {
                    i = 0;
                }
                return i == 0 ? Custom.Objects.News.Type.News : Custom.Objects.News.Type.Show;
            }
        }
    }
}
