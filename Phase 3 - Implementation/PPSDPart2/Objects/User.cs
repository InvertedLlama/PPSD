using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPSDPart2.Objects
{
    public enum UserAccessLevel
    {
        Admin, Instructor
    }

    public class User
    {
        string strName;
        string strUsername;
        string strPassword;
        UserAccessLevel usrAccess;

        public User(string strName, string strUsername, string strPassword, UserAccessLevel usrAccess)
        {
            this.strName = strName;
            this.strUsername = strUsername;
            this.strPassword = strPassword;
            this.usrAccess = usrAccess;
        }


        //Properties
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        public string Username
        {
            get { return strUsername; }
            set { strUsername = value; }
        }

        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        public UserAccessLevel AccessLevel
        {
            get { return usrAccess; }
            set { usrAccess = value; }
        }
    }
}
