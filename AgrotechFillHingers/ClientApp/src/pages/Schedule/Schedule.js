import React, { useState } from 'react';
import {
    Space,
    Layout,
    Tag,
    Table,
    Avatar,
    PageHeader,
    Button,
    Calendar,
    Badge,
    Typography,
    Modal
} from 'antd';
import { PlusOutlined, UserOutlined, CalendarOutlined, UnorderedListOutlined } from '@ant-design/icons';

import { ScheduleService } from '../../api_services/Schedule.service'
import { ScheduleStatusService } from '../../api_services/ScheduleStatus.service'
import AsyncLoader from '../../helpers/AsyncLoader';

import moment from 'moment';
import 'moment/locale/ru';
import ScheduleCalendar from './ScheduleCalendar';
import ScheduleList from './ScheduleList';
import CreateTask from '../Task/CreateTask';
import TaskCard from '../Task/TaskCard';
moment.locale('ru');

const { Column } = Table;
const { Text, Title } = Typography;
const { Content, Header } = Layout;

const getData = async ({ params }) => {
    let data = [];

    let sheduleData = await ScheduleService.list();
    let sheduleStatusesData = await ScheduleStatusService.list();

    data["SheduleList"] = sheduleData;
    data["SheduleStatusList"] = sheduleStatusesData;

    return data;
}


const ScheduleTable = (props) => {
    const [displayCalendar, setDisplayCalendar] = useState(false);
    const [displayAdd, setDisplayAdd] = useState(false);
    const [taskId, setTaskID] = useState(null);

    return (
        <>
            {
                !taskId &&
                <>
                    <Header>
                        <PageHeader
                            ghost={false}
                            title={
                                <Space direction="vertical" size={1}>
                                    <Title style={{ marginBottom: '0px' }} level={3}>{!displayAdd ? 'Расписание' : 'Создать задание'}</Title >
                                    <Text style={{ fontSize: '14px' }} type="secondary">{!displayAdd ? 'Cледите за заданиями и создавайте новые' : 'Создайте задание для волонтеров'}</Text>
                                </Space>

                            }
                            extra={
                                !displayAdd ?
                                    [
                                        <Button key="1" type="primary" icon={<PlusOutlined />} onClick={() => setDisplayAdd(!displayAdd)}> Добавить задание </Button>,
                                        <Button key="2" icon={displayCalendar ? <UnorderedListOutlined /> : < CalendarOutlined />} onClick={() => setDisplayCalendar(!displayCalendar)} />,
                                    ]
                                    : undefined
                            }
                        >
                        </PageHeader>
                    </Header>
                    {
                        displayCalendar && !displayAdd &&
                        <ScheduleCalendar data={props.data} />
                    }
                    {
                        !displayCalendar && !displayAdd &&
                        <ScheduleList data={props.data} />
                    }
                    {
                        displayAdd &&
                        <CreateTask onOk={() => setDisplayAdd(!displayAdd)} />
                    }
                </>
            }
            {
                taskId &&
                <TaskCard onOk={() => setDisplayAdd(!displayAdd)} />
            }
        </>
    )
}

const Schedule = (props) => {
    return (

        <AsyncLoader {...props}
            asyncFunc={getData}
        >
            <ScheduleTable {...props} />
        </AsyncLoader>


    )
}

export default Schedule;