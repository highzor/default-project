import React from 'react';
import { Switch, Route } from 'react-router-dom';

import 'antd/dist/antd.css';
import CreateTask from './pages/CreateTask';
import Login from './pages/Login';

const App = (props) => {

    return (
        <Switch>
            <Route exact path="/login" component={(props) => <Login {...props} />} />
            <Route exact path="/content" component={(props) => <CreateTask {...props} />} />
        </Switch>
    );
}

export default App;
