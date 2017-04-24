using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Custom.Data;

namespace WonderFleur9.Controls
{
    public partial class NewsCtrlView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Custom.Objects.News[] news = DataProvider.News.GetList(this.Mode);
            NewsControl1.Items.Clear();
            if (news != null)
            {
                foreach (Custom.Objects.News n in news)
                {
                    NewsControl1.Items.Add(n.Title, n.Text, string.Format("~/ContextPage.aspx?ContextId={0}", n.ContextId),
                        n.Id.ToString(), string.Format("~/GetImageUrl.ashx?id={0}", n.ImageId), n.Date);
                }
            }
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