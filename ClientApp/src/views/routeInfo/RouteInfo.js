import React, { useEffect, useState } from "react";
import PageContainer from "src/components/container/PageContainer";
import DashboardCard from 'src/components/shared/DashboardCard';
import { CreateRoute, EditRoute, FetchRouteList, DeleteRoute } from "src/api/RouteAPI";

import { connect } from 'react-redux';
import * as actions from './../../actions/authActions';
import RouteTable from "./RouteTable";
import { FetchDeliverymanList } from "src/api/DeliveryAPI";
import { FetchVehicleList } from "src/api/VehicleAPI";
import { FetchPackageList } from "src/api/PackageAPI";
import stringValue from "../utilities/StringValue";

const RouteInfo = ({ auth }) => {

    console.log("RouteInfo Render")

    const [dataList, setDataList] = useState([])
    const [titleList, setTitleList] = useState([])
    const [totalCount, setTotalCount] = useState(0)
    const [deliverymanColumnList, setDeliverymanColumnList] = useState([])
    const [deliverymanDataList, setDeliverymanDataList] = useState([])
    const [vehicleColumnList, setVehicleColumnList] = useState([])
    const [vehicleDateList, setVehicleDataList] = useState([])
    const [packageColumList, setPackageColumnList] = useState([])
    const [packageDateList, setPackageDataList] = useState([])
    const [apiResponse, setAPIResponse] = useState([]);

    const fetchRoute = async () => {
        const res = await FetchRouteList(auth.companyId);
        const deliverymanRes = await FetchDeliverymanList(auth.companyId);
        const vehicleRes = await FetchVehicleList(auth.companyId);
        const packageRes = await FetchPackageList(auth.companyId);
        console.log("fetch RouteInfo");

        setTitleList(res.tableColumn);
        setTotalCount(res.totalCount);

        setDeliverymanColumnList(deliverymanRes.tableColumn);
        setDeliverymanDataList(deliverymanRes.records);

        setVehicleColumnList(vehicleRes.tableColumn);
        setVehicleDataList(vehicleRes.records);

        setPackageColumnList(packageRes.tableColumn);
        setPackageDataList(packageRes.records);

        if (res.totalCount !== 0) {
            setDataList(res.records);
        }
    }

    useEffect(() => {
        fetchRoute();
    }, []);

    const handleCreate = async (data, companyId) => {
        const res = await CreateRoute(data, companyId);
        setAPIResponse(res);
        fetchRoute();
    };

    const handleEdit = async (id, data, companyId) => {
        const res = await EditRoute(id, data, companyId);
        setAPIResponse(res);
        fetchRoute();
    };

    const handleDelete = async (id, packageId, vehicleId, delivermanId, companyId) => {
        const res = await DeleteRoute(id, packageId, vehicleId, delivermanId, companyId);
        setAPIResponse(res);
        fetchRoute();
    };

    return (
        <PageContainer title="RouteInfo Table" description="This is RouteInfo Table">
            <DashboardCard>
                <RouteTable
                    title={stringValue[3]}
                    titleButton={"New Route"}
                    tableTitle={titleList}
                    tableData={dataList}
                    totalCount={totalCount}
                    deliverymanColumnList={deliverymanColumnList}
                    deliverymanDataList={deliverymanDataList}
                    vehicleColumnList={vehicleColumnList}
                    vehicleDateList={vehicleDateList}
                    packageColumList={packageColumList}
                    packageDateList={packageDateList}
                    companyId={auth.companyId}
                    onCreate={handleCreate}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    apiResponse={apiResponse}
                />
            </DashboardCard>
        </PageContainer>
    )
}

function mapStateToProps(state) {
    return { auth: state.auth };
}

export default connect(mapStateToProps, actions)(RouteInfo);