import React, { useEffect, useState } from "react";
import PageContainer from "src/components/container/PageContainer";
import DataTable from '../table/DataTable';
import DashboardCard from 'src/components/shared/DashboardCard';
import { CreatePackage, EditPackage, FetchPackageList , DeletePackage } from "src/api/PackageAPI";

import { connect } from 'react-redux';
import * as actions from './../../actions/authActions';
import stringValue from "../utilities/StringValue";

const PackageInfo = ({ auth }) => {

    console.log("PackageInfo Render")

    const [dataList, setDataList] = useState([])
    const [titleList, setTitleList] = useState([])
    const [totalCount, setTotalCount] = useState(0)
    const [apiResponse, setAPIResponse] = useState();

    const fetchPackage = async () => {
        const res = await FetchPackageList(auth.companyId);

        console.log("fetch PackageInfo");        
        setTitleList(res.tableColumn);
        setTotalCount(res.totalCount);
        if (res.totalCount !== 0) {
            setDataList(res.records);
        }
    }

    useEffect(() => {
        fetchPackage();
    }, []);

    const handleCreate = async (data, companyId) => {
        const res = await CreatePackage(data, companyId);
        setAPIResponse(res);
        fetchPackage();
    };

    const handleEdit = async (id, data, companyId) => {
        const res = await EditPackage(id, data, companyId);
        setAPIResponse(res);
        fetchPackage();
    };

    const handleDelete = async (id, companyId, routeId) => {
        const res = await DeletePackage(id, companyId, routeId);
        setAPIResponse(res);
        fetchPackage();
    };

    return (
        <PageContainer title="PackageInfo Table" description="This is PackageInfo Table">
            <DashboardCard>                
                    <DataTable
                        title={stringValue[2]}
                        titleButton={"New Package"}
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
    )
}

function mapStateToProps(state) {
    return { auth: state.auth };
}

export default connect(mapStateToProps, actions)(PackageInfo);