import { Modal } from "@mui/material";
import axios from "axios";

export const FetchVehicleList = async (companyId) => {
    var result = { status: true, message: "", data: null };
    var data = {
        CompanyId: companyId
    }            
    try {
        const response = await axios.post(`/api/Vehicle/FetchVehicleList`, data);                
        if (response && response.status === 200) {
            result.status = true;
            return response.data;
        } else {
            result.status = false;
            result.message = "Something went wrong";
            return result;
        }
    } catch (error) {
        result.status = false;
        result.message = error.message;
        return result;
    }
};

export const CreateVehicle = async (VehicleValues, companyId) => {
    var result = { status: true, message: "", data: null};    
    let data = {            
        LicensePlate: VehicleValues.licensePlate,
        Modal: VehicleValues.modal,
        Manufacturer: VehicleValues.manufacturer,
        VehicleStatus: 1,        
        DeliverymanId : 0,
        Capacity: parseInt(VehicleValues.capacity),
        insuranceExpiryDate: VehicleValues.insuranceExpiryDate,
        FuelLevel: parseFloat(VehicleValues.fuelLevel),
        RouteId : 0,
        CompanyId: companyId,
    };            
    try {
        const response = await axios.post(`/api/Vehicle/CreateVehicle`, data);      
        if (response && response.status === 200) {
            return response.data;
        } else {
            result.status = false;
            result.message = "Something went wrong";
            return result;
        }
    } catch (error) {
        if (error.response.status === 401) {
            return error.response.status;
        } else {
            result.status = false;
            result.message = error.Message;
            return result;
        }
    }
}

export const EditVehicle = async (id , VehicleValues, companyId) => {    
    var result = { status: true, message: "", data: null};        
    let data = {
        VehicleId: id,       
        LicensePlate: VehicleValues.licensePlate,
        Modal: VehicleValues.modal,
        Manufacturer: VehicleValues.manufacturer,
        DeliverymanId : parseInt(VehicleValues.deliveryId),        
        VehicleStatus: 1,
        Capacity: parseInt(VehicleValues.capacity),
        insuranceExpiryDate: VehicleValues.insuranceExpiryDate,
        FuelLevel: parseFloat(VehicleValues.fuelLevel),
        CompanyId: companyId,
    };            
    try {
        const response = await axios.post(`/api/Vehicle/EditVehicle`, data);              
        if (response && response.status === 200) {
            return response.data;
        } else {
            result.status = false;
            result.message = "Something went wrong";
            return result;
        }
    } catch (error) {
        if (error.response.status === 401) {
            return error.response.status;
        } else {
            result.status = false;
            result.message = error.Message;
            return result;
        }
    }
}

export const DeleteVehicle = async (vehicleId, companyId, routeId) => {
    var result = { status: true, message: "", data: null};
    let data = {
        RouteId: routeId,
        VehicleId: vehicleId,    
        CompanyId: companyId,
    };    
    try {
        const response = await axios.post(`/api/Vehicle/DeleteVehicle`, data);
        if (response && response.status === 200) {
            return response.data;
        } else {
            result.status = false;
            result.message = "Something went wrong";
            return result;
        }
    } catch (error) {
        if (error.response.status === 401) {
            return error.response.status;
        } else {
            result.status = false;
            result.message = error.Message;
            return result;
        }
    }
}