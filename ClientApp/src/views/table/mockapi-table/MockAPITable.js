import React from 'react';
import PageContainer from 'src/components/container/PageContainer';
import DataTable from '../DataTable';
import DashboardCard from 'src/components/shared/DashboardCard';
import { GetMockApiData } from 'src/api/MockAPI';

const MockAPITable = () => {
    
    return (
        // <PageContainer title="MockAPI Table" description="This is MockAPI Table">
        //     <DashboardCard>
        //         <DataTable title={"MockAPI Table"} titleButton={"New User"} fetchData={GetMockApiData} />
        //     </DashboardCard>
        // </PageContainer>
        <div>
            This is MockApi Table
        </div>
    );
}

export default MockAPITable;
