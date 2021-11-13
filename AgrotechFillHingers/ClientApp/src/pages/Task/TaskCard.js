import {
    Layout,
    Form,
    Input,
    Button,
    Radio,
    Select,
    DatePicker,
    Tabs,
    PageHeader,
    Space,
    Typography
} from 'antd';
import React, { useState } from 'react';
import { PlusOutlined, UserOutlined, CalendarOutlined, UnorderedListOutlined, EditOutlined } from '@ant-design/icons';
import { TasksService } from '../../api_services/Tasks.service'

import AsyncLoader from '../../helpers/AsyncLoader';

const { Content, Header } = Layout;
const { Text, Title } = Typography;
const { TabPane } = Tabs;

const getData = async ({ params }) => {
    let data = [];

    let taskInfo = await TasksService.info(params.id);

    data["Info"] = taskInfo;

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
                            <Title style={{ marginBottom: '0px' }} level={3}>{props.data.Info.name}</Title >
                            <Text style={{ fontSize: '14px' }} type="secondary">{props.data.Info.partner_law_name + "," + props.data.Info.partner_law_name + "•" + props.data.Info.partner_address}</Text>
                        </Space>

                    }
                    extra={
                        <Button key="1" type="primary" icon={<EditOutlined />} > Редактировать </Button>
                    }
                >
                    <Tabs defaultActiveKey="1" >
                        <TabPane tab="Общие сведения" key="1">
                            Content of Tab Pane 1
                        </TabPane>
                        <TabPane tab="Акт приема-передачи" key="2">
                            Content of Tab Pane 2
                        </TabPane>
                    </Tabs>
                </PageHeader>
            </Header>
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