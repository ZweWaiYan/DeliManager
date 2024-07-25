import axios from "axios";
import { FETCH_USER, KEEP_USER } from "./types";

const initialState = { key: '', name: '', userId: '', isAuth: false, forceToChangePW: false }
export const fetchUser = () => async dispatch => {
    const res = await axios.get('/api/auth/CurrentUser');
    if (res.data.data === null) {
        dispatch({ type: FETCH_USER, payload: initialState })
    }
    else if (res.data.data != null) {
        dispatch({ type: FETCH_USER, payload: res.data.data });
    }
};

export const keepUser = (userData) => async dispatch => {    
    dispatch({type : KEEP_USER , payload: userData});
};