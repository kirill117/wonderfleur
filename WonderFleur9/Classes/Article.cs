using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;

namespace Custom.Objects
{
    public class Article
    {
        protected int id;
        protected int contextId;
        protected string title_ru;
        protected string title_en;
        protected int sort;


        public Article()
        {
            title_ru = "";
            title_en = "";
        }

        public Article(SqlDataReader rd)
        {
            this.title_ru = (string)rd["Name_ru"];
            this.title_en = (string)rd["Name_en"];
            this.id = (int)rd["Id"];
            this.contextId = (int)rd["ContextId"];
            this.sort = (int)rd["Sort"];
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

        public int ContextId
        {
            get
            {
                return this.contextId;
            }
            set
            {
                this.contextId = value;
            }
        }

        public string Title_ru
        {
            get
            {
                return this.title_ru;
            }
            set
            {
                this.title_ru = value;
            }
        }

        public string Title_en
        {
            get
            {
                return this.title_en;
            }
            set
            {
                this.title_en = value;
            }
        }

        public string Title
        {
            get
            {
                return  Settings.UserLanguage == Settings.Language.English ? this.title_en : this.title_ru;
            }
        }
    }
}
