// src/utils/getRoute.js
import axios from 'axios';

const getRoute = async (start, end) => {
  const url = `http://router.project-osrm.org/route/v1/driving/${start[1]},${start[0]};${end[1]},${end[0]}`;
  const params = {
    overview: 'full',
    geometries: 'geojson'
  };

  try {
    const response = await axios.get(url, { params });
    const { routes } = response.data;
    if (routes && routes.length > 0) {
      return routes[0].geometry.coordinates.map(coord => [coord[1], coord[0]]);
    } else {
      throw new Error('No routes found');
    }
  } catch (error) {
    console.error('Error fetching route:', error);
    return [];
  }
};

export default getRoute;

