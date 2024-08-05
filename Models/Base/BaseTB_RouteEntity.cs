namespace DeliManager.Models.Base
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using DeliManager.Common;

    public class BaseTB_RouteEntity
    {
        #region "private variable"
        private Int32? _routeId;
        private String _deliverymanName;
        private Int32? _deliverymanId;
        private String _vehicleLicensePlate;
        private Int32? _vehicleId;
        private String _packageId;
        private Int32? _packageTotal;
        private Int32? _routeRemainQty;
        private Int32? _routeStatus;
        private String _routeTownship;
        private Int32? _totalPackagePrice;
        private Int32? _totalDeliFee;
        private Int32? _totalCollectMoney;
        private String _startDate;
        private String _startTime;
        private String _finishDate;
        private String _finishTime;
        private Int32? _companyId;
        private String _createdBy;
        private DateTime? _createdDate;
        private String _updatedBy;
        private DateTime? _updatedDate;
        #endregion

        #region "public get & set"
        public Int32? RouteId { get { return this._routeId.ToNonNullable(); } set { this._routeId = value; } }
        public String DeliverymanName { get { return this._deliverymanName; } set { this._deliverymanName = value; } }
        public Int32? DeliverymanId { get { return this._deliverymanId.ToNonNullable(); } set { this._deliverymanId = value; } }
        public String VehicleLicensePlate { get { return this._vehicleLicensePlate; } set { this._vehicleLicensePlate = value; } }
        public Int32? VehicleId { get { return this._vehicleId.ToNonNullable(); } set { this._vehicleId = value; } }
        public String PackageId { get { return this._packageId.ToNonNullable(); } set { this._packageId = value; } }
        public Int32? PackageTotal { get { return this._packageTotal.ToNonNullable(); } set { this._packageTotal = value; } }
        public Int32? RouteRemainQty { get { return this._routeRemainQty.ToNonNullable(); } set { this._routeRemainQty = value; } }
        public Int32? RouteStatus { get { return this._routeStatus.ToNonNullable(); } set { this._routeStatus = value; } }
        public String RouteTownship { get { return this._routeTownship; } set { this._routeTownship = value; } }
        public Int32? TotalPackagePrice { get { return this._totalPackagePrice.ToNonNullable(); } set { this._totalPackagePrice = value; } }
        public Int32? TotalDeliFee { get { return this._totalDeliFee.ToNonNullable(); } set { this._totalDeliFee = value; } }
        public Int32? TotalCollectMoney { get { return this._totalCollectMoney.ToNonNullable(); } set { this._totalCollectMoney = value; } }
        public String StartDate { get { return this._startDate; } set { this._startDate = value; } }
        public String StartTime { get { return this._startTime; } set { this._startTime = value; } }
        public String FinishDate { get { return this._finishDate; } set { this._finishDate = value; } }        
        public String FinishTime { get { return this._finishTime; } set { this._finishTime = value; } }
        public Int32? CompanyId { get { return this._companyId.ToNonNullable(); } set { this._companyId = value; } }
        public String CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }
        public DateTime? CreatedDate { get { return this._createdDate.ToNonNullable(); } set { this._createdDate = value; } }
        public String UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }
        public DateTime? UpdatedDate { get { return this._updatedDate.ToNonNullable(); } set { this._updatedDate = value; } }
        #endregion

        #region "Is Null functions"        
        public bool IsRouteIdNull() { return this._routeId == null; }
        public bool IsDeliverymanNameNull() { return this._deliverymanName == null; }
        public bool IsDeliverymanIdNull() { return this._deliverymanId == null; }
        public bool IsVehicleLicensePlateNull() { return this._vehicleLicensePlate == null; }
        public bool IsVehicleIdNull() { return this._vehicleId == null; }
        public bool IsPackageIdNull() { return this._packageId == null; }
        public bool IsPackageTotalNull() { return this._packageTotal == null; }
        public bool IsRouteRemainQtyNull() { return this._routeRemainQty == null; }
        public bool IsRouteStatusNull() { return this._routeStatus == null; }
        public bool IsRouteTownshipNull() { return this._routeTownship == null; }
        public bool IsTotalPackagePriceNull() { return this._totalPackagePrice == null; }
        public bool IsTotalDeliFeeNull() { return this._totalDeliFee == null; }
        public bool IsTotalCollectMoneyNull() { return this._totalCollectMoney == null; }
        public bool IsStartDateNull() { return this._startDate == null; }
        public bool IsStartTimeNull() { return this._startTime == null; }
        public bool IsFinishDateNull() { return this._finishDate == null; }
        public bool IsFinishTimeNull() { return this._finishTime == null; }
        public bool IsCompanyIdNull() { return this._companyId == null; }
        public bool IsCreatedByNull() { return this._createdBy == null; }
        public bool IsCreatedDateNull() { return this._createdDate == null; }
        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        public bool IsUpdatedDateNull() { return this._updatedDate == null; }
        #endregion

        #region "Set Null functions"                            
        public void SetRouteIdNull() { this._routeId = null; }
        public void SetDeliverymanNameNull() { this._deliverymanName = null; }
        public void SetDeliverymanIdNull() { this._deliverymanId = null; }
        public void SetVehicleLicensePlateNull() { this._vehicleLicensePlate = null; }
        public void SetVehicleIdNull() { this._vehicleId = null; }
        public void SetPackageIdNull() { this._packageId = null; }
        public void SetPackageTotalNull() { this._packageTotal = null; }
        public void SetRouteRemainQtyNull() { this._routeRemainQty = null; }
        public void SetRouteStatusNull() { this._routeStatus = null; }
        public void SetRouteTownshipNull() { this._routeTownship = null; }
        public void SetTotalPackagePriceNull() { this._totalPackagePrice = null; }
        public void SetTotalDeliFeeNull() { this._totalDeliFee = null; }
        public void SetTotalCollectMoneyNull() { this._totalCollectMoney = null; }
        public void SetStartDateNull() { this._startDate = null; }
        public void SetStartTimeNull() { this._startTime = null; }
        public void SetFinishDateNull() { this._finishDate = null; }
        public void SetFinishTimeNull() { this._finishTime = null; }
        public void SetCompanyIdNull() { this._companyId = null; }
        public void SetCreatedByNull() { this._createdBy = null; }
        public void SetCreatedDateNull() { this._createdDate = null; }
        public void SetUpdatedByNull() { this._updatedBy = null; }
        public void SetUpdatedDateNull() { this._updatedDate = null; }
        #endregion
    }
}