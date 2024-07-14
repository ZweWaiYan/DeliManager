using DeliManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Web;
using DeliManager.Models;
using Newtonsoft.Json;
using System.Data.Common;

namespace DeliManager.DataAccess
{
    public class BaseDA
    {
        public static DbProviderFactory factory = null;
        public static string MainConnectionString = string.Empty;
        CurrentUser cUser = new CurrentUser();
        public virtual void StampCreated(object targetClass , string createby)
        {
            cUser = SessionManager.GetCurrentUser();
            CommonUtility.StampCreated(
                targetClass,
                DateTime.Now,
                cUser.UserName == "" ? createby : cUser.UserName//LoginInfo.UserId,
                );
        }
       
        public virtual void StampUpdated(object targetClass)
        {
            cUser = SessionManager.GetCurrentUser();
            CommonUtility.StampUpdated(
                targetClass,
                DateTime.Now,
                cUser.UserName//LoginInfo.UserId,
                );
        } 
    }
}
