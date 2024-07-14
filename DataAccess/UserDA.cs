namespace DeliManager.DataAccess
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using DeliManager.Common;
    using DeliManager.Models.Base;
    using DeliManager.Models;
    using static DeliManager.Common.CommonConst;
    using Org.BouncyCastle.Bcpg;

    public class UserDA : BaseDA
    {
        //Check this user already have on DB
        public bool HasDuplicatedUserDA(string LoginPhone)
        {
            var sqlCheck = new StringBuilder();
            sqlCheck.AppendLine("SELECT count(*) from [User]");
            sqlCheck.AppendLine("WHERE");
            sqlCheck.AppendFormat(" LoginPhone = '{0}'", LoginPhone);

            return (int)DataBase.ExecuteScalar(sqlCheck.ToString()) != 0;
        }

        //Create new user on "User" table
        public ResultStatus CreateUserDA(BaseTB_UserEntity userEntityInfo, string createdBy)
        {
            ResultStatus result = new ResultStatus();
            var userBaseTB = new BaseTB_User();

            userEntityInfo.CreatedBy = createdBy;
          
            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampCreated(userEntityInfo, userEntityInfo.CreatedBy);
                //Add User into User Table
                int Id = userBaseTB.CreateUserQuery(con, tran, userEntityInfo);
                if (Id != 0)
                {
                    result.Data = Id;
                    result.Status = true;
                    result.Message = "Successfully to create new user";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to create new user";
                }
            }
            catch (Exception exp)
            {
                tran.Rollback();
                result.Status = false;
                result.Message = exp.Message;
            }
            return result;
        }

        //Create user's role on "UserRole" table
        public ResultStatus CreateUserRoleDA(int userId, string userName, string createdBy)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_UserRole userRoleBaseTB = new BaseTB_UserRole();
            BaseTB_UserRoleEntity userRoleEntity = new BaseTB_UserRoleEntity();

            if (createdBy != null)
                userName = createdBy;

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {

                this.StampCreated(userRoleEntity, userName);
                userRoleBaseTB.CreateUserRoleQuery(con, tran, userRoleEntity, userId);
                result.Status = true;
                result.Message = "Successfully to create new userRole";
                tran.Commit();
            }
            catch (Exception exp)
            {
                tran.Rollback();
                result.Status = false;
                result.Message = exp.Message;
            }
            return result;
        }

        //Get all data of user info
        public BaseTB_UserEntity GetAllUserInfoDA(int userId)
        {
            BaseTB_User userBaseTB = new BaseTB_User();

            return userBaseTB.GetAllUserInfo(userId);
        }

        public int GetUserIdDA(string LoginPhone)
        {
            ResultStatus result = new ResultStatus();
            var sqlCheck = new StringBuilder();
            sqlCheck.AppendLine("SELECT UserId from [User]");
            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat("LoginPhone = '{0}' AND IsActive = 1", LoginPhone);

            result.Data = DataBase.ExecuteScalar(sqlCheck.ToString());
            return result.Data;
        }

    }
}
