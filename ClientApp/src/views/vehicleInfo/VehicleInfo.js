import React, { useEffect, useReducer, useRef, useState } from "react";
import PageContainer from "src/components/container/PageContainer";
import DataTable from '../table/DataTable';
import DashboardCard from 'src/components/shared/DashboardCard';
import { FetchVehicleList, CreateVehicle, EditVehicle, DeleteVehicle } from "src/api/VehicleAPI";

import { connect } from 'react-redux';
import * as actions from './../../actions/authActions';
import stringValue from "../utilities/StringValue";

const VehicleInfo = ({ auth }) => {

    console.log("VehicleInfo Render")

    const [dataList, setDataList] = useState([]);
    const [titleList, setTitleList] = useState([]);
    const [totalCount, setTotalCount] = useState(0);
    const [apiResponse, setAPIResponse] = useState();

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
        const res = await CreateVehicle(data, companyId);
        setAPIResponse(res);
        fetchVehicle();
    };

    const handleEdit = async (id, data, companyId) => {
        const res = await EditVehicle(id, data, companyId);
        setAPIResponse(res);
        fetchVehicle();
    };

    const handleDelete = async (id, companyId, routeId) => {
        const res = await DeleteVehicle(id, companyId, routeId);
        setAPIResponse(res);
        fetchVehicle();
    };

    return (
        <PageContainer title="VehicleInfo Table" description="This is VehicleInfo Table">
            <DashboardCard>
                <DataTable
                    title={stringValue[1]}
                    titleButton={"New Vehicle"}
                    tableTitle={titleList}
                    tableData={dataList}
                    totalCount={totalCount}
                    companyId={auth.companyId}
                    onCreate={handleCreate}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    apiResponse={apiResponse}
                />
            </DashboardCard>
        </PageContainer>
    );
}

// export default VehicleInfo;

function mapStateToProps(state) {
    return { auth: state.auth };
}

export default connect(mapStateToProps, actions)(VehicleInfo);