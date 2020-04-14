// Redux
import {combineReducers} from "redux";

// Different reducers
import GetAllArticlesReducer from './GetAllArticlesReducer';

const allReducers = combineReducers({
   listArticles : GetAllArticlesReducer
});

export default allReducers;