using DeliManager.Common;
using DeliManager.DataAccess;
using DeliManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

public abstract class BaseCustomController<T> : Controller where T : BaseCustomController<T>
{

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        dynamic Data = SessionManager.GetCurrentUser();
        base.OnActionExecuting(context);
        string action = context.RouteData.Values["action"].ToString();
        string calledScreen = context.HttpContext.Request.Path;
        if (action.Equals("SignIn") == false && action.Equals("CurrentUser") == false)
        {
            // チェックに引っかかった場合、ログイン画面を表示する。
            if (!this.ValidateSessionUser(Data))
            {
                context.Result = new UnauthorizedObjectResult(SessionManager.GetCurrentUser());
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
            // try
            // {
            //     currentUser item = new currentUser();
            //     string loginID = item.UserId;
            //     string CookieUserId = context.HttpContext.User.Identity.Name;
            //     string calledScreen = context.HttpContext.Request.Path;
            //     string remoteIPAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            //     string calledAction = context.RouteData.Values["action"].ToString();
            //     string actionParameter = string.Empty;
            //     string remoteHostName = "Unknown";

            //     foreach (var keyValuePair in context.ActionArguments.Values)
            //     {
            //         actionParameter = string.Format("{0}", keyValuePair.ToString());
            //     };
            //     try
            //     {
            //         IPHostEntry iphe = Dns.GetHostEntry(remoteIPAddress);
            //         remoteHostName = iphe.HostName;
            //     }
            //     catch (Exception ex)
            //     {
            //         System.Diagnostics.Debug.WriteLine(ex.ToString());
            //     }
            //     // WriteOperationLog(loginID, CookieUserId, remoteIPAddress, remoteHostName, calledScreen, calledAction, actionParameter);
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"Error {e.Message}");
            // }
        }
    }
    protected bool ValidateSessionUser(dynamic LoginInfo)
    {
        bool hasSession = LoginInfo.IsAuth;

        if (!hasSession)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}