// src/App.js
import React, { useState, useEffect } from 'react';
import Map from './components/Map';

const moveCloser = (start, end, factor) => {
  const lat = start[0] + (end[0] - start[0]) * factor;
  const lng = start[1] + (end[1] - start[1]) * factor;
  return [lat, lng];
};

const TrackDelivery = () => {
  const [userPosition, setUserPosition] = useState([51.505, -0.09]);
  const [deliveryPosition, setDeliveryPosition] = useState([51.515, -0.1]);

  useEffect(() => {
    const watchId = navigator.geolocation.watchPosition(
      (pos) => {
        const { latitude, longitude } = pos.coords;
        setUserPosition([latitude, longitude]);
        setDeliveryPosition([latitude + 0.5 ,  longitude + 0.5]);
      },
      (err) => {
        console.error(err);
      },
      { enableHighAccuracy: true, timeout: 20000, maximumAge: 1000 }
    );

    return () => {
      navigator.geolocation.clearWatch(watchId);
    };
  }, []);  

  useEffect(() => {
    const intervalId = setInterval(() => {
      setDeliveryPosition(prevPosition => moveCloser(prevPosition, userPosition, 0.1));
    }, 3000);

    return () => clearInterval(intervalId);
  }, [userPosition]);

  return (
    <div className="App">
      <Map userPosition={userPosition} deliveryPosition={deliveryPosition}/>
    </div>
  );
};

export default TrackDelivery;
