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

    public class RouteDA : BaseDA
    {
        public SearchResultObject<BaseTB_RouteEntity> FetchRouteDA(int? companyId)
        {
            BaseTB_Route BaseTB_Route = new BaseTB_Route();
            int RouteTotalRecord = BaseTB_Route.GetCountRouteQuery(companyId);            
             List<string> RouteColumn = BaseTB_Route.GetRouteColumnQuery();
            List<BaseTB_RouteEntity> list = BaseTB_Route.FetchRouteQuery(companyId);
            SearchResultObject<BaseTB_RouteEntity> sro = new SearchResultObject<BaseTB_RouteEntity>
            {
                TableColumn = RouteColumn,
                TotalCount = RouteTotalRecord,
                Records = new List<BaseTB_RouteEntity>()
            };
            foreach (var row in list)
            {
                sro.Records.Add(new BaseTB_RouteEntity()
                {
                    RouteId = row.RouteId,
                    DeliverymanName = row.DeliverymanName,
                    DeliverymanId = row.DeliverymanId,
                    VehicleLicensePlate = row.VehicleLicensePlate,
                    VehicleId = row.VehicleId,
                    PackageId = row.PackageId,
                    PackageTotal = row.PackageTotal,
                    RouteRemainQty = row.RouteRemainQty,
                    RouteStatus = row.RouteStatus,
                    RouteTownship = row.RouteTownship,
                    TotalCollectMoney = row.TotalCollectMoney,
                    TotalDeliFee = row.TotalDeliFee,
                    TotalPackagePrice = row.TotalPackagePrice,
                    StartDate = row.StartDate,
                    StartTime = row.StartTime,
                    FinishDate = row.FinishDate,
                    FinishTime = row.FinishTime,                    
                    CompanyId = row.CompanyId,
                    CreatedBy = row.CreatedBy,
                    CreatedDate = row.CreatedDate,
                    UpdatedBy = row.UpdatedBy,
                    UpdatedDate = row.UpdatedDate,
                });
            }
            return sro;
        }

        public ResultStatus CreateRouteDA(BaseTB_RouteEntity RouteEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Route BaseTB_Route = new BaseTB_Route();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampCreated(RouteEntityInfo, null);
                //Add Route Info into User Table
                int Id = BaseTB_Route.CreateRouteQuery(con, tran, RouteEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Data = Id.ToString();
                    result.Message = "Successfully to create Route";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to create new Route";
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

        public ResultStatus EditRouteDA(BaseTB_RouteEntity RouteEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Route BaseTB_Route = new BaseTB_Route();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                this.StampUpdated(RouteEntityInfo);
                //Update Route Info into User Table
                int Id = BaseTB_Route.EditRouteQuery(con, tran, RouteEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;                    
                    result.Message = "Successfully to update Route";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to update Route";
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
         public ResultStatus DeleteRouteDA(BaseTB_RouteEntity RouteEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_Route BaseTB_Route = new BaseTB_Route();

            using var con = DataBase.GetConnection();
            using var tran = DataBase.GetTransaction(con);
            try
            {
                //Delete Route Info into User Table
                int Id = BaseTB_Route.DeleteRouteQuery(con, tran, RouteEntityInfo);
                if (Id != 0)
                {
                    result.Status = true;
                    result.Message = "Successfully to delete Route";
                    tran.Commit();
                }
                else
                {
                    result.Status = false;
                    result.Message = "Failed to delete Route";
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

           //Get all data of route info
        public BaseTB_RouteEntity GetRouteDataDA(int routeId)
        {
            BaseTB_Route BaseTB_Route = new BaseTB_Route();

            return BaseTB_Route.GetRouteDataQuery(routeId);
        }

    }
}
