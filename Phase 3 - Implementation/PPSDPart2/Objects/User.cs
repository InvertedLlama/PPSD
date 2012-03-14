using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPSDPart2.Objects
{
    public enum UserAccessLevel
    {
        Admin, Owner, Instructor, CounterStaff
    }

    public class User
    {
        //User permission settings, static, class bound
        private static bool READ = false,
                            CREATE = false,
                            MODIFY = false,
                             DELETE = false;


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

        public virtual bool canRead
        {
            get { return READ;}
        }

        public virtual bool canCreate
        {
            get { return CREATE; }
        }

        public virtual bool canModify
        {
            get { return MODIFY; }
        }

        public virtual bool canDelete
        {
            get { return DELETE; }
        }

    }
}
