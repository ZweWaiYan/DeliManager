import axios from "axios";

export const FetchPackageList = async (companyId) => {
    var result = { status: true, message: "", data: null };
    var data = {
        CompanyId: companyId
    }
    try {
        const response = await axios.post(`/api/Package/FetchPackageList`, data);        
        if (response && response.status === 200) {
            result.status = true;
            return response.data;
        } else {
            result.status = false;
            result.message = "Something went wrong!";
            return result;
        }
    } catch (error) {
        result.Status = false;
        result.Message = error.message;
        return result;
    }
}

export const CreatePackage = async (packageValues, companyId) => { 

    var result = { status: true, message: "", data: null};    
    let data = {                
        PackageTitle: packageValues.packageTitle,
        PackageQty: parseInt(packageValues.packageQty),
        PackageWayProcess: 1,
        PackagePrice: parseFloat(packageValues.packagePrice),
        DeliFee: parseFloat(packageValues.deliFee),        
        CollectMoney: packageValues.collectMoney == "" ? 0 : parseFloat(packageValues.collectMoney),      
        SenderName: packageValues.senderName, 
        SenderPh: packageValues.senderPh,   
        SenderAddress: packageValues.senderAddress,    
        PickupDate: packageValues.pickupDate,
        PickupTime: packageValues.pickupTime,              
        ReceiverName: packageValues.receiverName,        
        ReceiverPh: packageValues.receiverPh,        
        ReceiverAddress: packageValues.receiverAddress,      
        RouteId : 0,          
        CompanyId: companyId,                       
    };                
    try {
        const response = await axios.post(`/api/Package/CreatePackage`, data);      
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

export const EditPackage = async (id , packageValues, companyId) => {    
    var result = { status: true, message: "", data: null};    
    let data = {        
        PackageId: id,
        CompanyId: companyId,     
        PackageTitle: packageValues.packageTitle,
        PackageQty: parseInt(packageValues.packageQty),        
        PackagePrice: parseFloat(packageValues.packagePrice),
        DeliFee: parseFloat(packageValues.deliFee),        
        CollectMoney: packageValues.collectMoney == "" ? 0 : parseFloat(packageValues.collectMoney),                
        SenderName: packageValues.senderName, 
        SenderPh: packageValues.senderPh,   
        PickupDate: packageValues.pickupDate,
        PickupTime: packageValues.pickupTime,
        SenderAddress: packageValues.senderAddress,                  
        ReceiverName: packageValues.receiverName,        
        ReceiverPh: packageValues.receiverPh,        
        ReceiverAddress: packageValues.receiverAddress,                                                  
    };                
    try {
        const response = await axios.post(`/api/Package/EditPackage`, data);           
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

export const DeletePackage = async (packageId, companyId, routeId) => {
    var result = { status: true, message: "", data: null};
    let data = {
        RouteId: routeId,
        PackageId: packageId,    
        CompanyId: companyId,
    };        
    try {
        const response = await axios.post(`/api/Package/DeletePackage`, data);
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