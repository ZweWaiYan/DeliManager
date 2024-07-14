namespace DeliManager.Models.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Text;
    using DeliManager.Models.Base;
    using DeliManager.Common;
    using Google.Protobuf.Collections;

    public class BaseTB_Deliveryman : BaseTB_DeliverymanEntity
    {

        #region "Get All Data"        
        public virtual List<BaseTB_DeliverymanEntity> FetchDeliverymanQuery(int? companyId)
        {
            var list = new List<BaseTB_DeliverymanEntity>();
            var dt = this.GetDeliverymanData(companyId);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_DeliverymanEntity();
                this.SetDeliverymanData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region "Get Delivery Column"
        public virtual List<string> GetDeliverymanColumnQuery()
        {
            var list = new List<string>();
           var dt = this.GetDeliverymanColumn();
             for (var i = 0; i < dt.Rows.Count - 5; i++)
            {
                var row = dt.Rows[i];                
                list.Add(row.ItemArray[0].ToString());
            }
            return list;
        }
        #endregion

        #region "Insert Data"
        public virtual int CreateDeliverymanQuery(DbConnection con, DbTransaction tran, BaseTB_DeliverymanEntity srcClass = null)
        {
            srcClass ??= this;

            var columnList = new List<string>();
            var paramList = new List<string>();
            if (!srcClass.IsDeliverymanIdNull())
            {
                columnList.Add("DeliverymanId");
                paramList.Add("@DeliverymanId");
            }
            if (!srcClass.IsDeliverymanNameNull())
            {
                columnList.Add("DeliverymanName");
                paramList.Add("@DeliverymanName");
            }
            if (!srcClass.IsDeliverymanPhNull())
            {
                columnList.Add("DeliverymanPh");
                paramList.Add("@DeliverymanPh");
            }
            if (!srcClass.IsDeliverymanAddressNull())
            {
                columnList.Add("DeliverymanAddress");
                paramList.Add("@DeliverymanAddress");
            }
            if (!srcClass.IsDeliverymanNRCNull())
            {
                columnList.Add("DeliverymanNRC");
                paramList.Add("@DeliverymanNRC");
            }
            if (!srcClass.IsDeliverymanImageNull())
            {
                columnList.Add("DeliverymanImage");
                paramList.Add("@DeliverymanImage");
            }
            if (!srcClass.IsDeliverymanAgeNull())
            {
                columnList.Add("DeliverymanAge");
                paramList.Add("@DeliverymanAge");
            }
            if (!srcClass.IsCompanyIdNull())
            {
                columnList.Add("CompanyId");
                paramList.Add("@CompanyId");
            }
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
                columnList.Add("Updatedby");
                paramList.Add("@Updatedby");
            }
            if (!srcClass.IsUpdatedDateNull())
            {
                columnList.Add("UpdatedDate");
                paramList.Add("@UpdatedDate");
            }

            var sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO [Deliveryman] ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, columnList));
            sql.AppendLine(" ) ");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, paramList));
            sql.AppendLine(" ); ");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Update Data"
        public virtual int EditDeliverymanQuery( DbConnection con, DbTransaction tran, BaseTB_DeliverymanEntity srcClass = null)
        {
            srcClass ??= this;

            var setList = new List<string>();

            if (!srcClass.IsDeliverymanNameNull())
            {
                setList.Add("DeliverymanName = @DeliverymanName");
            }
            if (!srcClass.IsDeliverymanPhNull())
            {
                setList.Add("DeliverymanPh = @DeliverymanPh");
            }
            if (!srcClass.IsDeliverymanAddressNull())
            {
                setList.Add("DeliverymanAddress = @DeliverymanAddress");
            }
            if (!srcClass.IsDeliverymanNRCNull())
            {
                setList.Add("DeliverymanNRC = @DeliverymanNRC");
            }
            if (!srcClass.IsDeliverymanImageNull())
            {
                setList.Add("DeliverymanImage = @DeliverymanImage");
            }
            if (!srcClass.IsDeliverymanAgeNull())
            {
                setList.Add("DeliverymanAge = @DeliverymanAge");
            }
            if (!srcClass.IsCompanyIdNull())
            {
                setList.Add("CompanyId = @CompanyId");
            }
            if (!srcClass.IsCreatedByNull())
            {
                setList.Add("CreatedBy = @CreatedBy");
            }
            if (!srcClass.IsCreatedDateNull())
            {
                setList.Add("CreatedDate = @CreatedDate");
            }
            if (!srcClass.IsUpdatedByNull())
            {
                setList.Add("UpdatedBy = @UpdatedBy");
            }
            if (!srcClass.IsUpdatedDateNull())
            {
                setList.Add("UpdatedDate = @UpdatedDate");
            }


            var sql = new StringBuilder();
            sql.AppendLine(" UPDATE ");
            sql.AppendLine(" [Deliveryman] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine(" DeliverymanId = @DeliverymanId");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Delete Data"
        public virtual int DeleteDeliverymanQuery( DbConnection con, DbTransaction tran, BaseTB_DeliverymanEntity srcClass = null)
        {
             srcClass ??= this;

            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [Deliveryman] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("  DeliverymanId = @DeliverymanId ");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Parameter functions

        private QueryParamList GetParameter(BaseTB_DeliverymanEntity srcClass)
        {

            var param = new QueryParamList
            {
                { "@DeliverymanId", srcClass.DeliverymanId },
                { "@DeliverymanName", srcClass.DeliverymanName },
                { "@DeliverymanPh", srcClass.DeliverymanPh },
                { "@DeliverymanAddress", srcClass.DeliverymanAddress },
                { "@DeliverymanNRC", srcClass.DeliverymanNRC },
                { "@DeliverymanImage", srcClass.DeliverymanImage == "" ? null : srcClass.DeliverymanImage},
                { "@DeliverymanAge", srcClass.DeliverymanAge == 0 ? null : srcClass.DeliverymanAge },
                { "@CompanyId", srcClass.CompanyId },
                { "@Createdby", srcClass.CreatedBy },
                { "@CreatedDate", srcClass.CreatedDate },
                { "@Updatedby", srcClass.UpdatedBy },
                { "@UpdatedDate", srcClass.UpdatedDate }
            };
           
            return param;
        }

          public virtual int GetCountDeliverymanQuery(int? companyId)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT ");
            sql.AppendLine("   COUNT(1) ");
            sql.AppendLine(" FROM ");
            sql.AppendLine(" [Deliveryman] ");
            sql.AppendFormat(" WHERE CompanyId = {0} ", companyId);            
            return (int)DataBase.ExecuteScalar(sql.ToString());
        }


        public virtual DataTable GetDeliverymanColumn()
        {            
            var sql = new StringBuilder();
            sql.AppendLine("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('Deliveryman')");                           
            return DataBase.ExecuteAdapter(sql.ToString());
        }

        public virtual DataTable GetDeliverymanData(int? companyId)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT ");
            sql.AppendLine(" * FROM ");
            sql.AppendLine(" [Deliveryman]");
            sql.AppendFormat(" WHERE [Deliveryman].CompanyId = {0} ", companyId);           
            return DataBase.ExecuteAdapter(sql.ToString());
        }

         public virtual void SetDeliverymanData(
          BaseTB_DeliverymanEntity targetClass,
          DataRow row)
        {
            targetClass.DeliverymanId = NullableValueExtension.DBNullToIntegerZero(row["DeliverymanId"]);
            targetClass.DeliverymanName = row["DeliverymanName"].ToString();
            targetClass.DeliverymanPh = row["DeliverymanPh"].ToString();
            targetClass.DeliverymanAddress = row["DeliverymanAddress"].ToString();
            targetClass.DeliverymanNRC = row["DeliverymanNRC"].ToString();
            targetClass.DeliverymanImage = row["DeliverymanImage"].ToString();
            targetClass.DeliverymanAge = NullableValueExtension.DBNullToIntegerZero(row["DeliverymanAge"]);
            targetClass.CompanyId = NullableValueExtension.DBNullToIntegerZero(row["CompanyId"]);
            targetClass.CreatedDate = NullableValueExtension.ToForceDateTime(row["CreatedDate"].ToString());
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            targetClass.UpdatedDate = NullableValueExtension.ToForceDateTime(row["UpdatedDate"].ToString());
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }

          public bool HasDuplicatedDeliveryman(String phNo, int? companyId)
        {
            var sqlCheck = new StringBuilder();
            sqlCheck.AppendLine("SELECT count(*) from [Deliveryman]");
            sqlCheck.AppendLine("WHERE");
            sqlCheck.AppendFormat(" DeliverymanPh = '{0}'", phNo);
            if (companyId != 0)
            {
                sqlCheck.AppendFormat("AND CompanyId = '{0}'", companyId);
            }

            return (int)DataBase.ExecuteScalar(sqlCheck.ToString()) != 0;
        }
    }
}
