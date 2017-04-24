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
using Custom.Objects;
using DevExpress.Web.ASPxEditors;

namespace WonderFleur9
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected override void OnPreRender(EventArgs e)
        {
            foreach (DevExpress.Web.ASPxMenu.MenuItem item in this.ASPxMenu1.Items)
            {
                ASPxHyperLink lbt = (ASPxHyperLink)item.FindControl("lbName1");
                if (lbt != null)
                {
                    lbt.Text = item.Text;
                    lbt.NavigateUrl = item.NavigateUrl;
                }
            }
            foreach (DevExpress.Web.ASPxNavBar.NavBarGroup group in this.NavBar1.Groups)
            {
                Label lb = (Label)group.FindControl("lbName");
                if (lb != null)
                {
                    lb.Text = group.Text;
                }
            }
            foreach (DevExpress.Web.ASPxNavBar.NavBarGroup group in this.NavBar2.Groups)
            {
                Label lb = (Label)group.FindControl("lbName");
                if (lb != null)
                {
                    lb.Text = group.Text;
                }
            }
            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Custom.Settings.UserLanguage == Custom.Settings.Language.English)
                {
                    rpCopyRight.HeaderText = "For Your guidance...";
                    rpCopyRight.FindControl("pnlCopyRightRu").Visible = false;
                    rpCopyRight.FindControl("pnlCopyRightEn").Visible = true;

                    this.ASPxMenu1.Items.FindByName("Main").Text = "Main";
                    this.ASPxMenu1.Items.FindByName("News").Text = "News";
                    this.ASPxMenu1.Items.FindByName("Shows").Text = "Shows";
                    this.ASPxMenu1.Items.FindByName("Kittens").Text = "Kittens";
                    this.ASPxMenu1.Items.FindByName("Gallery").Text = "Gallery";
                    this.ASPxMenu1.Items.FindByName("Contacts").Text = "Contacts";

                    this.NavBar2.Groups.FindByName("News").Text = "Last news";
                    this.NavBar2.Groups.FindByName("Shows").Text = "Shows";
                    this.NavBar2.Groups.FindByName("Articles").Text = "Useful articles";

                    this.NavBar1.Groups.FindByName("Pets").Text = "Our cats";
                    this.NavBar1.Groups.FindByName("Pets").Items.FindByName("Tomcats").Text = "Studs";
                    this.NavBar1.Groups.FindByName("Pets").Items.FindByName("Cats").Text = "Queens";
                    this.NavBar1.Groups.FindByName("Pets").Items.FindByName("Veterans").Text = "Veterans";
                    this.NavBar1.Groups.FindByName("Pets").Items.FindByName("Litters").Text = "Our plans";

                    this.NavBar1.Groups.FindByName("About").Text = "Abous us";
                    this.NavBar1.Groups.FindByName("About").Items.FindByName("History").Text = "History";
                    this.NavBar1.Groups.FindByName("About").Items.FindByName("About").Text = "About British Shorthair";
                    this.NavBar1.Groups.FindByName("About").Items.FindByName("Contacts").Text = "Contacts";
                    
                    this.NavBar1.Groups.FindByName("Achievements").Text = "Our achievements";

                    this.NavBar1.Groups.FindByName("Links").Text = "Links";
                    this.NavBar1.Groups.FindByName("Links").Items.FindByName("Friends").Text = "Friends";
                    this.NavBar1.Groups.FindByName("Links").Items.FindByName("Banner").Text = "Banner";
                }
                this.ASPxMenu1.Items.FindByName("admin").Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design;

                DevExpress.Web.ASPxNavBar.NavBarGroup group_a = (DevExpress.Web.ASPxNavBar.NavBarGroup)this.NavBar1.Groups.FindByName("Achievements");
                group_a.Items.Clear();
                Custom.Objects.Gallery[] galleries = DataProvider.Gallery.GetList(true);
                foreach(Custom.Objects.Gallery gallery in galleries)
                {
                    string s = string.Format("~/ShowGallery.aspx?id={0}", gallery.Id);
                    group_a.Items.Add(gallery.Name, "", "", s);
                }

                
                DevExpress.Web.ASPxNavBar.NavBarGroup group = (DevExpress.Web.ASPxNavBar.NavBarGroup)this.NavBar2.Groups.FindByName("Articles");
                group.Items.Clear();
                Custom.Objects.Article[] articles = DataProvider.Article.GetList();
                foreach (Custom.Objects.Article article in articles)
                {
                    if (article.Title != "New article")
                    {
                        string s = string.Format("~/ContextPage.aspx?ContextId={0}", article.ContextId);
                        group.Items.Add(article.Title, "", "", s);
                    }
                }
                group.Visible = group.Items.Count > 0;
                group = (DevExpress.Web.ASPxNavBar.NavBarGroup)this.NavBar2.Groups.FindByName("News");
                group.Items.Clear();
                Custom.Objects.News[] news = DataProvider.News.GetList(News.Type.News);
                int i = 1;
                foreach (Custom.Objects.News nw in news)
                {
                    string s = string.Format("~/ContextPage.aspx?ContextId={0}", nw.ContextId);
                    group.Items.Add(nw.DateSt + " - " + nw.Title, "", "", s);
                    i++;
                    if (i > 3)
                    {
                        group.Items.Add(Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "more..." : "ещё...", "", "", "~/TopNews.aspx?Mode=0");
                        break;
                    }
                }
                i = 1;
                group = (DevExpress.Web.ASPxNavBar.NavBarGroup)this.NavBar2.Groups.FindByName("Shows");
                group.Items.Clear();
                Custom.Objects.News[] shows = DataProvider.News.GetList(News.Type.Show);
                foreach (Custom.Objects.News nw in shows)
                {
                    string s = string.Format("~/ContextPage.aspx?ContextId={0}", nw.ContextId);
                    group.Items.Add(nw.DateSt + " - " + nw.Title, "", "", s);
                    i++;
                    if (i > 3)
                    {
                        group.Items.Add(Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "more..." : "ещё...", "", "", "~/TopNews.aspx?Mode=1");
                        break;
                    }
                }
            }
        }
    }
}
