using System;
using System.Collections.Generic;
using System.Web;

namespace Custom
{
    public class Settings
    {
        public static Language UserLanguage
        {
            get
            {
                string lang = string.Empty;
                try
                {
                    lang = HttpContext.Current.Request.QueryString["language"].ToString();
                }
                catch { }
                switch (lang)
                {
                    case "ru":
                        HttpContext.Current.Session["userLanguage"] = Language.Russian;
                        break;
                    case "en":
                        HttpContext.Current.Session["userLanguage"] = Language.English;
                        break;
                }
                if (HttpContext.Current.Session["userLanguage"] == null)
                {
                    HttpContext.Current.Session["userLanguage"] = Language.Russian;
                }
                return (Language)HttpContext.Current.Session["userLanguage"];
            }
            set
            {
                HttpContext.Current.Session["userLanguage"] = value;
            }        
        }

        public static bool isAdmin
        {
            get
            {
                if (HttpContext.Current.Session["UserMode"] == null)
                {
                    HttpContext.Current.Session["UserMode"] = false;
                    return false;
                }
                return (bool)HttpContext.Current.Session["UserMode"]; ;
            }
            set
            {
                HttpContext.Current.Session["UserMode"] = value;
            }
        }

        public static User CurrentUser
        {
            get 
            {
                if (HttpContext.Current.Session["currentUser"] == null)
                {
                    Custom.User user = new Custom.User();
                    HttpContext.Current.Session["currentUser"] = user;
                    return user;
                }
                return (User)HttpContext.Current.Session["currentUser"]; 
            }
            set
            {
                HttpContext.Current.Session["currentUser"] = value;
            }
        }

        public enum Language
        {
            Russian = 0,
            English = 1
        }

        public enum UserMode
        {
            View = 0,
            Design = 1
        }

        public enum Sex
        {
            Кот,
            Кошка
        }
    }
}