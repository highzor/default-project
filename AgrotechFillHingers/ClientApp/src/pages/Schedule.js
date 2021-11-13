import React, { useState } from 'react';
import {
    Space,
    Layout,
    Tag,
    Table,
    Avatar
} from 'antd';
import { UserOutlined } from '@ant-design/icons';

import { ScheduleService } from '../api_services/Schedule.service'
import { ScheduleStatusService } from '../api_services/ScheduleStatus.service'
import AsyncLoader from '../helpers/AsyncLoader';

const { Column } = Table;
const { Content } = Layout;

const getData = async ({ params }) => {
    let data = [];

    let sheduleData = await ScheduleService.list();
    let sheduleStatusesData = await ScheduleStatusService.list();

    data["SheduleList"] = sheduleData;
    data["SheduleStatusList"] = sheduleStatusesData;
}


const ScheduleTable = (props) => {

    const statusPack = [
        {
            color: 'grey',
            reason: 'Создан'
        },
        {
            color: 'geekblue',
            reason: 'Выбраны исполнители'
        },
        {
            color: 'red',
            reason: 'Нужна замена'
        },
        {
            color: 'orange',
            reason: 'Принято у партнера'
        },
        {
            color: 'blue',
            reason: 'Выполнено'
        },
    ];

    const data = [
        {
            key: '1',
            date: '12.12.2021',
            time: '12:00',
            address: 'Хлеб Насущный, Ивантеевская ул., д.4 к.1',
            status: 0,
            volunteers: ['nice', 'developer'],
        },
        {
            key: '2',
            date: '13.12.2021',
            time: '12:01',
            address: 'Хлеб Насущный, Ивантеевская ул., д.4 к.1',
            status: 1,
            volunteers: ['nice', 'developer'],
        },
        {
            key: '3',
            date: '14.12.2021',
            time: '12:02',
            address: 'Хлеб Насущный, Ивантеевская ул., д.4 к.1',
            status: 2,
            volunteers: ['nice', 'deeloper'],
        },
    ];

    return (


        <Table dataSource={props.data}>
            <Column title="Дата" dataIndex="date" key="date" />
            <Column title="Время" dataIndex="time" key="time" />
            <Column title="Адрес" dataIndex="address" key="address" />
            <Column title="Статус" dataIndex="status" key="status"
                render={(data) => {
                    let statusData = props.data.SheduleStatusList.find((val) => val.id == data.status);
                    return <Tag color={statusData.color}>{statusData.reason}</Tag>;
                }}>
            </Column>
            <Column flex='40px'
                title="Волонтеры"
                dataIndex="volunteers"
                key="volunteers"
                render={volunteers => (
                    <>
                        {volunteers.map(volunteer => (
                            <Avatar
                                key={volunteer}
                                //icon={<img src={'' + volunteer.Photo} />}
                                icon={<UserOutlined />}
                                shape='sicle'
                            />
                        ))}
                    </>
                )}
            />
            <Column
                title="Action"
                key="action"
                render={(text, record) => (
                    <Space size="middle">
                        <a>Invite {record.lastName}</a>
                        <a>Delete</a>
                    </Space>
                )}
            />
        </Table>

    )
}

const Schedule = (props) => {
    return (
        <Layout className="inner-content">
            <Content>
                <AsyncLoader {...props}
                    asyncFunc={getData}
                >
                    <ScheduleTable {...props} />
                </AsyncLoader>
            </Content>
        </Layout>
    )
}

export default Schedule;