import React, { lazy } from 'react';
import { Navigate } from 'react-router-dom';
import Loadable from '../layouts/full/shared/loadable/Loadable';
import { element, exact } from 'prop-types';
import DeliveryInfo from 'src/views/deliveryInfo/DeliveryInfo';

/* ***Layouts**** */
const FullLayout = Loadable(lazy(() => import('../layouts/full/FullLayout')));
const BlankLayout = Loadable(lazy(() => import('../layouts/blank/BlankLayout')));

/* ****Pages***** */
const Dashboard = Loadable(lazy(() => import('../views/dashboard/Dashboard')))
const MockAPITable = Loadable(lazy(() => import('../views/table/mockapi-table/MockAPITable')))
const TrackDelivery = Loadable(lazy(() => import('../views/trackdelivery/TrackDelivery')))
const Error = Loadable(lazy(() => import('../views/authentication/Error')));
const Register = Loadable(lazy(() => import('../views/authentication/Register')));
const Login = Loadable(lazy(() => import('../views/authentication/Login')));

const Router = (isAuth) => [  
  {    
    path: '/',    
    element: isAuth ? <FullLayout/> : <Navigate to ="/auth/login"/>,
    children: [
      { path: '/', element: <Navigate to="/dashboard" /> },
      { path: '/dashboard', exact: true, element: <Dashboard /> },   
      { path: '/deliveryInfo', exact: true, element: <DeliveryInfo />},
      { path: '/mockapitable', exact: true, element: <MockAPITable />},     
      { path: '/trackDelivery', exact: true, element: <TrackDelivery /> },     
      { path: '*', element: <Navigate to="/auth/404" /> },      
    ],
  },
  {
    path: '/auth',
    element: <BlankLayout />,
    children: [
      { path: '404', element: <Error /> },
      { path: '/auth/register', element: <Register /> },
      { path: '/auth/login', element: <Login /> },
      { path: '*', element: <Navigate to="/auth/404" /> },
    ],
  },
];

export default Router;
