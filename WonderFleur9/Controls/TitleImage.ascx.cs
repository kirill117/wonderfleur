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

namespace WonderFleur9.Controls
{
    public partial class TitleImage : System.Web.UI.UserControl
    {
        protected int imageId;
        protected int galleryId;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.imageId > 0)
                this.AddImage(this.imageId, true);
            else
                BuildGallery();
            base.OnPreRender(e);
        }

        private void BuildGallery()
        {
            bool t = true;
            Custom.Objects.Image[] images = DataProvider.Gallery.GetImagesList(this.galleryId);
            foreach (Custom.Objects.Image image in images)
            {
                this.AddImage(image.Id, t);
                t = false;
            }

        }

        private void AddImage(int imageId, bool ifTitle)
        {
            HtmlAnchor a = new HtmlAnchor();
            a.Attributes.Add("class", "highslide");
            a.Attributes.Add("href", string.Format("~/GetImageUrl.ashx?id={0}&height=500", imageId));
            a.Attributes.Add("onclick", "return hs.expand(this)");
            a.Attributes.Add("title", "");
            HtmlImage i = new HtmlImage();
            i.Src = string.Format("~/GetImageUrl.ashx?id={0}&height=120", imageId);
            i.Alt = "";
            a.Controls.Add(i);
            if (ifTitle)
            {
                pnImage.Controls.Add(a);
             //   pnGallery.Controls.Add(a);
            }
            else
                pnGallery.Controls.Add(a);
        }

        public int GalleryId
        {
            get { return this.galleryId; }
            set { this.galleryId = value; }
        }

        public int ImageId
        {
            get 
            {
                return this.imageId;

            }
            set 
            { 
                this.imageId = value; 
            }
        }
    }
}