namespace DeliManager.DataAccess
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using DeliManager.Common;
    using DeliManager.Models.Base;
    using DeliManager.Models;
    using static DeliManager.Common.CommonConst;
    using Microsoft.AspNetCore.Mvc;

    public class PackageDA : BaseDA
    {
        public SearchResultObject<BaseTB_PackageEntity> FetchPackageDA(int? companyId)
        {
            BaseTB_Package BaseTB_Package = new BaseTB_Package();
            int packageTotalRecord = BaseTB_Package.GetCountPackageQuery(companyId);            
             List<string> packageColumn = BaseTB_Package.GetPackageColumnQuery();
            List<BaseTB_PackageEntity> list = BaseTB_Package.FetchPackageQuery(companyId);
            SearchResultObject<BaseTB_PackageEntity> sro = new SearchResultObject<BaseTB_PackageEntity>
            {
                TableColumn = packageColumn,
                TotalCount = packageTotalRecord,
                Records = new List<BaseTB_PackageEntity>()
            };
            foreach (var row in list)
            {
                sro.Records.Add(new BaseTB_PackageEntity()
                {                                       
                    PackageId = row.PackageId,                    
                    DeliverymanId = row.DeliverymanId,
                    PackageTitle = row.PackageTitle,
                    PackageQty = row.PackageQty,
                    PackageWayProcess = row.PackageWayProcess,
                    PackagePrice = row.PackagePrice,
                    DeliFee = row.DeliFee,
                    CollectMoney = row.CollectMoney,                    
                    SenderName = row.SenderName,
                    SenderPh = row.SenderPh,
                    SenderAddress = row.SenderAddress,
                    SenderCity = row.SenderCity,
                    PickupDate = row.PickupDate,
                    PickupTime = row.PickupTime,
                    ReceiverName = row.ReceiverName,
                    ReceiverPh = row.ReceiverPh,
                    ReceiverAddress = row.ReceiverAddress,
                    ReceiverCity = row.ReceiverCity,
                    ReceivedDate = row.ReceivedDate, 
                    ReceivedTime = row.ReceivedTime,
                    CompanyId = row.CompanyId,  
                    RouteId = row.RouteId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                });
            }
            return sro;
        }

        public ResultStatus CreatePackageDA(BaseTB_PackageEntity PackageEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Package BaseTB_Package = new BaseTB_Package();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampCreated(PackageEntityInfo, null);
                //Add Package Info into User Table
                int Id = BaseTB_Package.CreatePackageQuery(con, tran, PackageEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Data = Id.ToString();
                    result.Message = "Successfully to create Package";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to create new Package";
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

        public ResultStatus EditPackageDA(BaseTB_PackageEntity PackageEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Package BaseTB_Package = new BaseTB_Package();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampUpdated(PackageEntityInfo);
                //Update Package Info into User Table
                int Id = BaseTB_Package.EditPackageQuery(con, tran, PackageEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Message = "Successfully to update Package";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to update Package";
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
         public ResultStatus DeletePackageDA(BaseTB_PackageEntity PackageEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Package BaseTB_Package = new BaseTB_Package();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                //Delete Package Info into User Table
                int Id = BaseTB_Package.DeletePackageQuery(con, tran, PackageEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Message = "Successfully to delete Package";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to delete Package";
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

         public virtual int CheckPackageInUse(int packageId)
        {
            var sql = new StringBuilder();
            sql.AppendFormat(" SELECT Count(1) FROM [Route] WHERE PackageId = {0}; ", packageId);
            return (int)DataBase.ExecuteScalar(sql.ToString());
        }   
    }
}
