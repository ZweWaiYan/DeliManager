import { configureStore } from '@reduxjs/toolkit';
import routeReducer from './../reducers/routeReducer';
import authReducer from 'src/reducers/authReducer';

const store = configureStore({
    reducer : {
        route : routeReducer,
        auth : authReducer,
    }
});

export default store;
