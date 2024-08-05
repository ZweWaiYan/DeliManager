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

    public class BaseTB_Route : BaseTB_RouteEntity
    {

        #region "Get All Data"        
        public virtual List<BaseTB_RouteEntity> FetchRouteQuery(int? companyId)
        {
            var list = new List<BaseTB_RouteEntity>();
            var dt = this.GetRouteData(companyId);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_RouteEntity();
                this.SetRouteData(entity, row, 0);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region "Get Route Column"
        public virtual List<string> GetRouteColumnQuery()
        {
            var list = new List<string>();
            var dt = this.GetRouteColumn();
            for (var i = 0; i < dt.Rows.Count - 5; i++)
            {
                var row = dt.Rows[i];
                list.Add(row.ItemArray[0].ToString());
            }
            return list;
        }
        #endregion

        #region "Insert Data"
        public virtual int CreateRouteQuery(DbConnection con, DbTransaction tran, BaseTB_RouteEntity srcClass = null)
        {
            srcClass ??= this;

            var columnList = new List<string>();
            var paramList = new List<string>();
            if (!srcClass.IsRouteIdNull())
            {
                columnList.Add("RouteId");
                paramList.Add("@RouteId");
            }
            if (!srcClass.IsDeliverymanNameNull())
            {
                columnList.Add("DeliverymanName");
                paramList.Add("@DeliverymanName");
            }
            if (!srcClass.IsDeliverymanIdNull())
            {
                columnList.Add("DeliverymanId");
                paramList.Add("@DeliverymanId");
            }
            if (!srcClass.IsVehicleLicensePlateNull())
            {
                columnList.Add("VehicleLicensePlate");
                paramList.Add("@VehicleLicensePlate");
            }
            if (!srcClass.IsVehicleIdNull())
            {
                columnList.Add("VehicleId");
                paramList.Add("@VehicleId");
            }
            if (!srcClass.IsPackageIdNull())
            {
                columnList.Add("PackageId");
                paramList.Add("@PackageId");
            }
            if (!srcClass.IsPackageTotalNull())
            {
                columnList.Add("PackageTotal");
                paramList.Add("@PackageTotal");
            }
            if (!srcClass.IsRouteRemainQtyNull())
            {
                columnList.Add("RouteRemainQty");
                paramList.Add("@RouteRemainQty");
            }
            if (!srcClass.IsRouteStatusNull())
            {
                columnList.Add("RouteStatus");
                paramList.Add("@RouteStatus");
            }
            if (!srcClass.IsRouteTownshipNull())
            {
                columnList.Add("RouteTownship");
                paramList.Add("@RouteTownship");
            }
            if (!srcClass.IsTotalPackagePriceNull())
            {
                columnList.Add("TotalPackagePrice");
                paramList.Add("@TotalPackagePrice");
            }
            if (!srcClass.IsTotalDeliFeeNull())
            {
                columnList.Add("TotalDeliFee");
                paramList.Add("@TotalDeliFee");
            }
            if (!srcClass.IsTotalCollectMoneyNull())
            {
                columnList.Add("TotalCollectMoney");
                paramList.Add("@TotalCollectMoney");
            }
            if (!srcClass.IsStartDateNull())
            {
                columnList.Add("StartDate");
                paramList.Add("@StartDate");
            }
            if (!srcClass.IsStartTimeNull())
            {
                columnList.Add("StartTime");
                paramList.Add("@StartTime");
            }
            if (!srcClass.IsFinishDateNull())
            {
                columnList.Add("FinishDate");
                paramList.Add("@FinishDate");
            }
            if (!srcClass.IsFinishTimeNull())
            {
                columnList.Add("FinishTime");
                paramList.Add("@FinishTime");
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
            sql.AppendLine(" INSERT INTO [Route] ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, columnList));
            sql.AppendLine(" ) ");
            sql.AppendLine(" VALUES ");
            sql.AppendLine(" ( ");
            sql.AppendLine(string.Join("," + Environment.NewLine, paramList));
            sql.AppendLine(" ); ");
            sql.AppendLine(" SELECT [Route].RouteId AS LastID FROM [Route] WHERE [Route].RouteId = @@Identity; ");

            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteScalar(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Update Data"
        public virtual int EditRouteQuery(DbConnection con, DbTransaction tran, BaseTB_RouteEntity srcClass = null)
        {
            srcClass ??= this;

            var setList = new List<string>();

            if (!srcClass.IsDeliverymanNameNull())
            {
                setList.Add("DeliverymanName = @DeliverymanName");
            }
            if (!srcClass.IsDeliverymanIdNull())
            {
                setList.Add("DeliverymanId = @DeliverymanId");
            }
            if (!srcClass.IsVehicleLicensePlateNull())
            {
                setList.Add("VehicleLicensePlate = @VehicleLicensePlate");
            }
            if (!srcClass.IsVehicleIdNull())
            {
                setList.Add("VehicleId = @VehicleId");
            }
            if (!srcClass.IsPackageIdNull())
            {
                setList.Add("PackageId = @PackageId");
            }
            if (!srcClass.IsPackageTotalNull())
            {
                setList.Add("PackageTotal = @PackageTotal");
            }
            if (!srcClass.IsRouteRemainQtyNull())
            {
                setList.Add("RouteRemainQty = @RouteRemainQty");
            }
            if (!srcClass.IsRouteStatusNull())
            {
                setList.Add("RouteStatus = @RouteStatus");
            }
            if (!srcClass.IsRouteTownshipNull())
            {
                setList.Add("RouteTownship = @RouteTownship");
            }
            if (!srcClass.IsTotalPackagePriceNull())
            {
                setList.Add("TotalPackagePrice = @TotalPackagePrice");
            }
            if (!srcClass.IsTotalDeliFeeNull())
            {
                setList.Add("TotalDeliFee = @TotalDeliFee");
            }
            if (!srcClass.IsTotalCollectMoneyNull())
            {
                setList.Add("TotalCollectMoney = @TotalCollectMoney");
            }
            if (!srcClass.IsStartDateNull())
            {
                setList.Add("StartDate = @StartDate");
            }
            if (!srcClass.IsStartTimeNull())
            {
                setList.Add("StartTime = @StartTime");
            }
            if (!srcClass.IsFinishDateNull())
            {
                setList.Add("FinishDate = @FinishDate");
            }
            if (!srcClass.IsFinishTimeNull())
            {
                setList.Add("FinishTime = @FinishTime");
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
            sql.AppendLine(" [Route] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine(" RouteId = @RouteId");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Delete Data"
        public virtual int DeleteRouteQuery(DbConnection con, DbTransaction tran, BaseTB_RouteEntity srcClass = null)
        {
            srcClass ??= this;

            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [Route] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("  RouteId = @RouteId ");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Parameter functions

        private QueryParamList GetParameter(BaseTB_RouteEntity srcClass)
        {

            var param = new QueryParamList
            {
                { "@RouteId", srcClass.RouteId },
                { "@DeliverymanName", srcClass.DeliverymanName },
                { "@DeliverymanId", srcClass.DeliverymanId },
                { "@VehicleLicensePlate", srcClass.VehicleLicensePlate },
                { "@VehicleId", srcClass.VehicleId },
                { "@PackageId", srcClass.PackageId },
                { "@PackageTotal", srcClass.PackageTotal },
                { "@RouteRemainQty", srcClass.RouteRemainQty },
                { "@RouteStatus", srcClass.RouteStatus },
                { "@RouteTownship", srcClass.RouteTownship },
                { "@TotalPackagePrice", srcClass.TotalPackagePrice },
                { "@TotalDeliFee", srcClass.TotalDeliFee },
                { "@TotalCollectMoney", srcClass.TotalCollectMoney },
                { "@StartDate", srcClass.StartDate },
                { "@StartTime", srcClass.StartTime },
                { "@FinishDate", srcClass.FinishDate },
                { "@FinishTime", srcClass.FinishTime },
                { "@CompanyId", srcClass.CompanyId },
                { "@Createdby", srcClass.CreatedBy },
                { "@CreatedDate", srcClass.CreatedDate },
                { "@Updatedby", srcClass.UpdatedBy },
                { "@UpdatedDate", srcClass.UpdatedDate }
            };

            return param;
        }

        public virtual int GetCountRouteQuery(int? companyId)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT ");
            sql.AppendLine("   COUNT(1) ");
            sql.AppendLine(" FROM ");
            sql.AppendLine(" [Route] ");
            sql.AppendFormat(" WHERE CompanyId = {0} ", companyId);
            return (int)DataBase.ExecuteScalar(sql.ToString());
        }

        public virtual BaseTB_RouteEntity GetRouteDataQuery(int routeId)
        {
            var sql = new StringBuilder();
            sql.AppendFormat("SELECT RouteId, DeliverymanId, VehicleId , PackageId FROM [Route] where RouteId = '{0}'", routeId);
            var dt = DataBase.ExecuteAdapter(sql.ToString());
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                this.SetRouteData(this, row, 1);
            }
            return this;
        }


        public virtual DataTable GetRouteColumn()
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('Route')");
            return DataBase.ExecuteAdapter(sql.ToString());
        }

        public virtual DataTable GetRouteData(int? companyId)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT ");
            sql.AppendLine(" * FROM ");
            sql.AppendLine(" [Route]");
            sql.AppendFormat(" WHERE [Route].CompanyId = {0} ", companyId);
            return DataBase.ExecuteAdapter(sql.ToString());
        }

        public virtual void SetRouteData(
         BaseTB_RouteEntity targetClass,
         DataRow row,
         int funcType)
        {
            targetClass.RouteId = NullableValueExtension.DBNullToIntegerZero(row["RouteId"]);
            targetClass.DeliverymanId = NullableValueExtension.DBNullToIntegerZero(row["DeliverymanId"]);
            targetClass.VehicleId = NullableValueExtension.DBNullToIntegerZero(row["VehicleId"]);
            targetClass.PackageId = row["PackageId"].ToString();

            if (funcType == 0)
            {
                targetClass.DeliverymanName = row["DeliverymanName"].ToString();
                targetClass.VehicleLicensePlate = row["VehicleLicensePlate"].ToString();
                targetClass.PackageTotal = NullableValueExtension.DBNullToIntegerZero(row["PackageTotal"]);
                targetClass.RouteRemainQty = NullableValueExtension.DBNullToIntegerZero(row["RouteRemainQty"]);
                targetClass.RouteStatus = NullableValueExtension.DBNullToIntegerZero(row["RouteStatus"]);
                targetClass.RouteTownship = row["RouteTownship"].ToString();
                targetClass.TotalPackagePrice = NullableValueExtension.DBNullToIntegerZero(row["TotalPackagePrice"]);
                targetClass.TotalDeliFee = NullableValueExtension.DBNullToIntegerZero(row["TotalDeliFee"]);
                targetClass.TotalCollectMoney = NullableValueExtension.DBNullToIntegerZero(row["TotalCollectMoney"]);
                targetClass.StartDate = row["StartDate"].ToString();
                targetClass.StartTime = row["StartTime"].ToString();
                targetClass.FinishDate = row["FinishDate"].ToString();
                targetClass.FinishTime = row["FinishTime"].ToString();
                targetClass.CompanyId = NullableValueExtension.DBNullToIntegerZero(row["CompanyId"]);
                targetClass.CreatedDate = NullableValueExtension.ToForceDateTime(row["CreatedDate"].ToString());
                targetClass.CreatedBy = row["CreatedBy"].ToString();
                targetClass.UpdatedDate = NullableValueExtension.ToForceDateTime(row["UpdatedDate"].ToString());
                targetClass.UpdatedBy = row["UpdatedBy"].ToString();
            }
        }

        public bool HasDuplicatedRouteQuery(String township, int? companyId)
        {
            var sqlCheck = new StringBuilder();
            sqlCheck.AppendLine("SELECT count(*) from [Route]");
            sqlCheck.AppendLine("WHERE");
            sqlCheck.AppendFormat(" RouteTownship = '{0}'", township);
            if (companyId != 0)
            {
                sqlCheck.AppendFormat("AND CompanyId = '{0}'", companyId);
            }

            return (int)DataBase.ExecuteScalar(sqlCheck.ToString()) != 0;
        }
    }
}
