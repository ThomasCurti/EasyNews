import {call, delay, put, takeLatest} from "redux-saga/effects";
import {REQUEST_POSTS_ARTICLES} from "../Actions/ActionsTypes";
import {client, getAllArticlesApiCall} from "../Client";
import {SetArticles} from "../Actions/Actions";

function apiCallToFetch() {
    return client.get(getAllArticlesApiCall);
}

function* fetchArticles() {
    try {
        const fetchedArticles = yield call(apiCallToFetch);
        yield delay(2000);
        console.log('Articles :' + fetchedArticles.data);
        yield put(SetArticles(fetchedArticles.data));
    } catch (error) {
        console.log("Error Fetch Articles");
    }
}

function* SiteSaga() {
    yield takeLatest(REQUEST_POSTS_ARTICLES, fetchArticles);
}

export default SiteSaga;