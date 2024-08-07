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

    public class VehicleDA : BaseDA
    {
        public SearchResultObject<BaseTB_VehicleEntity> FetchVehicleDA(int? companyId)
        {
            BaseTB_Vehicle BaseTB_Vehicle = new BaseTB_Vehicle();
            int VehicleTotalRecord = BaseTB_Vehicle.GetCountVehicleQuery(companyId);            
             List<string> vehicleColumn = BaseTB_Vehicle.GetVehicleColumnQuery();
            List<BaseTB_VehicleEntity> list = BaseTB_Vehicle.FetchVehicleQuery(companyId);
            SearchResultObject<BaseTB_VehicleEntity> sro = new SearchResultObject<BaseTB_VehicleEntity>
            {
                TableColumn = vehicleColumn,
                TotalCount = VehicleTotalRecord,
                Records = new List<BaseTB_VehicleEntity>()
            };
            foreach (var row in list)
            {
                sro.Records.Add(new BaseTB_VehicleEntity()
                {
                    VehicleId = row.VehicleId,
                    LicensePlate = row.LicensePlate,
                    Modal = row.Modal,
                    Manufacturer = row.Manufacturer,
                    DeliverymanId = row.DeliverymanId,
                    VehicleStatus = row.VehicleStatus,
                    Capacity = row.Capacity,
                    InsuranceExpiryDate = row.InsuranceExpiryDate,
                    FuelLevel = row.FuelLevel,
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

        public ResultStatus CreateVehicleDA(BaseTB_VehicleEntity VehicleEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Vehicle BaseTB_Vehicle = new BaseTB_Vehicle();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampCreated(VehicleEntityInfo, null);
                //Add Vehicle Info into User Table
                int Id = BaseTB_Vehicle.CreateVehicleQuery(con, tran, VehicleEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Data = Id.ToString();
                    result.Message = "Successfully to create Vehicle";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to create new Vehicle";
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

        public ResultStatus EditVehicleDA(BaseTB_VehicleEntity VehicleEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Vehicle BaseTB_Vehicle = new BaseTB_Vehicle();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampUpdated(VehicleEntityInfo);
                //Update Vehicle Info into User Table
                int Id = BaseTB_Vehicle.EditVehicleQuery(con, tran, VehicleEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Message = "Successfully to update Vehicle";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to update Vehicle";
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
         public ResultStatus DeleteVehicleDA(BaseTB_VehicleEntity VehicleEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Vehicle BaseTB_Vehicle = new BaseTB_Vehicle();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                //Delete Vehicle Info into User Table
                int Id = BaseTB_Vehicle.DeleteVehicleQuery(con, tran, VehicleEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Message = "Successfully to delete Vehicle";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to delete Vehicle";
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

         public virtual int CheckVehicleInUse(int vehicleId)
        {
            var sql = new StringBuilder();
            sql.AppendFormat(" SELECT Count(1) FROM [Route] WHERE VehicleId = {0}; ", vehicleId);
            return (int)DataBase.ExecuteScalar(sql.ToString());
        }   
    }
}
