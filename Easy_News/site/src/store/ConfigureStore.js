import { createStore } from 'redux';
import GetAllArticlesReducer from '../reducers/GetAllArticlesReducer';

const configureStore = () => {
    return createStore(
        GetAllArticlesReducer,
    );
};

export default configureStore