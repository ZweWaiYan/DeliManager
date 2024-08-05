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
            if (!srcClass.IsDeliverymanStatusNull())
            {
                columnList.Add("DeliverymanStatus");
                paramList.Add("@DeliverymanStatus");
            }
            if (!srcClass.IsDeliverymanLicenseNoNull())
            {
                columnList.Add("DeliverymanLicenseNo");
                paramList.Add("@DeliverymanLicenseNo");
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
            if (!srcClass.IsRouteIdNull())
            {
                columnList.Add("RouteId");
                paramList.Add("@RouteId");
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
        public virtual int EditDeliverymanQuery(DbConnection con, DbTransaction tran, BaseTB_DeliverymanEntity srcClass = null)
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
            if (!srcClass.IsDeliverymanStatusNull())
            {
                setList.Add("Status = @Status");
            }
            if (!srcClass.IsDeliverymanLicenseNoNull())
            {
                setList.Add("DeliverymanLicenseNo = @DeliverymanLicenseNo");
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
            if (!srcClass.IsRouteIdNull())
            {
                setList.Add("RouteId = @RouteId");
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
        public virtual int DeleteDeliverymanQuery(DbConnection con, DbTransaction tran, BaseTB_DeliverymanEntity srcClass = null)
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
                { "@DeliverymanStatus", srcClass.DeliverymanStatus},
                { "@DeliverymanLicenseNo", srcClass.DeliverymanLicenseNo },
                { "@DeliverymanNRC", srcClass.DeliverymanNRC },
                { "@DeliverymanImage", srcClass.DeliverymanImage == "" ? null : srcClass.DeliverymanImage},
                { "@DeliverymanAge", srcClass.DeliverymanAge == 0 ? null : srcClass.DeliverymanAge },
                { "@RouteId", srcClass.RouteId },
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


        #region "Update Deliveryman Status and RouteId"
        public virtual int UpdateDeliverymanStatusQuery(int? routeId, int deliverymanId, int deliverymanStatus)
        {
            var sqlCheck = new StringBuilder();
            using var con = DataBase.GetConnection();
            sqlCheck.AppendLine(" UPDATE [Deliveryman] ");
            sqlCheck.AppendFormat(" SET DeliverymanStatus = '{0}' , RouteId = '{1}'", deliverymanStatus, routeId);
            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat("  DeliverymanId = '{0}'", deliverymanId);

            var result = DataBase.ExecuteNonQuery(con, sqlCheck.ToString());
            return result;
        }
        #endregion

        #region "Update Deliveryman Status and RouteId with Case for only Editing"
        public virtual int UpdateDeliverymanStatusWithCaseQuery(int routeId, int deliverymanId, int vehicleId, string packageIds)
        {
            var sqlCheck = new StringBuilder();
            using var con = DataBase.GetConnection();

            // sqlCheck.AppendLine("UPDATE [Deliveryman] SET ");
            // sqlCheck.AppendLine("  DeliverymanStatus = CASE ");
            // sqlCheck.AppendFormat(" WHEN RouteId = '{0}' THEN 1 " , routeId);
            // sqlCheck.AppendFormat(" WHEN DeliverymanId = '{0}' THEN 2 ", deliverymanId);
            // sqlCheck.AppendLine(" ELSE DeliverymanStatus ");
            // sqlCheck.AppendLine(" END , ");

            // sqlCheck.AppendLine(" RouteId = CASE ");
            // sqlCheck.AppendFormat(" WHEN RouteId = '{0}' AND DeliverymanId != '{1}' THEN 0 " , routeId , deliverymanId);
            // sqlCheck.AppendFormat(" WHEN DeliverymanId = '{0}' THEN {1} ", deliverymanId , routeId);
            // sqlCheck.AppendLine(" ELSE RouteId ");
            // sqlCheck.AppendLine(" END ");

            // sqlCheck.AppendLine(" WHERE ");
            // sqlCheck.AppendFormat("  RouteId = '{0}' OR DeliverymanId = '{1}' ", routeId, deliverymanId);

            var packageIdArray = packageIds.Split(',');
            var validPackageIds = new List<int>();
            foreach (var id in packageIdArray)
            {
                if (int.TryParse(id, out int packageId))
                {
                    validPackageIds.Add(packageId);
                }
                else
                {
                    throw new ArgumentException($"Invalid package ID: {id}");
                }
            }

            if (validPackageIds.Count == 0)
            {
                return 0;
            }

            //Update Deliveryman table
            sqlCheck.AppendLine("UPDATE [Deliveryman] SET ");
            sqlCheck.AppendLine("  DeliverymanStatus = CASE ");
            sqlCheck.AppendFormat(" WHEN DeliverymanId = {0} THEN 2 ", deliverymanId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 1 ", routeId);
            sqlCheck.AppendLine(" END , ");

            sqlCheck.AppendLine(" RouteId = CASE ");
            sqlCheck.AppendFormat(" WHEN DeliverymanId = {0} THEN {1} ", deliverymanId, routeId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 0 ", routeId);
            sqlCheck.AppendLine(" END ");

            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat(" RouteId = {0} OR DeliverymanId = {1}; ", routeId, deliverymanId);

            //Update Vehicle table
            sqlCheck.AppendLine("UPDATE [Vehicle] SET ");
            sqlCheck.AppendLine("  DeliverymanId = CASE ");
            sqlCheck.AppendFormat(" WHEN VehicleId = {0} THEN {1} ", vehicleId, deliverymanId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 0 ", routeId);
            sqlCheck.AppendLine(" END , ");

            sqlCheck.AppendLine(" VehicleStatus = CASE ");
            sqlCheck.AppendFormat(" WHEN VehicleId = {0} THEN 2 ", vehicleId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 1 ", routeId);
            sqlCheck.AppendLine(" END , ");

            sqlCheck.AppendLine(" RouteId = CASE ");
            sqlCheck.AppendFormat(" WHEN VehicleId = {0} THEN {1} ", vehicleId, routeId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 0 ", routeId);
            sqlCheck.AppendLine(" END ");

            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat(" RouteId = {0} OR VehicleId = {1}; ", routeId, vehicleId);

            // -- Update Package table
            sqlCheck.AppendLine("UPDATE [Package] SET ");
            sqlCheck.AppendLine("  DeliverymanId = CASE ");
            sqlCheck.AppendFormat(" WHEN PackageId IN ({0}) THEN {1} ", string.Join(",", validPackageIds), deliverymanId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 0 ", routeId);
            sqlCheck.AppendLine(" END ,");

            sqlCheck.AppendLine(" PackageWayProcess = CASE ");
            sqlCheck.AppendFormat(" WHEN PackageId IN ({0}) THEN 4 ", string.Join(",", validPackageIds));
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 1 ", routeId);
            sqlCheck.AppendLine(" END ,");

            sqlCheck.AppendLine(" RouteId = CASE ");
            sqlCheck.AppendFormat(" WHEN PackageId IN ({0}) THEN {1} ", string.Join(",", validPackageIds), routeId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 0 ", routeId);
            sqlCheck.AppendLine(" END ");

            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat(" RouteId = {0} OR PackageId IN ({1}); ", routeId, string.Join(",", validPackageIds));

            var result = DataBase.ExecuteNonQuery(con, sqlCheck.ToString());
            return result;
        }
        #endregion


        public virtual void SetDeliverymanData(
         BaseTB_DeliverymanEntity targetClass,
         DataRow row)
        {
            targetClass.DeliverymanId = NullableValueExtension.DBNullToIntegerZero(row["DeliverymanId"]);
            targetClass.DeliverymanName = row["DeliverymanName"].ToString();
            targetClass.DeliverymanPh = row["DeliverymanPh"].ToString();
            targetClass.DeliverymanStatus = NullableValueExtension.DBNullToIntegerZero(row["DeliverymanStatus"]);
            targetClass.DeliverymanAddress = row["DeliverymanAddress"].ToString();
            targetClass.DeliverymanLicenseNo = row["DeliverymanLicenseNo"].ToString();
            targetClass.DeliverymanNRC = row["DeliverymanNRC"].ToString();
            targetClass.DeliverymanImage = row["DeliverymanImage"].ToString();
            targetClass.DeliverymanAge = NullableValueExtension.DBNullToIntegerZero(row["DeliverymanAge"]);
            targetClass.RouteId = NullableValueExtension.DBNullToIntegerZero(row["RouteId"]);
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
