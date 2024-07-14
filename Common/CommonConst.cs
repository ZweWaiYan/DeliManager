using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliManager.Common
{
    public static class CommonConst
    {
        public const int DEFAULT_MAX_SELECT_COUNT = 99;

        public enum UserType{
            MobileUser,
            WebUser,
            Admins
        }
    }
}
