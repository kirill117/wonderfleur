using System;
using System.Collections.Generic;
using System.Web;
using Custom;

namespace Custom
{
    [Serializable]
    public class User
    {
        protected Settings.UserMode mode;

        public User()
        {
            //this.mode = Settings.UserMode.Design;
            this.mode = Settings.UserMode.View;
        }

        public Settings.UserMode Mode
        {
            get { return this.mode; }
            set { this.mode = value; }
        }
    }
}