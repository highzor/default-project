import React from 'react';
import { Switch, Route } from 'react-router-dom';

import 'antd/dist/antd.css';
import Login from './pages/Login';
import Landing from './pages/Landing';
import PageLayout from './pages/Layout/PageLayout';
import CabinetCard from './pages/CabinetCard';

import './Styles.css';

const App = (props) => {

    return (
        <PageLayout>
            <Switch>
                <Route exact path="/" component={(props) => <Landing {...props} />} />
                <Route exact path="/login" component={(props) => <Login {...props} />} />
                <Route exact path="/cabinet" component={(props) => <CabinetCard {...props} />} />
            </Switch>
        </PageLayout>
    );
}

export default App;
