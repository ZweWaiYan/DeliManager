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
    IconButton,
    Menu,
    FormControlLabel,
    Switch,
    MenuList
} from '@mui/material';

import dayjs from 'dayjs';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';

import { CreateMockApiData, DeleteMockApiData, EditMockApiData } from 'src/api/MockAPI';
import { TimePicker } from '@mui/x-date-pickers';
import customParseFormat from 'dayjs/plugin/customParseFormat';

import packageWayProcess from '../utilities/PackageWayProcess';
import vehicleStatus from '../utilities/VehicleStatus';
import deliverymanStatus from '../utilities/DeliverymanStatus';
import stringValue from '../utilities/StringValue';

import {
    IconFilter,
    IconSearch,
    IconClockCancel,
} from '@tabler/icons';
import { BorderAllRounded, Start } from '@mui/icons-material';
import { filter } from 'lodash';

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
    width: 550,
    maxHeight: '95vh',
    bgcolor: 'background.paper',
    display: 'block',
    boxShadow: 15,
    p: 4,
    overflowY: 'auto',
};

//For MOCK API
// const DataTable = ({ title, titleButton, fetchData }) => {
//     const [apiData, setApiData] = useState([]);
//     const [columnNames, setColumnNames] = useState([]);
//     const [isLoading, setIsLoading] = useState(true);
//     const [modalState, setModalState] = useState({
//         open: false,
//         type: 'create',
//         data: {},
//         rowIndex: null
//     });

//     useEffect(() => {
//         startFetching();
//     }, []);

//     const startFetching = async () => {
//         try {            
//             const jsonData = await fetchData;
//             if (jsonData.length > 0) {
//                 setApiData(jsonData);
//                 setColumnNames(Object.keys(jsonData[0]));
//                 setIsLoading(false);
//             } else {
//                 console.error("Invalid data format received from API.");
//             }
//         } catch (error) {
//             console.error("Error fetching data:", error);
//         }
//     };   

//     const openModal = (type, data = {}, rowIndex = null) => {
//         setModalState({ open: true, type, data, rowIndex });
//     };

//     const closeModal = () => {
//         setModalState({ open: false, type: 'create', data: {}, rowIndex: null });        
//         startFetching();
//     };

//     const handleEdit = (rowData, rowIndex) => openModal('edit', rowData, rowIndex);

//     const handleDelete = (rowIndex) => openModal('delete', {}, rowIndex);

//     const handleSubmit = async (e) => {
//         e.preventDefault();
//         const { type, data, rowIndex } = modalState;

//         if (type === 'create') {
//             await CreateMockApiData(data);
//         } else if (type === 'edit') {
//             const id = getClickedRowId(rowIndex);
//             await EditMockApiData(id, data);
//         } else if (type === 'delete') {
//             const id = getClickedRowId(rowIndex);
//             await DeleteMockApiData(id);
//         }

//         setIsLoading(true);
//         closeModal();
//     };

//     const handleChange = (e, key) => {
//         setModalState(prevState => ({
//             ...prevState,
//             data: {
//                 ...prevState.data,
//                 [key]: e.target.value
//             }
//         }));
//     };

//     const getClickedRowId = (rowIndex) => {
//         const row = apiData[rowIndex];
//         const idKey = Object.keys(row).find(key => key.toLowerCase().includes('id'));
//         return idKey ? row[idKey] : null;
//     };

//     const modalContent = () => {
//         const { type, data } = modalState;

//         if (type === 'delete') {
//             return (
//                 <Box sx={deleteModalStyle}>
//                     <form onSubmit={handleSubmit}>
//                         <Typography sx={{ marginBottom: '30px', marginLeft: '25px' }} variant="h6" component="h2">
//                             Are you sure to delete this user?
//                         </Typography>
//                         <Button sx={{ marginTop: '10px', marginRight: '120px' }} type="submit" variant="contained" color="error">
//                             Submit
//                         </Button>
//                         <Button sx={{ marginTop: '10px' }} onClick={closeModal} type="button" variant="contained" color="primary">
//                             Cancel
//                         </Button>
//                     </form>
//                 </Box>
//             );
//         }

//         return (
//             <Box sx={createEditModalStyle}>
//                 <Typography sx={{ marginBottom: '20px' }} variant="h6" component="h2">
//                     {type === 'create' ? 'Create new user' : 'Edit existing user'}
//                 </Typography>
//                 <form onSubmit={handleSubmit}>
//                     {columnNames.map((key) => (
//                         <TextField
//                             key={key}
//                             label={key}
//                             name={key}
//                             value={data[key] || ''}
//                             onChange={(e) => handleChange(e, key)}
//                             fullWidth
//                             margin="normal"
//                             variant="outlined"
//                         />
//                     ))}
//                     <Button sx={{ marginTop: '30px' }} type="submit" variant="contained" color="primary">
//                         Submit
//                     </Button>
//                 </form>
//             </Box>
//         );
//     };

//     return (
//         <>
//             <Modal
//                 open={modalState.open}
//                 onClose={closeModal}
//                 aria-labelledby="modal-modal-title"
//                 aria-describedby="modal-modal-description"
//             >
//                 {modalContent()}
//             </Modal>
//             {title && (
//                 <CardContent sx={{ p: "3px" }}>
//                     <Stack
//                         direction="row"
//                         spacing={2}
//                         justifyContent="space-between"
//                         alignItems="center"
//                         mb={3}
//                     >
//                         <Box>
//                             <Typography variant="h5">{title}</Typography>
//                         </Box>
//                         <Box sx={{ display: 'flex', justifyContent: 'center', marginBottom: '20px' }}>
//                             <Button onClick={() => openModal('create')} variant="contained">{titleButton}</Button>
//                         </Box>
//                     </Stack>
//                 </CardContent>
//             )}
//             {isLoading ? (
//                 <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
//                     <CircularProgress />
//                 </div>
//             ) : (
//                 apiData.length > 0 && (
//                     <Box sx={{ overflow: 'auto', width: { xs: '280px', sm: 'auto' } }}>
//                         <Table aria-label="simple table" sx={{ whiteSpace: "nowrap", mt: 2 }}>
//                             <TableHead>
//                                 <TableRow>
//                                     {columnNames.map((columnName, index) => (
//                                         <TableCell key={index} style={{ textAlign: 'center' }}>
//                                             <Typography variant="subtitle2" fontWeight={600}>
//                                                 {columnName}
//                                             </Typography>
//                                         </TableCell>
//                                     ))}
//                                     <TableCell style={{ textAlign: 'center' }}>
//                                         <Typography variant="subtitle2" fontWeight={600}>
//                                             Actions
//                                         </Typography>
//                                     </TableCell>
//                                 </TableRow>
//                             </TableHead>
//                             <TableBody>
//                                 {apiData.map((row, rowIndex) => (
//                                     <TableRow key={rowIndex}>
//                                         {columnNames.map((columnName, colIndex) => (
//                                             <TableCell key={colIndex} style={{ textAlign: 'center' }}>
//                                                 {row[columnName] === null ? <div>-</div> : row[columnName]}
//                                             </TableCell>
//                                         ))}
//                                         <TableCell>
//                                             <div style={{ display: 'flex', justifyContent: 'center' }}>
//                                                 <Button sx={{ marginRight: 1 }} onClick={() => handleEdit(row, rowIndex)} variant="outlined" color="secondary">Edit</Button>
//                                                 <Button style={{ justifyContent: 'center' }} variant="outlined" onClick={() => handleDelete(rowIndex)} color="error">Delete</Button>
//                                             </div>
//                                         </TableCell>
//                                     </TableRow>
//                                 ))}
//                             </TableBody>
//                         </Table>
//                     </Box>
//                 )
//             )}
//         </>
//     );
// };

//FOR MSSQL Database
const DataTable = ({ title, titleButton, tableTitle, tableData, totalCount, companyId, onCreate, onEdit, onDelete, apiResponse = null }) => {

    console.log("DataTable Render");

    dayjs.extend(customParseFormat);

    const [modalState, setModalState] = useState({
        open: false,
        type: 'create',
        rowIndex: null
    });

    //menu filter
    const [filtermodalState, setFilterModalState] = useState({
        open: false,
    });

    const [menuFilter, setMenuFilter] = useState({        
        //for all table
        deliverymanStatus: '',

        //vehicle
        vehicleStatus: '',
        capacity: '',
        insuranceExpiryDate: '',
        fuelLevel: '',

        //Package
        packageWayProcess: '',
        packageQty: '',
        packagePrice: '',
        deliFee: '',
        collectMoney: '',
        senderCity: '',
        receiverCity: '',
        pickupDate: '',
        receivedDate: '',
    });

    const [snackBarState, setSnackBarState] = useState({
        open: false,
        message: '',
        severity: 'success'
    });

    const [errors, setErrors] = useState({});
    const [filteredData, setFilteredData] = useState(tableData);

    const searchRef = useRef('');

    const textFieldRefs = useRef({});
    const routeId = useRef({});

    const openModal = (type, data = {}, rowIndex = null) => {

        setErrors({});
        setModalState({ open: true, type, rowIndex });
        const isEmptyData = Object.keys(data).length === 0;

        if (type === 'delete') {
            routeId.current = data.routeId;
        }

        if (!isEmptyData && type !== 'delete') {
            tableTitle.slice(1).forEach((key) => {
                textFieldRefs.current[key.charAt(0).toLowerCase() + key.slice(1)] = data[key.charAt(0).toLowerCase() + key.slice(1)] || '';
            });
        }
    }

    const openFilterModal = () => {
        setFilterModalState({ open: true });
    }

    const closeModal = () => {
        setModalState({ open: false, type: 'create', rowIndex: null });
        setFilterModalState({ open: false });
    };

    useEffect(() => {
        setFilteredData(tableData);
    }, [tableData]);

    const handleSearch = (event) => {

        const { name, value } = event.target;

        searchRef.current = value.toLowerCase();

        let filteredData = tableData;

        if (searchRef.current) {
            switch (title.id) {
                case 1:
                    filteredData = filteredData.filter(item => {
                        return item.deliverymanName.toLowerCase().includes(searchRef.current) ||
                            item.deliverymanPh.toLowerCase().includes(searchRef.current) ||
                            item.deliverymanAddress.toLowerCase().includes(searchRef.current) ||
                            item.deliverymanLicenseNo.toLowerCase().includes(searchRef.current) ||
                            item.deliverymanNRC.toLowerCase().includes(searchRef.current);
                    });
                    break;
                case 2:
                    filteredData = filteredData.filter(item => {
                        return item.licensePlate.toLowerCase().includes(searchRef.current) ||
                            item.modal.toLowerCase().includes(searchRef.current) ||
                            item.manufacturer.toLowerCase().includes(searchRef.current) ||
                            item.capacity.toString().includes(searchRef.current) ||
                            item.fuelLevel.toString().includes(searchRef.current) ||
                            item.insuranceExpiryDate.toLowerCase().includes(searchRef.current)
                    });
                    break;
                case 3:
                    filteredData = filteredData.filter(item => {
                        return item.packageTitle.toLowerCase().includes(searchRef.current) ||
                            item.senderName.toLowerCase().includes(searchRef.current) ||
                            item.senderAddress.toLowerCase().includes(searchRef.current) ||
                            item.senderCity.toLowerCase().includes(searchRef.current) ||
                            item.receiverAddress.toString().includes(searchRef.current) ||
                            item.receiverCity.toString().includes(searchRef.current) ||
                            item.receiverName.toLowerCase().includes(searchRef.current)
                    });
                    break;
                default:
                    break;
            }
        }

        setFilteredData(filteredData);
    };

    const handleFilterBtn = () => {
        handleFilter();
    }

    const handleRemoveFilterBtn = () => {
        setMenuFilter({
            //filtered or not
            filtered: false,

            //for all table
            status: '',

            //vehicle
            capacity: '',
            insuranceExpiryDate: '',
            fuelLevel: '',

            //Package
            packageWayProcess: '',
            packageQty: '',
            PackagePrice: '',
            DeliFee: '',
            CollectMoney: '',
            SenderAddress: '',
            ReceiverAddress: '',
            pickupDate: '',
            receivedDate: '',
        });
        closeModal();
        setFilteredData(tableData);
    }

    const handleFilter = () => {        

        let filteredData = tableData;

        const filterMap = {
            //deliveryman
            deliverymanStatus: (item, value) => item.deliverymanStatus === value,

            //vehicle
            vehicleStatus: (item, value) => item.vehicleStatus === value,
            insuranceExpiryDate: (item, value) => item.insuranceExpiryDate === value,
            capacity: (item, value) => item.capacity === value,
            fuelLevel: (item, value) => item.fuelLevel === value,

            //package
            packageWayProcess: (item, value) => item.packageWayProcess === value,
            packageQty: (item, value) => item.packageQty === value,
            packagePrice: (item, value) => item.packagePrice === value,
            deliFee: (item, value) => item.deliFee === value,
            collectMoney: (item, value) => item.collectMoney === value,
            senderCity: (item, value) => item.senderCity === value,
            receiverCity: (item, value) => item.receiverCity === value,
            pickupDate: (item, value) => item.pickupDate === value,
            receivedDate: (item, value) => item.receivedDate === value,
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
            //vehicle       
            insuranceExpiryDate: null,
            //package
            pickupDate: null,
            receivedDate: null,
        }));
    }

    const handleEdit = (rowData, rowIndex) => openModal('edit', rowData, rowIndex);

    const handleDelete = (rowData, rowIndex) => openModal('delete', rowData, rowIndex);

    const validate = () => {
        const newErrors = {};

        const deliverymanValidationRules = {
            deliverymanName: [
                {
                    test: value => value.trim() === "",
                    message: "Name must not be empty"
                }
            ],
            deliverymanPh: [
                {
                    test: value => value.trim() === "",
                    message: "Phone number not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "Phone number must be a number"
                }
            ],
            deliverymanAddress: [
                {
                    test: value => value.trim() === "",
                    message: "Address not be empty"
                },
            ],
            deliverymanLicenseNo: [
                {
                    test: value => value.trim() === "",
                    message: "LicenseNo not be empty"
                },
            ],
            deliverymanNRC: [
                {
                    test: value => value.trim() === "",
                    message: "NRC not be empty"
                },
            ],
            deliverymanAge: [
                {
                    test: value => value.trim() === "",
                    message: "Age not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "Age must be a number"
                }
            ],
        };

        const vehicleValidationRules = {
            licensePlate: [
                {
                    test: value => value.trim() === "",
                    message: "LicensePlate must not be empty"
                }
            ],
            modal: [
                {
                    test: value => value.trim() === "",
                    message: "Modal must not be empty"
                }
            ],
            manufacturer: [
                {
                    test: value => value.trim() === "",
                    message: "Manufacturer must not be empty"
                }
            ],
            capacity: [
                {
                    test: value => value.trim() === "",
                    message: "Capacity must not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "Capacity must be a number"
                }
            ],
            fuelLevel: [
                {
                    test: value => value.trim() === "",
                    message: "FuelLevel must not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "FuelLevel must be a number"
                }
            ],
        };

        const packageValidationRules = {
            packageTitle: [
                {
                    test: value => value.trim() === "",
                    message: "Title must not be empty"
                },
            ],
            packageQty: [
                {
                    test: value => value.trim() === "",
                    message: "PackageQty must not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "PackageQty must be a number"
                }
            ],
            packagePrice: [
                {
                    test: value => value.trim() === "",
                    message: "Price must not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "Price must be a number"
                }
            ],
            deliFee: [
                {
                    test: value => value.trim() === "",
                    message: "DeliFee must not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "DeliFee must be a number"
                }
            ],
            collectMoney: [
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "CollectMoney must be a number"
                }
            ],
            senderName: [
                {
                    test: value => value.trim() === "",
                    message: "SenderName must not be empty"
                },
            ],
            senderPh: [
                {
                    test: value => value.trim() === "",
                    message: "SenderPhone must not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "SenderPhone must be a number"
                }
            ],
            senderAddress: [
                {
                    test: value => value.trim() === "",
                    message: "SenderAddress must not be empty"
                },
            ],
            senderCity: [
                {
                    test: value => value.trim() === "",
                    message: "SenderCity must not be empty"
                },
            ],
            receiverName: [
                {
                    test: value => value.trim() === "",
                    message: "ReceiverName must not be empty"
                },
            ],
            receiverPh: [
                {
                    test: value => value.trim() === "",
                    message: "ReceiverPhone must not be empty"
                },
                {
                    test: value => value.trim() !== "" && !/^\d+$/.test(value),
                    message: "ReceiverPhone must be a number"
                }
            ],
            receiverAddress: [
                {
                    test: value => value.trim() === "",
                    message: "ReceiverAddress must not be empty"
                },
            ],
            receiverCity: [
                {
                    test: value => value.trim() === "",
                    message: "ReceiverCity must not be empty"
                },
            ],
        };

        let validationRules;

        switch (title.id) {
            case 1:
                validationRules = deliverymanValidationRules;
                break;
            case 2:
                validationRules = vehicleValidationRules;
                break;
            case 3:
                validationRules = packageValidationRules;
                break;
            default:
                break;
        }



        Object.keys(validationRules).forEach((field) => {

            const fieldValue = textFieldRefs.current[field]?.value || '';
            newErrors[field] = [];

            validationRules[field].forEach(rule => {

                if (rule.test(fieldValue)) {
                    newErrors[field].push(rule.message);
                }
            })

            if (newErrors[field].length === 0) {
                delete newErrors[field];
            }
        })

        setErrors(newErrors);
        return Object.keys(newErrors).length === 0; // Return true if no errors
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        const { type, rowIndex } = modalState;
        const data = {};

        if (type === 'delete') {

            let operation = onDelete(getClickedRowId(rowIndex), companyId, routeId.current);
            operation.then(() => { setSnackBarState({ open: true }) });

            closeModal();
        }

        if (validate() && type !== 'delete') {

            Object.keys(textFieldRefs.current).forEach((key) => {
                data[key] = textFieldRefs.current[key].value;
            });


            let operation;

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

    const handleCloseSnackbar = () => {
        setSnackBarState({ open: false, message: '', severity: 'success' });
    };

    const getClickedRowId = (rowIndex) => {
        const row = tableData[rowIndex];
        const idKey = Object.keys(row).find(key => key.toLowerCase().includes('id'));
        return idKey ? row[idKey] : null;
    };

    const modalContent = () => {
        const { type } = modalState;
        if (type === 'delete') {
            return (
                <Box sx={deleteModalStyle}>
                    <form onSubmit={handleSubmit}>
                        <Typography sx={{ marginBottom: '30px' }} variant="h6" component="h6">
                            Are you sure to delete deliveryman?
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

        return (
            <Box sx={createEditModalStyle}>
                <Typography sx={{ marginBottom: '20px' }} variant="h6">
                    {type === 'create' ? 'Create new deliveryman' : 'Edit existing deliveryman'}
                </Typography>
                <form onSubmit={handleSubmit}>
                    {tableTitle.slice(1).map((key) => {
                        const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
                        if (!key.toLowerCase().includes('deliverymanstatus') && !key.toLowerCase().includes('routeid') && !key.toLowerCase().includes('deliverymanimage')) {
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
    };


    const vehicleModalContent = () => {
        const { type } = modalState;

        if (type === 'delete') {
            return (
                <Box sx={deleteModalStyle}>
                    <form onSubmit={handleSubmit}>
                        <Typography sx={{ marginBottom: '30px', marginLeft: '10px' }} variant="h6" component="h6">
                            Are you sure to delete this vehicle?
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
                        {type === 'create' ? 'Create new vehicle' : 'Edit existing vehicle'}
                    </Typography>
                    <form onSubmit={handleSubmit}>
                        {tableTitle.slice(1).map((key) => {
                            const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
                            if (key.toLowerCase().includes('insuranceexpirydate')) {
                                return (
                                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                                        <DatePicker
                                            label="insuranceExpiryDate"
                                            defaultValue={textFieldRefs.current["insuranceExpiryDate"] || dayjs()}
                                            inputRef={ref => { textFieldRefs.current["insuranceExpiryDate"] = ref; }}
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
                                    </LocalizationProvider>
                                );
                            }

                            if (!key.toLowerCase().includes('vehiclestatus') && !key.toLowerCase().includes('routeid') && !key.toLowerCase().includes('deliverymanid')) {
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
                        {type === 'create' ? 'Create new vehicle' : 'Edit existing vehicle'}
                    </Typography>
                    <form onSubmit={handleSubmit}>
                        {tableTitle.slice(1).map((key) => {
                            const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);

                            const dateString = textFieldRefs.current["insuranceExpiryDate"];
                            const dateValue = dateString ? dayjs(dateString, "MM/DD/YYYY") : dayjs();

                            if (key.toLowerCase().includes('insuranceexpirydate')) {
                                return (
                                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                                        <DatePicker
                                            label="insuranceExpiryDate"
                                            defaultValue={dateValue}
                                            inputRef={ref => { textFieldRefs.current["insuranceExpiryDate"] = ref; }}
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
                                    </LocalizationProvider>
                                );
                            }

                            if (!key.toLowerCase().includes('vehiclestatus') && !key.toLowerCase().includes('routeid') && !key.toLowerCase().includes('deliverymanid')) {
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

    const packageModalContent = () => {
        const { type } = modalState;

        if (type === 'delete') {
            return (
                <Box sx={deleteModalStyle}>
                    <form onSubmit={handleSubmit}>
                        <Typography sx={{ marginBottom: '30px' }} variant="h6" component="h6">
                            Are you sure to delete this package?
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
                        Create new package
                    </Typography>
                    <form onSubmit={handleSubmit}>
                        {tableTitle.slice(1).map((key) => {
                            const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
                            if (key.toLowerCase().includes('pickupdate')) {
                                return (
                                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                                        <Box sx={{ marginTop: '10px' }}>
                                            <Stack direction="row" spacing={2}>
                                                <DatePicker
                                                    label="PickupDate"
                                                    defaultValue={textFieldRefs.current["pickupDate"] || dayjs()}
                                                    inputRef={ref => { textFieldRefs.current["pickupDate"] = ref; }}
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
                                                    label="PickupTime"
                                                    defaultValue={textFieldRefs.current["pickupTime"] || dayjs()}
                                                    inputRef={ref => { textFieldRefs.current["pickupTime"] = ref; }}
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

                            if (!key.toLowerCase().includes('receiveddate') &&
                                !key.toLowerCase().includes('time') &&
                                !key.toLowerCase().includes('deliverymanid') &&
                                !key.toLowerCase().includes('packagewayprocess') &&
                                !key.toLowerCase().includes('routeid')
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
                        Edit package
                    </Typography>
                    <form onSubmit={handleSubmit}>
                        {tableTitle.slice(1).map((key) => {
                            const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
                            if (key.toLowerCase().includes('pickupdate')) {

                                const dateString = textFieldRefs.current["pickupDate"];
                                const dateValue = dateString ? dayjs(dateString, "MM/DD/YYYY") : dayjs();

                                const timeString = textFieldRefs.current["pickupTime"];
                                const timeValue = timeString ? dayjs(timeString, "hh:mm A") : dayjs();

                                return (
                                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                                        <Box sx={{ marginTop: '10px' }}>
                                            <Stack direction="row" spacing={2}>
                                                <DatePicker
                                                    label="PickupDate"
                                                    defaultValue={dateValue}
                                                    inputRef={ref => { textFieldRefs.current["pickupDate"] = ref; }}
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
                                                    label="PickupTime"
                                                    defaultValue={timeValue}
                                                    inputRef={ref => { textFieldRefs.current["pickupTime"] = ref; }}
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

                            if (!key.toLowerCase().includes('receiveddate') &&
                                !key.toLowerCase().includes('time') &&
                                !key.toLowerCase().includes('deliverymanid') &&
                                !key.toLowerCase().includes('packagewayprocess') &&
                                !key.toLowerCase().includes('routeid')
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
            )
        }
    }

    const getModalContent = () => {
        switch (title.id) {
            case 2:
                return vehicleModalContent();
            case 3:
                return packageModalContent();
            default:
                return modalContent();
        }
    }

    const getFilterModalContent = () => {
        switch (title.id) {
            case 1:
                return deliverymanFilterModalContent();
            case 2:
                return vehicleFilterModalContent();
            case 3:
                return packageFilterModalContent();
        }
    }

    const vehicleFilterModalContent = () => {

        return (
            <Box sx={createEditModalStyle}>
                <Typography sx={{ mb: '30px' }} variant="h6">
                    Vehicle Filter
                </Typography>
                <Stack
                    direction={'row'}
                    spacing={2}
                    justifyContent="flex-start"
                >
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker
                            label="Insurance Expiry Date"
                            value={menuFilter.insuranceExpiryDate ? dayjs(menuFilter.insuranceExpiryDate, "MM/DD/YYYY") : null}
                            onChange={(newValue) => getFilterDate('insuranceExpiryDate', newValue)}
                        />
                    </LocalizationProvider>
                    <Tooltip title="Remove Date Filter">
                        <IconButton onClick={removeDateFilter}>
                            <IconClockCancel />
                        </IconButton>
                    </Tooltip>
                </Stack>
                <FormControl fullWidth sx={{ mb: '20px', mt: '20px' }}>
                    <TextField
                        select
                        label="Status"
                        name="vehicleStatus"
                        value={menuFilter.vehicleStatus}
                        onChange={getFilterValue}
                        variant="outlined"
                    >
                        <MenuItem value={0} divider>None</MenuItem>
                        {getStatusSwitchData()}
                    </TextField>
                </FormControl>

                <FormControl fullWidth sx={{ mb: '20px' }}>
                    <TextField
                        select
                        label="Capacity"
                        name="capacity"
                        value={menuFilter.capacity}
                        onChange={getFilterValue}
                        variant="outlined"
                    >
                        <MenuItem value={0} divider>0</MenuItem>
                        {getSwitchData('capacity')}
                    </TextField>
                </FormControl>

                <FormControl fullWidth sx={{ mb: '40px' }}>
                    <TextField
                        select
                        label="Fuel Level"
                        name="fuelLevel"
                        value={menuFilter.fuelLevel}
                        onChange={getFilterValue}
                        variant="outlined"
                    >
                        <MenuItem value={0} divider>0%</MenuItem>
                        {getSwitchData('fuelLevel')}
                    </TextField>
                </FormControl>
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
            </Box>
        );
    }

    const deliverymanFilterModalContent = () => {

        return (
            <Box sx={createEditModalStyle}>
                <Typography sx={{ mb: '30px' }} variant="h6">
                    Deliveryman Filter
                </Typography>
                <FormControl fullWidth sx={{ mb: '20px' }}>
                    <TextField
                        select
                        label="Status"
                        name="deliverymanStatus"
                        value={menuFilter.deliverymanStatus}
                        onChange={getFilterValue}
                        variant="outlined"
                    >
                        <MenuItem value={0} divider>None</MenuItem>
                        {getStatusSwitchData()}
                    </TextField>
                </FormControl>
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
            </Box>
        );
    }

    const packageFilterModalContent = () => {

        return (
            <Box sx={createEditModalStyle}>
                <Typography sx={{ mb: '30px' }} variant="h6">
                    Package Filter
                </Typography>
                {/* PickUp Date and Received Date UI Session                  */}
                <Stack
                    direction={'row'}
                    spacing={2}
                    justifyContent="flex-start"
                >
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker
                            label="Pickup Date"
                            value={menuFilter.pickupDate ? dayjs(menuFilter.pickupDate, "MM/DD/YYYY") : null}
                            onChange={(newValue) => getFilterDate('pickupDate', newValue)}
                        />
                    </LocalizationProvider>
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker
                            label="Received Date"
                            value={menuFilter.receivedDate ? dayjs(menuFilter.receivedDate, "MM/DD/YYYY") : null}
                            onChange={(newValue) => getFilterDate('receivedDate', newValue)}
                        />
                    </LocalizationProvider>
                    <Tooltip title="Remove Date Filter">
                        <IconButton onClick={removeDateFilter}>
                            <IconClockCancel />
                        </IconButton>
                    </Tooltip>
                </Stack>
                <FormControl fullWidth sx={{ mt: '20px', mb: '20px' }}>
                    <TextField
                        select
                        label="PackageWayProcess"
                        name="packageWayProcess"
                        value={menuFilter.packageWayProcess}
                        onChange={getFilterValue}
                        variant="outlined"
                    >
                        <MenuItem value={0} divider>None</MenuItem>
                        {getStatusSwitchData()}
                    </TextField>
                </FormControl>
                {/* Package Price , Deli Fee , Collect Money UI Session */}
                <Stack
                    direction={'row'}
                    spacing={2}
                    justifyContent="flex-start"
                >
                    <FormControl fullWidth sx={{ mb: '20px' }}>
                        <TextField
                            select
                            label="PackagePrice"
                            name="packagePrice"
                            value={menuFilter.packagePrice}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>0</MenuItem>
                            {getSwitchData('packagePrice')}
                        </TextField>
                    </FormControl>
                    <FormControl fullWidth sx={{ mb: '20px' }}>
                        <TextField
                            select
                            label="DeliFee"
                            name="deliFee"
                            value={menuFilter.deliFee}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>0</MenuItem>
                            {getSwitchData('deliFee')}
                        </TextField>
                    </FormControl>
                    <FormControl fullWidth sx={{ mb: '20px' }}>
                        <TextField
                            select
                            label="CollectMoney"
                            name="collectMoney"
                            value={menuFilter.collectMoney}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>0</MenuItem>
                            {getSwitchData('collectMoney')}
                        </TextField>
                    </FormControl>
                </Stack>
                <FormControl fullWidth sx={{ mt: '20px', mb: '20px' }}>
                    <TextField
                        select
                        label="Package Qty"
                        name="packageQty"
                        value={menuFilter.packageQty}
                        onChange={getFilterValue}
                        variant="outlined"
                    >
                        <MenuItem value={0} divider>0</MenuItem>
                        {getSwitchData('packageQty')}
                    </TextField>
                </FormControl>
                <Stack
                    direction={'row'}
                    spacing={2}
                    justifyContent="space-between"
                    sx={{ mb: '20px' }}
                >
                    <FormControl fullWidth>
                        <TextField
                            select
                            label="Sender City"
                            name="senderCity"
                            value={menuFilter.senderCity}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>None</MenuItem>
                            {getSwitchData('senderCity')}
                        </TextField>
                    </FormControl>
                    <FormControl fullWidth>
                        <TextField
                            select
                            label="Receiver City"
                            name="receiverCity"
                            value={menuFilter.receiverCity}
                            onChange={getFilterValue}
                            variant="outlined"
                        >
                            <MenuItem value={0} divider>None</MenuItem>
                            {getSwitchData('receiverCity')}
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
            </Box>
        );
    }


    const getProcessNameById = (id) => {
        const process = packageWayProcess.find(p => p.id === id);
        return process ? process.status : 'Unknown Process';
    };

    const getVehicleStatus = (id) => {
        const vehiclestatus = vehicleStatus.find(p => p.id === id);
        return vehiclestatus ? vehiclestatus.status : 'Unknown Status';
    };

    const getDeliverymanStatus = (id) => {
        const deliverymanstatus = deliverymanStatus.find(p => p.id === id);
        return deliverymanstatus ? deliverymanstatus.status : 'Unknown Status';
    };

    const getRowData = (column, row, value) => {
        switch (column) {
            case "PackageWayProcess":
                return getProcessNameById(row["packageWayProcess"])
            case "VehicleStatus":
                return getVehicleStatus(row["vehicleStatus"])
            case "DeliverymanStatus":
                return getDeliverymanStatus(row["deliverymanStatus"])
            default:
                return value === "" || value === 0 ? <div>-</div> : value
        }
    }

    const getStatusSwitchData = () => {
        switch (title.id) {
            case 1:
                return deliverymanStatus.map((item, index) => (
                    <MenuItem key={index} divider value={item.id}>{item.status}</MenuItem>
                ))
            case 2:
                return vehicleStatus.map((item, index) => (
                    <MenuItem key={index} divider value={item.id}>{item.status}</MenuItem>
                ))
            case 3:
                return packageWayProcess.map((item, index) => (
                    <MenuItem key={index} divider value={item.id}>{item.status}</MenuItem>
                ))
            default:
                break;
        }
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

    return (
        <>
            <Modal
                open={modalState.open}
                onClose={closeModal}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                {getModalContent()}
            </Modal>
            <Modal
                open={filtermodalState.open}
                onClose={closeModal}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                {getFilterModalContent()}
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
            {title.value && (
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
            <Box sx={{ overflow: 'auto', width: { xs: '100%', sm: 'auto' }, mt: 2 }}>
                <Table aria-label="simple table" sx={{ whiteSpace: "nowrap" }}>
                    <TableHead>
                        <TableRow>
                            {tableTitle.map((column, index) => {
                                if (column != "RouteId" && column != "DeliverymanImage") {
                                    return (
                                        <TableCell key={index} style={{ textAlign: 'center', minWidth: 120 }}>
                                            <Typography variant="subtitle2" fontWeight={600}>
                                                {column}
                                            </Typography>
                                        </TableCell>
                                    )
                                }
                            })}
                            <TableCell style={{ textAlign: 'center', minWidth: 120 }}>
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
                                    <Typography variant="h6" fontWeight="bold">
                                        No Data
                                    </Typography>
                                </TableCell>
                            </TableRow>
                        </TableBody>
                        :
                        <TableBody>
                            {filteredData.map((row, rowIndex) => (
                                <TableRow key={rowIndex}>
                                    {tableTitle.map((column, colIndex) => {
                                        if (column != "RouteId" && column != "DeliverymanImage") {
                                            const value = row[column.charAt(0).toLowerCase() + column.slice(1)]
                                            return (
                                                < TableCell key={colIndex} style={{ textAlign: 'center', minWidth: 120 }}>
                                                    {getRowData(column, row, value)}
                                                </TableCell>
                                            )
                                        }
                                    })}
                                    <TableCell>
                                        <div style={{ textAlign: 'center', minWidth: 150 }}>
                                            <Box sx={{ display: 'flex', justifyContent: 'center' }}>
                                                <Button
                                                    disabled={row.routeId !== 0}
                                                    sx={{ marginRight: 1 }}
                                                    onClick={() => handleEdit(row, rowIndex)}
                                                    variant="outlined"
                                                    color="secondary"
                                                >
                                                    Edit
                                                </Button>
                                                <Button
                                                    disabled={row.routeId !== 0}
                                                    variant="outlined"
                                                    onClick={() => handleDelete(row, rowIndex)}
                                                    color="error"
                                                >
                                                    Delete
                                                </Button>
                                            </Box>
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


export default DataTable;

