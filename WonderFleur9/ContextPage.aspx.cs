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

namespace WonderFleur9
{
    public partial class ContextPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int ContextId
        {
            get
            {
                int i;
                if (!int.TryParse(this.Request.QueryString["ContextId"], out i))
                    i = 0;
                return i;
            }
        }
    }
}
