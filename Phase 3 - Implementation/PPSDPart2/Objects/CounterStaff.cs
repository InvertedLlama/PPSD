using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPSDPart2.Objects
{
    class CounterStaff : User
    {
        //User permission settings, static, class bound
        private static bool READ = true,
                            CREATE = true,
                            MODIFY = true,
                            DELETE = false;

        public CounterStaff(string strName, string strUsername, string strPassword)
            : base(strName, strUsername, strPassword, UserAccessLevel.Instructor)
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
