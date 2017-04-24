using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using Custom.Objects;

namespace Custom.Data
{
    public class DataProvider
    {
        public static SqlConnection GetConnection()
        {
            string con = ConfigurationManager.ConnectionStrings["DATABASE"].ConnectionString;
            SqlConnection sc = new SqlConnection(con);
            return sc;
        }

        public static Custom.Objects.Person[] GetKittensList()
        {
            ArrayList list = new ArrayList();
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = "select * from person where isKitten = 1 and isActual = 1 order by Id";
            SqlCommand com = new SqlCommand(s, sc);
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Custom.Objects.Person(rd));
            }
            rd.Close();
            sc.Close();
            return (Custom.Objects.Person[])list.ToArray(typeof(Custom.Objects.Person));
        }

        public static Custom.Objects.Litter[] GetLittersList()
        {
            ArrayList list = new ArrayList();
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = @"select p.*, 
                         fatherImageID = ISNULL((select TOP 1 i1.Id from Images i1 where i1.GalleryID = p.GalleryID ORDER BY i1.Id), 0),
                         motherImageID = ISNULL((select TOP 1 i1.Id from Images i1 where i1.GalleryID = p.GalleryID ORDER BY i1.Id DESC),0)
                         from person p where p.isLitter = 1 and p.isActual = 1 order by p.Id";
            SqlCommand com = new SqlCommand(s, sc);
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Custom.Objects.Litter(rd));
            }
            rd.Close();
            sc.Close();
            return (Custom.Objects.Litter[])list.ToArray(typeof(Custom.Objects.Litter));
        }

        public static Custom.Objects.Person[] GetPersonListBySex(int sex)
        {
            ArrayList list = new ArrayList();
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = string.Format("select * from person where Sex = {0} and isKitten = 0 and isActual = 1 and isLitter = 0 order by Id", sex);
            SqlCommand com = new SqlCommand(s, sc);
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Custom.Objects.Person(rd));
            }
            rd.Close();
            sc.Close();
            return (Custom.Objects.Person[])list.ToArray(typeof(Custom.Objects.Person));
        }

        public static Custom.Objects.Person[] GetVeteransList()
        {
            ArrayList list = new ArrayList();
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = "select * from person where isKitten = 0 and isActual = 0 and isLitter = 0 order by Id";
            SqlCommand com = new SqlCommand(s, sc);
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Custom.Objects.Person(rd));
            }
            rd.Close();
            sc.Close();
            return (Custom.Objects.Person[])list.ToArray(typeof(Custom.Objects.Person));
        }

        public static Custom.Objects.Person GetPerson(int personId)
        {
            Custom.Objects.Person person = null;
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = string.Format("select * from person where Id = {0}", personId);
            SqlCommand com = new SqlCommand(s, sc);
            SqlDataReader rd = com.ExecuteReader();
            if (rd.Read())
                person = new Custom.Objects.Person(rd);
            rd.Close();
            sc.Close();
            return person;
        }

        public static void SavePerson(Custom.Objects.Person person)
        {
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = @"update Person set Name_en = @P1, Name_ru = @P2,
                                           Titul_en = @P3, Titul_ru = @P4, 
                                           GalleryId = @P5, ImageId = @P6,
                                           Owner = @P7, Color = @P8,
                                           Parent1 = @P9, Parent2 = @P10,
                                           Parent1Id = @P11, Parent2Id = @P12,
                                           DateBirth = @P13, isKitten = @P14,
                                           isActual = @P15, Sex = @P16,
                                           Comment = @P17
                         where Id = @P0";
            SqlCommand com = new SqlCommand(s, sc);
            com.Parameters.AddWithValue("@P0", person.Id);
            com.Parameters.AddWithValue("@P1", person.Name_en ?? string.Empty);
            com.Parameters.AddWithValue("@P2", person.Name_ru ?? string.Empty);
            com.Parameters.AddWithValue("@P3", person.Titul_en ?? string.Empty);
            com.Parameters.AddWithValue("@P4", person.Titul_ru ?? string.Empty);
            com.Parameters.AddWithValue("@P5", person.GalleryId);
            com.Parameters.AddWithValue("@P6", person.ImageId);
            com.Parameters.AddWithValue("@P7", person.Owner ?? string.Empty);
            com.Parameters.AddWithValue("@P8", person.Color ?? string.Empty);
            com.Parameters.AddWithValue("@P9", person.Father ?? string.Empty);
            com.Parameters.AddWithValue("@P10", person.Mother ?? string.Empty);
            com.Parameters.AddWithValue("@P11", person.FatherId);
            com.Parameters.AddWithValue("@P12", person.MotherId);
            if (string.IsNullOrEmpty(person.DateBirth))
                com.Parameters.AddWithValue("@P13", DBNull.Value);
            else
                com.Parameters.AddWithValue("@P13",Convert.ToDateTime(person.DateBirth));
            com.Parameters.AddWithValue("@P14", person.IsKitten);
            com.Parameters.AddWithValue("@P15", person.IsActual);
            com.Parameters.AddWithValue("@P16", person.Sex);
            com.Parameters.AddWithValue("@P17", person.Comment ?? string.Empty);
            com.ExecuteNonQuery();
            if (Gallery.CheckForEmptyName(person.GalleryId))
            {
                s = "update Gallery SET Name_ru = @P1, Name_en = @P2 where Id = @P0";
                com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", person.GalleryId);
                com.Parameters.AddWithValue("@P1", person.Name_en ?? string.Empty);
                com.Parameters.AddWithValue("@P2", person.Name_en ?? string.Empty);
                com.ExecuteNonQuery();
            }
            sc.Close();
        }

        public static void DelPerson(int personId)
        {
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = "delete from Person where Id = @P1";
            SqlCommand com = new SqlCommand(s, sc);
            com.Parameters.AddWithValue("@P1", personId);
            com.ExecuteNonQuery();
            sc.Close();
        }

        public static int AddPerson(Custom.Objects.Person person)
        {
            var ret = -1;
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = "EXEC AddPerson @P1,@P2,@P3";
            SqlCommand com = new SqlCommand(s, sc);
            com.Parameters.AddWithValue("@P1", person.Sex);
            com.Parameters.AddWithValue("@P2", person.IsKitten);
            com.Parameters.AddWithValue("@P3", person.IsLitter);
            try
            {
                ret = (int)com.ExecuteScalar();
            }
            catch { }
            sc.Close();
            return ret;
        }

        public static string GetUserContextValue(int contextId, Custom.Settings.Language language)
        {
            string ret;
            SqlConnection sc = GetConnection();
            sc.Open();
            string s;
            if (language == Settings.Language.English)
                s = string.Format("select CAST(Value_en as nvarchar(MAX)) from context where Id = {0}", contextId);
            else
                s = string.Format("select CAST(Value as nvarchar(MAX)) from context where Id = {0}", contextId);
            SqlCommand com = new SqlCommand(s, sc);
            ret = (string)com.ExecuteScalar();
            if (string.IsNullOrEmpty(ret))
                ret = "";
            sc.Close();
            return ret;
        }

        public static void SaveUserContextValue(int contextId, string value)
        {
            SqlConnection sc = GetConnection();
            sc.Open();
            string s = "";
            if (Custom.Settings.UserLanguage == Settings.Language.English)
                s = string.Format("update context set Value_en = @P2 where Id = @P1", contextId);
            else
                s = string.Format("update context set Value = @P2 where Id = @P1", contextId);
            SqlCommand com = new SqlCommand(s, sc);
            com.Parameters.AddWithValue("@P1", contextId);
            com.Parameters.AddWithValue("@P2", value);
            com.ExecuteNonQuery();
            sc.Close();
        }

        public class Article
        {
            public static Custom.Objects.Article Get(int id)
            {
                Custom.Objects.Article ret = null;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "select * from Articles where Id = @P1";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P1", id); 
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    ret = new Custom.Objects.Article(rd);
                }
                rd.Close();
                sc.Close();
                return ret;
            }

            public static void MoveDown(Custom.Objects.Article article)
            {
                int i = -1;
                Custom.Objects.Article[] articles = GetList();
                foreach (Custom.Objects.Article art in articles)
                {
                    i++;
                    if (art.Id == article.Id)
                    {
                        break;
                    }
                }
                if (i >= 0 && i < articles.Length - 1)
                {
                    int oldSort = article.Sort;
                    article.Sort = articles[i + 1].Sort;
                    articles[i + 1].Sort = oldSort;
                    Update(article);
                    Update(articles[i + 1]);
                }
            }

            public static void MoveUp(Custom.Objects.Article article)
            {
                int i = -1;
                Custom.Objects.Article[] articles = GetList();
                foreach (Custom.Objects.Article art in articles)
                {
                    i++;
                    if (art.Id == article.Id)
                    {
                        break;
                    }
                }
                if (i > 0 && i <= articles.Length)
                {
                    int oldSort = article.Sort;
                    article.Sort = articles[i - 1].Sort;
                    articles[i - 1].Sort = oldSort;
                    Update(article);
                    Update(articles[i - 1]);
                }
            }

            public static Custom.Objects.Article[] GetList()
            {
                ArrayList list = new ArrayList();
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "select * from Articles where isPublish = 1 order by Sort desc";
                SqlCommand com = new SqlCommand(s, sc);
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Custom.Objects.Article(rd));
                }
                rd.Close();
                sc.Close();
                return (Custom.Objects.Article[])list.ToArray(typeof(Custom.Objects.Article));
            }

            public static int Add(Custom.Objects.Article article)
            {
                int ret;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "EXEC AddArticle @P1,@P2";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P1", article.Title_ru);
                com.Parameters.AddWithValue("@P2", article.Title_en);
                ret = (int)com.ExecuteScalar();
                sc.Close();
                return ret;
            }

            public static void Update(Custom.Objects.Article article)
            {
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "UPDATE Articles set Name_ru = @P1, Name_en = @P2, Sort = @P3 where Id = @P0";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", article.Id);
                com.Parameters.AddWithValue("@P1", article.Title_ru);
                com.Parameters.AddWithValue("@P2", article.Title_en);
                com.Parameters.AddWithValue("@P3", article.Sort);
                com.ExecuteNonQuery();
                sc.Close();
            }

            public static void Delete(int id)
            {
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "EXEC DeleteArticle @P0";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", id);
                com.ExecuteNonQuery();
                sc.Close();
            }
        }

        public class Gallery
        {
            public static void MoveDown(Custom.Objects.Gallery gallery)
            {
                int i = -1;
                Custom.Objects.Gallery[] galleryes = GetList();
                foreach (Custom.Objects.Gallery art in galleryes)
                {
                    i++;
                    if (art.Id == gallery.Id)
                    {
                        break;
                    }
                }
                if (i >= 0 && i < galleryes.Length - 1)
                {
                    int oldSort = gallery.Sort;
                    gallery.Sort = galleryes[i + 1].Sort;
                    galleryes[i + 1].Sort = oldSort;
                    Update(gallery);
                    Update(galleryes[i + 1]);
                }
            }

            public static void MoveUp(Custom.Objects.Gallery gallery)
            {
                int i = -1;
                Custom.Objects.Gallery[] galleryes = GetList();
                foreach (Custom.Objects.Gallery art in galleryes)
                {
                    i++;
                    if (art.Id == gallery.Id)
                    {
                        break;
                    }
                }
                if (i > 0 && i <= galleryes.Length)
                {
                    int oldSort = gallery.Sort;
                    gallery.Sort = galleryes[i - 1].Sort;
                    galleryes[i - 1].Sort = oldSort;
                    Update(gallery);
                    Update(galleryes[i - 1]);
                }
            }

            public static bool CheckForEmptyName(int id)
            {
                bool ret = false;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "select (Name_en+Name_ru) Name from Gallery where Id = @P1";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P1", id);
                var chk = com.ExecuteScalar();
                if (chk != null && string.IsNullOrEmpty(chk.ToString()))
                    ret = true;
                sc.Close();
                return ret;
            }

            public static bool CheckForDelete(int id)
            {
                bool ret = true;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "select Id from Person where GalleryId = @P1";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P1", id);
                if (com.ExecuteScalar() != null)
                    ret = false;
                sc.Close();
                return ret;
            }

            public static Custom.Objects.Gallery Get(int id)
            {
                Custom.Objects.Gallery ret = null;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "select * from Gallery where Id = @P1";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P1", id);
                SqlDataReader rd = com.ExecuteReader();
                if (rd.Read())
                {
                    ret = new Custom.Objects.Gallery(rd);
                }
                rd.Close();
                sc.Close();
                return ret;
            }

            public static int Add(Custom.Objects.Gallery galley)
            {
                int ret;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "EXEC AddGallery @P1,@P2";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P1", galley.Name_ru);
                com.Parameters.AddWithValue("@P2", galley.Name_en);
                ret = (int)com.ExecuteScalar();
                sc.Close();
                return ret;
            }

            public static void Update(Custom.Objects.Gallery galley)
            {
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "UPDATE Gallery set Name_ru = @P1, Name_en = @P2, Sort = @P3, IsAchievement = @P4 where Id = @P0";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", galley.Id);
                com.Parameters.AddWithValue("@P1", galley.Name_ru);
                com.Parameters.AddWithValue("@P2", galley.Name_en);
                com.Parameters.AddWithValue("@P3", galley.Sort);
                com.Parameters.AddWithValue("@P4", galley.IsAchievement);
                com.ExecuteNonQuery();
                sc.Close();
            }

            public static void Delete(int id)
            {
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "EXEC DeleteGallery @P0";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", id);
                com.ExecuteNonQuery();
                sc.Close();            
            }
            public static Custom.Objects.Gallery[] GetList()
            {
                return Gallery.GetList(false);
            }

            public static Custom.Objects.Gallery[] GetList(bool isAchievement)
            {
                ArrayList list = new ArrayList();
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = isAchievement ? "select * from gallery where IsHidden = 0 and IsAchievement = 1 order by Sort desc " : "select * from gallery where IsHidden = 0 order by Sort desc";
                SqlCommand com = new SqlCommand(s, sc);
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Custom.Objects.Gallery(rd));
                }
                rd.Close();
                sc.Close();
                return (Custom.Objects.Gallery[])list.ToArray(typeof(Custom.Objects.Gallery));
            }

            public static int GetTopImageId(int galleryId)
            {
                int ret = 0;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = string.Format("select top 1 Id from Images where GalleryId = {0} order by Id", galleryId);
                SqlCommand com = new SqlCommand(s, sc);
                try
                {
                    int.TryParse(com.ExecuteScalar().ToString(), out ret);
                }
                catch
                {
                }
                sc.Close();
                return ret;
            }

            public static Custom.Objects.Image[] GetImagesList(int galleryId)
            {
                ArrayList list = new ArrayList();
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = string.Format("select * from Images where galleryId = {0} order by id", galleryId);
                SqlCommand com = new SqlCommand(s, sc);
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Custom.Objects.Image(rd));
                }
                rd.Close();
                sc.Close();
                return (Custom.Objects.Image[])list.ToArray(typeof(Custom.Objects.Image));
            }

            public static Custom.Objects.Image GetImage(int imageId)
            {
                Custom.Objects.Image ret = null;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = string.Format("select * from Images where Id = {0}", imageId);
                SqlCommand com = new SqlCommand(s, sc);
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                   ret = new Custom.Objects.Image(rd);
                }
                rd.Close();
                sc.Close();
                return ret;
            }

            public static void UpdateImage(Custom.Objects.Image image)
            {
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "UPDATE Images SET Image = @P1, Name = @P2, GalleryId = @P3, Url = @P4, Name_en = @P5 WHERE Id = @P0";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", image.Id);
                com.Parameters.AddWithValue("@P1", image.Body);
                com.Parameters.AddWithValue("@P2", image.Name_ru);
                com.Parameters.AddWithValue("@P3", image.GalleryId);
                com.Parameters.AddWithValue("@P4", image.TargetUrl);
                com.Parameters.AddWithValue("@P5", image.Name_en);
                com.ExecuteNonQuery();
                sc.Close();
            }

            public static void DeleteImage(int imageId)
            {
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "DELETE FROM Images WHERE Id = @P0";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", imageId);
                com.ExecuteNonQuery();
                sc.Close();
            }

            public static int AddImage(Custom.Objects.Image image)
            {
                int ret = 0;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "exec AddImage @P1, @P2, @P3, @P4";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P1", image.Body);
                com.Parameters.AddWithValue("@P2", image.Name);
                com.Parameters.AddWithValue("@P3", image.GalleryId);
                com.Parameters.AddWithValue("@P4", image.TargetUrl);
                ret = (int)com.ExecuteScalar();
                sc.Close();
                return ret;
            }
        }

        public class News
        {
            public static Custom.Objects.News[] GetList(Custom.Objects.News.Type type)
            {
                ArrayList list = new ArrayList();
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = string.Format("select * from News where [Type] = {0} order by DateNews desc", (int)type);
                SqlCommand com = new SqlCommand(s, sc);
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Custom.Objects.News(rd));
                }
                rd.Close();
                sc.Close();
                return (Custom.Objects.News[])list.ToArray(typeof(Custom.Objects.News));
            }

            public static Custom.Objects.News Get(int newsId)
            {
                Custom.Objects.News news = null;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = string.Format("select * from News where Id = {0}", newsId);
                SqlCommand com = new SqlCommand(s, sc);
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    news = new Custom.Objects.News(rd);
                }
                rd.Close();
                sc.Close();
                return news;
            }

            public static void Delete(int newsId)
            {
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "EXEC DeleteNews @P0";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", newsId);
                com.ExecuteNonQuery();
                sc.Close();
            }

            public static int Add(Custom.Objects.News news)
            {
                int ret;
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = "EXEC AddNews @P1,@P2,@P3,@P4";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P1", news.Title_ru);
                com.Parameters.AddWithValue("@P2", news.Title_en);
                com.Parameters.AddWithValue("@P3", news.NewsType);
                com.Parameters.AddWithValue("@P4", news.Date);
                ret = (int)com.ExecuteScalar();
                sc.Close();
                return ret;
            }

            public static void Update(Custom.Objects.News news)
            {
                SqlConnection sc = GetConnection();
                sc.Open();
                string s = @"UPDATE News set Title_ru = @P1, Title_en = @P2, 
                                             Text_ru = @P3, Text_en = @P4,
                                             DateNews = @P5, ImageId = @P6
                             where Id = @P0";
                SqlCommand com = new SqlCommand(s, sc);
                com.Parameters.AddWithValue("@P0", news.Id);
                com.Parameters.AddWithValue("@P1", news.Title_ru);
                com.Parameters.AddWithValue("@P2", news.Title_en);
                com.Parameters.AddWithValue("@P3", news.Text_ru);
                com.Parameters.AddWithValue("@P4", news.Text_en);
                com.Parameters.AddWithValue("@P5", news.Date);
                com.Parameters.AddWithValue("@P6", news.ImageId);
                com.ExecuteNonQuery();
                sc.Close();
            }
        }
    }
}