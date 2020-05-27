import {createStore, applyMiddleware, compose} from 'redux';
import allReducers from "../reducers/AllReducers";
import createSagaMiddleware from 'redux-saga';
import BackEndSaga from "../Sagas/BackEndSaga";
import SiteSaga from "../Sagas/SiteSaga";
import SearchSaga from "../Sagas/SearchSaga";

const sagaMiddleware = createSagaMiddleware();

const enhancer = compose(
    applyMiddleware(sagaMiddleware),
    // eslint-disable-next-line no-underscore-dangle
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
);

export const store = createStore(allReducers, enhancer);

[SiteSaga, BackEndSaga, SearchSaga].map(saga => sagaMiddleware.run(saga));

export default store;