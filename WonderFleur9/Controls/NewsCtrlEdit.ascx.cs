using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Custom.Data;
using Custom.Objects;
using DevExpress.Web.ASPxEditors;

namespace WonderFleur9.Controls
{
    public partial class NewsCtrlEdit : System.Web.UI.UserControl
    {
        private void BindGrid()
        {
            GridView1.DataSource = DataProvider.News.GetList(this.Mode);
            GridView1.KeyFieldName = "Id";
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
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

        protected void GridView1_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            Custom.Objects.News news = DataProvider.News.Get((int)e.KeyValue);
            switch (e.CommandArgs.CommandName)
            {
                case "Edit":
                    GridView1.StartEdit(e.VisibleIndex);
                    break;
                case "Update":
                    ASPxTextBox tb = (ASPxTextBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "tbTitle");
                    if (tb != null)
                    {
                        news.Title = tb.Text.Trim();
                    }
                    ASPxMemo tb1 = (ASPxMemo)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[1] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "tbText");
                    if (tb1 != null)
                    {
                        news.Text = tb1.Text.Trim();
                    }
                    ASPxDateEdit de = (ASPxDateEdit)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[2] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "DateEdit1");
                    if (de != null && de.Value != null)
                    {
                        try
                        {
                            news.Date = Convert.ToDateTime(de.Value);
                        }
                        catch
                        { }
                    }
                    DevExpress.Web.ASPxUploadControl.ASPxUploadControl upload = (DevExpress.Web.ASPxUploadControl.ASPxUploadControl)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[3] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "Upload1");
                    if (upload.UploadedFiles != null && upload.UploadedFiles.Length > 0 && upload.UploadedFiles[0].FileBytes.Length > 0)
                    {
                        Custom.Objects.Image image = null;
                        if (news.ImageId > 0)
                        {
                            image = DataProvider.Gallery.GetImage(news.ImageId);
                            image.Body = upload.UploadedFiles[0].FileBytes;
                            DataProvider.Gallery.UpdateImage(image);
                        }
                        else
                        {
                            image = new Custom.Objects.Image();
                            image.Body = upload.UploadedFiles[0].FileBytes;
                            news.ImageId = DataProvider.Gallery.AddImage(image);
                        }
                    }
                    DataProvider.News.Update(news);
                    GridView1.CancelEdit();
                    break;
                case "Cancel":
                    GridView1.CancelEdit();
                    break;
                case "Add":
                    news = new Custom.Objects.News();
                    news.Title_ru = "Новая тема";
                    news.Title_en = "New subject";
                    news.NewsType = this.Mode;
                    news.Date = DateTime.Now;
                    DataProvider.News.Add(news);
                    break;
                case "Delete":
                    DataProvider.News.Delete((int)e.KeyValue);
                    break;
            }
            this.BindGrid();
        }

        protected void cmdNew_Click(object sender, ImageClickEventArgs e)
        {
            Custom.Objects.News news = new Custom.Objects.News();
            news.Title_ru = "Новая тема";
            news.Title_en = "New subject";
            news.NewsType = this.Mode;
            news.Date = DateTime.Now;
            DataProvider.News.Add(news);
            this.BindGrid();
        }
    }
}