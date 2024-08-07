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
    public class PackageController : ControllerBase
    {
        [HttpPost("[action]")]
        public ActionResult<SearchResultObject<BaseTB_PackageEntity>> FetchPackageList(BaseTB_PackageEntity packageEntityInfo)
        {
            PackageDA DA_Package = new PackageDA();
            return DA_Package.FetchPackageDA(packageEntityInfo.CompanyId);
        }


        [HttpPost("[action]")]
        public ActionResult<ResultStatus> CreatePackage(BaseTB_PackageEntity packageEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            PackageDA DA_Package = new PackageDA();
            BaseTB_Package BaseTB_Package = new BaseTB_Package();

            packageEntityInfo.PackageId = null;
            // var HasUser = BaseTB_Package.HasDuplicatedPackage(packageEntityInfo., packageEntityInfo.CompanyId);

            var HasUser = false;

            if (!HasUser)
            {
                //Create New Package
                result = DA_Package.CreatePackageDA(packageEntityInfo);
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
                result.Status = false;
                result.Message = "This package is already existed";
            }
            return result;
        }

        //PUT
        [HttpPost("[action]")]
        public ActionResult<ResultStatus> EditPackage(BaseTB_PackageEntity packageEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            PackageDA DA_Package = new PackageDA();
            //Edit Package
            result = DA_Package.EditPackageDA(packageEntityInfo);
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
        public ActionResult<ResultStatus> DeletePackage(BaseTB_PackageEntity packageEntity)
        {
            ResultStatus result = new ResultStatus();
            PackageDA DA_Package = new PackageDA();
            int isHas = DA_Package.CheckPackageInUse((int)packageEntity.PackageId);
            if (isHas == 0)
            {
                //Delete Package
                result = DA_Package.DeletePackageDA(packageEntity);
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
                result.Status = false;
                result.Message = "This Package is used on Route No." + packageEntity.RouteId;
            }
            return result;
        }
    }
}
