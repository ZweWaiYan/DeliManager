import axios from "axios";

export const FetchDeliverymanList = async (companyId) => {
    var result = { status: true, message: "", data: null };
    var data = {
        CompanyId: companyId
    }        
    try {
        const response = await axios.post(`/api/Deliveryman/FetchDeliverymanList`, data);        
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

export const CreateDeliveryman = async (deliverymanValues, companyId) => {
    var result = { status: true, message: "", data: null};        
    let data = {
        DeliverymanName: deliverymanValues.deliverymanName,
        DeliverymanPh: deliverymanValues.deliverymanPh,        
        DeliverymanAddress: deliverymanValues.deliverymanAddress,
        DeliverymanStatus : 1,
        DeliverymanNRC: deliverymanValues.deliverymanNRC,
        DeliverymanLicenseNo: deliverymanValues.deliverymanLicenseNo,
        // DeliverymanImage: deliverymanValues.DeliverymanImage.value,
        RouteId : 0,
        DeliverymanAge: parseInt(deliverymanValues.deliverymanAge),
        CompanyId: companyId,
    };             
    try {
        const response = await axios.post(`/api/Deliveryman/CreateDeliveryman`, data);            
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

export const EditDeliveryman = async (id , deliverymanValues, companyId) => {    
    var result = { status: true, message: "", data: null};    
    let data = {
        DeliverymanId: id,
        DeliverymanName: deliverymanValues.deliverymanName,
        DeliverymanPh: deliverymanValues.deliverymanPh,        
        DeliverymanAddress: deliverymanValues.deliverymanAddress,
        DeliverymanStatus : 1,
        DeliverymanNRC: deliverymanValues.deliverymanNRC,
        DeliverymanLicenseNo: deliverymanValues.deliverymanLicenseNo,
        // DeliverymanImage: deliverymanValues.DeliverymanImage.value,
        DeliverymanAge: parseInt(deliverymanValues.deliverymanAge),
        CompanyId: companyId,
    };            
    try {
        const response = await axios.post(`/api/Deliveryman/EditDeliveryman`, data);      
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

export const DeleteDeliveryman = async (deliverymanId, companyId, routeId) => {
    var result = { status: true, message: "", data: null};    
    let data = {
        RouteId: routeId,
        DeliverymanId: deliverymanId,    
        CompanyId: companyId,
    };        
    try {
        const response = await axios.post(`/api/Deliveryman/DeleteDeliveryman`, data);            
        if (response.data.status && response.status === 200) {
            return response.data;
        } else {
            result.status = false;
            result.message = response.data.message;
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