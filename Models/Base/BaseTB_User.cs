namespace DeliManager.Models.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Text;
    using DeliManager.Common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualBasic;

    public class BaseTB_User : BaseTB_UserEntity
    {
        //Create new user on "User" table
        public virtual int CreateUserQuery(DbConnection con, DbTransaction tran, BaseTB_UserEntity srcClass = null)
        {
            if (srcClass == null)
            {
                srcClass = this;
            }
            var columnList = new List<string>();
            var paramList = new List<string>();

            if (!srcClass.IsUserNameNull()) { columnList.Add("UserName"); paramList.Add("@UserName"); }
            if (!srcClass.IsLoginPhoneNull()) { columnList.Add("LoginPhone"); paramList.Add("@LoginPhone"); }
            if (!srcClass.IsLoginPhoneNull()) { columnList.Add("LoginPhone"); paramList.Add("@LoginPhone"); }
            columnList.Add("IsActive"); paramList.Add("@IsActive");
            // if (!srcClass.IsCompanyId()) { columnList.Add("CompanyId"); paramList.Add("@CompanyId"); }
            if (!srcClass.IsCreatedByNull()) { columnList.Add("CreatedBy"); paramList.Add("@CreatedBy"); }
            if (!srcClass.IsCreatedDateNull()) { columnList.Add("CreatedDate"); paramList.Add("@CreatedDate"); }
            // if (!srcClass.IsUpdatedByNull()) { columnList.Add("UpdatedBy"); paramList.Add("@UpdatedBy"); }
            // if (!srcClass.IsUpdatedDateNull()) { columnList.Add("UpdatedDate"); paramList.Add("@UpdatedDate"); }

            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [User] ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, columnList));
            sql.AppendLine(" ) ");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, paramList));
            sql.AppendLine(" ); ");
            sql.AppendLine(" SELECT UserId AS LastID FROM [User] WHERE UserId = @@Identity; ");

            var param = this.GetParameter(srcClass);
            return (int)DataBase.ExecuteScalar(con, sql.ToString(), param, tran);
        }

        //Get All User Info
        public virtual BaseTB_UserEntity GetAllUserInfo(int userId)
        {
            var whereParam = new Dictionary<string, object>();
            var whereString = new StringBuilder();

            whereParam["@UserId"] = userId;

            whereString.AppendLine("[User].UserId = @UserId");

            var dt = this.GetUserData(whereString.ToString(), whereParam);
            if(dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetUserData(this , row);
            }
            return this;
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Parameter functions

        //For DataInsert's func
        private QueryParamList GetParameter(BaseTB_UserEntity srcClass)
        {
            var param = new QueryParamList
            {
                { "@UserName", srcClass.UserName },
                { "@LoginPhone", srcClass.LoginPhone },
                { "@LoginPhone", srcClass.LoginPhone },
                { "@IsActive" , true },
                // { "@CompanyId", srcClass.CompanyId },
                { "@CreatedBy", srcClass.CreatedBy },
                { "@CreatedDate", srcClass.CreatedDate },
                // { "@UpdatedBy", srcClass.UpdatedBy },
                // { "@UpdatedDate", srcClass.UpdatedDate }
            };
            return param;

        }

        //For GetAllUserInfo's func
        public virtual DataTable GetUserData(string whereString, Dictionary<string, object> whereParam)
        {
            var sql = new StringBuilder();            
            sql.AppendLine(" SELECT * FROM [USER] ");            
            var param = new QueryParamList();
            if(!string.IsNullOrEmpty(whereString))
            {
                sql.AppendLine(" WHERE ");
                sql.AppendLine(whereString);
                foreach( var key in whereParam.Keys)
                {
                    object value = whereParam[key];

                    param.Add(key , value);
                }
            }

            return DataBase.ExecuteAdapter(sql.ToString() , param);

        }

        //For GetAllUserInfo's func
        public virtual void SetUserData( BaseTB_UserEntity targetClass , DataRow row)
        {
            targetClass.UserId = NullableValueExtension.DBNullToIntegerZero(row["UserId"]);
            targetClass.UserName = row["UserName"].ToString();
            targetClass.LoginPhone = row["LoginPhone"].ToString();
            targetClass.LoginPassword = row["LoginPassword"].ToString();
            targetClass.CompanyId = NullableValueExtension.DBNullToIntegerZero(row["CompanyId"]);
            // targetClass.RoleId = NullableValueExtension.DBNullToIntegerZero(row["RoleId"]);
            // targetClass.RoleName = row["RoleName"].ToString();
        }
    }
}
