import React, { cloneElement } from 'react';

import { Button, Result, Spin } from 'antd';
import Async from 'react-async';
import { useHistory } from 'react-router-dom';


const AsyncLoader = (props) => {
    const history = { useHistory };

    return (
        <Async
            params={props}
            promiseFn={props.asyncFunc}
        >
            <Async.Pending>
                <Spin />
            </Async.Pending>
            <Async.Fulfilled>
                {(data, obj) => {
                    if (Array.isArray(props.children)) {
                        let childrens = [];
                        props.children.forEach((child, index) => {
                            childrens.push(cloneElement(child, { ...props, data: data, asyncObj: obj, key:index }));
                        })

                        return childrens;
                    }
                    else {
                        return cloneElement(props.children, { ...props, data: data, asyncObj: obj })
                    }
                }}

            </Async.Fulfilled>
            <Async.Rejected>
                {(error, obj) => {
                    let error_type = error.message === 'Unauthorized' ? 'auth' : 'inner';

                    if (error_type === 'auth') {
                        return (
                            <Result
                                status="warning"
                                subTitle="Сейчас вы будете переадресованы на страницу авторизации"
                                title="Необходима авторизация"
                            />
                        )
                    }
                    else {
                        return (
                            <Result
                                extra={[
                                    <Button
                                        key={1}
                                        onClick={() => history.push('/')}
                                        type="primary"
                                    >
                                        Вернуться на главную
                                    </Button>,
                                    <Button
                                        key={2}
                                        onClick={() => obj.reload()}
                                        type="primary"
                                    >
                                        Попробовать еще раз
                                    </Button>
                                ]}
                                status="error"
                                subTitle="Произошла внутренняя ошибка."
                                title="Произошла ошибка"
                            />
                        )
                    }

                }}
            </Async.Rejected>
        </Async>
    )
}

export default AsyncLoader;