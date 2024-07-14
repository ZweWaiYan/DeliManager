namespace DeliManager.Models.Base
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using DeliManager.Common;

    public class BaseTB_DeliverymanEntity
    {
        #region "private variable"
        private Int32? _deliverymanId;
        private String _deliverymanName;
        private String _deliverymanPh;
        private String _deliverymanAddress;
        private String _deliverymanNRC;
        private String _deliverymanImage;
        private Int32? _deliverymanAge;
        private Int32? _companyId;
        private String _createdBy;
        private DateTime? _createdDate;
        private String _updatedBy;
        private DateTime? _updatedDate;
        #endregion

        #region "public get & set"
        public Int32? DeliverymanId { get { return this._deliverymanId.ToNonNullable(); } set { this._deliverymanId = value; } }
        public String DeliverymanName { get { return this._deliverymanName; } set { this._deliverymanName = value; } }
        public String DeliverymanPh { get { return this._deliverymanPh; } set { this._deliverymanPh = value; } }
        public String DeliverymanAddress { get { return this._deliverymanAddress; } set { this._deliverymanAddress = value; } }
        public String DeliverymanNRC { get { return this._deliverymanNRC; } set { this._deliverymanNRC = value; } }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public String DeliverymanImage { get { return this._deliverymanImage; } set { this._deliverymanImage = value; } }
        public Int32? DeliverymanAge { get { return this._deliverymanAge.ToNonNullable(); } set { this._deliverymanAge = value; } }
        public Int32? CompanyId { get { return this._companyId.ToNonNullable(); } set { this._companyId = value; } }
        public String CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }
        public DateTime? CreatedDate { get { return this._createdDate.ToNonNullable(); } set { this._createdDate = value; } }
        public String UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }
        public DateTime? UpdatedDate { get { return this._updatedDate.ToNonNullable(); } set { this._updatedDate = value; } }
        #endregion

        #region "Is Null functions"
        public bool IsDeliverymanIdNull() { return this._deliverymanId == null; }
        public bool IsDeliverymanNameNull() { return this._deliverymanName == null; }
        public bool IsDeliverymanPhNull() { return this._deliverymanPh == null; }
        public bool IsDeliverymanAddressNull() { return this._deliverymanAddress == null; }
        public bool IsDeliverymanNRCNull() { return this._deliverymanNRC == null; }
        public bool IsDeliverymanImageNull() { return this._deliverymanImage == null; }
        public bool IsDeliverymanAgeNull() { return this._deliverymanAge == null; }
        public bool IsCompanyIdNull() { return this._companyId == null; }
        public bool IsCreatedByNull() { return this._createdBy == null; }
        public bool IsCreatedDateNull() { return this._createdDate == null; }
        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        public bool IsUpdatedDateNull() { return this._updatedDate == null; }
        #endregion

        #region "Set Null functions"                    
        public void SetDeliverymanIdNull() { this._deliverymanId = null; }
        public void SetDeliverymanNameNull() { this._deliverymanName = null; }
        public void SetDeliverymanPhNull() { this._deliverymanPh = null; }
        public void SetDeliverymanAddressNull() { this._deliverymanAddress = null; }
        public void SetDeliverymanNRCNull() { this._deliverymanNRC = null; }
        public void SetDeliverymanImageNull() { this._deliverymanImage = null; }
        public void SetDeliverymanAgeNull() { this._deliverymanAge = null; }
        public void SetCompanyIdNull() { this._companyId = null; }
        public void SetCreatedByNull() { this._createdBy = null; }
        public void SetCreatedDateNull() { this._createdDate = null; }
        public void SetUpdatedByNull() { this._updatedBy = null; }
        public void SetUpdatedDateNull() { this._updatedDate = null; }
        #endregion
    }
}