using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DeliManager.Common
{
    public class CommonUtility
    {
        public static void StampCreated(object targetClass,
                                        DateTime createdDate,
                                        string createdBy)
        {
            PropertyInfo propCreatedDate = targetClass.GetType().GetProperty("CreatedDate");
            PropertyInfo propCreatedBy = targetClass.GetType().GetProperty("CreatedBy");

            propCreatedDate.SetValue(targetClass, createdDate);
            propCreatedBy.SetValue(targetClass, createdBy);
        }

        public static void StampUpdated(object targetClass,
                                        DateTime updatedDate,
                                        string updatedBy)
        {
            PropertyInfo propUpdatedDate = targetClass.GetType().GetProperty("UpdatedDate");
            PropertyInfo propUpdatedBy = targetClass.GetType().GetProperty("UpdatedBy");

            propUpdatedDate.SetValue(targetClass, updatedDate);
            propUpdatedBy.SetValue(targetClass, updatedBy);
        }
        //get sms's auth and url from appsettings.json 
        //get Short & Long App Name
        public static Dictionary<string,string> getSMSPohData(){
            Dictionary<string,string> data = new Dictionary<string, string>();
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            try
            {
                // String newData  = root.GetValue<string>("SMSDataAuth");
                data.Add("auth",root.GetValue<string>("SMSDataAuth"));
                data.Add("endPoint",root.GetValue<string>("SMSDataEndPoint"));
                data.Add("ShortAppName",root.GetValue<string>("ShortAppName"));
                data.Add("LongAppName",root.GetValue<string>("LongAppName"));
                // data["endPoint"] = root.GetValue<string>("SMSDataEndPoint");
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
            throw;
            }
                return data;
        }

        //get table name and userkey to upload what user is created this row in DB
        public static void SetOwner(object targetClass , int key){
            PropertyInfo propOwnerKey = targetClass.GetType().GetProperty("OwnerKey");
            propOwnerKey.SetValue(targetClass,key);
        }
    }
}
