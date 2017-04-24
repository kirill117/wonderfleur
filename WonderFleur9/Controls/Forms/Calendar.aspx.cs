using System;
using System.Text;
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

namespace WonderFleur9
{
    public class PopupCalendarForm : Page
    {
        protected System.Web.UI.WebControls.Calendar cal;
        protected System.Web.UI.WebControls.Calendar cdrCalendar;
        protected DropDownList month;
        protected DropDownList year;

        protected void cal_SelectionChanged(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<html><body>");
            builder.Append("<script>\r\n");
            builder.AppendFormat("window.opener.document.getElementById('{0}').value='{1}';\r\n", this.ParentControlID, this.cal.SelectedDate.ToShortDateString());
            builder.Append("self.close();\r\n");
            builder.Append("</script>");
            builder.Append("</body></html>");
            base.Response.Write(builder.ToString());
            base.Response.End();
        }

        private void InitializeComponent()
        {
        }

        protected void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshDate();
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.cal.VisibleDate = this.InitialValue;
                this.year.Items.Add(DateTime.Now.AddYears(-3).Year.ToString());
                this.year.Items.Add(DateTime.Now.AddYears(-2).Year.ToString());
                this.year.Items.Add(DateTime.Now.AddYears(-1).Year.ToString());
                this.year.Items.Add(DateTime.Now.Year.ToString());
                this.year.Items.Add(DateTime.Now.AddYears(1).Year.ToString());
                this.year.Items.Add(DateTime.Now.AddYears(2).Year.ToString());
                this.year.Items.Add(DateTime.Now.AddYears(3).Year.ToString());
                this.month.Items.Add(new ListItem("Январь", "1"));
                this.month.Items.Add(new ListItem("Февраль", "2"));
                this.month.Items.Add(new ListItem("Март", "3"));
                this.month.Items.Add(new ListItem("Апрель", "4"));
                this.month.Items.Add(new ListItem("Май", "5"));
                this.month.Items.Add(new ListItem("Июнь", "6"));
                this.month.Items.Add(new ListItem("Июль", "7"));
                this.month.Items.Add(new ListItem("Август", "8"));
                this.month.Items.Add(new ListItem("Сентябрь", "9"));
                this.month.Items.Add(new ListItem("Октябрь", "10"));
                this.month.Items.Add(new ListItem("Ноябрь", "11"));
                this.month.Items.Add(new ListItem("Декабрь", "12"));
                foreach (ListItem item in this.year.Items)
                {
                    if (item.Value == this.cal.SelectedDate.Year.ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                }
                foreach (ListItem item in this.month.Items)
                {
                    if (item.Value == this.cal.SelectedDate.Month.ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        private void RefreshDate()
        {
            int year = int.Parse(this.year.SelectedValue);
            int month = int.Parse(this.month.SelectedValue);
            this.cal.VisibleDate = new DateTime(year, month, this.cal.VisibleDate.Day);
        }

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshDate();
        }

        private DateTime InitialValue
        {
            get
            {
                DateTime now = DateTime.Now;
                if (base.Request.QueryString["val"] != null)
                {
                    try
                    {
                        now = DateTime.Parse(base.Request.QueryString["val"]);
                    }
                    catch
                    {
                    }
                }
                return now;
            }
        }

        private string ParentControlID
        {
            get
            {
                return base.Request.QueryString["ctl"];
            }
        }
    }
}
