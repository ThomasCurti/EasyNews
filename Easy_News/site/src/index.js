import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';

// Bootstrap
import 'bootstrap';
import 'bootstrap/dist/js/bootstrap.js';

// Components
import App from "./Components/App";

// Redux and store
import {Provider} from "react-redux";
import configureStore from "./store/ConfigureStore";



const store = configureStore();

ReactDOM.render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById("app"));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
