import React, { useEffect, useReducer, useRef, useState } from "react";
import PageContainer from "src/components/container/PageContainer";
import DataTable from '../table/DataTable';
import DashboardCard from 'src/components/shared/DashboardCard';
import { FetchVehicleList , CreateVehicle , EditVehicle , DeleteVehicle } from "src/api/VehicleAPI";

import { connect } from 'react-redux';
import * as actions from './../../actions/authActions';

const VehicleInfo = ({ auth }) => {

    console.log("VehicleInfo Render")

    const [dataList, setDataList] = useState([]);
    const [titleList, setTitleList] = useState([]);
    const [totalCount, setTotalCount] = useState(0);

    const fetchVehicle = async () => {        
        const res = await FetchVehicleList(auth.companyId);

        console.log("fetch VehicleInfo");
        setTitleList(res.tableColumn);
        setTotalCount(res.totalCount);
        if (res.totalCount !== 0) {
            setDataList(res.records);                     
        }
    }

    useEffect(() => {
        fetchVehicle();
    }, []);

    const handleCreate = async (data, companyId) => {        
        await CreateVehicle(data, companyId);                
        fetchVehicle();
    };

    const handleEdit = async (id, data, companyId) => {            
        await EditVehicle(id , data, companyId);
        fetchVehicle();
    };

    const handleDelete = async (id, companyId) => {        
        await DeleteVehicle(id, companyId);
        fetchVehicle();
    };

    return (
        <PageContainer title="VehicleInfo Table" description="This is VehicleInfo Table">
            <DashboardCard>
                <DataTable
                    title={"VehicleInfo Table"}
                    titleButton={"New Vehicle"}
                    tableTitle={titleList}
                    tableData={dataList}
                    totalCount={totalCount}
                    companyId={auth.companyId}
                    onCreate={handleCreate}
                    onEdit={handleEdit}
                    onDelete={handleDelete} />
            </DashboardCard>
        </PageContainer>
    );
}

// export default VehicleInfo;

function mapStateToProps(state) {
    return { auth: state.auth };
}

export default connect(mapStateToProps, actions)(VehicleInfo);