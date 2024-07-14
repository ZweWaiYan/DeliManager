import React, { useEffect , useState} from 'react';
import { MapContainer, TileLayer, Marker, Popup , Polyline } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';
import getRoute from '../../trackdelivery/components/GetRoute';

import deliveryimg from '../../../assets/images/delivery/DeliveryIcon.png';
import userimg from '../../../assets/images/delivery/userIcon.png';

const userIcon = new L.Icon({
    iconUrl: userimg,
    iconSize: [27, 29],
    iconAnchor: [12, 41],
    popupAnchor: [1, -34],
    shadowSize: [41, 41]
  });

const deliveryIcon = new L.Icon({
    iconUrl: deliveryimg,
    iconSize: [25, 41],
    iconAnchor: [12, 41],
    popupAnchor: [1, -34],
    shadowSize: [41, 41]
});

const Map = ({ deliveryPosition, userPosition }) => {    
    const [route, setRoute] = useState([]);

    useEffect(() => {
      const fetchRoute = async () => {
        const routeData = await getRoute(deliveryPosition, userPosition);
        setRoute(routeData);
      };
  
      fetchRoute();
    }, [userPosition, deliveryPosition]);

    return (
        <MapContainer center={userPosition} zoom={13} style={{ height: '80vh', width: '100%' }}>
            <TileLayer
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            />
            <Marker position={userPosition} icon={userIcon}>
                <Popup>Package receiver location</Popup>
            </Marker>
            <Marker position={deliveryPosition} icon={deliveryIcon}>
                <Popup>Delivery location</Popup>
            </Marker>            
            <Polyline positions={route} color="blue" />
        </MapContainer>
    );
};

export default Map;