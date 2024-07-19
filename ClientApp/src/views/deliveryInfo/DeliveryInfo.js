import React, { useEffect, useReducer, useRef, useState } from "react";
import PageContainer from "src/components/container/PageContainer";
import DataTable from '../table/DataTable';
import DashboardCard from 'src/components/shared/DashboardCard';
import { FetchDeiverymanList } from "src/api/DeliveryAPI";

import { connect } from 'react-redux';
import * as actions from './../../actions/authActions';

import { DeleteDeliveryman , CreateDeliveryman , EditDeliveryman} from '../../api/DeliveryAPI';

const DeliveryInfo = ({ auth }) => {

    console.log("DeliveryInfo Render")

    const [dataList, setDataList] = useState([]);
    const [titleList, setTitleList] = useState([]);
    const [totalCount, setTotalCount] = useState(0);

    const fetchDelivery = async () => {        
        const res = await FetchDeiverymanList(auth.companyId);

        console.log("fetch DeliveryInfo" , res);
        setTitleList(res.tableColumn);
        setTotalCount(res.totalCount);
        if (res.totalCount !== 0) {
            setDataList(res.records);                     
        }
    }

    useEffect(() => {
        fetchDelivery();
    }, []);

    const handleCreate = async (data, companyId) => {
        await CreateDeliveryman(data, companyId);                
        fetchDelivery();
    };

    const handleEdit = async (id, data, companyId) => {            
        await EditDeliveryman(id , data, companyId);
        fetchDelivery();
    };

    const handleDelete = async (id, companyId) => {        
        await DeleteDeliveryman(id, companyId);
        fetchDelivery();
    };

    return (
        <PageContainer title="DeliveryInfo Table" description="This is DeliveryInfo Table">
            <DashboardCard>
                <DataTable
                    title={"DeliveryInfo Table"}
                    titleButton={"New Delivery"}
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

// export default DeliveryInfo;

function mapStateToProps(state) {
    return { auth: state.auth };
}

export default connect(mapStateToProps, actions)(DeliveryInfo);