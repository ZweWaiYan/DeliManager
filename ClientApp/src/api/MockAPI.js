import axios from "axios";
var result = { Status: true, Message: "", Data: null };

export const GetMockApiData = async () => {
    try {
        const response = await axios.get(`https://661d2de1e7b95ad7fa6c6b8b.mockapi.io/api/v1/Users`);
        if (response && response.status === 200) {
            result.Status = true;
            return response.data;
        } else {
            result.Status = false;
            result.Message = "Something went wrong";
            return result;
        }
    } catch (error) {

    }
}

export const CreateMockApiData = async (mockApiData) => {
    console.log("api mockApiData" , mockApiData);
    try {
        const response = await axios.post(`https://661d2de1e7b95ad7fa6c6b8b.mockapi.io/api/v1/Users`, mockApiData);
        if (response && response.status === 200) {
            result.Status = true;
            return result.Status;
        } else {
            result.Status = false;
            result.Message = "Something went wrong";
            return result;
        }; 
    } catch (error) {
        result.Status = false;
        result.Message = error.message;
        return result;
    }
};

export const EditMockApiData = async (id, mockApiData) => {
    try {
        const response = await axios.put(`https://661d2de1e7b95ad7fa6c6b8b.mockapi.io/api/v1/Users/${id}`, mockApiData); // Use PUT instead of POST
        if (response && response.status === 200) {
            result.Status = true;
            return result.Status;
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
            result.Message = error.message; // Use error.message instead of error.Message
            return result;
        }
    }
}

export const DeleteMockApiData = async (id) => { 
    try {
        const response = await axios.delete(`https://661d2de1e7b95ad7fa6c6b8b.mockapi.io/api/v1/Users/${id}`);
        if (response && response.status === 200) {
            result.Status = true;
            return result.Status;
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
            result.Message = error.message; // Use error.message instead of error.Message
            return result;
        }
    }
};





