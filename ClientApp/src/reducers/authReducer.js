import { FETCH_USER, KEEP_USER } from "src/actions/types";

const initialState = { key: '', name: '', userId: '', isAuth: false }

const authReducer = (state = initialState, action) => {
    switch (action.type) {        
        case FETCH_USER:
            return action.payload;      
        case KEEP_USER:
            return action.payload;     
        default:
            return state;
    }
}

export default authReducer;