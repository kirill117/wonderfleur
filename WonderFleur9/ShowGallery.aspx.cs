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
using DevExpress.Web.ASPxDataView;

namespace WonderFleur9
{
    public partial class ShowGallery : System.Web.UI.Page
    {
        private void BindGrid()
        {
            list.DataSource = DataProvider.Gallery.GetImagesList(this.galleryId);
            list.DataBind();
            foreach (DataViewItem dvi in list.Items)
            {
                DevExpress.Web.ASPxPanel.ASPxPanel pnl = (DevExpress.Web.ASPxPanel.ASPxPanel)list.FindItemControl("pnImage", dvi);
                if (pnl != null)
                {
                    Custom.Objects.Image img = dvi.DataItem as Custom.Objects.Image;
                    HtmlAnchor a = new HtmlAnchor();
                    a.Attributes.Add("class", "highslide");
                    a.Attributes.Add("href", string.Format("~/GetImageUrl.ashx?id={0}&height=500", img.Id));
                    a.Attributes.Add("onclick", "return hs.expand(this)");
                    a.Attributes.Add("title", "");
                    HtmlImage i = new HtmlImage();
                    i.Src = string.Format("~/GetImageUrl.ashx?id={0}&height=120", img.Id);
                    i.Alt = "";
                    a.Controls.Add(i);
                    pnl.Controls.Add(a);
                    Label lb1 = list.FindItemControl("lbComment", dvi) as Label;
                    lb1.Text = img.Name;
                    lb1.Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View;
                    TextBox tb1 = list.FindItemControl("tbComment", dvi) as TextBox;
                    tb1.Text = img.Name;
                    tb1.Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design;
                    HtmlTable pnt = (HtmlTable)list.FindItemControl("pnEdit", dvi);
                    pnt.Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design;

                    HtmlTableRow upc = (HtmlTableRow)list.FindItemControl("Upload1", dvi);
                    DevExpress.Web.ASPxEditors.ASPxButton btn = (DevExpress.Web.ASPxEditors.ASPxButton)list.FindItemControl("btnUpload", dvi);
                    btn.Attributes.Add("onclick", string.Format("ShowUpload('{0}')", upc.ClientID));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Custom.Objects.Gallery gallery = DataProvider.Gallery.Get(this.galleryId);
                Label1.Text = gallery.Name;
                if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
                {
                    list.AllowPaging = false;
                    this.BindGrid();
                }
            }
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View)
            {
                list.AllowPaging = true;
                this.BindGrid();
            }
        }

        public int galleryId
        {
            get
            {
                int id = 0;
                int.TryParse(this.Request.QueryString["id"].ToString(), out id);
                return id;
            }
        }

        protected void list_ItemCommand(object source, DataViewItemCommandEventArgs e)
        {
            int imageId = 0;
            try
            {
                imageId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            catch
            { }
            Custom.Objects.Image image = new Custom.Objects.Image();
            if (imageId > 0)
                 image = DataProvider.Gallery.GetImage(imageId);
            switch (e.CommandName)
            {
                case "Save":
                    HtmlTableRow tr = (HtmlTableRow)list.FindItemControl("Upload1", e.Item);
                    tr.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    TextBox tb1 = (TextBox)list.FindItemControl("tbComment", e.Item);
                    image.Name = tb1.Text;
                    DevExpress.Web.ASPxUploadControl.ASPxUploadControl upload = (DevExpress.Web.ASPxUploadControl.ASPxUploadControl)list.FindItemControl("Upload", e.Item);
                    if (upload.UploadedFiles != null && upload.UploadedFiles.Length > 0 && upload.UploadedFiles[0].FileBytes.Length > 0)
                    {
                        image.Body = upload.UploadedFiles[0].FileBytes;
                    }
                    DataProvider.Gallery.UpdateImage(image);
                    break;
                case "Delete":
                    DataProvider.Gallery.DeleteImage(imageId);
                    break;
                case "Upload":
                    list.FindItemControl("Upload", e.Item).Visible = true;
                    break;
                case "Add":
                    image.GalleryId = this.galleryId;
                    DataProvider.Gallery.AddImage(image);
                    break;
            }
            this.BindGrid();
        }

        protected void cmdNew_Click(object sender, ImageClickEventArgs e)
        {
            Custom.Objects.Image image = new Custom.Objects.Image();
            image.GalleryId = this.galleryId;
            DataProvider.Gallery.AddImage(image);
            this.BindGrid();
        }

        protected void list_PageIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}
