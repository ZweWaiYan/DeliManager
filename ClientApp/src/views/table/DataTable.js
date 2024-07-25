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
    CardContent, Stack, Snackbar, Alert, MenuItem
} from '@mui/material';

import dayjs from 'dayjs';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';

import { CreateMockApiData, DeleteMockApiData, EditMockApiData } from 'src/api/MockAPI';
import { TimePicker } from '@mui/x-date-pickers';
import customParseFormat from 'dayjs/plugin/customParseFormat';

import packageWayProcess from '../utilities/packageWayProcess';
import vehicleStatus from '../utilities/vehicleStatus';

import { times } from 'lodash';

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
const DataTable = ({ title, titleButton, tableTitle, tableData, totalCount, companyId, onCreate, onEdit, onDelete }) => {

    console.log("DataTable Render");
    dayjs.extend(customParseFormat);

    const [modalState, setModalState] = useState({
        open: false,
        type: 'create',
        rowIndex: null
    });

    const [snackBarState, setSnackBarState] = useState({
        open: false,
        message: '',
        severity: 'success'
    });

    const textFieldRefs = useRef({});

    const openModal = (type, data = {}, rowIndex = null) => {
        setModalState({ open: true, type, rowIndex });
        const isEmptyData = Object.keys(data).length === 0;
        if (!isEmptyData) {
            tableTitle.slice(1).forEach((key) => {
                textFieldRefs.current[key.charAt(0).toLowerCase() + key.slice(1)] = data[key.charAt(0).toLowerCase() + key.slice(1)] || '';
            });
        }
    }

    const closeModal = () => {
        setModalState({ open: false, type: 'create', rowIndex: null });
    };

    const handleEdit = (rowData, rowIndex) => openModal('edit', rowData, rowIndex);

    const handleDelete = (rowIndex) => openModal('delete', {}, rowIndex);

    const handleSubmit = (e) => {
        e.preventDefault();
        const { type, rowIndex } = modalState;
        const data = {};

        let operation;
        let successMsg;
        let errorMsg;

        if (type !== 'delete') {
            Object.keys(textFieldRefs.current).forEach((key) => {
                data[key] = textFieldRefs.current[key].value;
            });
        }

        switch (type) {
            case 'create':
                operation = onCreate(data, companyId);
                successMsg = 'User created successfully';
                errorMsg = 'Failed to create user.';
                break;
            case 'edit':
                operation = onEdit(getClickedRowId(rowIndex), data, companyId);
                successMsg = 'User updated successfully';
                errorMsg = 'Failed to update user.';
                break;
            case 'delete':
                operation = onDelete(getClickedRowId(rowIndex), companyId);
                successMsg = 'User deleted successfully';
                errorMsg = 'Failed to delete user.';
                break;
        }

        operation.then(
            () => {
                setSnackBarState({ open: true, message: successMsg, severity: 'success' });
            },
            () => {
                setSnackBarState({ open: true, message: errorMsg, severity: 'error' });
            },
        )

        closeModal();
    };

    const handleCloseSnackbar = () => {
        setSnackBarState({ open: false, message: '', severity: 'success' });
    };

    const getClickedRowId = (rowIndex) => {
        const row = tableData[rowIndex];
        const idKey = Object.keys(row).find(key => key.toLowerCase().includes('id'));
        return idKey ? row[idKey] : null;
    };

    // const modalContent = () => {
    //     const { type } = modalState;

    //     if (type === 'delete') {
    //         return (
    //             <Box sx={deleteModalStyle}>
    //                 <form onSubmit={handleSubmit}>
    //                     <Typography sx={{ marginBottom: '30px', marginLeft: '25px' }} variant="h6" component="h2">
    //                         Are you sure to delete this user?
    //                     </Typography>
    //                     <Button sx={{ marginTop: '10px', marginRight: '120px' }} type="submit" variant="contained" color="error">
    //                         Submit
    //                     </Button>
    //                     <Button sx={{ marginTop: '10px' }} onClick={closeModal} type="button" variant="contained" color="primary">
    //                         Cancel
    //                     </Button>
    //                 </form>
    //             </Box>
    //         );
    //     }

    //     return (
    //         <Box sx={createEditModalStyle}>
    //             <Typography sx={{ marginBottom: '20px' }} variant="h6">
    //                 {type === 'create' ? 'Create new user' : 'Edit existing user'}
    //             </Typography>
    //             <form onSubmit={handleSubmit}>
    //                 {tableTitle.slice(1).map((key) => {
    //                     const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);

    //                     if (key.toLowerCase().includes('pickupdate')) {
    //                         return (
    //                             <LocalizationProvider dateAdapter={AdapterDayjs}>
    //                                 <Box sx={{ marginTop: '10px' }}>
    //                                     <Stack direction="row" spacing={2}>
    //                                         <DatePicker
    //                                             label="PickupDate"
    //                                             defaultValue={textFieldRefs.current["pickupDate"] || dayjs()}
    //                                             inputRef={ref => { textFieldRefs.current["pickupDate"] = ref; }}
    //                                             renderInput={(params) => (
    //                                                 <TextField
    //                                                     {...params}
    //                                                     fullWidth
    //                                                     margin="normal"
    //                                                     variant="outlined"
    //                                                 />
    //                                             )}
    //                                         />
    //                                         <TimePicker
    //                                             label="PickupTime"
    //                                             defaultValue={textFieldRefs.current["pickupTime"] || dayjs()}
    //                                             inputRef={ref => { textFieldRefs.current["pickupTime"] = ref; }}
    //                                             renderInput={(params) => (
    //                                                 <TextField
    //                                                     {...params}
    //                                                     fullWidth
    //                                                     margin="normal"
    //                                                     variant="outlined"
    //                                                 />
    //                                             )}
    //                                         />
    //                                     </Stack>
    //                                 </Box>
    //                             </LocalizationProvider>
    //                         );
    //                     }
    //                     if (type !== 'create' && key.toLowerCase().includes('receiveddate')) {
    //                         return (
    //                             <LocalizationProvider dateAdapter={AdapterDayjs}>
    //                                 <Box sx={{ marginTop: '15px' }}>
    //                                     <Stack direction="row" spacing={2}>
    //                                         <DatePicker
    //                                             label="ReceivedDate"
    //                                             defaultValue={textFieldRefs.current["receivedDate"] || dayjs()}
    //                                             inputRef={ref => { textFieldRefs.current["receivedDate"] = ref; }}
    //                                             renderInput={(params) => (
    //                                                 <TextField
    //                                                     {...params}
    //                                                     fullWidth
    //                                                     margin="normal"
    //                                                     variant="outlined"
    //                                                 />
    //                                             )}
    //                                         />
    //                                         <TimePicker
    //                                             label="ReceivedTime"
    //                                             defaultValue={textFieldRefs.current["receivedTime"] || dayjs()}
    //                                             inputRef={ref => { textFieldRefs.current["receivedTime"] = ref; }}
    //                                             renderInput={(params) => (
    //                                                 <TextField
    //                                                     {...params}
    //                                                     fullWidth
    //                                                     margin="normal"
    //                                                     variant="outlined"
    //                                                 />
    //                                             )}
    //                                         />
    //                                     </Stack>
    //                                 </Box>
    //                             </LocalizationProvider>
    //                         );
    //                     }
    //                     if (!key.toLowerCase().includes('time') && !key.toLowerCase().includes('date') && !key.toLowerCase().includes('packagewayprocess') && !(key.toLowerCase().includes('packagewayprocess') && type !== 'create')) {
    //                         return (
    //                             <TextField
    //                                 key={key}
    //                                 label={key}
    //                                 name={key}
    //                                 defaultValue={textFieldRefs.current[lowerKey] || ''}
    //                                 inputRef={ref => textFieldRefs.current[lowerKey] = ref}
    //                                 fullWidth
    //                                 margin="normal"
    //                                 variant="outlined"
    //                             />
    //                         )
    //                     }

    //                 })}
    //                 <Button sx={{ marginTop: '30px' }} type="submit" variant="contained" color="primary">
    //                     Submit
    //                 </Button>
    //             </form>
    //         </Box>
    //     );
    // };

    const modalContent = () => {
        const { type } = modalState;

        if (type === 'delete') {
            return (
                <Box sx={deleteModalStyle}>
                    <form onSubmit={handleSubmit}>
                        <Typography sx={{ marginBottom: '30px', marginLeft: '25px' }} variant="h6" component="h2">
                            Are you sure to delete this user?
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
                    {type === 'create' ? 'Create new user' : 'Edit existing user'}
                </Typography>
                <form onSubmit={handleSubmit}>
                    {tableTitle.slice(1).map((key) => {
                        const lowerKey = key.charAt(0).toLowerCase() + key.slice(1);
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
                            />
                        )
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
                        <Typography sx={{ marginBottom: '30px', marginLeft: '25px' }} variant="h6" component="h2">
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

                            if (!key.toLowerCase().includes('vehiclestatus')) {
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

                            if (!key.toLowerCase().includes('vehiclestatus')) {
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
                        <Typography sx={{ marginBottom: '30px', marginLeft: '25px' }} variant="h6" component="h2">
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
                                                    renderInput={(params) => (
                                                        <TextField
                                                            {...params}
                                                            fullWidth
                                                            margin="normal"
                                                            variant="outlined"
                                                        />
                                                    )}
                                                />
                                                <TimePicker
                                                    label="PickupTime"
                                                    defaultValue={textFieldRefs.current["pickupTime"] || dayjs()}
                                                    inputRef={ref => { textFieldRefs.current["pickupTime"] = ref; }}
                                                    renderInput={(params) => (
                                                        <TextField
                                                            {...params}
                                                            fullWidth
                                                            margin="normal"
                                                            variant="outlined"
                                                        />
                                                    )}
                                                />
                                            </Stack>
                                        </Box>
                                    </LocalizationProvider>
                                );
                            }

                            if (!key.toLowerCase().includes('receiveddate') &&
                                !key.toLowerCase().includes('time') &&
                                !key.toLowerCase().includes('deliverymanid') &&
                                !key.toLowerCase().includes('packagewayprocess')
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
                                !key.toLowerCase().includes('packagewayprocess')
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
        switch (title.toLowerCase()) {
            case "vehicleinfo table":
                return vehicleModalContent();
            case "packageinfo table":
                return packageModalContent();
            default:
                return modalContent();
        }
    }

    const getProcessNameById = (id) => {
        const process = packageWayProcess.find(p => p.id === id);
        return process ? process.wayProcess : 'Unknown Process';
    };

    const getVehicleStatus = (id) => {        
        const vehiclestatus = vehicleStatus.find(p => p.id === id);        
        return vehiclestatus ? vehiclestatus.vehiclestatus : 'Unknown Status';
    };

    const getRowData = (column,row,value) => {          
        switch (column) {
            case "PackageWayProcess":
                return getProcessNameById(row["packageWayProcess"])                
            case "VehicleStatus":
                return getVehicleStatus(row["vehicleStatus"])                
            default:                
                return value === "" || value === 0 ? <div>-</div> : value            
        }
    }

    return (
        <>
            <Modal
                open={modalState.open}
                onClose={closeModal}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                {/* {title.toLowerCase().includes('package') ?
                    packageModalContent()
                    :
                    modalContent()
                } */}
                {getModalContent()}
            </Modal>
            <Snackbar
                open={snackBarState.open}
                autoHideDuration={6000}
                onClose={handleCloseSnackbar}
                anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
                sx={{ maxWidth: 600 }}
            >
                <Alert onClose={handleCloseSnackbar} severity={snackBarState.severity} sx={{ width: '100%' }}>
                    {snackBarState.message}
                </Alert>
            </Snackbar>
            {title && (
                <CardContent sx={{ p: "3px" }}>
                    <Stack
                        direction="row"
                        spacing={2}
                        justifyContent="space-between"
                        alignItems="center"
                        mb={3}
                    >
                        <Box>
                            <Typography variant="h5">{title}</Typography>
                        </Box>
                        <Box sx={{ display: 'flex', justifyContent: 'center', marginBottom: '20px' }}>
                            <Button onClick={() => openModal('create')} variant="contained">{titleButton}</Button>
                        </Box>
                    </Stack>
                </CardContent>
            )}
            <Box sx={{ overflow: 'auto', width: { xs: '280px', sm: 'auto' } }}>
                <Table aria-label="simple table" sx={{ whiteSpace: "nowrap", mt: 2 }}>
                    <TableHead>
                        <TableRow>
                            {tableTitle.map((column, index) => (
                                <TableCell key={index} style={{ textAlign: 'center' }}>
                                    <Typography variant="subtitle2" fontWeight={600}>
                                        {column}
                                    </Typography>
                                </TableCell>
                            ))}
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
                            {tableData.map((row, rowIndex) => (
                                <TableRow key={rowIndex}>
                                    {tableTitle.map((column, colIndex) => {
                                        const value = row[column.charAt(0).toLowerCase() + column.slice(1)]
                                        return (
                                            < TableCell key={colIndex} style={{ textAlign: 'center' }}>
                                                {/* {column === "PackageWayProcess" ?
                                                    getProcessNameById(row["packageWayProcess"])
                                                    :
                                                    value === "" || value === 0 ? <div>-</div> : value
                                                } */}
                                                {getRowData(column,row,value)}
                                            </TableCell>
                                        )
                                    })}
                                    <TableCell>
                                        <div style={{ display: 'flex', justifyContent: 'center' }}>
                                            <Button sx={{ marginRight: 1 }} onClick={() => handleEdit(row, rowIndex)} variant="outlined" color="secondary">Edit</Button>
                                            <Button style={{ justifyContent: 'center' }} variant="outlined" onClick={() => handleDelete(rowIndex)} color="error">Delete</Button>
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

