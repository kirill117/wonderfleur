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
    public class Gallery
    {
        private int galleryId;
        private string name_ru;
        private string name_en;
        private bool isHidden;
        private int sort;
        private bool isAchievement;

        public Gallery()
        {
        }

        public Gallery(SqlDataReader rd)
        {
            this.galleryId = (int)rd["Id"];
            this.name_ru = (string)rd["Name_ru"];
            this.name_en = (string)rd["Name_en"];
            this.isHidden = (bool)rd["IsHidden"];
            this.isAchievement = (bool)rd["IsAchievement"];
            this.sort = (int)rd["Sort"];
        }

        public int Id
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

        public int Sort
        {
            get
            {
                return this.sort;
            }
            set
            {
                this.sort = value;
            }
        }

        public bool IsHidden
        {
            get
            {
                return this.isHidden;
            }
            set
            {
                this.isHidden = value;
            }
        }

        public bool IsAchievement
        {
            get
            {
                return this.isAchievement;
            }
            set
            {
                this.isAchievement = value;
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

        public string Name
        {
            get
            {
                return Custom.Settings.UserLanguage == Settings.Language.English ? this.name_en : this.name_ru ;
            }
            set
            {
                if (Custom.Settings.UserLanguage == Settings.Language.English)
                    this.name_en = value;
                else
                    this.name_ru = value;
            }
        }
    }
}
