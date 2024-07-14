using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeliManager.Common;
using DeliManager.Models;
using DeliManager.Models.Base;
using DeliManager.DataAccess;
using Newtonsoft.Json;
using MySqlX.XDevAPI.Common;

namespace DeliManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpGet("[action]")]
        public ResultStatus CurrentUser()
        {
            ResultStatus result = new ResultStatus();
            result.Data = SessionManager.GetCurrentUser();
            return result;
        }

        [HttpPost("[action]")]
        public ResultStatus SignOut()
        {
            ResultStatus result = new ResultStatus();
            HttpContext.Session.Clear();
            CurrentUser user = new CurrentUser();
            result.Data = user;
            return result;
        }

        [HttpPost("[action]")]
        public ResultStatus SignIn(BaseTB_UserEntity userEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            BaseTB_UserEntity userEntity = new BaseTB_UserEntity();
            UserDA userDA = new UserDA();

            userEntityInfo.LoginPassword = EncryptDecrypt.Encrypt(userEntityInfo.LoginPassword);

            try
            {
                int userId = userDA.GetUserIdDA(userEntityInfo.LoginPhone);
                userEntity = userDA.GetAllUserInfoDA(userId);
                if (result.Status)
                {
                    if (userEntity.LoginPhone != userEntityInfo.LoginPhone)
                    {
                        result.Message = "wrong user's phone number";
                        result.Status = false;
                    }
                    if (userEntity.UserId == null)
                    {
                        result.Message = "user is not existed";
                        result.Status = false;
                    }
                    if (userEntity.LoginPassword != userEntityInfo.LoginPassword)
                    {
                        result.Message = "Invalid password";
                        result.Status = false;
                    }

                    CurrentUser currentUser = new CurrentUser()
                    {
                        UserName = userEntity.UserName,
                        UserId = userEntity.UserId,
                        IsAuth = true,
                        RoleName = userEntity.RoleName,
                        CompanyId = userEntity.CompanyId,
                    };

                    SessionManager.SetCurrenUser(JsonConvert.SerializeObject(currentUser));
                    result.Status = true;
                    result.Data = currentUser;
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.ToString();
            }

            return result;
        }
    }
}
