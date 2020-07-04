import {delay, put, takeLatest, select} from "redux-saga/effects";
import {SEARCH_TEXT_INPUT} from "../Actions/ActionsTypes";
import {Pagination_RESET, showSearchArticles, showSearchNo, showSearchYes} from "../Actions/Actions";

const SearchInputState = state => state.Articles.searchText;

function* handleSearchInput() {
    // Delay by 500ms
    yield delay(500);
    const searchInput = yield select(SearchInputState);
    yield put(Pagination_RESET());
    if (searchInput !== ''){
        yield put(showSearchArticles());
        yield put(showSearchYes());
    }
    else{
        yield put(showSearchNo());
    }
}

function* SearchSaga() {
    yield takeLatest(SEARCH_TEXT_INPUT, handleSearchInput)
}

export default SearchSaga;