using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;

namespace Custom.Objects
{
    public class Litter : Person
    {
        protected int fatherImageId;
        protected int motherImageId;

        public Litter(SqlDataReader dr)
            : base(dr)
        {
            this.fatherImageId = (int)dr["fatherImageID"];
            this.motherImageId = (int)dr["motherImageID"];
        }

        public int MotherImageId
        {
            get
            {
                return this.motherImageId;
            }
            set
            {
                this.motherImageId = value;
            }
        }

        public int FatherImageId
        {
            get
            {
                return this.fatherImageId;
            }
            set
            {
                this.fatherImageId = value;
            }
        }
    }
}
