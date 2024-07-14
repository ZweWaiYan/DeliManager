namespace DeliManager.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using DeliManager.Common;
    public class BaseTB_UserEntity
    {
        #region Private fields

        //User Table
        private Int32? _userId;
        private String _userName;
        private String _loginPhone;
        private String _loginPassword;
        private Boolean _isActive;
        private Int32? _companyId;
        private String _createdBy;
        private DateTime? _createdDate;
        private String _updatedBy;
        private DateTime? _updatedDate;

        //Role Table
        private Int32? _roleId;
        private String _roleName;

        #endregion

        #region Public getter & setter

        //User Table
        public Int32? UserId { get { return this._userId.ToNonNullable(); } set { this._userId = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public String UserName { get { return this._userName; } set { this._userName = value; } }
        public String LoginPhone { get { return this._loginPhone; } set { this._loginPhone = value; } }
        public String LoginPassword { get { return this._loginPassword; } set { this._loginPassword = value; } }
        public Boolean IsActive { get { return this._isActive; } set { this._isActive = value; } }
        public Int32? CompanyId { get { return this._companyId; } set { this._companyId = value; } }
        public String CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }
        public DateTime? CreatedDate { get { return this._createdDate.ToNonNullable(); } set { this._createdDate = value; } }
        public String UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }
        public DateTime UpdatedDate { get { return this._updatedDate.ToNonNullable(); } set { this._updatedDate = value; } }

        //Role Table
        public Int32? RoleId { get { return this._roleId; } set { this._roleId = value; } }
        public String RoleName { get { return this._roleName; } set { this._roleName = value; } }

        #endregion

        #region "IsNull functions"

        //User Table
        public bool IsUserIdNull() { return this._userId == null; }
        public bool IsUserNameNull() { return this._userName == null; }
        public bool IsLoginPhoneNull() { return this._loginPhone == null; }
        public bool IsLoginPasswordNull() { return this._loginPassword == null; }
        public bool IsCompanyIdNull() { return this._companyId == null; }
        public bool IsCreatedByNull() { return this._createdBy == null; }
        public bool IsCreatedDateNull() { return this._createdDate == null; }
        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        public bool IsUpdatedDateNull() { return this._updatedDate == null; }

        //Role Table
        public bool IsRoleIdNull() { return this._roleId == null; }
        public bool IsRoleNameNull() { return this._roleName == null; }

        #endregion

        #region "SetNull functions"
        //User Table
        public void SetIsUserIdNull() { this._userId = null; }
        public void SetUserNameNull() { this._userName = null; }
        public void SetLoginPhoneNull() { this._loginPhone = null; }
        public void SetLoginPasswordNull() { this._loginPassword = null; }
        public void SetIsCompanyIdNull() { this._companyId = null; }     
        public void SetCreatedByNull() { this._createdBy = null; }
        public void SetCreatedDateNull() { this._createdDate = null; }
        public void SetUpdatedByNull() { this._updatedBy = null; }
        public void SetUpdatedDateNull() { this._updatedDate = null; }

        //Role Table
        public void SetRoleIdNull() { this._roleId = null; }
        public void SetRoleNameNull() { this._roleName = null; }

        #endregion
    }
}
