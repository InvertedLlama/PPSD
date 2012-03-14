using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPSDPart2.Objects
{
    class Owner : User
    {
        //User permission settings, static, class bound
        private static bool READ = true,
                            CREATE = false,
                            MODIFY = false,
                            DELETE = false;

        public Owner(string strName, string strUsername, string strPassword) 
            : base(strName, strUsername, strPassword, UserAccessLevel.Owner)
        {
        }

        public override bool canRead
        {
            get { return READ; }
        }

        public override bool canCreate
        {
            get { return CREATE; }
        }

        public override bool canModify
        {
            get { return MODIFY; }
        }

        public override bool canDelete
        {
            get { return DELETE; }
        }
    }
}
