import {
    Space,
    Typography,
    Layout,
    Form,
    Input,
    Button,
    Radio,
    Select,
    Cascader,
    DatePicker,
    InputNumber,
    TimePicker,
    Switch,
    Tag,
    Table,
    Avatar
} from 'antd';
import { UserOutlined, AppstoreOutlined, TableOutlined, ShoppingCartOutlined, ProjectOutlined, FormOutlined, UserSwitchOutlined } from '@ant-design/icons';
import React, { useState } from 'react';
import moment from 'moment';

const { Column } = Table;
const { Content } = Layout;

const Schedule = (props) => {

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
            volunteers: ['nice', 'developer'],
        },
    ];

    return (

        <Layout style={{ padding: '0 24px 24px' }}>
            <Content
                className="site-layout-background"
                style={{
                    padding: 24,
                    margin: 0,
                    minHeight: 280,
                }}
            >
                <Table dataSource={data}>
                    <Column title="Дата" dataIndex="date" key="date" />
                    <Column title="Время" dataIndex="time" key="time" />
                    <Column title="Адрес" dataIndex="address" key="address" />
                    <Column title="Статус" dataIndex="status" key="status"
                    render={(data) => {

                        switch (data.status) {

                            case 0:
                                return <Tag color={statusPack[0].color}>{statusPack[0].reason}</Tag>
                            case 1:
                               return <Tag color={statusPack[1].color}>{statusPack[1].reason}</Tag>
                            case 2:
                                return <Tag color={statusPack[2].color}>{statusPack[2].reason}</Tag>
                            case 3:
                                return <Tag color={statusPack[3].color}>{statusPack[3].reason}</Tag>
                            case 4:
                                return <Tag color={statusPack[4].color}>{statusPack[4].reason}</Tag>                                     
                        }
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
            </Content>
        </Layout>
    )
}

export default Schedule;