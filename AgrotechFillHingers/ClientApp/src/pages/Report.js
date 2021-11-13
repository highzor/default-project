import { Space, Typography } from 'antd';
import React from 'react';

import { UserService } from '../api_services/User.service'

const { Text } = Typography;

const Report = (props) => {

    UserService.info(1);

    return (
        <Space >
            <Text> Отчеты </Text>
        </Space>
    )
}

export default Report;