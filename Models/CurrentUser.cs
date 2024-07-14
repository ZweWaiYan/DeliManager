namespace DeliManager.Models
{
    using System;
    public class CurrentUser
    {
        public String UserName { get; set; }
        public Int32? UserId { get; set; }
        public Boolean IsAuth { get; set; }
        public String RoleName { get; set; }
        public Int32? CompanyId { get; set; }

        public CurrentUser()
        {
            UserName = "";
            UserId = 0;
            IsAuth = false;
            RoleName = "";
            CompanyId = 0;
        }

    }
}
