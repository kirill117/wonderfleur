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
    public partial class Galleries : System.Web.UI.Page
    {
        private void BindGrid()
        {

            GridView1.DataSource = DataProvider.Gallery.GetList();
            GridView1.KeyFieldName =  "Id";
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Label1.Text = Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Gallery" : "Фотогалерея";
                if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
                {
                    GridView1.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowAllRecords;
                    this.BindGrid();
                }
            }
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View)
            {
                GridView1.Columns[0].Visible = false;
                GridView1.Columns[3].Visible = false;
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
                GridView1.Settings.ShowColumnHeaders = false;
                GridView1.SettingsPager.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowPager;
                this.BindGrid();
            }
        }

        protected void cmdNew_Click(object sender, ImageClickEventArgs e)
        {
            Custom.Objects.Gallery gallery = new Custom.Objects.Gallery();
            gallery.Name_ru = "Новая галерея";
            gallery.Name_en = "New gallery";
            DataProvider.Gallery.Add(gallery);
            this.BindGrid();
        }

        protected void GridView1_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            Custom.Objects.Gallery gallery = DataProvider.Gallery.Get((int)e.KeyValue);
            switch (e.CommandArgs.CommandName)
            {
                case "Edit":
                    GridView1.StartEdit(e.VisibleIndex);
                    break;
                case "Update":
                    ASPxTextBox tb = (ASPxTextBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[1] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "tbName");
                    if (tb != null)
                        gallery.Name = tb.Text;
                    ASPxCheckBox cb = (ASPxCheckBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[3] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "cbAchievEdit");
                    if (tb != null)
                        gallery.IsAchievement = (bool)cb.Value;
                    DataProvider.Gallery.Update(gallery);
                    GridView1.CancelEdit();
                    break;
                case "Cancel":
                    GridView1.CancelEdit();
                    break;
                case "Add":
                    gallery = new Custom.Objects.Gallery();
                    gallery.Name_ru = "Новая галерея";
                    gallery.Name_en = "New gallery";
                    DataProvider.Gallery.Add(gallery);
                    break;
                case "Delete":
                    DataProvider.Gallery.Delete((int)e.KeyValue);
                    break;
                case "Up":
                    DataProvider.Gallery.MoveUp(gallery);
                    break;
                case "Down":
                    DataProvider.Gallery.MoveDown(gallery);
                    break;
            }
            this.BindGrid();
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            this.DataBind();
        }

        protected void GridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxTextBox tbx = (ASPxTextBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[1] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "tbName");
            if (tbx != null)
            {
                this.Page.ClientScript.RegisterStartupScript(Page.GetType(), "Scroll", string.Format("<script>scrollTo('{0}')</script>", tbx.ClientID));
            }
            
        }
    }
}
