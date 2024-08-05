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

    public class BaseTB_Package : BaseTB_PackageEntity
    {

        #region "Get All Data"        
        public virtual List<BaseTB_PackageEntity> FetchPackageQuery(int? companyId)
        {
            var list = new List<BaseTB_PackageEntity>();
            var dt = this.GetPackageData(companyId);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                var entity = new BaseTB_PackageEntity();
                this.SetPackageData(entity, row);
                list.Add(entity);
            }
            return list;
        }
        #endregion

        #region "Get Package Column"
        public virtual List<string> GetPackageColumnQuery()
        {
            var list = new List<string>();
            var dt = this.GetPackageColumn();
            for (var i = 0; i < dt.Rows.Count - 5; i++)
            {
                var row = dt.Rows[i];
                list.Add(row.ItemArray[0].ToString());
            }
            return list;
        }
        #endregion

        #region "Insert Data"
        public virtual int CreatePackageQuery(DbConnection con, DbTransaction tran, BaseTB_PackageEntity srcClass = null)
        {
            srcClass ??= this;

            var columnList = new List<string>();
            var paramList = new List<string>();
            if (!srcClass.IsPackageIdNull())
            {
                columnList.Add("PackageId");
                paramList.Add("@PackageId");
            }
            if (!srcClass.IsCompanyIdNull())
            {
                columnList.Add("CompanyId");
                paramList.Add("@CompanyId");
            }
            if (!srcClass.IsPackageTitleNull())
            {
                columnList.Add("PackageTitle");
                paramList.Add("@PackageTitle");
            }
            if (!srcClass.IsPackageQtyNull())
            {
                columnList.Add("PackageQty");
                paramList.Add("@PackageQty");
            }
            if (!srcClass.IsPackageWayProcessNull())
            {
                columnList.Add("PackageWayProcess");
                paramList.Add("@PackageWayProcess");
            }
            if (!srcClass.IsPackagePriceNull())
            {
                columnList.Add("PackagePrice");
                paramList.Add("@PackagePrice");
            }
            if (!srcClass.IsDeliFeeNull())
            {
                columnList.Add("DeliFee");
                paramList.Add("@DeliFee");
            }
            if (!srcClass.IsCollectMoneyNull())
            {
                columnList.Add("CollectMoney");
                paramList.Add("@CollectMoney");
            }
            if (!srcClass.IsSenderNameNull())
            {
                columnList.Add("SenderName");
                paramList.Add("@SenderName");
            }
            if (!srcClass.IsSenderPhNull())
            {
                columnList.Add("SenderPh");
                paramList.Add("@SenderPh");
            }
            if (!srcClass.IsSenderAddressNull())
            {
                columnList.Add("SenderAddress");
                paramList.Add("@SenderAddress");
            }
            if (!srcClass.IsPickupDateNull())
            {
                columnList.Add("PickupDate");
                paramList.Add("@PickupDate");
            }
            if (!srcClass.IsPickupTimeNull())
            {
                columnList.Add("PickupTime");
                paramList.Add("@PickupTime");
            }
            if (!srcClass.IsReceiverNameNull())
            {
                columnList.Add("ReceiverName");
                paramList.Add("@ReceiverName");
            }
            if (!srcClass.IsReceiverPhNul())
            {
                columnList.Add("ReceiverPh");
                paramList.Add("@ReceiverPh");
            }
            if (!srcClass.IsReceiverAddressNull())
            {
                columnList.Add("ReceiverAddress");
                paramList.Add("@ReceiverAddress");
            }
            if (!srcClass.IsReceivedDateNull())
            {
                columnList.Add("ReceivedDate");
                paramList.Add("@ReceivedDate");
            }
            if (!srcClass.IsReceivedTimeNull())
            {
                columnList.Add("ReceivedTime");
                paramList.Add("@ReceivedTime");
            }
            if (!srcClass.IsRouteIdNull())
            {
                columnList.Add("RouteId");
                paramList.Add("@RouteId");
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
            sql.AppendLine(" INSERT INTO [Package] ");
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
        public virtual int EditPackageQuery(DbConnection con, DbTransaction tran, BaseTB_PackageEntity srcClass = null)
        {
            srcClass ??= this;

            var setList = new List<string>();

            if (!srcClass.IsDeliverymanIdNull())
            {
                setList.Add("DeliverymanId = @DeliverymanId");
            }
            if (!srcClass.IsPackageTitleNull())
            {
                setList.Add("PackageTitle = @PackageTitle");
            }
            if (!srcClass.IsPackageQtyNull())
            {
                setList.Add("PackageQty = @PackageQty");
            }
            if (!srcClass.IsPackageWayProcessNull())
            {
                setList.Add("PackageWayProcess = @PackageWayProcess");
            }
            if (!srcClass.IsPackagePriceNull())
            {
                setList.Add("PackagePrice = @PackagePrice");
            }
            if (!srcClass.IsDeliFeeNull())
            {
                setList.Add("DeliFee = @DeliFee");
            }
            if (!srcClass.IsCollectMoneyNull())
            {
                setList.Add("CollectMoney = @CollectMoney");
            }
            if (!srcClass.IsSenderNameNull())
            {
                setList.Add("SenderName = @SenderName");
            }
            if (!srcClass.IsSenderPhNull())
            {
                setList.Add("SenderPh = @SenderPh");
            }
            if (!srcClass.IsSenderAddressNull())
            {
                setList.Add("SenderAddress = @SenderAddress");
            }
            if (!srcClass.IsPickupDateNull())
            {
                setList.Add("PickupDate = @PickupDate");
            }
            if (!srcClass.IsPickupTimeNull())
            {
                setList.Add("PickupTime = @PickupTime");
            }
            if (!srcClass.IsReceiverNameNull())
            {
                setList.Add("ReceiverName = @ReceiverName");
            }
            if (!srcClass.IsReceiverPhNul())
            {
                setList.Add("ReceiverPh = @ReceiverPh");
            }
            if (!srcClass.IsReceiverAddressNull())
            {
                setList.Add("ReceiverAddress = @ReceiverAddress");
            }
            if (!srcClass.IsReceivedDateNull())
            {
                setList.Add("ReceivedDate = @ReceivedDate");
            }
            if (!srcClass.IsReceivedTimeNull())
            {
                setList.Add("ReceivedTime = @ReceivedTime");
            }
            if (!srcClass.IsCompanyIdNull())
            {
                setList.Add("CompanyId = @CompanyId");
            }
            if (!srcClass.IsRouteIdNull())
            {
                setList.Add("RouteId = @RouteId");
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
            sql.AppendLine(" [Package] ");
            sql.AppendLine(" SET ");
            sql.AppendLine(string.Join("," + Environment.NewLine, setList));
            sql.AppendLine(" WHERE ");
            sql.AppendLine(" PackageId = @PackageId");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        #region "Delete Data"
        public virtual int DeletePackageQuery(DbConnection con, DbTransaction tran, BaseTB_PackageEntity srcClass = null)
        {
            srcClass ??= this;

            var sql = new StringBuilder();
            sql.AppendLine(" DELETE [Package] ");
            sql.AppendLine(" WHERE ");
            sql.AppendLine("  PackageId = @PackageId ");
            var param = this.GetParameter(srcClass);

            return (int)DataBase.ExecuteNonQuery(con, sql.ToString(), param, tran);
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Parameter functions

        private QueryParamList GetParameter(BaseTB_PackageEntity srcClass)
        {

            var param = new QueryParamList
            {
                { "@packageId" , srcClass.PackageId},
                { "@CompanyId", srcClass.CompanyId },
                { "@PackageTitle" , srcClass.PackageTitle},
                { "@PackageQty" , srcClass.PackageQty},
                { "@PackageWayProcess" , srcClass.PackageWayProcess},
                { "@PackagePrice" , srcClass.PackagePrice},
                { "@DeliFee" , srcClass.DeliFee},
                { "@CollectMoney" , srcClass.CollectMoney},
                { "@SenderName" , srcClass.SenderName},
                { "@SenderPh" , srcClass.SenderPh},
                { "@SenderAddress" , srcClass.SenderAddress},
                { "@PickupDate" , srcClass.PickupDate},
                { "@PickupTime" , srcClass.PickupTime},
                { "@ReceiverName" , srcClass.ReceiverName},
                { "@ReceiverPh" , srcClass.ReceiverPh},
                { "@ReceiverAddress" , srcClass.ReceiverAddress},
                { "@ReceivedDate" , srcClass.ReceivedDate},
                { "@ReceivedTime" , srcClass.ReceivedTime},
                { "@RouteId" , srcClass.RouteId},
                { "@Createdby", srcClass.CreatedBy },
                { "@CreatedDate", srcClass.CreatedDate },
                { "@Updatedby", srcClass.UpdatedBy },
                { "@UpdatedDate", srcClass.UpdatedDate }
            };

            return param;
        }

        public virtual int GetCountPackageQuery(int? companyId)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT ");
            sql.AppendLine("   COUNT(1) ");
            sql.AppendLine(" FROM ");
            sql.AppendLine(" [Package] ");
            sql.AppendFormat(" WHERE CompanyId = {0} ", companyId);
            return (int)DataBase.ExecuteScalar(sql.ToString());
        }

        #region "Update Package Status"
        public virtual int UpdatePackageStatusQuery(int? routeId, string packageIds, int deliverymanId, int packageWayProcess)
        {
            var sqlCheck = new StringBuilder();
            using var con = DataBase.GetConnection();

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

            sqlCheck.AppendLine(" UPDATE [Package] ");
            sqlCheck.AppendFormat(" SET PackageWayProcess = '{0}', RouteId = '{1}' , DeliverymanId = '{2}'", packageWayProcess, routeId, deliverymanId);
            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat("  PackageId IN ({0})", string.Join(",", validPackageIds));

            var result = DataBase.ExecuteNonQuery(con, sqlCheck.ToString());
            return result;
        }
        #endregion

        #region "Update Package Status and RouteId with Case for only Editing""
        public virtual int UpdatePackageStatusQueryWithCase(int? routeId, string packageIds, int deliverymanId)
        {
            var sqlCheck = new StringBuilder();
            using var con = DataBase.GetConnection();

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

            // sqlCheck.AppendLine(" UPDATE [Package] ");
            // sqlCheck.AppendLine(" SET ");

            // sqlCheck.AppendLine(" DeliverymanId = CASE ");
            // sqlCheck.AppendFormat(" WHEN RouteID = {0} AND PackageId NOT IN ({1}) THEN 0", routeId, string.Join(",", validPackageIds));
            // sqlCheck.AppendFormat(" WHEN PackageId IN ({0}) THEN 1", string.Join(",", validPackageIds));
            // sqlCheck.AppendLine(" ELSE DeliverymanId ");
            // sqlCheck.AppendLine(" END,");

            // sqlCheck.AppendLine(" PackageWayProcess = CASE ");
            // sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 1", routeId);
            // sqlCheck.AppendFormat(" WHEN PackageId IN ({0}) THEN 4", string.Join(",", validPackageIds));
            // sqlCheck.AppendLine(" ELSE PackageWayProcess ");
            // sqlCheck.AppendLine(" END,");

            // sqlCheck.AppendLine(" RouteId = CASE ");
            // sqlCheck.AppendFormat(" WHEN RouteId = {0} AND PackageId NOT IN ({0}) THEN 0", routeId, string.Join(",", validPackageIds));
            // sqlCheck.AppendFormat("WHEN PackageId IN ({0}) THEN {1}", string.Join(",", validPackageIds), routeId);
            // sqlCheck.AppendLine(" ELSE RouteId ");
            // sqlCheck.AppendLine(" END");

            // sqlCheck.AppendLine(" WHERE ");
            // sqlCheck.AppendFormat("  RouteId = {0} OR PackageId IN ({1})", routeId, string.Join(",", validPackageIds));

            sqlCheck.AppendLine(" UPDATE [Package] ");
            sqlCheck.AppendLine(" SET ");

            sqlCheck.AppendLine(" DeliverymanId = CASE ");
            sqlCheck.AppendFormat(" WHEN PackageId IN ({0}) THEN {1}", string.Join(",", validPackageIds) , deliverymanId);
            sqlCheck.AppendFormat(" WHEN RouteId = {0} THEN 0", routeId);            
            sqlCheck.AppendLine(" END,");

            sqlCheck.AppendLine(" PackageWayProcess = CASE ");
            sqlCheck.AppendFormat(" WHEN PackageId IN ({0}) THEN 4", string.Join(",", validPackageIds));
            sqlCheck.AppendFormat("  WHEN RouteId = {0} THEN 1", routeId);         
            sqlCheck.AppendLine(" END,");

            sqlCheck.AppendLine(" RouteId = CASE ");
            sqlCheck.AppendFormat(" WHEN PackageId IN ({0}) THEN {1}", string.Join(",", validPackageIds) , routeId);
            sqlCheck.AppendFormat("WHEN RouteId = ({0}) THEN 0", routeId);            
            sqlCheck.AppendLine(" END");

            sqlCheck.AppendLine(" WHERE ");
            sqlCheck.AppendFormat(" RouteId = {0} OR PackageId IN ({1});", routeId, string.Join(",", validPackageIds));

            var result = DataBase.ExecuteNonQuery(con, sqlCheck.ToString());
            return result;
        }
        #endregion      

        public virtual DataTable GetPackageColumn()
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('Package')");
            return DataBase.ExecuteAdapter(sql.ToString());
        }

        public virtual DataTable GetPackageData(int? companyId)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT ");
            sql.AppendLine(" * FROM ");
            sql.AppendLine(" [Package]");
            sql.AppendFormat(" WHERE [Package].CompanyId = {0} ", companyId);
            return DataBase.ExecuteAdapter(sql.ToString());
        }

        public virtual void SetPackageData(
         BaseTB_PackageEntity targetClass,
         DataRow row)
        {
            targetClass.PackageId = NullableValueExtension.DBNullToIntegerZero(row["PackageId"]);
            targetClass.CompanyId = NullableValueExtension.DBNullToIntegerZero(row["CompanyId"]);
            targetClass.DeliverymanId = NullableValueExtension.DBNullToIntegerZero(row["DeliverymanId"]);
            targetClass.PackageTitle = row["PackageTitle"].ToString();
            targetClass.PackageQty = NullableValueExtension.DBNullToIntegerZero(row["PackageQty"]);
            targetClass.PackageWayProcess = NullableValueExtension.DBNullToIntegerZero(row["PackageWayProcess"]);
            targetClass.PackagePrice = NullableValueExtension.DBNullToDoubleZero(row["PackagePrice"]);
            targetClass.DeliFee = NullableValueExtension.DBNullToDoubleZero(row["DeliFee"]);
            targetClass.CollectMoney = NullableValueExtension.DBNullToDoubleZero(row["CollectMoney"]);
            targetClass.SenderName = row["SenderName"].ToString();
            targetClass.SenderAddress = row["SenderAddress"].ToString();
            targetClass.SenderPh = row["SenderPh"].ToString();
            targetClass.PickupDate = row["PickupDate"].ToString();
            targetClass.PickupTime = row["PickupTime"].ToString();
            targetClass.ReceiverName = row["ReceiverName"].ToString();
            targetClass.ReceiverAddress = row["ReceiverAddress"].ToString();
            targetClass.ReceiverPh = row["ReceiverPh"].ToString();
            targetClass.ReceivedDate = row["ReceivedDate"].ToString();
            targetClass.ReceivedTime = row["ReceivedTime"].ToString();
            targetClass.RouteId = NullableValueExtension.DBNullToIntegerZero(row["RouteId"]);
            targetClass.CreatedBy = row["CreatedBy"].ToString();
            targetClass.CreatedDate = NullableValueExtension.ToForceDateTime(row["CreatedDate"].ToString());
            targetClass.UpdatedBy = row["UpdatedBy"].ToString();
            targetClass.UpdatedDate = NullableValueExtension.ToForceDateTime(row["UpdatedDate"].ToString());
        }

        public bool HasDuplicatedPackage(String phNo, int? companyId)
        {
            var sqlCheck = new StringBuilder();
            sqlCheck.AppendLine("SELECT count(*) from [Package]");
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
