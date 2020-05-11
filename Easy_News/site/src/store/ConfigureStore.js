import {createStore} from 'redux';
import allReducers from "../Reducers/AllReducers";

const configureStore = () => {
    return createStore(
        allReducers,
        window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());
};

const store = configureStore();

export default store;