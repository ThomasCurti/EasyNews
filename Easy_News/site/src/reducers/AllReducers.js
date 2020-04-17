// Redux
import {combineReducers} from "redux";

// Different reducers
import GetAllArticlesReducer from './GetAllArticlesReducer';

const allReducers = combineReducers({
   Articles : GetAllArticlesReducer
});

export default allReducers;