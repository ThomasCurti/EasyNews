import {put} from "redux-saga/effects";
import {RequestArticles} from "../Actions/Actions";

let dayInterval = 1000 * 60 * 60 * 24;

const waitXMilliseconds = (x) =>
    new Promise((resolve) => {
        setTimeout(() => {
            resolve(true);
        }, x)
    });

function* BackEndSaga() {
    while (true) {
        yield put(RequestArticles());
        yield waitXMilliseconds(dayInterval);
    }
}

export default BackEndSaga;