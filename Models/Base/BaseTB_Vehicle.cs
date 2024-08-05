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

    public class BaseTB_Vehicle : BaseTB_VehicleEntity
    {

        #region "Get All Data"        
        public virtual List<BaseTB_VehicleEntity> FetchVehicleQuery(int? companyId)
        {
            var list = new List<BaseTB_VehicleEntity>();
            var dt = this.GetVehicleData(companyId);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_VehicleEntity();
                this.SetVehicleData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region "Get Vehicle Column"
        public virtual List<string> GetVehicleColumnQuery()
        {
            var list = new List<string>();
            var dt = this.GetVehicleColumn();
            for (var i = 0; i < dt.Rows.Count - 5; i++)
            {
                var row = dt.Rows[i];
                list.Add(row.ItemArray[0].ToString());
            }
            return list;
        }
        #endregion

        #region "Insert Data"
        public virtual int CreateVehicleQuery(DbConnection con, DbTransaction tran, BaseTB_VehicleEntity srcClass = null)
        {
            srcClass ??= this;

            var columnList = new List<string>();
            var paramList = new List<string>();
            if (!srcClass.IsVehicleIdNull())
            {
                columnList.Add("VehicleId");
                paramList.Add("@VehicleId");
            }
            if (!srcClass.IsLicensePlateNull())
            {
                columnList.Add("LicensePlate");
                paramList.Add("@LicensePlate");
            }
            if (!srcClass.IsModalNull())
            {
                columnList.Add("Modal");
                paramList.Add("@Modal");
            }
            if (!srcClass.IsManufacturerNull())
            {
                columnList.Add("Manufacturer");
                paramList.Add("@Manufacturer");
            }
            if (!srcClass.IsDeliverymanIdNull())
            {
                columnList.Add("DeliverymanId");
                paramList.Add("@DeliverymanId");
            }
            if (!srcClass.IsVehicleStatusNull())
            {
                columnList.Add("VehicleStatus");
                paramList.Add("@VehicleStatus");
            }
            if (!srcClass.IsCapacityNull())
            {
                columnList.Add("Capacity");
                paramList.Add("@Capacity");
            }
            if (!srcClass.IsInsuranceExpiryDateNull())
            {
                columnList.Add("InsuranceExpiryDate");
                paramList.Add("@InsuranceExpiryDate");
            }
            if (!srcClass.IsFuelLevelNull())
            {
                columnList.Add("FuelLevel");
                paramList.Add("@FuelLevel");
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
            sql.AppendLine(" INSERT INTO [Vehicle] ");
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
        public virtual int EditVehicleQuery(DbConnection con, DbTransaction tran, BaseTB_VehicleEntity srcClass = null)
        {
            srcClass ??= this;

            var setList = new List<string>();

            if (!srcClass.IsLicensePlateNull())
            {
                setList.Add("LicensePlate = @LicensePlate");
            }
            if (!srcClass.IsModalNull())
            {
                setList.Add("Modal = @Modal");
            }
            if (!srcClass.IsManufacturerNull())
            {
                setList.Add("Manufacturer = @Manufacturer");
            }
            if (!srcClass.IsDeliverymanIdNull())
            {
                setList.Add("DeliveryId = @DeliveryId");
            }
            if (!srcClass.IsVehicleStatusNull())
            {
                setList.Add("VehicleStatus = @VehicleStatus");
            }
            if (!srcClass.IsCapacityNull())
            {
                setList.Add("Capacity = @Capacity");
            }
            if (!srcClass.IsInsuranceExpiryDateNull())
            {
                setList.Add("InsuranceExpiryDate = @InsuranceExpiryDate");
            }
            if (!srcClass.IsFuelLevelNull())
            {
                setList.Add("FuelLevel = @FuelLevel");
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
            sql.AppendLine(" [Vehicle] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine(" VehicleId = @VehicleId");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Delete Data"
        public virtual int DeleteVehicleQuery(DbConnection con, DbTransaction tran, BaseTB_VehicleEntity srcClass = null)
        {
            srcClass ??= this;

            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [Vehicle] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("  VehicleId = @VehicleId ");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Update Vehicle Status , set RouteId and set DeliverymanId"
        public virtual int UpdateVehicleStatusQuery(int? routeId, int vehicleId, int deliverymanId, int vehicleStatus)
        {
            var sqlCheck = new StringBuilder();
            using var con = DataBase.GetConnection();

            sqlCheck.AppendLine(" UPDATE [Vehicle] ");
            sqlCheck.AppendFormat(" SET VehicleStatus = '{0}', RouteId = '{1}' , DeliverymanId = '{2}'", vehicleStatus, routeId, deliverymanId);
            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat("  VehicleId = '{0}'", vehicleId);

            var result = DataBase.ExecuteNonQuery(con, sqlCheck.ToString());
            return result;
        }
        #endregion

        #region "Update Vehicle Status and RouteId with Case for only Editing"
        public virtual int UpdateVehicleStatusWithCaseQuery(int routeId, int vehicleId, int deliverymanId)
        {
            var sqlCheck = new StringBuilder();
            using var con = DataBase.GetConnection();

            // sqlCheck.AppendLine("UPDATE [Vehicle] SET ");

            // sqlCheck.AppendLine(" DeliverymanId = CASE  ");
            // sqlCheck.AppendFormat(" WHEN RouteId = '{0}' AND VehicleId != '{1}' THEN 0", routeId, vehicleId);
            // sqlCheck.AppendFormat(" WHEN VehicleId = '{0}' THEN '{1}' ", vehicleId, deliverymanId);
            // sqlCheck.AppendLine(" ELSE DeliverymanId ");
            // sqlCheck.AppendLine(" END , ");

            // sqlCheck.AppendLine(" VehicleStatus = CASE ");
            // sqlCheck.AppendFormat(" WHEN RouteId = '{0}' THEN 1 ", routeId);
            // sqlCheck.AppendFormat(" WHEN VehicleId = '{0}' THEN 2 ", vehicleId);
            // sqlCheck.AppendLine(" ELSE VehicleStatus ");
            // sqlCheck.AppendLine(" END , ");


            // sqlCheck.AppendLine(" RouteId = CASE ");
            // sqlCheck.AppendFormat(" WHEN RouteId = '{0}' AND VehicleId != '{1}' THEN 0 ", routeId, vehicleId);
            // sqlCheck.AppendFormat(" WHEN VehicleId = '{0}' THEN {1} ", vehicleId, routeId);
            // sqlCheck.AppendLine(" ELSE RouteId ");
            // sqlCheck.AppendLine(" END ");

            // sqlCheck.AppendLine(" WHERE ");
            // sqlCheck.AppendFormat("  RouteId = '{0}' OR VehicleId = '{1}' ", routeId, vehicleId);                             
        
            sqlCheck.AppendLine("UPDATE [Vehicle] SET ");

            sqlCheck.AppendLine(" DeliverymanId = CASE  ");
            sqlCheck.AppendFormat("  WHEN VehicleId = {0} THEN {1} ", vehicleId , deliverymanId);
            sqlCheck.AppendFormat("  WHEN RouteId = {0} THEN 0 ", routeId);            
            sqlCheck.AppendLine(" END , ");

            sqlCheck.AppendLine(" VehicleStatus = CASE ");
            sqlCheck.AppendFormat(" WHEN VehicleId = {0} THEN 2  ", vehicleId);
            sqlCheck.AppendFormat("  WHEN RouteId = {0} THEN 1  ", routeId);            
            sqlCheck.AppendLine(" END , ");

            sqlCheck.AppendLine(" RouteId = CASE ");
            sqlCheck.AppendFormat(" WHEN VehicleId = {0} THEN {1} ", vehicleId , routeId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 0  ", routeId);            
            sqlCheck.AppendLine(" END ");

            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat("  RouteId = '{0}' OR VehicleId = '{1}' ", routeId, vehicleId);

            var result = DataBase.ExecuteNonQuery(con, sqlCheck.ToString());
            return result;
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Parameter functions

        private QueryParamList GetParameter(BaseTB_VehicleEntity srcClass)
        {

            var param = new QueryParamList
            {
                { "@VehicleId", srcClass.VehicleId},
                { "@LicensePlate", srcClass.LicensePlate },
                { "@Modal", srcClass.Modal },
                { "@Manufacturer", srcClass.Manufacturer },
                { "@DeliverymanId", srcClass.DeliverymanId },
                { "@VehicleStatus", srcClass.VehicleStatus },
                { "@Capacity", srcClass.Capacity },
                { "@InsuranceExpiryDate", srcClass.InsuranceExpiryDate },
                { "@FuelLevel", srcClass.FuelLevel },
                { "@RouteId", srcClass.RouteId },
                { "@CompanyId", srcClass.CompanyId },
                { "@Createdby", srcClass.CreatedBy },
                { "@CreatedDate", srcClass.CreatedDate },
                { "@Updatedby", srcClass.UpdatedBy },
                { "@UpdatedDate", srcClass.UpdatedDate }
            };

            return param;
        }

        public virtual int GetCountVehicleQuery(int? companyId)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT ");
            sql.AppendLine("   COUNT(1) ");
            sql.AppendLine(" FROM ");
            sql.AppendLine(" [Vehicle] ");
            sql.AppendFormat(" WHERE CompanyId = {0} ", companyId);
            return (int)DataBase.ExecuteScalar(sql.ToString());
        }


        public virtual DataTable GetVehicleColumn()
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('Vehicle')");
            return DataBase.ExecuteAdapter(sql.ToString());
        }

        public virtual DataTable GetVehicleData(int? companyId)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT ");
            sql.AppendLine(" * FROM ");
            sql.AppendLine(" [Vehicle]");
            sql.AppendFormat(" WHERE [Vehicle].CompanyId = {0} ", companyId);
            return DataBase.ExecuteAdapter(sql.ToString());
        }

        public virtual void SetVehicleData(
         BaseTB_VehicleEntity targetClass,
         DataRow row)
        {
            targetClass.VehicleId = NullableValueExtension.DBNullToIntegerZero(row["VehicleId"]);
            targetClass.LicensePlate = row["LicensePlate"].ToString();
            targetClass.Modal = row["Modal"].ToString();
            targetClass.Manufacturer = row["Manufacturer"].ToString();
            targetClass.DeliverymanId = NullableValueExtension.DBNullToIntegerZero(row["DeliverymanId"]);
            targetClass.VehicleStatus = NullableValueExtension.DBNullToIntegerZero(row["VehicleStatus"].ToString());
            targetClass.Capacity = NullableValueExtension.DBNullToIntegerZero(row["Capacity"]);
            targetClass.InsuranceExpiryDate = row["InsuranceExpiryDate"].ToString();
            targetClass.FuelLevel = NullableValueExtension.DBNullToDoubleZero(row["FuelLevel"].ToString());
            targetClass.RouteId = NullableValueExtension.DBNullToIntegerZero(row["RouteId"]);
            targetClass.CompanyId = NullableValueExtension.DBNullToIntegerZero(row["CompanyId"]);
            targetClass.CreatedDate = NullableValueExtension.ToForceDateTime(row["CreatedDate"].ToString());
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            targetClass.UpdatedDate = NullableValueExtension.ToForceDateTime(row["UpdatedDate"].ToString());
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
        }

        public bool HasDuplicatedVehicle(String licensePlate, int? companyId)
        {
            var sqlCheck = new StringBuilder();
            sqlCheck.AppendLine("SELECT count(*) from [Vehicle]");
            sqlCheck.AppendLine("WHERE");
            sqlCheck.AppendFormat(" LicensePlate = '{0}'", licensePlate);
            if (companyId != 0)
            {
                sqlCheck.AppendFormat("AND CompanyId = '{0}'", companyId);
            }

            return (int)DataBase.ExecuteScalar(sqlCheck.ToString()) != 0;
        }
    }
}
