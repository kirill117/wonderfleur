using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Custom.Data;
using Custom.Objects;

namespace WonderFleur9
{
    public partial class Articles : System.Web.UI.Page
    {
        private void BindGrid()
        {
            Custom.Objects.Article[] articles = DataProvider.Article.GetList();
            this.list.DataSource = articles;
            this.list.DataKeyNames = new string[] { "Id" };
            this.list.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        protected void list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.list.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void list_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox tb = (TextBox)this.list.Rows[e.RowIndex].Cells[0].FindControl("TextBox1");
            if (tb != null)
            {

                Custom.Objects.Article article = DataProvider.Article.Get((int)list.DataKeys[e.RowIndex].Value);
                if (Custom.Settings.UserLanguage == Custom.Settings.Language.English)
                    article.Title_en = tb.Text.Trim();
                else
                    article.Title_ru = tb.Text.Trim();
                DataProvider.Article.Update(article);
            }
            this.list.EditIndex = -1;
            this.BindGrid();
        }

        protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataProvider.Article.Delete((int)list.DataKeys[e.RowIndex].Value);
            this.BindGrid();
        }

        protected void list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    Custom.Objects.Article article = new Custom.Objects.Article();
                    article.Title_ru = "Новая стаья";
                    article.Title_en = "New article";
                    DataProvider.Article.Add(article);
                    this.BindGrid();
                    break;
                case "ContextEdit":
                    string s = string.Format("~/ContextPage.aspx?ContextId={0}", e.CommandArgument);
                    Response.Redirect(s, true);
                    break;
                case "Up":
                    Custom.Objects.Article article1 = DataProvider.Article.Get(Convert.ToInt32(e.CommandArgument));
                    Custom.Data.DataProvider.Article.MoveUp(article1);
                    this.BindGrid();
                    break;
                case "Down":
                    Custom.Objects.Article article2 = DataProvider.Article.Get(Convert.ToInt32(e.CommandArgument));
                    Custom.Data.DataProvider.Article.MoveDown(article2);
                    this.BindGrid();
                    break;
            }
        }

        protected void list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.list.EditIndex = -1;
            this.BindGrid();
        }

    }
}
