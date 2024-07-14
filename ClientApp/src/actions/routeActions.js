import { ADD_ROUTES } from "./types";

export const addRoute = (route) => ({
    type : ADD_ROUTES,
    payload : route,
});