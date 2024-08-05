import axios from "axios";

export const FetchRouteList = async (companyId) => {
    var result = { Status: true, Message: "", Data: null };
    var data = {
        CompanyId: companyId
    }        
    try {
        const response = await axios.post(`/api/Route/FetchRouteList`, data);        
        if (response && response.status === 200) {
            result.Status = true;
            return response.data;
        } else {
            result.Status = false;
            result.Message = "Something went wrong";
            return result;
        }
    } catch (error) {
        result.Status = false;
        result.Message = error.message;
        return result;
    }
};

export const CreateRoute = async (RouteValues, companyId) => {    
    var result = { Status: true, Message: "", Data: null};    
    let data = {
        DeliverymanName: RouteValues.deliverymanName,
        DeliverymanId: parseInt(RouteValues.deliverymanId),        
        VehicleLicensePlate: RouteValues.vehicleLicensePlate,
        VehicleId: parseInt(RouteValues.vehicleId),        
        PackageId: RouteValues.packageId,
        PackageTotal: parseInt(RouteValues.packageTotal),  
        // RouteRemainQty: parseInt(RouteValues.routeTotalQty),      
        RouteStatus: 1,
        RouteTownship: RouteValues.routeTownship,
        TotalPackagePrice: parseInt(RouteValues.totalPackagePrice),
        TotalDeliFee: parseInt(RouteValues.totalDeliFee),        
        // TotalCollectMoney: parseInt(RouteValues.totalCollectMoney),
        StartDate: RouteValues.startDate,
        StartTime: RouteValues.startTime,
        FinishDate: RouteValues.finishDate,
        FinishTime: RouteValues.finishTime,
        CompanyId: parseInt(companyId),
    };            
    try {
        const response = await axios.post(`/api/Route/CreateRoute`, data);      
        console.log("response" , response);
        if (response && response.status === 200) {
            return response.data;
        } else {
            result.Status = false;
            result.Message = "Something went wrong";
            return result;
        }
    } catch (error) {
        if (error.response.status === 401) {
            return error.response.status;
        } else {
            result.Status = false;
            result.Message = error.Message;
            return result;
        }
    }
}

export const EditRoute = async (id , RouteValues, companyId) => {    
    var result = { Status: true, Message: "", Data: null};    
    console.log("edit value" , RouteValues);
    let data = {
        RouteId : id,
        DeliverymanName: RouteValues.deliverymanName,
        DeliverymanId: parseInt(RouteValues.deliverymanId),        
        VehicleLicensePlate: RouteValues.vehicleLicensePlate,
        VehicleId: parseInt(RouteValues.vehicleId),        
        PackageId: RouteValues.packageId,
        PackageTotal: parseInt(RouteValues.packageTotal),  
        // RouteRemainQty: parseInt(RouteValues.routeTotalQty),      
        RouteStatus: 1,
        RouteTownship: RouteValues.routeTownship,
        TotalPackagePrice: parseInt(RouteValues.totalPackagePrice),
        TotalDeliFee: parseInt(RouteValues.totalDeliFee),        
        // TotalCollectMoney: parseInt(RouteValues.totalCollectMoney),
        StartDate: RouteValues.startDate,
        StartTime: RouteValues.startTime,
        FinishDate: RouteValues.finishDate,
        FinishTime: RouteValues.finishTime,
        CompanyId: parseInt(companyId),
    };   
    console.log("editRoute" , data);   
    try {
        const response = await axios.post(`/api/Route/EditRoute`, data);      
        if (response && response.status === 200) {
            return response.data;
        } else {
            result.Status = false;
            result.Message = "Something went wrong";
            return result;
        }
    } catch (error) {
        if (error.response.status === 401) {
            return error.response.status;
        } else {
            result.Status = false;
            result.Message = error.Message;
            return result;
        }
    }
}

export const DeleteRoute = async (routeId, packageId, vehicleId, deliverymanId, companyId) => {        
    var result = { Status: true, Message: "", Data: null};
    let data = {
        RouteId: routeId,    
        PackageId : packageId,
        CompanyId: companyId,
        VehicleId: vehicleId,
        DeliverymanId: deliverymanId
    };        
    try {
        const response = await axios.post(`/api/Route/DeleteRoute`, data);
        if (response && response.status === 200) {
            return response.data;
        } else {
            result.Status = false;
            result.Message = "Something went wrong";
            return result;
        }
    } catch (error) {
        if (error.response.status === 401) {
            return error.response.status;
        } else {
            result.Status = false;
            result.Message = error.Message;
            return result;
        }
    }
}