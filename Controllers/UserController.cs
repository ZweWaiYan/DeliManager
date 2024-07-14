using Microsoft.AspNetCore.Mvc;
using DeliManager.DataAccess;
using DeliManager.Models;
using DeliManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Bcpg;
using MySqlX.XDevAPI;
using DeliManager.Common;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DeliManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Create new user on "User" table
        [HttpPost("[action]")]
        public ActionResult<ResultStatus> CreateUser(BaseTB_UserEntity userEntityInfo)
        {
            ResultStatus result = new ResultStatus();
            UserDA userDA = new UserDA();
            BaseTB_UserEntity userEntity = new BaseTB_UserEntity();
            BaseTB_UserRoleEntity userRoleEntity = new BaseTB_UserRoleEntity();

            try
            {
                userEntityInfo.UserId = null;
                userEntityInfo.LoginPhone = EncryptDecrypt.Encrypt(userEntityInfo.LoginPhone);

                var HasUser = userDA.HasDuplicatedUserDA(userEntityInfo.LoginPhone);
                if (!HasUser)
                {
                    //Create New user on User Table
                    result = userDA.CreateUserDA(userEntityInfo, userEntityInfo.CreatedBy);
                    //Status of create new user
                    if (result.Status)
                    {
                        result.Status = true;
                        //Create user's role on "UserRole" table with new user's "UserId" column
                        userDA.CreateUserRoleDA(result.Data, userEntityInfo.UserName, userEntityInfo.CreatedBy);
                        //Status of create new role for user
                        if (result.Status && userEntityInfo.CreatedBy == "System")
                        {
                            //When successfully create user & userrole , it automatically save on cookie (C#) and return that data to react
                            userEntity = userDA.GetAllUserInfoDA(result.Data);
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
                            if (userEntity.LoginPhone != userEntityInfo.LoginPhone)
                            {
                                result.Message = "Invalid password";
                                result.Status = false;
                            }

                            CurrentUser currentUser = new CurrentUser()
                            {
                                UserName = userEntity.UserName,
                                UserId = (int)userEntity.UserId,
                                IsAuth = true,
                                RoleName = userEntity.RoleName
                            };

                            SessionManager.SetCurrenUser(JsonConvert.SerializeObject(currentUser));
                            result.Status = true;
                            result.Data = currentUser;
                            return result;

                        }
                        else
                        {
                            result.Status = false;
                            result.Message = result.Message;
                        }
                    }
                    else
                    {
                        result.Status = false;
                        result.Message = result.Message;
                    }
                }
                else
                {
                    result.Status = false;
                    result.Message = "Duplicated User";
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
