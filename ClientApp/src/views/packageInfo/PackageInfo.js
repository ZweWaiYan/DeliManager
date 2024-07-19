import React, { useEffect, useState } from "react";
import PageContainer from "src/components/container/PageContainer";
import DataTable from '../table/DataTable';
import DashboardCard from 'src/components/shared/DashboardCard';
import { CreatePackage, EditPackage, FetchPackageList , DeletePackage } from "src/api/PackageAPI";

import { connect } from 'react-redux';
import * as actions from './../../actions/authActions';

const PackageInfo = ({ auth }) => {

    console.log("PackageInfo Render")

    const [dataList, setDataList] = useState([])
    const [titleList, setTitleList] = useState([])
    const [totalCount, setTotalCount] = useState(0)

    const fetchPackage = async () => {
        const res = await FetchPackageList(auth.companyId);

        console.log("fetch PackageInfo", res);        
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
        await CreatePackage(data, companyId);
        fetchPackage();
    };

    const handleEdit = async (id, data, companyId) => {
        await EditPackage(id, data, companyId);
        fetchPackage();
    };

    const handleDelete = async (id, companyId) => {
        await DeletePackage(id, companyId);
        fetchPackage();
    };

    return (
        <PageContainer title="PackageInfo Table" description="This is PackageInfo Table">
            <DashboardCard>                
                    <DataTable
                        title={"PackageInfo Table"}
                        titleButton={"New Package"}
                        tableTitle={titleList}
                        tableData={dataList}
                        totalCount={totalCount}
                        companyId={auth.companyId}
                        onCreate={handleCreate}
                        onEdit={handleEdit}
                        onDelete={handleDelete} />                
            </DashboardCard>
        </PageContainer>
    )
}

function mapStateToProps(state) {
    return { auth: state.auth };
}

export default connect(mapStateToProps, actions)(PackageInfo);