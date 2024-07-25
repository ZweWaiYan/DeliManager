import {
  IconLayoutDashboard, IconTable, IconPackgeExport,
  IconUsers, IconPackages, IconRoute,
  IconCar
} from '@tabler/icons';
import { icon } from 'leaflet';

import { uniqueId } from 'lodash';

const Menuitems = [
  {
    navlabel: true,
    subheader: 'Home',
  },
  {
    id: uniqueId(),
    title: 'Dashboard',
    icon: IconLayoutDashboard,
    href: '/dashboard',
  },
  {
    navlabel: true,
    subheader: 'Table',
  },
  {
    id: uniqueId(),
    title: 'MockAPI Table',
    icon: IconTable,
    href: '/mockapitable',
  },
  {
    navlabel: true,
    subheader: 'Delivery',
  },
  {
    id: uniqueId(),
    title: 'Track Delivery',
    icon: IconPackgeExport,
    href: '/trackdelivery',
  },
  {
    id: uniqueId(),
    title: 'Delivery Info',
    icon: IconUsers,
    href: '/deliveryinfo',
  },  
  {
    id: uniqueId(),
    title: 'Vehicle Info',
    icon: IconCar,
    href: '/vehicleinfo',
  },
  {
    id: uniqueId(),
    title: 'Package Info',
    icon: IconPackages,
    href: '/packageinfo',
  },
  {
    id: uniqueId(),
    title: 'Route',
    icon: IconRoute,
    href: '/routeinfo',
  }
]

export default Menuitems;
