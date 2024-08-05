namespace DeliManager.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using DeliManager.Common;
    public class BaseTB_VehicleEntity
    {
        #region Private fields

        //Vechicle Table
        private Int32? _vehicleId;
        private String _licensePlate;
        private String _modal;
        private String _manufacturer;
        private Int32? _deliverymanId;
        private Int32? _vehicleStatus;
        private Int32? _capacity;
        private String _insuranceExpiryDate;
        private Double? _fuelLevel;
        private Int32? _routeId;
        private Int32? _companyId;
        private String _createdBy;
        private DateTime? _createdDate;
        private String _updatedBy;
        private DateTime? _updatedDate;

        #endregion

        #region Public getter & setter

        //Vechicle Table
        public Int32? VehicleId { get { return this._vehicleId.ToNonNullable(); } set { this._vehicleId = value; } }
        public String LicensePlate { get { return this._licensePlate; } set { this._licensePlate = value; } }
        public String Modal { get { return this._modal; } set { this._modal = value; } }
        public String Manufacturer { get { return this._manufacturer; } set { this._manufacturer = value; } }
        public Int32? DeliverymanId { get { return this._deliverymanId.ToNonNullable(); } set { this._deliverymanId = value; } }
        public Int32? VehicleStatus { get { return this._vehicleStatus.ToNonNullable(); } set { this._vehicleStatus = value; } }
        public Int32? Capacity { get { return this._capacity.ToNonNullable(); } set { this._capacity = value; } }
        public String InsuranceExpiryDate { get { return this._insuranceExpiryDate; } set { this._insuranceExpiryDate = value; } }
        public Double? FuelLevel { get { return this._fuelLevel.ToNonNullable(); } set { this._fuelLevel = value; } }        
        public Int32? RouteId { get { return this._routeId.ToNonNullable(); } set { this._routeId = value; } }
        public Int32? CompanyId { get { return this._companyId.ToNonNullable(); } set { this._companyId = value; } }
        public String CreatedBy { get { return this._createdBy; } set { this._createdBy = value; } }
        public DateTime? CreatedDate { get { return this._createdDate.ToNonNullable(); } set { this._createdDate = value; } }
        public String UpdatedBy { get { return this._updatedBy; } set { this._updatedBy = value; } }
        public DateTime UpdatedDate { get { return this._updatedDate.ToNonNullable(); } set { this._updatedDate = value; } }
        
        #endregion

        #region "IsNull functions"

        //Vechicle Table
        public bool IsVehicleIdNull() { return this._vehicleId == null; }
        public bool IsLicensePlateNull() { return this._licensePlate == null; }
        public bool IsModalNull() { return this._modal == null; }
        public bool IsManufacturerNull() { return this._manufacturer == null; }
        public bool IsDeliverymanIdNull() { return this._deliverymanId == null; }
        public bool IsVehicleStatusNull() { return this._vehicleStatus == null; }
        public bool IsCapacityNull() { return this._capacity == null; }
        public bool IsInsuranceExpiryDateNull() { return this._insuranceExpiryDate == null; }
        public bool IsFuelLevelNull() { return this._fuelLevel == null; }
        public bool IsRouteIdNull() { return this._routeId == null; }
        public bool IsCompanyIdNull() { return this._companyId == null; }
        public bool IsCreatedByNull() { return this._createdBy == null; }
        public bool IsCreatedDateNull() { return this._createdDate == null; }
        public bool IsUpdatedByNull() { return this._updatedBy == null; }
        public bool IsUpdatedDateNull() { return this._updatedDate == null; }      

        #endregion

        #region "SetNull functions"
        //Vehicle Table
        public void SetVehicleIdNull() { this._vehicleId = null; }
        public void SetLicensePlateNull() { this._licensePlate = null; }
        public void SetModalNull() { this._modal = null; }
        public void SetManufacturerNull() { this._manufacturer = null; }
        public void SetDeliverymanIdNull() { this._deliverymanId = null; }
        public void SetVehicleStatusNull() { this._vehicleStatus = null; }
        public void SetCapacityNull() { this._capacity = null; }
        public void SetInsuranceExpiryDateNull() { this._insuranceExpiryDate = null; }
        public void SetFuelLevelNull() { this._fuelLevel = null; }
        public void SetIsRouteIdNull() { this._routeId = null; }     
        public void SetIsCompanyIdNull() { this._companyId = null; }     
        public void SetCreatedByNull() { this._createdBy = null; }
        public void SetCreatedDateNull() { this._createdDate = null; }
        public void SetUpdatedByNull() { this._updatedBy = null; }
        public void SetUpdatedDateNull() { this._updatedDate = null; }
        #endregion
    }
}
