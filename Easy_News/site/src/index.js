import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';

// Bootstrap
import 'bootstrap';
import 'bootstrap/dist/js/bootstrap.js';

import {BrowserRouter, Switch, Route} from "react-router-dom";

// Components
import Home from "./Components/Home";

// Routes
ReactDOM.render(
    <BrowserRouter>
        <div>
            <Switch>
                <Route exact path="/" component={Home}/>
            </Switch>
        </div>
    </BrowserRouter>,
    document.getElementById("app")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
