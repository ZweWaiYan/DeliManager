namespace DeliManager.Models.Base
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using DeliManager.Common;

    public class BaseTB_PackageEntity
    {
        #region "private variable"
        private Int32? _packageId;
        private Int32? _deliverymanId;
        private String _packageTitle;
        private Int32? _packageQty;
        private Int32? _packageWayProcess;
        private Double? _packagePrice;
        private Double? _deliFee;
        private Double? _collectMoney;        
        private String _senderName;
        private String _senderPh;
        private String _senderAddress;
        private String _pickupDate;
        private String _pickupTime;
        private String _receiverName;
        private String _receiverPh;
        private String _receiverAddress;
        private String _receivedDate;
        private String _receivedTime;
        private Int32? _companyId;
        private String _createdBy;
        private DateTime? _createdDate;
        private String _updatedBy;
        private DateTime? _updatedDate;
        #endregion

        #region "public get & set"
        public Int32? PackageId { get { return this._packageId.ToNonNullable(); } set { this._packageId = value; } }
        public Int32? DeliverymanId { get { return this._deliverymanId.ToNonNullable(); } set { this._deliverymanId = value; } }
        public String PackageTitle { get { return this._packageTitle.ToNonNullable(); } set { this._packageTitle = value; } }
        public Int32? PackageQty { get { return this._packageQty.ToNonNullable(); } set { this._packageQty = value; } }
        public Int32? PackageWayProcess { get { return this._packageWayProcess.ToNonNullable(); } set { this._packageWayProcess = value; } }
        public Double PackagePrice { get { return this._packagePrice.ToNonNullable(); } set { this._packagePrice = value; } }
        public Double DeliFee { get { return this._deliFee.ToNonNullable(); } set { this._deliFee = value; } }
        public Double CollectMoney { get { return this._collectMoney.ToNonNullable(); } set { this._collectMoney = value; } }        
        public String SenderName { get { return this._senderName.ToNonNullable(); } set { this._senderName = value; } }
        public String SenderPh { get { return this._senderPh.ToNonNullable(); } set { this._senderPh = value; } }
        public String SenderAddress { get { return this._senderAddress.ToNonNullable(); } set { this._senderAddress = value; } }
        public String PickupDate { get { return this._pickupDate.ToNonNullable(); } set { this._pickupDate = value; } }
        public String PickupTime { get { return this._pickupTime.ToNonNullable(); } set { this._pickupTime = value; } }
        public String ReceiverName { get { return this._receiverName.ToNonNullable(); } set { this._receiverName = value; } }
        public String ReceiverPh { get { return this._receiverPh.ToNonNullable(); } set { this._receiverPh = value; } }
        public String ReceiverAddress { get { return this._receiverAddress.ToNonNullable(); } set { this._receiverAddress = value; } }
        public String ReceivedDate { get { return this._receivedDate.ToNonNullable(); } set { this._receivedDate = value; } }
        public String ReceivedTime { get { return this._receivedTime.ToNonNullable(); } set { this._receivedTime = value; } }
        public Int32? CompanyId { get { return this._companyId.ToNonNullable(); } set { this._companyId = value; } }
        public String CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }
        public DateTime? CreatedDate { get { return this._createdDate.ToNonNullable(); } set { this._createdDate = value; } }
        public String UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }
        public DateTime? UpdatedDate { get { return this._updatedDate.ToNonNullable(); } set { this._updatedDate = value; } }
        #endregion

        #region "Is Null functions"
        public bool IsPackageIdNull() { return this._packageId == null; }    
        public bool IsDeliverymanIdNull() { return this._deliverymanId == null; }
        public bool IsPackageTitleNull() { return this._packageTitle == null; }
        public bool IsPackageQtyNull() { return this._packageQty == null; }
        public bool IsPackageWayProcessNull() { return this._packageWayProcess == null; }
        public bool IsPackagePriceNull() { return this._packagePrice == null; }
        public bool IsDeliFeeNull() { return this._deliFee == null; }
        public bool IsCollectMoneyNull() { return this._collectMoney == null; }        
        public bool IsSenderNameNull() { return this._senderName == null; }
        public bool IsSenderPhNull() { return this._senderPh == null; }
        public bool IsSenderAddressNull() { return this._senderAddress == null; }
        public bool IsPickupDateNull() { return this._pickupDate == null; }
        public bool IsPickupTimeNull() { return this._pickupTime == null; }
        public bool IsReceiverNameNull() { return this._receiverName == null; }
        public bool IsReceiverPhNul() { return this._receiverPh == null; }
        public bool IsReceiverAddressNull() { return this._receiverAddress == null; }
        public bool IsReceivedDateNull() { return this._receivedDate == null; }
        public bool IsReceivedTimeNull() { return this._receivedTime == null; }
        public bool IsCompanyIdNull() { return this._companyId == null; }
        public bool IsCreatedByNull() { return this._createdBy == null; }
        public bool IsCreatedDateNull() { return this._createdDate == null; }
        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        public bool IsUpdatedDateNull() { return this._updatedDate == null; }
        #endregion

        #region "Set Null functions"                    
        public void SetPackageIdNull() { this._packageId = null; }
        public void SetDeliverymanIdNull() { this._deliverymanId = null; }
        public void SetPackageTitleNull() { this._packageTitle = null; }
        public void SetPackageQtyNull() { this._packageQty = null; }
        public void SetPackageWayProcessNull() { this._packageWayProcess = null; }
        public void SetPackagePriceNull() { this._packagePrice = null; }
        public void SetDeliFeeNull() { this._deliFee = null; }
        public void SetCollectMoneyNull() { this._collectMoney = null; }        
        public void SetSenderNameNull() { this._senderName = null; }
        public void SetSenderPhNull() { this._senderPh = null; }
        public void SetSenderAddressNull() { this._senderAddress = null; }
        public void SetPickupDateNull() { this._pickupDate = null; }
        public void SetPickupTimeNull() { this._pickupTime = null; }
        public void SetReceiverNameNull() { this._receiverName = null; }
        public void SetReceiverPhNull() { this._receiverPh = null; }
        public void SetReceiverAddressNull() { this._receiverAddress = null; }
        public void SetReceivedDateNull() { this._receivedDate = null; }
        public void SetReceivedTimeNull() { this._receivedTime = null; }
        public void SetCompanyIdNull() { this._companyId = null; }
        public void SetCreatedByNull() { this._createdBy = null; }
        public void SetCreatedDateNull() { this._createdDate = null; }
        public void SetUpdatedByNull() { this._updatedBy = null; }
        public void SetUpdatedDateNull() { this._updatedDate = null; }
        #endregion
    }
}