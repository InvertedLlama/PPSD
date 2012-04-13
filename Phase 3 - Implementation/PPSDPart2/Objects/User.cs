using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPSDPart2
{
    public enum UserAccessLevel
    {
        Admin, Owner, Instructor, CounterStaff, None
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

        public virtual bool canRead
        {
            get
            {
                switch (usrAccess)
                {
                    case UserAccessLevel.Admin:
                        return true;
                    case UserAccessLevel.CounterStaff:
                        return true;
                    case UserAccessLevel.Instructor:
                        return true;
                    case UserAccessLevel.Owner:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public virtual bool canCreate
        {
            get
            {
                switch (usrAccess)
                {
                    case UserAccessLevel.Admin:
                        return true;
                    case UserAccessLevel.CounterStaff:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public virtual bool canModify
        {
            get
            {
                switch (usrAccess)
                {
                    case UserAccessLevel.Admin:
                        return true;
                    case UserAccessLevel.CounterStaff:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public virtual bool canDelete
        {
            get
            {
                switch (usrAccess)
                {
                    case UserAccessLevel.Admin:
                        return true;
                    default:
                        return false;
                }
            }
        }

    }
}
