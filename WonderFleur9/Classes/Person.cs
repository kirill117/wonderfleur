using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;

namespace Custom.Objects
{
    public class Person
    {
        protected int id;
        protected string name_ru;
        protected string name_en;
        protected string titul_ru;
        protected string titul_en;
        protected int imageId;
        protected int galleryId;
        protected int contextId;
        protected DateTime dateBirth;
        protected int sex;
        protected bool isKitten;
        protected string owner;
        protected string mother;
        protected string father;
        protected int motherId;
        protected int fatherId;
        protected string color;
        protected bool isActual;
        protected bool isLitter;
        protected string comment;

        public Person()
        {
            this.sex = 0;
            this.isKitten = false;
            this.isActual = true;
            this.isLitter = false;
        }

        public Person(int sex)
        {
            this.sex = sex > 2 ? 0 : sex;
            this.isKitten = false;
            this.isActual = sex != 3;
            this.isLitter = false;
        }
        
        public Person(bool isKitten)
        {
            this.sex = 0;
            this.isKitten = isKitten;
            this.isActual = true;
        }

        public Person(SqlDataReader rd) 
        {
            this.id = (int)rd["Id"];
            this.sex = (int)rd["Sex"]; 
            this.name_ru = (string)rd["Name_ru"];
            this.owner = (string)rd["Owner"];
            this.color = (string)rd["Color"];
            this.name_en = (string)rd["Name_en"];
            this.titul_ru = (string)rd["Titul_ru"];
            this.titul_en = (string)rd["Titul_en"];
            this.imageId = (int)rd["ImageId"];
            this.galleryId = (int)rd["GalleryId"]; 
            this.contextId = (int)rd["ContextId"];
            this.fatherId = (int)rd["Parent1Id"];
            this.motherId = (int)rd["Parent2Id"];
            this.father = (string)rd["Parent1"];
            this.mother = (string)rd["Parent2"];
            this.comment = (string)rd["Comment"];
            this.dateBirth = rd["DateBirth"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(rd["DateBirth"]);
            this.isKitten = (bool)rd["isKitten"];
            this.isActual = (bool)rd["isActual"];
            this.isLitter = (bool)rd["isLitter"];
        }

        public string DateBirth
        {
            get
            {
                return this.dateBirth == DateTime.MinValue ? string.Empty : this.dateBirth.ToShortDateString();
            }
            set
            {
                DateTime d;
                if (DateTime.TryParse(value, out d))
                    this.dateBirth = d;
            }
        }

        public int Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public int FatherId
        {
            get
            {
                return this.fatherId;
            }
            set
            {
                this.fatherId = value;
            }
        }

        public int MotherId
        {
            get
            {
                return this.motherId;
            }
            set
            {
                this.motherId = value;
            }
        }

        public string Father
        {
            get
            {
                return this.father;
            }
            set
            {
                this.father = value;
            }
        }

        public string Mother
        {
            get
            {
                return this.mother;
            }
            set
            {
                this.mother = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public bool IsKitten
        {
            get
            {
                return this.isKitten;
            }
            set
            {
                this.isKitten = value;
            }
        }

        public bool IsActual
        {
            get
            {
                return this.isActual;
            }
            set
            {
                this.isActual = value;
            }
        }

        public bool IsLitter
        {
            get
            {
                return this.isLitter;
            }
            set
            {
                this.isLitter = value;
            }
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

        public string Titul
        {
            get
            {
                return Settings.UserLanguage == Settings.Language.English ? this.titul_en : this.titul_ru;
            }
            set
            {
                if (Settings.UserLanguage == Settings.Language.English)
                    this.titul_en = value;
                else
                    this.titul_ru = value;
            }
        }

        public string Titul_ru
        {
            get
            {
                return this.titul_ru;
            }
            set
            {
                this.titul_ru = value;
            }
        }

        public string Titul_en
        {
            get
            {
                return this.titul_en;
            }
            set
            {
                this.titul_en = value;
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
                return Settings.UserLanguage == Settings.Language.English ? this.name_en : this.name_ru;
            }
            set
            {
                if (Settings.UserLanguage == Settings.Language.English)
                    this.name_en = value;
                else
                    this.name_ru = value;
            }
        }

        public string SexSt
        {
            get
            {
                if (Settings.UserLanguage == Settings.Language.English)
                    return this.sex == 0 ? "Male" : "Female";
                else
                    return this.sex == 0 ? "Кот" : "Кошка";
            }
        }

        public string Age
        {
            get
            {
                int d = (DateTime.Today - this.dateBirth).Days;
                return d.ToString();
            }
        }
    }
}
