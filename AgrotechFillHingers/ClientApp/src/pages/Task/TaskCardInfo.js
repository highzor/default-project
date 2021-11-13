
import React, { useState } from 'react';
import {
    Layout,
    Space,
    Row,
    Col,
    Typography
} from 'antd';

import moment from 'moment';
import 'moment/locale/ru';
import { ReloadOutlined, EnvironmentOutlined, CalendarOutlined, ClockCircleOutlined, PhoneOutlined } from '@ant-design/icons';
import { Divider } from 'antd/es';
moment.locale('ru');

const { Content } = Layout;
const { Text, Link, Title } = Typography;

const TaskCardInfo = (props) => {

    return (
        <Layout className="inner-content">

            <Content style={{ margin: '24px' }}>
                <Space direction="vertical" size={4}>
                    <Title style={{ marginBottom: '0px' }} level={3}>{props.data.Info.partner_law_name}</Title >
                    <Text style={{ fontSize: '14px' }} type="secondary">{props.data.Info.partner_law_name}</Text>
                    <Row gutter={16}>
                        <Col className="gutter-row" span={12}>
                            <Space direction="vertical" size={4}>
                                <Space direction="horizontal" size={2}>
                                    <ReloadOutlined />
                                    <Text>{"Разовое"}</Text>
                                </Space>
                                <Divider />
                                <Space direction="horizontal" size={2}>
                                    <EnvironmentOutlined />
                                    <Text>{props.data.Info.partner_address}</Text>
                                </Space>
                                <Space direction="horizontal" size={2}>
                                    <CalendarOutlined />
                                    <Text>{props.data.Info.delivery_date}</Text>
                                </Space>
                                <Space direction="horizontal" size={2}>
                                    <ClockCircleOutlined />
                                    <Text>{props.data.Info.delivery_time}</Text>
                                </Space>
                                <Divider />
                                <Space direction="horizontal" size={2}>
                                    <Text><PhoneOutlined /> Лицо от организации:</Text>
                                 
                                    <Text>{props.data.Info.delivery_date}</Text>
                                </Space>
                                <Space direction="horizontal" size={2}>
                                    <Text><PhoneOutlined /> Координатор:</Text>
                                    <Text>{props.data.Info.coordinator_name} <Link href={"tel:" + props.data.Info.coordinator_phone}> {props.data.Info.coordinator_phone}</Link></Text>
                                </Space>
                            </Space>
                        </Col>
                        <Col className="gutter-row" span={12}>
                            <div style={style}>col-6</div>
                        </Col>
                    </Row>
                </Space>
            </Content >
        </Layout>
    )
}

export default TaskCardInfo;