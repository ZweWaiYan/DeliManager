using DeliManager.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DeliManager.Models.Base
{
    public class BaseTB_UserRole : BaseTB_UserRoleEntity
    {
        public virtual object CreateUserRoleQuery(DbConnection con, DbTransaction tran, BaseTB_UserRoleEntity srcClass = null, int userId = 0)
        {
            srcClass ??= this;
            var columnList = new List<string>();
            var paramList = new List<string>();
            columnList.Add("UserId");
            paramList.Add("@UserId");
            columnList.Add("RoleId");
            paramList.Add("@RoleId");

            if (!srcClass.IsCreatedByNull())
            {
                columnList.Add("CreatedBy");
                paramList.Add("@CreatedBy");
            }

            if (!srcClass.IsCreatedDateNull())
            {
                columnList.Add("CreatedDate");
                paramList.Add("@CreatedDate");
            }

            if (!srcClass.IsUpdatedByNull())
            {
                columnList.Add("UpdatedBy");
                paramList.Add("@UpdatedBy");
            }

            if (!srcClass.IsUpdatedDateNull())
            {
                columnList.Add("UpdatedDate");
                paramList.Add("@UpdatedDate");
            }
            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [UserRole] ");
            sql.AppendLine(" ( ");
            sql.AppendLine(String.Join("," + Environment.NewLine, columnList));
            sql.AppendLine(" ) ");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" ( ");
            sql.AppendLine(String.Join("," + Environment.NewLine, paramList));
            sql.AppendLine(" ); ");           

            var param = this.GetRoleParam(srcClass, userId);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);

        }

          private QueryParamList GetRoleParam(BaseTB_UserRoleEntity srcClass , int userId)
        {
            QueryParamList param = new QueryParamList();
            param.Add("@UserId", userId);
            if(srcClass.RoleId == null){
                param.Add("@RoleId",2);
            }else{
                param.Add("@RoleId",srcClass.RoleId);
            }
            param.Add("@CreatedBy", srcClass.CreatedBy.ToNonNullable());
            param.Add("@CreatedDate", srcClass.CreatedDate);
            param.Add("@UpdatedBy", srcClass.UpdatedBy.ToNonNullable());
            param.Add("@UpdatedDate", srcClass.UpdatedDate);
            return param;
        }
    }
}
