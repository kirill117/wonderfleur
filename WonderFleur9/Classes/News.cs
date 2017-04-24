using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using Custom;

namespace Custom.Objects
{
    public class News
    {
        protected string title_en;
        protected string title_ru;
        protected string text_ru;
        protected string text_en;
        protected DateTime date;
        protected int imageId;
        protected int contextId;
        protected Type type;
        protected int id;

        public News()
        {
        }

        public News(SqlDataReader rd)
        {
            this.title_ru = (string)rd["Title_ru"];
            this.text_ru = (string)rd["Text_ru"];
            this.title_en = (string)rd["Title_en"];
            this.text_en = (string)rd["Text_en"];
            this.date = rd["DateNews"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(rd["DateNews"]);
            this.imageId = (int)rd["ImageId"];
            this.contextId =(int)rd["ContextId"];
            this.type = (Type)rd["Type"];
            this.id = (int)rd["Id"];
        }

        public string Title
        {
            get { return  Settings.UserLanguage == Settings.Language.English ? this.title_en : this.title_ru; }
            set 
            {
                if (Settings.UserLanguage == Settings.Language.English)
                    this.title_en = value;
                else
                    this.title_ru = value;
            }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Text_ru
        {
            get { return this.text_ru; }
            set { this.text_ru = value; }
        }

        public string Text_en
        {
            get { return this.text_en; }
            set { this.text_en = value; }
        }

        public string Title_ru
        {
            get { return this.title_ru; }
            set { this.title_ru = value; }
        }

        public string Title_en
        {
            get { return this.title_en; }
            set { this.title_en = value; }
        }

        public string Text
        {
            get { return Settings.UserLanguage == Settings.Language.English ? this.text_en : this.text_ru; }
            set
            {
                if (Settings.UserLanguage == Settings.Language.English)
                    this.text_en = value;
                else
                    this.text_ru = value;
            }
        }

        public string DateSt
        {
            get { return this.date == DateTime.MinValue ? string.Empty : this.date.ToShortDateString(); }
            set 
            {
                DateTime d;
                if (DateTime.TryParse(value, out d))
                    this.date = d;
            }
        }

        public int ImageId
        {
            get { return this.imageId; }
            set { this.imageId = value; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public int ContextId
        {
            get { return this.contextId; }
            set { this.contextId = value; }
        }

        public Type NewsType
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public enum Type
        {
            News = 0,
            Show = 1
        }

        public byte[] ImageBody
        {
            get
            {
                Custom.Objects.Image img = Custom.Data.DataProvider.Gallery.GetImage(this.imageId);
                return img == null ? null : img.Body;
            }
        }
    }
}