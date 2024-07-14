using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DeliManager.Models;
namespace DeliManager.Common
{
    public class SessionManager
    {

        private static HttpContext _httpContext => new HttpContextAccessor().HttpContext;
        public static void SetCurrenUser(string value) => _httpContext.Session.SetString("CurrentUser", value);

        public static CurrentUser GetCurrentUser()
        {
            CurrentUser loginUser = new CurrentUser();
            if (_httpContext.Session.GetString("CurrentUser") != null)
            {
                return JsonConvert.DeserializeObject<CurrentUser>(_httpContext.Session.GetString("CurrentUser"));
            }
            else
            {
                return loginUser;
            }
        }
        public static bool ClearSession()
        {
            if (_httpContext.Session.GetString("CurrentUser") != null)
            {
                _httpContext.Session.Clear();
                return true;
            }
            return true;
        }
    }
}