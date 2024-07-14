import { ADD_ROUTES } from "src/actions/types";

const initialState = {
    routes: [],    
}

const routeReducer = (state = initialState, action) => {
    switch (action.type) {
        case ADD_ROUTES:
            return { ...state, routes: state.payload }      
        default:
            return state;
    }
};
    
export default routeReducer;

