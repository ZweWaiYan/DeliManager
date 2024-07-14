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
    public class DeliverymanController : ControllerBase
    {   
        [HttpPost("[action]")]        
        public ActionResult<SearchResultObject<BaseTB_DeliverymanEntity>> FetchDeiverymanList(BaseTB_DeliverymanEntity deliverymanEntityInfo)
        {            
            DeliverymanDA DA_Deliveryman = new DeliverymanDA();           
            return DA_Deliveryman.FetchDeliverymanDA(deliverymanEntityInfo.CompanyId);
        }


        [HttpPost("[action]")]
        public ActionResult<ResultStatus> CreateDeliveryman(BaseTB_DeliverymanEntity deliverymanEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            DeliverymanDA DA_Deliveryman = new DeliverymanDA();
            BaseTB_Deliveryman BaseTB_Deliveryman = new BaseTB_Deliveryman();

            deliverymanEntityInfo.DeliverymanId = null;
            var HasUser = BaseTB_Deliveryman.HasDuplicatedDeliveryman(deliverymanEntityInfo.DeliverymanPh, deliverymanEntityInfo.CompanyId);

            if (!HasUser)
            {
                //Create New Deliveryman
                result = DA_Deliveryman.CreateDeliverymanDA(deliverymanEntityInfo);
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
        public ActionResult<ResultStatus> EditDeliveryman(BaseTB_DeliverymanEntity deliverymanEntityInfo)
        {
            ResultStatus result = new ResultStatus();            
            DeliverymanDA DA_Deliveryman = new DeliverymanDA();
            //Edit Deliveryman
            result = DA_Deliveryman.EditDeliverymanDA(deliverymanEntityInfo);
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
        public ActionResult<ResultStatus> DeleteDeliveryman(BaseTB_DeliverymanEntity deliverymanEntityInfo)
        {
            ResultStatus result = new ResultStatus();            
            DeliverymanDA DA_Deliveryman = new DeliverymanDA();
            //Delete Deliveryman
            result = DA_Deliveryman.DeleteDeliverymanDA(deliverymanEntityInfo);
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
