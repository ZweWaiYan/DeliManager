import React, { useEffect, useState, useRef } from 'react';
import {
    Typography, Box,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    Button,
    Modal,
    TextField,
    CardContent, Stack, Snackbar, Alert, Select, MenuItem, InputAdornment, FormControl, Tooltip, Fab,
    Checkbox
} from '@mui/material';
import IconButton from '@mui/material/IconButton';

import dayjs from 'dayjs';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { TimePicker } from '@mui/x-date-pickers';

import customParseFormat from 'dayjs/plugin/customParseFormat';

import vehicleStatus from '../utilities/VehicleStatus';
import routeStatus from '../utilities/RouteStatus';
import deliverymanStatus from '../utilities/DeliverymanStatus';

import {
    IconPlus,
    IconFilter,
    IconSearch,
    IconClockCancel,
} from '@tabler/icons';
import { type } from '@testing-library/user-event/dist/type';
import PackageWayProcess from '../utilities/PackageWayProcess';

//Delete Modal Style
const deleteModalStyle = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 350,
    maxHeight: '95vh',
    bgcolor: 'background.paper',
    display: 'block',
    boxShadow: 15,
    p: 4,
    overflowY: 'auto',
};

//Create & Edit Modal Style
const createEditModalStyle = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 500,
    maxHeight: '95vh',
    bgcolor: 'background.paper',
    display: 'block',
    boxShadow: 15,
    p: 4,
    overflowY: 'auto',
};

//Delivery Modal Style
const deliveryModalStyle = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    maxHeight: '95vh',
    bgcolor: 'background.paper',
    display: 'block',
    boxShadow: 15,
    p: 4,
    overflowY: 'auto',
    borderRadius: 2,
};


const RouteTable = ({ title, titleButton, tableTitle, tableData, deliverymanColumnList, packageColumList, packageDateList, deliverymanDataList, vehicleColumnList, vehicleDateList, totalCount, companyId, onCreate, onEdit, onDelete, apiResponse }) => {

    console.log("Route Table Render");

    const [modalState, setModalState] = useState({
        open: false,
        type: 'create',
        rowIndex: null
    });

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Vehicle Session

    //Modal Function for choose Vehicle 
    const [vehicleModalState, setVehicleModalState] = useState({ open: false });
    const openVehicleModal = () => setVehicleModalState({ open: true });
    const closeVehicleModal = () => setVehicleModalState({ open: false });

    //Vehicle CheckBox for Vehicle inside of Modal
    const [selectedVehicle, setSelectedVehicle] = useState({ vehicleLicensePlate: '', vehicleId: null });

    //Vehicle CheckBox function
    const handleVehicleSelect = (row) => {
        if (selectedVehicle.vehicleId === row.vehicleId) {
            setSelectedVehicle({ vehicleLicensePlate: '', vehicleId: null });
        } else {
            setSelectedVehicle({ vehicleLicensePlate: row.licensePlate, vehicleId: row.vehicleId });
        }
    };

    //Modal for choose vehicle
    const vehicleModalContent = () => {

        return (
            <Box sx={deliveryModalStyle}>
                <Box sx={{ overflow: 'auto', width: { xs: '100px', sm: 'auto' } }}>
                    <Table aria-label="simple table" sx={{ whiteSpace: "nowrap" }}>
                        <TableHead>
                            <TableRow>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        Choose
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {vehicleColumnList[1]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {vehicleColumnList[2]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {vehicleColumnList[3]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {vehicleColumnList[9]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {vehicleColumnList[6]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {vehicleColumnList[8]}
                                    </Typography>
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        {vehicleColumnList.length === 0 ?
                            <TableBody>
                                <TableRow>
                                    <TableCell colSpan={tableTitle.length + 1} style={{ textAlign: 'center', padding: '50px' }}>
                                        <div style={{ fontSize: '20px', fontWeight: 'bold', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                                            No Data
                                        </div>
                                    </TableCell>
                                </TableRow>
                            </TableBody>
                            :
                            <TableBody>
                                {vehicleDateList.map((row, rowIndex) => {
                                    if (row.routeId === textFieldRefs.current.routeId || row.routeId === 0) {
                                        return (
                                            < TableRow
                                                key={rowIndex}
                                                hover
                                                style={{ cursor: row.vehicleStatus === 1 ? 'pointer' : 'not-allowed' }}
                                            >
                                                < TableCell style={{ textAlign: 'center' }}>
                                                    <Checkbox
                                                        checked={selectedVehicle.vehicleId === row.vehicleId}
                                                        onChange={() => handleVehicleSelect(row)}
                                                        disabled={row.vehicleStatus !== 1}
                                                    />
                                                </TableCell>
                                                < TableCell style={{ textAlign: 'center' }}> {row.licensePlate}  </TableCell>
                                                < TableCell style={{ textAlign: 'center' }}> {row.modal}  </TableCell>
                                                < TableCell style={{ textAlign: 'center' }}> {row.manufacturer} </TableCell>
                                                {/* < TableCell style={{ textAlign: 'center' }}> {getVehicleStatus(row.vehicleStatus)} </TableCell> */}
                                                < TableCell style={{ textAlign: 'center' }}> {row.routeId} </TableCell>
                                                < TableCell style={{ textAlign: 'center' }}> {row.capacity} </TableCell>
                                                < TableCell style={{ textAlign: 'center' }}> {row.fuelLevel} </TableCell>
                                            </TableRow>
                                        )
                                    }
                                })}
                            </TableBody>
                        }
                    </Table>
                    <Box sx={{ display: 'flex', justifyContent: 'space-between', mt: 2 }}>
                        <Button onClick={closeVehicleModal} sx={{ marginTop: '15px', marginLeft: '20px' }} type="submit" variant="contained" color="primary">
                            Done
                        </Button>
                    </Box>
                </Box >
            </Box >
        );
    }

    //Vehicle Session
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Deliveryman Session

    //Modal Function for choose Vehicle 
    const [deliverymanModalState, setDeliverymanModalState] = useState({ open: false });
    const openDeliverymanModal = () => setDeliverymanModalState({ open: true });
    const closeDeliverymanModal = () => setDeliverymanModalState({ open: false });

    //Vehicle CheckBox for Vehicle inside of Modal
    const [selectedDeliveryman, setSelectedDeliveryman] = useState({ deliverymanName: '', deliverymanId: null });

    //Vehicle CheckBox function
    const handleDeliverymanSelect = (row) => {
        if (selectedDeliveryman.deliverymanId === row.deliverymanId) {
            setSelectedDeliveryman({ deliverymanName: '', deliverymanId: null });
        } else {
            setSelectedDeliveryman({ deliverymanName: row.deliverymanName, deliverymanId: row.deliverymanId });
        }
    };

    //Modal for choose deliveryman
    const deliverymanModalContent = () => {

        return (
            <Box sx={deliveryModalStyle}>
                <Box sx={{ overflow: 'auto', width: { xs: '100px', sm: 'auto' } }}>
                    <Table aria-label="simple table" sx={{ whiteSpace: "nowrap" }}>
                        <TableHead>
                            <TableRow>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        Choose
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {deliverymanColumnList[1]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {deliverymanColumnList[2]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {deliverymanColumnList[9]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {deliverymanColumnList[5]}
                                    </Typography>
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        {deliverymanDataList.length === 0 ?
                            <TableBody>
                                <TableRow>
                                    <TableCell colSpan={tableTitle.length + 1} style={{ textAlign: 'center', padding: '50px' }}>
                                        <div style={{ fontSize: '20px', fontWeight: 'bold', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                                            No Data
                                        </div>
                                    </TableCell>
                                </TableRow>
                            </TableBody>
                            :
                            <TableBody>
                                {deliverymanDataList.map((row, rowIndex) => {                                    
                                    if (row.routeId === textFieldRefs.current.routeId || row.routeId === 0) {
                                        return (
                                            < TableRow
                                                key={rowIndex}
                                                hover
                                                style={{ cursor: row.deliverymanStatus === 1 ? 'pointer' : 'not-allowed' }}
                                            >
                                                < TableCell style={{ textAlign: 'center' }}>
                                                    <Checkbox
                                                        checked={selectedDeliveryman.deliverymanId === row.deliverymanId}
                                                        onChange={() => handleDeliverymanSelect(row)}
                                                        disabled={row.deliverymanStatus !== 1}
                                                    />
                                                </TableCell>
                                                < TableCell style={{ textAlign: 'center' }}> {row.deliverymanName}  </TableCell>
                                                < TableCell style={{ textAlign: 'center' }}> {row.deliverymanPh}  </TableCell>
                                                {/* < TableCell style={{ textAlign: 'center' }}> {getDeliverymanStatusById(row.deliverymanStatus)} </TableCell> */}
                                                < TableCell style={{ textAlign: 'center' }}> {row.routeId} </TableCell>
                                                < TableCell style={{ textAlign: 'center' }}> {row.deliverymanLicenseNo} </TableCell>
                                            </TableRow>
                                        )
                                    }
                                })}
                            </TableBody>
                        }
                    </Table>
                    <Box sx={{ display: 'flex', justifyContent: 'space-between', mt: 2 }}>
                        <Button onClick={closeDeliverymanModal} sx={{ marginTop: '15px', marginLeft: '20px' }} type="submit" variant="contained" color="primary">
                            Done
                        </Button>
                    </Box>
                </Box >
            </Box >
        );
    }

    //Deliveryman Session
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Package Session

    //Modal Function for choose Package 
    const [packageModalState, setPackageModalState] = useState({ open: false });
    const openPackageModal = () => setPackageModalState({ open: true });
    const closePackageModal = () => setPackageModalState({ open: false });

    const [selectedPackage, setselectedPackage] = useState([]);

    const handlePackageSelect = (row) => {


        setselectedPackage(prevSelectedPackage => {
            const isSelected = prevSelectedPackage.some(selectedRow => selectedRow.packageId === row.packageId);
            let newSelectedPackage;

            if (isSelected) {
                // Deselect row
                newSelectedPackage = prevSelectedPackage.filter(selectedRow => selectedRow.packageId !== row.packageId);
            } else {
                // Select row
                newSelectedPackage = [...prevSelectedPackage, row];
            }

            return newSelectedPackage;
        });
    };

    //Modal for choose vehicle  
    const packageModalContent = () => {

        return (
            <Box sx={deliveryModalStyle}>
                <Box sx={{ overflow: 'auto', width: { xs: '100px', sm: 'auto' } }}>
                    <Table aria-label="simple table" sx={{ whiteSpace: "nowrap" }}>
                        <TableHead>
                            <TableRow>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        Choose
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {packageColumList[2]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {packageColumList[18]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {packageColumList[3]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {packageColumList[5]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {packageColumList[8]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {packageColumList[10]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {packageColumList[13]}
                                    </Typography>
                                </TableCell>
                                <TableCell style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {packageColumList[15]}
                                    </Typography>
                                </TableCell>
                            </TableRow>
                        </TableHead>
                        {packageColumList.length === 0 ? (
                            <TableBody>
                                <TableRow>
                                    <TableCell colSpan={tableTitle.length + 1} style={{ textAlign: 'center', padding: '50px' }}>
                                        <div style={{ fontSize: '20px', fontWeight: 'bold', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                                            No Data
                                        </div>
                                    </TableCell>
                                </TableRow>
                            </TableBody>
                        ) : (
                            <TableBody>
                                {packageDateList.map((row, rowIndex) => {
                                    if (row.routeId === textFieldRefs.current.routeId || row.routeId === 0) {
                                        return (
                                            <TableRow key={rowIndex} hover style={{ cursor: 'pointer' }}>
                                                <TableCell style={{ textAlign: 'center' }}>
                                                    <Checkbox
                                                        onChange={() => handlePackageSelect(row)}
                                                        checked={selectedPackage.some(selectedRow => selectedRow.packageId === row.packageId)}
                                                    />
                                                </TableCell>
                                                <TableCell style={{ textAlign: 'center' }}> {row.packageTitle} </TableCell>
                                                <TableCell style={{ textAlign: 'center' }}> {row.routeId} </TableCell>
                                                <TableCell style={{ textAlign: 'center' }}> {row.packageQty} </TableCell>
                                                <TableCell style={{ textAlign: 'center' }}> {row.packagePrice} </TableCell>
                                                <TableCell style={{ textAlign: 'center' }}> {row.senderName} </TableCell>
                                                <TableCell style={{
                                                    textAlign: 'center',
                                                    maxWidth: '150px', // Adjust max-width as needed
                                                    whiteSpace: 'nowrap',
                                                    overflow: 'hidden',
                                                    textOverflow: 'ellipsis'
                                                }}> <Tooltip title={row.senderAddress}>
                                                        <span>{row.senderAddress}</span>
                                                    </Tooltip> </TableCell>
                                                <TableCell style={{
                                                    textAlign: 'center',
                                                    maxWidth: '150px', // Adjust max-width as needed
                                                    whiteSpace: 'nowrap',
                                                    overflow: 'hidden',
                                                    textOverflow: 'ellipsis'
                                                }}> {row.receiverName} </TableCell>
                                                <TableCell style={{
                                                    textAlign: 'center',
                                                    maxWidth: '150px', // Adjust max-width as needed
                                                    whiteSpace: 'nowrap',
                                                    overflow: 'hidden',
                                                    textOverflow: 'ellipsis'
                                                }}>  <Tooltip title={row.receiverAddress}>
                                                        <span>{row.receiverAddress}</span>
                                                    </Tooltip></TableCell>
                                            </TableRow>
                                        )
                                    }
                                })}
                            </TableBody>
                        )}
                    </Table>
                    <Box sx={{ display: 'flex', justifyContent: 'space-between', mt: 2 }}>
                        <Button onClick={closePackageModal} sx={{ marginTop: '15px', marginLeft: '20px' }} type="submit" variant="contained" color="primary">
                            Done
                        </Button>
                    </Box>
                </Box>
            </Box>

        );
    }

    //Package Session
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Common Session

    dayjs.extend(customParseFormat);

    const [snackBarState, setSnackBarState] = useState({
        open: false,
        // message: '',
        // severity: 'success'
    });

    //Store All Route Date
    const textFieldRefs = useRef({});

    const deletePackage = useRef();
    const deleteVehicle = useRef();
    const deleteDeliveryman = useRef();

    const [errors, setErrors] = useState({});

    const [totalPackagePrice, setTotalPackagePrice] = useState(0);
    const [totalDeliFee, setTotalDeliFee] = useState(0);

    const searchRef = useRef('');

    const [filteredData, setFilteredData] = useState(tableData);
    const [filtermodalState, setFilterModalState] = useState({
        open: false,
    });

    const [menuFilter, setMenuFilter] = useState({
        //for table               
        packageTotal: '',
        routeRemainQty: '',
        routeStatus: '',
        routeTownship: '',
        totalPackagePrice: '',
        totalDeliFee: '',
        totalCollectMoney: '',
        startDate: '',
        finishDate: '',
    });

    //UseEffect for TotalPackagePrice and TotalDeliFee
    useEffect(() => {
        const totalDeliFee = selectedPackage.reduce((sum, pkg) => sum + pkg.deliFee, 0);
        const totalPackagePrice = selectedPackage.reduce((sum, pkg) => sum + pkg.packagePrice, 0);

        setTotalDeliFee(totalDeliFee);
        setTotalPackagePrice(totalPackagePrice);

    }, [selectedPackage]);

    //Modal Function for common textField
    const openModal = (type, data = {}, rowIndex = null) => {

        setErrors({});
        setModalState({ open: true, type, rowIndex });
        if (type === 'delete') {
            deletePackage.current = data.packageId
            deleteVehicle.current = data.vehicleId
            deleteDeliveryman.current = data.deliverymanId
        }

        const isEmptyData = Object.keys(data).length === 0;
        if (!isEmptyData && type !== 'delete') {

            //set select package
            const existingPackageIds = data.packageId;
            const preSelectedPackages = existingPackageIds.split(',').map(id => {
                return packageDateList.find(pkg => pkg.packageId === parseInt(id));
            }).filter(pkg => pkg !== undefined);
            setselectedPackage(preSelectedPackages);

            textFieldRefs.current['routeId'] = data['routeId'];

            tableTitle.slice(1).forEach((key) => {
                var lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
                switch (key) {
                    case 'DeliverymanName':
                        setSelectedDeliveryman({ deliverymanName: data[lowerKey] || '', deliverymanId: data['deliverymanId'] || 0 });
                        break;
                    case 'VehicleLicensePlate':
                        setSelectedVehicle({ vehicleLicensePlate: data[lowerKey] || '', vehicleId: data['vehicleId'] || 0 });
                        break;
                    default:
                        textFieldRefs.current[lowerKey] = data[lowerKey] || '';
                        break;
                }
            });
        }
    }

    //Modal Function for common textField
    const closeModal = () => {
        setselectedPackage([]);
        setModalState({ open: false, type: 'create', rowIndex: null });
        setSelectedDeliveryman({ deliverymanName: '', deliverymanId: null });
        setSelectedVehicle({ vehicleLicensePlate: '', vehicleId: null });
        setFilterModalState({ open: false });
    };

    useEffect(() => {
        setFilteredData(tableData);
    }, [tableData]);

    //Edit Function
    const handleEdit = (rowData, rowIndex) => openModal('edit', rowData, rowIndex);

    //Delete Function
    const handleDelete = (rowData, rowIndex) => openModal('delete', rowData, rowIndex);

    const validate = () => {

        const newErrors = {};

        const routeValidationRules = {
            deliverymanName: [
                {
                    test: value => value.trim() === "",
                    message: "Name must not be empty"
                }
            ],
            vehicleLicensePlate: [
                {
                    test: value => value.trim() === "",
                    message: "LicensePlate must not be empty"
                }
            ],
            packageId: [
                {
                    test: value => value === 0,
                    message: "Package must not be empty"
                }
            ],
            routeTownship: [
                {
                    test: value => value.trim() === "",
                    message: "TownShip must not be empty"
                }
            ]
        }

        Object.keys(routeValidationRules).forEach((field) => {

            let fieldValue = '';

            switch (field) {
                case 'routeTownship':
                    fieldValue = textFieldRefs.current['routeTownship'].value || '';
                    break;
                case 'deliverymanName':
                    fieldValue = selectedDeliveryman.deliverymanName || '';
                    break;
                case 'vehicleLicensePlate':
                    fieldValue = selectedVehicle.vehicleLicensePlate || '';
                    break;
                case 'packageId':
                    fieldValue = selectedPackage.length;
                    break;
                default:
                    // fieldValue = '';
                    break;
            }

            newErrors[field] = [];

            routeValidationRules[field].forEach((rule) => {

                if (rule.test(fieldValue)) {
                    newErrors[field].push(rule.message);
                }
            })

            if (newErrors[field].length === 0) {
                delete newErrors[field];
            }
        });

        setErrors(newErrors);
        return Object.keys(newErrors).length === 0;
    }

    //Submit Function for create new route
    const handleSubmit = (e) => {
        e.preventDefault();
        const { type, rowIndex } = modalState;
        const data = {};

        let operation;

        if (type === 'delete') {
            operation = onDelete(getClickedRowId(rowIndex), deletePackage.current, deleteVehicle.current, deleteDeliveryman.current, companyId);
            operation.then(() => { setSnackBarState({ open: true }) });

            closeModal();
        }

        if (type !== 'delete' && validate()) {

            Object.keys(textFieldRefs.current).forEach((key) => {
                data[key] = textFieldRefs.current[key].value;
            });

            const packageId = selectedPackage.map(pkg => pkg.packageId).join(', ');

            data['deliverymanId'] = selectedDeliveryman.deliverymanId
            data['deliverymanName'] = selectedDeliveryman.deliverymanName
            data['vehicleLicensePlate'] = selectedVehicle.vehicleLicensePlate
            data['vehicleId'] = selectedVehicle.vehicleId
            data['packageId'] = packageId
            data['packageTotal'] = selectedPackage.length
            data['totalPackagePrice'] = totalPackagePrice
            data['totalDeliFee'] = totalDeliFee

            switch (type) {
                case 'create':
                    operation = onCreate(data, companyId);
                    break;
                case 'edit':
                    operation = onEdit(getClickedRowId(rowIndex), data, companyId);
                    break;
            }

            operation.then(() => { setSnackBarState({ open: true }) });
            closeModal();
        }
    };

    //After create route show snackBar / Toast dialog
    const handleCloseSnackbar = () => {
        setSnackBarState({ open: false, message: '', severity: 'success' });
    };

    //Search and Filter
    const handleSearch = (event) => {

        const { name, value } = event.target;

        searchRef.current = value.toLowerCase();

        let filteredData = tableData;

        if (searchRef.current) {
            filteredData = filteredData.filter(item => {
                return item.deliverymanName.toLowerCase().includes(searchRef.current) ||
                    item.vehicleLicensePlate.toLowerCase().includes(searchRef.current) ||
                    item.routeTownship.toLowerCase().includes(searchRef.current)
            });
        }

        setFilteredData(filteredData);
    };

    const openFilterModal = () => {
        setFilterModalState({ open: true });
    }

    const handleFilterBtn = () => {
        handleFilter();
    }

    const handleRemoveFilterBtn = () => {
        setMenuFilter({
            //filtered or not
            filtered: false,

            packageStatus: '',
        });
        closeModal();
        setFilteredData(tableData);
    }

    const handleFilter = () => {

        let filteredData = tableData;

        const filterMap = {
            packageTotal: (item, value) => item.packageTotal === value,
            routeRemainQty: (item, value) => item.routeRemainQty === value,
            routeTownship: (item, value) => item.routeTownship === value,
            routeStatus: (item, value) => item.routeStatus === value,
            totalPackagePrice: (item, value) => item.totalPackagePrice === value,
            totalDeliFee: (item, value) => item.totalDeliFee === value,
            totalCollectMoney: (item, value) => item.totalCollectMoney === value,
            startDate: (item, value) => item.startDate === value,
            startTime: (item, value) => item.startTime === value,
            finishDate: (item, value) => item.finishDate === value,
            finishTime: (item, value) => item.finishTime === value,
        }

        Object.keys(menuFilter).forEach((key) => {
            if (menuFilter[key] && filterMap[key]) {
                filteredData = filteredData.filter(item => {
                    return filterMap[key](item, menuFilter[key])
                });
            }
        })

        setFilteredData(filteredData);
    }

    const getStatusSwitchData = () => {
        return routeStatus.map((item, index) => (
            <MenuItem key={index} divider value={item.id}>{item.status}</MenuItem>
        ))
    }

    const getSwitchData = (type) => {

        const seenValues = new Set();

        return tableData.filter((item) => {
            const value = item[type];
            if (value === 0 || seenValues.has(value)) {
                return false;
            }
            seenValues.add(value);
            return true;
        })
            .map(item => item[type])
            .sort((a, b) => a - b)
            .map((value, index) => (
                <MenuItem key={index} divider value={value}>{value}</MenuItem>
            ));


    }

    const getFilterValue = (event) => {

        const { name, value } = event.target;

        setMenuFilter((menuFilter) => ({
            ...menuFilter,
            [name]: value
        }));
    }

    const getFilterDate = (name, newValue) => {

        const formattedDate = dayjs(newValue).format('MM/DD/YYYY')

        setMenuFilter((menuFilter) => ({
            ...menuFilter,
            [name]: formattedDate,
        }));
    }

    const removeDateFilter = () => {
        setMenuFilter((menuFilter) => ({
            ...menuFilter,
            startDate: null,
            finishDate: null,
        }));
    }

    const filterModalContent = () => {

        return (
            <Box sx={createEditModalStyle}>
                <Typography sx={{ mb: '30px' }} variant="h6">
                    Route Filter
                </Typography>
                {/* Start Date and Finish Date Session */}
                <Stack
                    direction={'row'}
                    spacing={2}
                    justifyContent="flex-start"
                >
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker
                            label="Start Date"
                            value={menuFilter.startDate ? dayjs(menuFilter.startDate, "MM/DD/YYYY") : null}
                            onChange={(newValue) => getFilterDate('startDate', newValue)}
                        />
                    </LocalizationProvider>
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker
                            label="End Date"
                            value={menuFilter.finishDate ? dayjs(menuFilter.finishDate, "MM/DD/YYYY") : null}
                            onChange={(newValue) => getFilterDate('finishDate', newValue)}
                        />
                    </LocalizationProvider>
                    <Tooltip title="Remove Date Filter">
                        <IconButton onClick={removeDateFilter}>
                            <IconClockCancel />
                        </IconButton>
                    </Tooltip>
                </Stack>
                {/* PackageTotal and RouteRemainQty Session */}
                <Stack
                    direction={'row'}
                    spacing={2}
                    justifyContent="space-between"
                    sx={{ mb: '20px', mt: '20px' }}
                >
                    <FormControl fullWidth sx={{ mb: '20px' }}>
                        <TextField
                            select
                            label="PackageTotal"
                            name="packageTotal"
                            value={menuFilter.packageTotal}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>None</MenuItem>
                            {getSwitchData("packageTotal")}
                        </TextField>
                    </FormControl>
                    <FormControl fullWidth sx={{ mb: '20px' }}>
                        <TextField
                            select
                            label="RouteRemainQty"
                            name="routeRemainQty"
                            value={menuFilter.routeRemainQty}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>None</MenuItem>
                            {getSwitchData("routeRemainQty")}
                        </TextField>
                    </FormControl>
                </Stack>
                {/* Package Wap Process session */}
                <FormControl fullWidth sx={{ mb: '20px' }}>
                    <TextField
                        select
                        label="Route Status"
                        name="routeStatus"
                        value={menuFilter.routeStatus}
                        onChange={getFilterValue}
                        variant="outlined"
                    >
                        <MenuItem value={0} divider>None</MenuItem>
                        {getStatusSwitchData()}
                    </TextField>
                </FormControl>
                {/* RouteTownShip session */}
                <FormControl fullWidth sx={{ mb: '20px' }}>
                    <TextField
                        select
                        label="RouteTownShip"
                        name="routeTownship"
                        value={menuFilter.routeTownship}
                        onChange={getFilterValue}
                        variant="outlined"
                    >
                        <MenuItem value={0} divider>None</MenuItem>
                        {getSwitchData("routeTownship")}
                    </TextField>
                </FormControl>
                {/* TotalPackagePrice & TotalDeliFee & TotalCollectMoney*/}
                <Stack
                    direction={'row'}
                    spacing={2}
                    justifyContent="space-between"
                    sx={{ mb: '20px' }}
                >
                    <FormControl fullWidth sx={{ mb: '20px' }}>
                        <TextField
                            select
                            label="PackagePrice"
                            name="totalPackagePrice"
                            value={menuFilter.totalPackagePrice}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>None</MenuItem>
                            {getSwitchData("totalPackagePrice")}
                        </TextField>
                    </FormControl>
                    <FormControl fullWidth sx={{ mb: '20px' }}>
                        <TextField
                            select
                            label="DeliFee"
                            name="totalDeliFee"
                            value={menuFilter.deliFee}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>None</MenuItem>
                            {getSwitchData("totalDeliFee")}
                        </TextField>
                    </FormControl>
                    <FormControl fullWidth sx={{ mb: '20px' }}>
                        <TextField
                            select
                            label="CollectMoney"
                            name="totalCollectMoney"
                            value={menuFilter.totalCollectMoney}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>None</MenuItem>
                            {getSwitchData("totalCollectMoney")}
                        </TextField>
                    </FormControl>
                </Stack>
                <Stack
                    direction={'row'}
                    spacing={2}
                    justifyContent="space-between"
                >
                    <Button
                        variant="contained"
                        color="primary"
                        onClick={handleFilterBtn}
                        fullWidth
                    >
                        Filter
                    </Button>
                    <Button
                        variant="contained"
                        color="error"
                        onClick={handleRemoveFilterBtn}
                        fullWidth
                    >
                        Remove Filter
                    </Button>
                </Stack>
            </Box >
        );
    }

    //Get clicked row of id
    const getClickedRowId = (rowIndex) => {
        const row = tableData[rowIndex];
        const idKey = Object.keys(row).find(key => key.toLowerCase().includes('id'));
        return idKey ? row[idKey] : null;
    };

    //Modal for create route
    const modalContent = () => {
        const { type } = modalState;

        if (type === 'delete') {
            return (
                <Box sx={deleteModalStyle}>
                    <form onSubmit={handleSubmit}>
                        <Typography sx={{ marginBottom: '30px', marginLeft: '25px' }} variant="h6" component="h2">
                            Are you sure to delete this route?
                        </Typography>
                        <Button sx={{ marginTop: '10px', marginRight: '120px' }} type="submit" variant="contained" color="error">
                            Submit
                        </Button>
                        <Button sx={{ marginTop: '10px' }} onClick={closeModal} type="button" variant="contained" color="primary">
                            Cancel
                        </Button>
                    </form>
                </Box>
            );
        }

        if (type === 'create') {
            return (
                <Box sx={createEditModalStyle}>
                    <Typography sx={{ marginBottom: '20px' }} variant="h6">
                        Create new route
                    </Typography>
                    <form onSubmit={handleSubmit}>
                        {tableTitle.slice(1).map((key) => {
                            const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
                            if (key.toLowerCase().includes('vehiclelicenseplate')) {
                                return (
                                    <TextField
                                        label="VehicleLicensePlate"
                                        value={selectedVehicle.vehicleLicensePlate || ''}
                                        InputLabelProps={{ shrink: !!selectedVehicle.vehicleLicensePlate }}
                                        InputProps={{
                                            endAdornment: (
                                                <InputAdornment position="end">
                                                    <IconButton onClick={() => openVehicleModal()}>
                                                        <IconPlus />
                                                    </IconButton>
                                                </InputAdornment>
                                            ),
                                            readOnly: true,
                                        }}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        error={type !== 'delete' ? !!errors[lowerKey] : false}
                                        helperText={type != 'delete' ? errors[lowerKey] : ''}
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('deliverymanname')) {
                                return (
                                    <TextField
                                        label="DeliverymanName"
                                        value={selectedDeliveryman.deliverymanName || ''}
                                        InputLabelProps={{ shrink: !!selectedDeliveryman.deliverymanName }}
                                        InputProps={{
                                            endAdornment: (
                                                <InputAdornment position="end">
                                                    <IconButton onClick={() => openDeliverymanModal()}>
                                                        <IconPlus />
                                                    </IconButton>
                                                </InputAdornment>
                                            ),
                                            readOnly: true,
                                        }}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        error={type !== 'delete' ? !!errors[lowerKey] : false}
                                        helperText={type != 'delete' ? errors[lowerKey] : ''}
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('packageid')) {
                                return (
                                    <TextField
                                        label="Package"
                                        value={selectedPackage.length || ''}
                                        InputLabelProps={{ shrink: !!selectedPackage.length }}
                                        InputProps={{
                                            endAdornment: (
                                                <InputAdornment position="end">
                                                    <IconButton onClick={() => openPackageModal()}>
                                                        <IconPlus />
                                                    </IconButton>
                                                </InputAdornment>
                                            ),
                                            readOnly: true,
                                        }}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        error={type !== 'delete' ? !!errors[lowerKey] : false}
                                        helperText={type != 'delete' ? errors[lowerKey] : ''}
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('packagetotal')) {
                                return (
                                    <TextField
                                        label="PackageTotal"
                                        value={selectedPackage.length || ''}
                                        InputLabelProps={{ shrink: !!selectedPackage.length }}
                                        InputProps={{
                                            readOnly: true,
                                        }}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('startdate')) {

                                return (
                                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                                        <Box sx={{ marginTop: '15px' }}>
                                            <Stack direction="row" spacing={2}>
                                                <DatePicker
                                                    label="StartData"
                                                    defaultValue={textFieldRefs.current["startDate"] || dayjs()}
                                                    inputRef={ref => { textFieldRefs.current["startDate"] = ref; }}
                                                    slots={{
                                                        textField: (params) => (
                                                            <TextField
                                                                {...params}
                                                                fullWidth
                                                                margin="normal"
                                                                variant="outlined"
                                                            />
                                                        ),
                                                    }}
                                                />
                                                <TimePicker
                                                    label="StartTime"
                                                    defaultValue={textFieldRefs.current["startTime"] || dayjs()}
                                                    inputRef={ref => { textFieldRefs.current["startTime"] = ref; }}
                                                    slots={{
                                                        textField: (params) => (
                                                            <TextField
                                                                {...params}
                                                                fullWidth
                                                                margin="normal"
                                                                variant="outlined"
                                                            />
                                                        ),
                                                    }}
                                                />
                                            </Stack>
                                        </Box>
                                    </LocalizationProvider>
                                );
                            }

                            if (key.toLowerCase().includes('finishdate')) {

                                return (
                                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                                        <Box sx={{ marginTop: '25px' }}>
                                            <Stack direction="row" spacing={2}>
                                                <DatePicker
                                                    label="FinishDate"
                                                    defaultValue={textFieldRefs.current["finishDate"] || dayjs()}
                                                    inputRef={ref => { textFieldRefs.current["finishDate"] = ref; }}
                                                    slots={{
                                                        textField: (params) => (
                                                            <TextField
                                                                {...params}
                                                                fullWidth
                                                                margin="normal"
                                                                variant="outlined"
                                                            />
                                                        ),
                                                    }}
                                                />
                                                <TimePicker
                                                    label="FinishTime"
                                                    defaultValue={textFieldRefs.current["finishTime"] || dayjs()}
                                                    inputRef={ref => { textFieldRefs.current["finishTime"] = ref; }}
                                                    slots={{
                                                        textField: (params) => (
                                                            <TextField
                                                                {...params}
                                                                fullWidth
                                                                margin="normal"
                                                                variant="outlined"
                                                            />
                                                        ),
                                                    }}
                                                />
                                            </Stack>
                                        </Box>
                                    </LocalizationProvider>
                                );
                            }

                            if (key.toLowerCase().includes('totalpackageprice')) {
                                return (
                                    <TextField
                                        key='totalPackagePrice'
                                        label='TotalPackagePrice'
                                        name='TotalPackagePrice'
                                        value={totalPackagePrice || ''}
                                        InputLabelProps={{ shrink: !!totalPackagePrice }}
                                        fullWidth
                                        InputProps={{ readOnly: true }}
                                        margin="normal"
                                        variant="outlined"
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('totaldelifee')) {
                                return (
                                    <TextField
                                        key='totalDeliFee'
                                        label='TotalDeliFee'
                                        name='totalDeliFee'
                                        value={totalDeliFee || ''}
                                        InputLabelProps={{ shrink: !!totalDeliFee }}
                                        fullWidth
                                        InputProps={{ readOnly: true }}
                                        margin="normal"
                                        variant="outlined"
                                    />
                                )
                            }

                            if (!key.toLowerCase().includes('starttime') &&
                                !key.toLowerCase().includes('finishtime') &&
                                !key.toLowerCase().includes('routeremainqty') &&
                                !key.toLowerCase().includes('routestatus') &&
                                !key.toLowerCase().includes('totalcollectmoney') &&
                                !key.toLowerCase().includes('deliverymanid') &&
                                !key.toLowerCase().includes('vehicleid')
                            ) {
                                return (
                                    <TextField
                                        key={key}
                                        label={key}
                                        name={key}
                                        defaultValue={textFieldRefs.current[lowerKey] || ''}
                                        inputRef={ref => textFieldRefs.current[lowerKey] = ref}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        error={type !== 'delete' ? !!errors[lowerKey] : false}
                                        helperText={type != 'delete' ? errors[lowerKey] : ''}
                                    />
                                )
                            }
                        })}
                        <Button sx={{ marginTop: '30px' }} type="submit" variant="contained" color="primary">
                            Submit
                        </Button>
                    </form>
                </Box>
            );
        }

        if (type === 'edit') {
            return (
                <Box sx={createEditModalStyle}>
                    <Typography sx={{ marginBottom: '20px' }} variant="h6">
                        Edit existing route
                    </Typography>
                    <form onSubmit={handleSubmit}>
                        {tableTitle.slice(1).map((key) => {
                            const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
                            if (key.toLowerCase().includes('vehiclelicenseplate')) {
                                return (
                                    <TextField
                                        label="VehicleLicensePlate"
                                        value={selectedVehicle.vehicleLicensePlate || ''}
                                        InputLabelProps={{ shrink: !!selectedVehicle.vehicleLicensePlate }}
                                        InputProps={{
                                            endAdornment: (
                                                <InputAdornment position="end">
                                                    <IconButton onClick={() => openVehicleModal()}>
                                                        <IconPlus />
                                                    </IconButton>
                                                </InputAdornment>
                                            ),
                                            readOnly: true,
                                        }}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        error={type !== 'delete' ? !!errors[lowerKey] : false}
                                        helperText={type != 'delete' ? errors[lowerKey] : ''}
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('deliverymanname')) {
                                return (
                                    <TextField
                                        label="DeliverymanName"
                                        value={selectedDeliveryman.deliverymanName || ''}
                                        InputLabelProps={{ shrink: !!selectedDeliveryman.deliverymanName }}
                                        InputProps={{
                                            endAdornment: (
                                                <InputAdornment position="end">
                                                    <IconButton onClick={() => openDeliverymanModal()}>
                                                        <IconPlus />
                                                    </IconButton>
                                                </InputAdornment>
                                            ),
                                            readOnly: true,
                                        }}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        error={type !== 'delete' ? !!errors[lowerKey] : false}
                                        helperText={type != 'delete' ? errors[lowerKey] : ''}
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('packageid')) {
                                return (
                                    <TextField
                                        label="Package"
                                        value={selectedPackage.length || ''}
                                        InputLabelProps={{ shrink: !!selectedPackage.length }}
                                        InputProps={{
                                            endAdornment: (
                                                <InputAdornment position="end">
                                                    <IconButton onClick={() => openPackageModal()}>
                                                        <IconPlus />
                                                    </IconButton>
                                                </InputAdornment>
                                            ),
                                            readOnly: true,
                                        }}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        error={type !== 'delete' ? !!errors[lowerKey] : false}
                                        helperText={type != 'delete' ? errors[lowerKey] : ''}
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('packagetotal')) {
                                return (
                                    <TextField
                                        label="PackageTotal"
                                        value={selectedPackage.length || ''}
                                        InputLabelProps={{ shrink: !!selectedPackage.length }}
                                        InputProps={{ readOnly: true }}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                    />
                                )
                            }

                            // if (key.toLowerCase().includes('packageId')) {
                            //     return (
                            //         <TextField
                            //             label="PackageId"
                            //             value={textFieldRefs.current[lowerKey] || ''}
                            //             InputLabelProps={{ shrink: !!textFieldRefs.current[lowerKey] }}
                            //             InputProps={{ readOnly: true }}
                            //             fullWidth
                            //             margin="normal"
                            //             variant="outlined"
                            //         />
                            //     )
                            // }

                            if (key.toLowerCase().includes('totalpackageprice')) {
                                return (
                                    <TextField
                                        key='totalPackagePrice'
                                        label='TotalPackagePrice'
                                        name='TotalPackagePrice'
                                        value={totalPackagePrice || ''}
                                        InputLabelProps={{ shrink: !!totalPackagePrice }}
                                        fullWidth
                                        InputProps={{ readOnly: true }}
                                        margin="normal"
                                        variant="outlined"
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('totaldelifee')) {
                                return (
                                    <TextField
                                        key='totalDeliFee'
                                        label='TotalDeliFee'
                                        name='totalDeliFee'
                                        value={totalDeliFee || ''}
                                        InputLabelProps={{ shrink: !!totalDeliFee }}
                                        fullWidth
                                        InputProps={{ readOnly: true }}
                                        margin="normal"
                                        variant="outlined"
                                    />
                                )
                            }

                            if (key.toLowerCase().includes('startdate')) {

                                const startDateString = textFieldRefs.current["startDate"];
                                const startDateValue = startDateString ? dayjs(startDateString, "MM/DD/YYYY") : dayjs();

                                const startTimeString = textFieldRefs.current["startTime"];
                                const startTimeValue = startTimeString ? dayjs(startTimeString, "hh:mm A") : dayjs();

                                return (
                                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                                        <Box sx={{ marginTop: '15px' }}>
                                            <Stack direction="row" spacing={2}>
                                                <DatePicker
                                                    label="StartDate"
                                                    defaultValue={startDateValue}
                                                    inputRef={ref => { textFieldRefs.current["startDate"] = ref; }}
                                                    slots={{
                                                        textField: (params) => (
                                                            <TextField
                                                                {...params}
                                                                fullWidth
                                                                margin="normal"
                                                                variant="outlined"
                                                            />
                                                        ),
                                                    }}
                                                />
                                                <TimePicker
                                                    label="StartTime"
                                                    defaultValue={startTimeValue}
                                                    inputRef={ref => { textFieldRefs.current["startTime"] = ref; }}
                                                    slots={{
                                                        textField: (params) => (
                                                            <TextField
                                                                {...params}
                                                                fullWidth
                                                                margin="normal"
                                                                variant="outlined"
                                                            />
                                                        ),
                                                    }}
                                                />
                                            </Stack>
                                        </Box>
                                    </LocalizationProvider>
                                );
                            }

                            if (key.toLowerCase().includes('finishdate')) {

                                const finishDateString = textFieldRefs.current["finishDate"];
                                const finishDateValue = finishDateString ? dayjs(finishDateString, "MM/DD/YYYY") : dayjs();

                                const finishTimeString = textFieldRefs.current["finishTime"];
                                const finishTimeValue = finishTimeString ? dayjs(finishTimeString, "hh:mm A") : dayjs();

                                return (
                                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                                        <Box sx={{ marginTop: '25px' }}>
                                            <Stack direction="row" spacing={2}>
                                                <DatePicker
                                                    label="FinishDate"
                                                    defaultValue={finishDateValue}
                                                    inputRef={ref => { textFieldRefs.current["finishDate"] = ref; }}
                                                    slots={{
                                                        textField: (params) => (
                                                            <TextField
                                                                {...params}
                                                                fullWidth
                                                                margin="normal"
                                                                variant="outlined"
                                                            />
                                                        ),
                                                    }}
                                                />
                                                <TimePicker
                                                    label="FinishTime"
                                                    defaultValue={finishTimeValue}
                                                    inputRef={ref => { textFieldRefs.current["finishTime"] = ref; }}
                                                    slots={{
                                                        textField: (params) => (
                                                            <TextField
                                                                {...params}
                                                                fullWidth
                                                                margin="normal"
                                                                variant="outlined"
                                                            />
                                                        ),
                                                    }}
                                                />
                                            </Stack>
                                        </Box>
                                    </LocalizationProvider>
                                );
                            }

                            if (!key.toLowerCase().includes('starttime') &&
                                !key.toLowerCase().includes('finishtime') &&
                                !key.toLowerCase().includes('routeremainqty') &&
                                !key.toLowerCase().includes('routestatus') &&
                                !key.toLowerCase().includes('totalcollectmoney') &&
                                !key.toLowerCase().includes('deliverymanid') &&
                                !key.toLowerCase().includes('vehicleid')
                            ) {
                                return (
                                    <TextField
                                        key={key}
                                        label={key}
                                        name={key}
                                        defaultValue={textFieldRefs.current[lowerKey] || ''}
                                        inputRef={ref => textFieldRefs.current[lowerKey] = ref}
                                        fullWidth
                                        margin="normal"
                                        variant="outlined"
                                        error={type !== 'delete' ? !!errors[lowerKey] : false}
                                        helperText={type != 'delete' ? errors[lowerKey] : ''}
                                    />
                                )
                            }
                        })}
                        <Button sx={{ marginTop: '30px' }} type="submit" variant="contained" color="primary">
                            Submit
                        </Button>
                    </form>
                </Box>
            );
        }
    };

    const getRouteStatusById = (id) => {
        const status = routeStatus.find(p => p.id === id);
        return status ? status.status : 'Unknown Process';
    };

    const getRowData = (column, row, value) => {
        switch (column) {
            case "RouteStatus":
                return getRouteStatusById(row["routeStatus"])
            default:
                return value === "" || value === 0 ? <div>-</div> : value
        }
    }

    //Common Session
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //UI Session

    return (
        <>
            <Modal
                open={filtermodalState.open}
                onClose={closeModal}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                {filterModalContent()}
            </Modal>
            <Modal
                open={modalState.open}
                onClose={closeModal}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                {modalContent()}
            </Modal>
            <Modal
                open={vehicleModalState.open}
                onClose={closeVehicleModal}
                aria-labelledby="modal-title"
                aria-describedby="modal-description"
            >
                {vehicleModalContent()}
            </Modal>
            <Modal
                open={deliverymanModalState.open}
                onClose={closeDeliverymanModal}
                aria-labelledby="modal-title"
                aria-describedby="modal-description"
            >
                {deliverymanModalContent()}
            </Modal>
            <Modal
                open={packageModalState.open}
                onClose={closePackageModal}
                aria-labelledby="modal-title"
                aria-describedby="modal-description"
            >
                {packageModalContent()}
            </Modal>
            <Snackbar
                open={snackBarState.open}
                autoHideDuration={6000}
                onClose={handleCloseSnackbar}
                anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
                sx={{ maxWidth: 600 }}
            >
                <Alert onClose={handleCloseSnackbar} severity={apiResponse != null ? apiResponse.status ? 'success' : 'error' : null} sx={{ width: '100%' }}>
                    {apiResponse != null ? apiResponse.message : null}
                </Alert>
            </Snackbar>
            {title && (
                <CardContent sx={{ p: "3px" }}>
                    <Typography
                        variant='h5'
                        sx={{
                            whiteSpace: 'nowrap',
                            pt: { xs: 0, sm: 1 },
                            mb: 5
                        }}
                    >
                        {title.value}
                    </Typography>
                    <Stack
                        direction={{ xs: 'column', sm: 'row' }}
                        spacing={2}
                        justifyContent="flex-end"
                        alignItems="flex-end"
                        mb={3}
                    >
                        <Box
                            display="flex"
                            alignItems="start"
                            justifyContent={{ xs: 'flex-start', sm: "flex-end" }}
                            width='100%'
                            flexDirection={'row'}
                        >
                            <TextField
                                name="search"
                                value={searchRef.current}
                                onChange={handleSearch}
                                fullWidth
                                variant='outlined'
                                sx={{
                                    width: 200,
                                    mr: { xs: 0, sm: 2 },
                                    mb: 1,
                                }}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <IconSearch />
                                        </InputAdornment>
                                    ),
                                    sx: { height: '45px' },
                                }}>
                            </TextField>
                            <Box width={{ xs: '10px', sm: 0 }}></Box>
                            <Tooltip title="Filter" sx={{ mr: { xs: 0, sm: 2 }, }}>
                                <Fab
                                    size="small"
                                    color="primary"
                                    onClick={openFilterModal}
                                >
                                    <IconFilter size="16" />
                                </Fab>
                            </Tooltip>
                            <Box width={{ xs: '10px', sm: 0 }}></Box>
                            <Button
                                sx={{
                                    width: 150,
                                    padding: { xs: '10px 12px', sm: '8px 16px' },
                                    fontSize: '14',
                                }}
                                onClick={() => openModal('create')}
                                variant='contained'
                            >{titleButton}
                            </Button>
                        </Box>
                    </Stack>
                </CardContent>
            )}
            <Box sx={{ overflow: 'auto', width: { xs: '280px', sm: 'auto' } }}>
                <Table aria-label="simple table" sx={{ whiteSpace: "nowrap", mt: 2 }}>
                    <TableHead>
                        <TableRow>
                            {tableTitle.map((column, index) => {
                                if (column !== "DeliverymanId" && column !== "VehicleId" && column !== "PackageId") {
                                    return (
                                        <TableCell key={index} style={{ textAlign: 'center' }}>
                                            <Typography variant="subtitle2" fontWeight={600}>
                                                {column}
                                            </Typography>
                                        </TableCell>
                                    )
                                }
                            })}
                            <TableCell style={{ textAlign: 'center' }}>
                                <Typography variant="subtitle2" fontWeight={600}>
                                    Actions
                                </Typography>
                            </TableCell>
                        </TableRow>
                    </TableHead>
                    {totalCount === 0 ?
                        <TableBody>
                            <TableRow>
                                <TableCell colSpan={tableTitle.length + 1} style={{ textAlign: 'center', padding: '50px' }}>
                                    <div style={{ fontSize: '20px', fontWeight: 'bold', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                                        No Data
                                    </div>
                                </TableCell>
                            </TableRow>
                        </TableBody>
                        :
                        <TableBody>
                            {filteredData.map((row, rowIndex) => (
                                <TableRow key={rowIndex}>
                                    {tableTitle.map((column, colIndex) => {
                                        if (column !== "DeliverymanId" && column !== "VehicleId" && column !== "PackageId") {
                                            const value = row[column.charAt(0).toLowerCase() + column.slice(1)]
                                            return (
                                                < TableCell key={colIndex} style={{ textAlign: 'center' }}>
                                                    {getRowData(column, row, value)}
                                                </TableCell>

                                            )
                                        }
                                    })}
                                    <TableCell>
                                        <div style={{ display: 'flex', justifyContent: 'center' }}>
                                            <Button sx={{ marginRight: 1 }} onClick={() => handleEdit(row, rowIndex)} variant="outlined" color="secondary">Edit</Button>
                                            <Button style={{ justifyContent: 'center' }} variant="outlined" onClick={() => handleDelete(row, rowIndex)} color="error">Delete</Button>
                                        </div>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    }
                </Table>
            </Box >
        </>
    )

};


export default RouteTable;

