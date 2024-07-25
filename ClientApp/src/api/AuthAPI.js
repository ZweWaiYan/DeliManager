import axios from "axios";

export const signIn = async (values) => {    
    var result = { Status: true, Message: "", Data: null };
    try {
        const response = await axios.post(`/api/Auth/SignIn`, values );
        if (response && response.status === 200) {            
            return response.data;
        } else {
            result.Status = false;
            result.Message = "Something went wrong";
            return result;
        }
    }
    catch (error) {
        if (error.response.status === 401) {
            return error.response.status;
        } else {
            result.Status = false;
            result.Message = error.Message;
            return result;
        }
    }
}