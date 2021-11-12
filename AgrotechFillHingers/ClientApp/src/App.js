import React from 'react';
import { Switch, Route } from 'react-router-dom';

import './custom.css'
import Login from './pages/Login';

const App = (props) => {

    return (
        <Switch>
            <Route exact path="/login" component={(props) => <Login {...props} />} />
        </Switch>
    );
}

export default App;
