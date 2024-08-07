using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DeliManager.Common;
using DeliManager.DataAccess;
using DeliManager.Models;
using DeliManager.Models.Base;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace DeliManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        [HttpPost("[action]")]
        public ActionResult<SearchResultObject<BaseTB_RouteEntity>> FetchRouteList(BaseTB_RouteEntity RouteEntityInfo)
        {
            RouteDA DA_Route = new RouteDA();
            return DA_Route.FetchRouteDA(RouteEntityInfo.CompanyId);
        }


        [HttpPost("[action]")]
        public ActionResult<ResultStatus> CreateRoute(BaseTB_RouteEntity RouteEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            RouteDA DA_Route = new RouteDA();
            BaseTB_Route BaseTB_Route = new BaseTB_Route();
            BaseTB_Vehicle BaseTB_Vehicle = new BaseTB_Vehicle();
            BaseTB_Package BaseTB_Package = new BaseTB_Package();
            BaseTB_Deliveryman BaseTB_Deliveryman = new BaseTB_Deliveryman();

            RouteEntityInfo.RouteId = null;
            var HasUser = BaseTB_Route.HasDuplicatedRouteQuery(RouteEntityInfo.RouteTownship, RouteEntityInfo.CompanyId);
            if (!HasUser)
            {
                //Create New Route
                result = DA_Route.CreateRouteDA(RouteEntityInfo);
                if (result.Status)
                {
                    //get RouteId from result
                    RouteEntityInfo.RouteId = int.Parse(result.Data);
                    //Update Vehicle Status
                    var isVehicleStatusUpdated = BaseTB_Vehicle.UpdateVehicleStatusQuery((int)RouteEntityInfo.RouteId, (int)RouteEntityInfo.VehicleId, (int)RouteEntityInfo.DeliverymanId, 2);
                    //Update Package Status
                    var isPackageStatusUpdated = BaseTB_Package.UpdatePackageStatusQuery((int)RouteEntityInfo.RouteId, RouteEntityInfo.PackageId, (int)RouteEntityInfo.DeliverymanId, 4);
                    //Update Deliveryman Status
                    var isDeliverymanStatusUpdated = BaseTB_Deliveryman.UpdateDeliverymanStatusQuery((int)RouteEntityInfo.RouteId, (int)RouteEntityInfo.DeliverymanId, 2);
                    if (isVehicleStatusUpdated != 0 && isPackageStatusUpdated != 0 && isDeliverymanStatusUpdated != 0)
                    {
                        result.Status = result.Status;
                        result.Message = result.Message;
                    }
                    else
                    {
                        result.Status = result.Status;
                        result.Message = result.Message;
                    }
                }
                else
                {
                    result.Status = result.Status;
                    result.Message = result.Message;
                }
            }
            else
            {
                result.Status = false;
                result.Message = "This Route is already existed";
            }
            return result;
        }

        //PUT
        [HttpPost("[action]")]
        public ActionResult<ResultStatus> EditRoute(BaseTB_RouteEntity RouteEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            RouteDA DA_Route = new RouteDA();
            BaseTB_RouteEntity previousRouteEntity = new BaseTB_RouteEntity();
            BaseTB_Deliveryman BaseTB_Deliveryman = new BaseTB_Deliveryman();
            BaseTB_Vehicle BaseTB_Vehicle = new BaseTB_Vehicle();
            BaseTB_Package BaseTB_Package = new BaseTB_Package();

            //Get previous route data
            previousRouteEntity = DA_Route.GetRouteDataDA((int)RouteEntityInfo.RouteId);

            //Edit Route
            result = DA_Route.EditRouteDA(RouteEntityInfo);
            if (result.Status)
            {

                var isDeliverymanStatusUpdated = 0;
                var isVehicleStatusUpdated = 0;
                var isPackageStatusUpdated = 0;

                //Update Deliveryman Status
                if (previousRouteEntity.DeliverymanId != RouteEntityInfo.DeliverymanId)
                {
                    isDeliverymanStatusUpdated = BaseTB_Deliveryman.UpdateDeliverymanStatusWithCaseQuery((int)RouteEntityInfo.RouteId, (int)RouteEntityInfo.DeliverymanId, (int)RouteEntityInfo.VehicleId, RouteEntityInfo.PackageId);
                }                

                //Update Vehciel Status               
                isVehicleStatusUpdated = BaseTB_Vehicle.UpdateVehicleStatusWithCaseQuery((int)RouteEntityInfo.RouteId, (int)RouteEntityInfo.VehicleId, (int)RouteEntityInfo.DeliverymanId);

                //Update Package Status
                isPackageStatusUpdated = BaseTB_Package.UpdatePackageStatusQueryWithCase((int)RouteEntityInfo.RouteId, RouteEntityInfo.PackageId, (int)RouteEntityInfo.DeliverymanId);

                if (isDeliverymanStatusUpdated != 0 || isVehicleStatusUpdated != 0 || isPackageStatusUpdated != 0)
                {
                    result.Status = result.Status;
                    result.Message = result.Message;
                }
            }
            else
            {
                result.Status = false;
                result.Message = result.Message;
            }
            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<ResultStatus> DeleteRoute(BaseTB_RouteEntity RouteEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            RouteDA DA_Route = new RouteDA();
            BaseTB_Vehicle BaseTB_Vehicle = new BaseTB_Vehicle();
            BaseTB_Package BaseTB_Package = new BaseTB_Package();
            BaseTB_Deliveryman BaseTB_Deliveryman = new BaseTB_Deliveryman();
            //Delete Route
            result = DA_Route.DeleteRouteDA(RouteEntityInfo);
            if (result.Status)
            {
                //Update Vehicle Status
                var isVehicleStatusUpdated = BaseTB_Vehicle.UpdateVehicleStatusQuery(0, (int)RouteEntityInfo.VehicleId, 0, 1);
                //Update Package Status
                var isPackageStatusUpdated = BaseTB_Package.UpdatePackageStatusQuery(0, RouteEntityInfo.PackageId, 0, 1);
                //Update Deliveryman Status
                var isDeliverymanStatusUpdated = BaseTB_Deliveryman.UpdateDeliverymanStatusQuery(0, (int)RouteEntityInfo.DeliverymanId, 1);
                if (isVehicleStatusUpdated != 0 && isPackageStatusUpdated != 0 && isDeliverymanStatusUpdated != 0)
                {
                    result.Status = result.Status;
                    result.Message = result.Message;
                }
                else
                {
                    result.Status = result.Status;
                    result.Message = result.Message;
                }

                result.Status = result.Status;
                result.Message = result.Message;
            }
            else
            {
                result.Status = result.Status;
                result.Message = result.Message;
            }
            return result;
        }
    }
}
