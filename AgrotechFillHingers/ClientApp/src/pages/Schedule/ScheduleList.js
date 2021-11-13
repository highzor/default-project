import React, { useState } from 'react';
import {
    Space,
    Layout,
    Tag,
    Table,
    Avatar,
} from 'antd';
import { UserOutlined } from '@ant-design/icons';

import moment from 'moment';
import 'moment/locale/ru';
moment.locale('ru');

const { Column } = Table;
const { Content} = Layout;


const ScheduleList = (props) => {
   
    return (
        <Layout className="inner-content">
            <Content style={{ margin: '24px' }}>
                <Table
                    bordered
                    style={{ margin: '24px' }}
                    dataSource={props.data.SheduleList}
                >
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
                        title="Действия"
                        key="action"
                        render={(text, record) => (
                            <Space size="middle">
                                <a>Invite {record.lastName}</a>
                                <a>Delete</a>
                            </Space>
                        )}
                    />
                </Table>
            </Content >
        </Layout>
    )
}

export default ScheduleList;