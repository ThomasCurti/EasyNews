// Redux
import {combineReducers} from "redux";

// Different Reducers
import GetAllArticlesReducer from './GetAllArticlesReducer';

const allReducers = combineReducers({
   Articles : GetAllArticlesReducer
});

export default allReducers;