import {
    Layout,
    Form,
    Input,
    Button,
    Radio,
    Select,
    DatePicker,
    TimePicker
} from 'antd';
import React, { useState } from 'react';

import moment from 'moment';

const { Content } = Layout;
const { TextArea } = Input;

const format = 'HH:mm';

const CreateTask = (props) => {

    const [taskType, setTaskType] = useState(1);
    const [volunteers, setVolunteers] = useState([]);

    const options = [];

    for (let i = 0; i < 4; i++) {
        
        const value = i.toString(36) + i;
        options.push({
            label: `ИмяВолонтера ФамилияВолонтера ОтвечтствоВолонтера ${i}`,
            value,
        });
    }

    const selectProps = {
        mode: 'multiple',
        style: {
            width: '100%',
        },
        volunteers,
        options,
        onChange: (newValue) => {
            setVolunteers(newValue);
        },
        placeholder: 'Select Item...',
        maxTagCount: 'responsive',
    };

    const layout = {
        labelCol: {
            span: 8,
        },
        wrapperCol: {
            span: 8,
        },
    };
    const tailLayout = {
        wrapperCol: {
            offset: 8,
            span: 16,
        },
    };

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
                <Form
                    {...layout}
                    layout="horizontal"
                >
                    <Form.Item label="Задание:">
                        <Input />
                    </Form.Item>
                    <Form.Item label="Партнер:">
                        <Select>
                            <Select.Option value="demo">Demo</Select.Option>
                        </Select>
                    </Form.Item>
                    <Form.Item label="Тип задания:">
                        <Radio.Group onChange={(e) => setTaskType(e.target.value)} value={taskType}>
                            <Radio value={1}>Разовое</Radio>
                            <Radio value={2}>Повторяющееся</Radio>
                        </Radio.Group>
                    </Form.Item>
                    <Form.Item label="Дата:">
                        <DatePicker />
                    </Form.Item>
                    <Form.Item label="Время:">
                        <TimePicker defaultValue={moment('12:08', format)} format={format} />
                    </Form.Item>
                    <Form.Item label="Волонтеры:">
                        <Select {...selectProps} />
                    </Form.Item>
                    <Form.Item label="Контактный телефон:">
                        <TextArea placeholder="textarea with clear icon" allowClear onChange={''} />
                    </Form.Item>
                    <Form.Item label="Описание:">
                        <TextArea placeholder="textarea with clear icon" allowClear onChange={''} />
                    </Form.Item>
                    <Form.Item {...tailLayout}>
                        <Button type="primary" htmlType="submit">Сохранить</Button>
                        <Button htmlType="button" onClick={(value) => console.log(value)}>Отменить</Button>
                    </Form.Item>
                </Form>
            </Content>
        </Layout>
    )
}

export default CreateTask;