import {
    Layout,
    Form,
    Input,
    Button,
    Radio,
    Select,
    DatePicker,
    TimePicker,
    PageHeader,
    Space,
    Typography
} from 'antd';
import React, { useState } from 'react';
import { PlusOutlined, UserOutlined, CalendarOutlined, UnorderedListOutlined, EditOutlined } from '@ant-design/icons';

import AsyncLoader from '../../helpers/AsyncLoader';

const { Content, Header } = Layout;
const { Text, Title } = Typography;
const { TextArea } = Input;


const getData = async ({ params }) => {
    let data = [];



    return data;
}

const TaskCardView = (props) => {

    return (
        <>
            <Header>
                <PageHeader
                    ghost={false}
                    title={
                        <Space direction="vertical" size={1}>
                            <Title style={{ marginBottom: '0px' }} level={3}>{'Карточка'}</Title >
                            <Text style={{ fontSize: '14px' }} type="secondary">{'Cледите за заданиями и создавайте новые'}</Text>
                        </Space>

                    }
                    extra={
                        <Button key="1" type="primary" icon={<EditOutlined />} > Редактировать </Button>
                    }
                >
                </PageHeader>
            </Header>
            <Layout className="inner-content">
                <Content style={{ margin: '24px' }}>

                </Content >
            </Layout>
        </>
    )
}

const TaskCard = (props) => {
    return (

        <AsyncLoader {...props}
            asyncFunc={getData}
        >
            <TaskCardView {...props} />
        </AsyncLoader>


    )
}

export default TaskCard;