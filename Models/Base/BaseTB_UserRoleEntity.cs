//UserId //int
//RoleId //int
//CreatedBy //nvarchar(50)
//CreatedDate //datetime
//UpdatedBy //nvarchar(50)
//UpdatedDate //datetime

namespace DeliManager.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using DeliManager.Common;

    public class BaseTB_UserRoleEntity
    {
        #region Private fields
        private Int32? _userId;
        private Int32? _roleId;
        private String _createdBy;
        private DateTime? _createdDate;
        private String _updatedBy;
        private DateTime? _updatedDate;
        #endregion

        #region Public properties
        public Int32? UserId { get { return this._userId.ToNonNullable(); } set { this._userId = value; } }
        public Int32? RoleId { get { return this._roleId; } set { this._roleId = value; } }
        public String CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }
        public DateTime CreatedDate { get { return this._createdDate.ToNonNullable(); } set { this._createdDate = value; } }
        public String UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }
        public DateTime UpdatedDate { get { return this._updatedDate.ToNonNullable(); } set { this._updatedDate = value; } }
        #endregion

        #region "IsNull functions"
        public bool IsUserIdNull() { return this._userId == null; }
        public bool IsRoleIdNull() { return this._roleId == null; }
        public bool IsCreatedByNull() { return this._createdBy == null; }
        public bool IsCreatedDateNull() { return this._createdDate == null; }
        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        public bool IsUpdatedDateNull() { return this._updatedDate == null; }
        #endregion

        #region "SetNull functions"
        public void SetUserIdNull() { this._userId = null; }
        public void SetRoleIdNull() { this._roleId = null; }
        public void SetCreatedByNull() { this._createdBy = null; }
        public void SetCreatedDateNull() { this._createdDate = null; }
        public void SetUpdatedByNull() { this._updatedBy = null; }
        public void SetUpdatedDateNull() { this._updatedDate = null; }
        #endregion
    }
}