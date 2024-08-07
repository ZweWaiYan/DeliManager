import React, { useEffect, useReducer, useRef, useState } from "react";
import PageContainer from "src/components/container/PageContainer";
import DataTable from '../table/DataTable';
import DashboardCard from 'src/components/shared/DashboardCard';
import { FetchDeliverymanList } from "src/api/DeliveryAPI";

import { connect } from 'react-redux';
import * as actions from './../../actions/authActions';

import stringValue from "../utilities/StringValue";

import { DeleteDeliveryman , CreateDeliveryman , EditDeliveryman} from '../../api/DeliveryAPI';

const DeliveryInfo = ({ auth }) => {

    console.log("DeliveryInfo Render")

    const [dataList, setDataList] = useState([]);
    const [titleList, setTitleList] = useState([]);
    const [totalCount, setTotalCount] = useState(0);
    const [apiResponse, setAPIResponse] = useState();

    const fetchDelivery = async () => {        
        const res = await FetchDeliverymanList(auth.companyId);

        console.log("fetch DeliveryInfo");
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
        const res = await CreateDeliveryman(data, companyId);                
        setAPIResponse(res);
        fetchDelivery();
    };

    const handleEdit = async (id, data, companyId) => {            
        const res = await EditDeliveryman(id , data, companyId);
        setAPIResponse(res);
        fetchDelivery();
    };

    const handleDelete = async (id, companyId, routeId) => {        
        const res = await DeleteDeliveryman(id, companyId, routeId);
        setAPIResponse(res);
        fetchDelivery();
    };

    return (
        <PageContainer title="DeliveryInfo Table" description="This is DeliveryInfo Table">
            <DashboardCard>
                <DataTable
                    title={stringValue[0]}                    
                    titleButton={"New Delivery"}
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

// export default DeliveryInfo;

function mapStateToProps(state) {
    return { auth: state.auth };
}

export default connect(mapStateToProps, actions)(DeliveryInfo);