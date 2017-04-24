using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Custom;

namespace Custom.Objects
{
    public class Image
    {
        private int id;
        private int galleryId;
        private string name_ru;
        private string name_en;
        private string url;
        private byte[] body;

        public Image()
        {
            this.body = new byte[] {};
            this.galleryId = 0;
            this.name_ru = "";
            this.name_en = "";
            this.url = "";
        }

        public Image(SqlDataReader rd)
        {
            this.galleryId = (int)rd["GalleryId"];
            this.name_ru = (string)rd["Name"];
            this.name_en = (string)rd["Name_en"];
            this.id = (int)rd["Id"];
            this.url = (string)rd["Url"];
            this.body = rd["Image"] == DBNull.Value ? new byte[0] : (byte[])rd["Image"];
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public byte[] Body
        {
            get
            {
                return this.body;
            }
            set
            {
                this.body = value;
            }
        }

        public int GalleryId
        {
            get
            {
                return this.galleryId;
            }
            set
            {
                this.galleryId = value;
            }
        }

        public string Name
        {
            get
            {
                return Custom.Settings.UserLanguage == Settings.Language.English ? this.name_en : this.name_ru;
            }
            set
            {
                if (Custom.Settings.UserLanguage == Settings.Language.English)
                    this.name_en = value;
                else
                    this.name_ru = value;
            }
        }

        public string Name_ru
        {
            get
            {
                return this.name_ru;
            }
            set
            {
                this.name_ru = value;
            }
        }

        public string Name_en
        {
            get
            {
                return this.name_en;
            }
            set
            {
                this.name_en = value;
            }
        }

        public string TargetUrl
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }

    }
}
