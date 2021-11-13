import React, { useState } from 'react';
import {
    Layout,
    Calendar,
    Badge,
} from 'antd';

import moment from 'moment';
import 'moment/locale/ru';
moment.locale('ru');

const { Content } = Layout;

const ScheduleCalendar = (props) => {
    const dateCellRender = (value) => {
        const listData = props.data.SheduleList.filter(val => val.date === value);
        return (
            <ul className="events">
                {listData.map(item => {
                    let statusData = props.data.SheduleStatusList.find((val) => val.id == item.status);
                    return (
                        <li key={item.address} >
                            <Badge status={statusData.color} text={item.address} />
                        </li>
                    )
                }
                )}
            </ul>
        );
    }

    return (
            <Layout className="inner-content">

                <Content style={{ margin: '24px' }}>
                    <Calendar dateCellRender={dateCellRender} />
                </Content >
            </Layout>
    )
}

export default ScheduleCalendar;