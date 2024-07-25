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
    public class VehicleController : ControllerBase
    {   
        [HttpPost("[action]")]        
        public ActionResult<SearchResultObject<BaseTB_VehicleEntity>> FetchVehicleList(BaseTB_VehicleEntity VehicleEntityInfo)
        {            
            VehicleDA DA_Vehicle = new VehicleDA();           
            return DA_Vehicle.FetchVehicleDA(VehicleEntityInfo.CompanyId);
        }


        [HttpPost("[action]")]
        public ActionResult<ResultStatus> CreateVehicle(BaseTB_VehicleEntity VehicleEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            VehicleDA DA_Vehicle = new VehicleDA();
            BaseTB_Vehicle BaseTB_Vehicle = new BaseTB_Vehicle();

            VehicleEntityInfo.VehicleId = null;
            var HasUser = BaseTB_Vehicle.HasDuplicatedVehicle(VehicleEntityInfo.LicensePlate, VehicleEntityInfo.CompanyId);

            if (!HasUser)
            {
                //Create New Vehicle
                result = DA_Vehicle.CreateVehicleDA(VehicleEntityInfo);
                if (result.Status)
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
                result.Message = "This user is already existed";
            }
            return result;
        }

//PUT
        [HttpPost("[action]")]
        public ActionResult<ResultStatus> EditVehicle(BaseTB_VehicleEntity VehicleEntityInfo)
        {
            ResultStatus result = new ResultStatus();            
            VehicleDA DA_Vehicle = new VehicleDA();
            //Edit Vehicle
            result = DA_Vehicle.EditVehicleDA(VehicleEntityInfo);
            if (result.Status)
            {
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

         [HttpPost("[action]")]
        public ActionResult<ResultStatus> DeleteVehicle(BaseTB_VehicleEntity VehicleEntityInfo)
        {
            ResultStatus result = new ResultStatus();            
            VehicleDA DA_Vehicle = new VehicleDA();
            //Delete Vehicle
            result = DA_Vehicle.DeleteVehicleDA(VehicleEntityInfo);
            if (result.Status)
            {
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
