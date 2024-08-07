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

    public class DeliverymanDA : BaseDA
    {
        public SearchResultObject<BaseTB_DeliverymanEntity> FetchDeliverymanDA(int? companyId)
        {
            BaseTB_Deliveryman BaseTB_Deliveryman = new BaseTB_Deliveryman();
            int deliverymanTotalRecord = BaseTB_Deliveryman.GetCountDeliverymanQuery(companyId);
            List<string> deliveryColumn = BaseTB_Deliveryman.GetDeliverymanColumnQuery();
            List<BaseTB_DeliverymanEntity> list = BaseTB_Deliveryman.FetchDeliverymanQuery(companyId);
            SearchResultObject<BaseTB_DeliverymanEntity> sro = new SearchResultObject<BaseTB_DeliverymanEntity>
            {
                TableColumn = deliveryColumn,
                TotalCount = deliverymanTotalRecord,
                Records = new List<BaseTB_DeliverymanEntity>()
            };
            foreach (var row in list)
            {
                sro.Records.Add(new BaseTB_DeliverymanEntity()
                {
                    DeliverymanId = row.DeliverymanId,
                    DeliverymanName = row.DeliverymanName,
                    DeliverymanPh = row.DeliverymanPh,
                    DeliverymanAddress = row.DeliverymanAddress,
                    DeliverymanStatus = row.DeliverymanStatus,
                    DeliverymanLicenseNo = row.DeliverymanLicenseNo,
                    DeliverymanNRC = row.DeliverymanNRC,
                    DeliverymanImage = row.DeliverymanImage,
                    DeliverymanAge = row.DeliverymanAge,
                    RouteId = row.RouteId,
                    CompanyId = row.CompanyId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                });
            }
            return sro;
        }

        public ResultStatus CreateDeliverymanDA(BaseTB_DeliverymanEntity deliverymanEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Deliveryman BaseTB_Deliveryman = new BaseTB_Deliveryman();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampCreated(deliverymanEntityInfo, null);
                //Add Deliveryman Info into User Table
                int Id = BaseTB_Deliveryman.CreateDeliverymanQuery(con, tran, deliverymanEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Data = Id.ToString();
                    result.Message = "Successfully to create Deliveryman";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to create new Deliveryman";
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

        public ResultStatus EditDeliverymanDA(BaseTB_DeliverymanEntity deliverymanEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Deliveryman BaseTB_Deliveryman = new BaseTB_Deliveryman();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampUpdated(deliverymanEntityInfo);
                //Update Deliveryman Info into User Table
                int Id = BaseTB_Deliveryman.EditDeliverymanQuery(con, tran, deliverymanEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Message = "Successfully to update Deliveryman";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to update Deliveryman";
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
        public ResultStatus DeleteDeliverymanDA(BaseTB_DeliverymanEntity deliverymanEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Deliveryman BaseTB_Deliveryman = new BaseTB_Deliveryman();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                //Delete Deliveryman Info into User Table
                int Id = BaseTB_Deliveryman.DeleteDeliverymanQuery(con, tran, deliverymanEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Message = "Successfully to delete Deliveryman";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to delete Deliveryman";
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

        public virtual int CheckDeliverymanInUse(int deliverymanId)
        {
            var sql = new StringBuilder();
            sql.AppendFormat(" SELECT Count(1) FROM [Route] WHERE DeliverymanId = {0}; ", deliverymanId);
            return (int)DataBase.ExecuteScalar(sql.ToString());
        }        
    }
}
