import React, { cloneElement } from 'react';

import ruRu from 'antd/lib/locale/ru_RU';

import { ConfigProvider, Menu, Layout, Space, Avatar } from 'antd';
import { UserOutlined, DashboardOutlined, TableOutlined, FormOutlined, ShoppingCartOutlined, ProjectOutlined, LogoutOutlined } from '@ant-design/icons';
import { useGlobalState } from '../../helpers/GlobalState';

import { useHistory, useLocation } from 'react-router-dom';

const { Header, Content } = Layout;

const PageLayout = (props) => {
    let history = useHistory();
    let location = useLocation();

    const [id] = useGlobalState('id');
    const [photo] = useGlobalState('photo');
    const [role] = useGlobalState('role');

    const handleClick = (e) => {
        if (e.key !== location.pathname) {
            history.push(e.key);
        }
    }

    let childrens = [];
    if (Array.isArray(props.children)) {
        props.children.forEach((child, index) => {
            childrens.push(
                cloneElement(child, { key: index, history: history })
            )
        })
    }
    else {
        childrens.push(
            cloneElement(props.children, { key: 1, history: history })
        )
    }

    return (
        <ConfigProvider locale={ruRu}>
            <Layout>
                <Header>
                    <span className="main-menu">
                        <Menu
                            mode="horizontal"
                            onClick={handleClick}
                            defaultSelectedKeys={[location.pathname]}
                        >
                            <Menu.Item key="/home" >О нас</Menu.Item>
                            <Menu.Item key="/cabinet" >Личный кабинет</Menu.Item>
                            <Menu.Item key="photo" style={{ width: 50, marginLeft: 'auto' }}>
                                <span className="submeny-title-wrapper">
                                    {' '}
                                    <Avatar
                                        icon={
                                            photo ? (<img src={'data:image/jpeg;base64,' + photo} />)
                                                : (<UserOutlined style={{ fontSize: '28px'}} />)
                                        }
                                        size={40}
                                    />
                                </span>
                            </Menu.Item>
                            <Menu.Item key="4" icon={<LogoutOutlined />} />
                        </Menu>
                    </span>
                </Header>
                <Content>
                    {childrens}
                </Content>
            </Layout>
        </ConfigProvider>
    );
}

export default PageLayout;