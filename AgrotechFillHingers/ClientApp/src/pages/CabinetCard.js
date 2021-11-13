import React, { useState } from 'react';

import { Tabs } from 'antd';
import { useGlobalState } from '../helpers/GlobalState';
import { UserOutlined, AppstoreOutlined, TableOutlined, ShoppingCartOutlined, ProjectOutlined, FormOutlined, UserSwitchOutlined} from '@ant-design/icons';
import Report from './Report';

const { TabPane } = Tabs;

const CabinetCard = (props) => {
    const [role] = useGlobalState('role');

    return (
        <Tabs
            destroyInactiveTabPane
            tabPosition="left"
        >
            <TabPane
                key="cabinet_main"
                tab={<span> <AppstoreOutlined /> Основное </span>}
            >

            </TabPane>
            <TabPane
                key="cabinet_schedule"
                tab={<span> <TableOutlined /> Расписание </span>}
            >

            </TabPane>
            <TabPane
                key="cabinet_tasks"
                tab={<span> <FormOutlined /> Задания </span>}
            >

            </TabPane>
            {
                (role === 2 || role === 3) &&
                <TabPane
                    key="cabinet_volunteers"
                    tab={<span> <UserOutlined /> Волонтеры </span>}
                >

                </TabPane>
            }
            {
                role === 3 &&
                <TabPane
                    key="cabinet_curators"
                    tab={<span> <UserSwitchOutlined /> Кураторы </span>}
                >

                </TabPane>
            }
            {
                (role === 2 || role === 3) &&
                <TabPane
                    key="cabinet_partners"
                    tab={<span> <ShoppingCartOutlined /> Партнеры </span>}
                >

                </TabPane>
            }
            {
                role === 3 &&
                <TabPane
                    key="cabinet_reports"
                    tab={<span> <ProjectOutlined /> Отчеты </span>}
                >
                    <Report />
                </TabPane>
            }
           
        </Tabs>
    );
}

export default CabinetCard;