import * as types from './ActionsTypes'

export const RequestArticles = () => {
    return {
        type: types.REQUEST_POSTS_ARTICLES,
    };
};

export const SetArticles = (payload) => {
    return {
        type: types.SET_ARTICLES,
        payload
    };
};

export const Pagination_SET = (payload) => {
    return {
        type: types.PAGINATION_SET,
        payload
    };
};

export const Pagination_UP = () => {
    return {
        type: types.PAGINATION_UP,
    };
};

export const Pagination_DOWN = () => {
    return {
        type: types.PAGINATION_DOWN,
    };
};

export const Pagination_RESET = () => {
    return {
        type: types.PAGINATION_RESET,
    };
};

export const showSearchArticles = () => {
    return {
        type: types.SHOW_SEARCH_ARTICLES,
    };
};

export const searchTextInput = (payload) => {
    return {
        type: types.SEARCH_TEXT_INPUT,
        payload
    };
};

export const searchTextClear = () => {
    return {
        type: types.SEARCH_TEXT_CLEAR,
    };
};

export const showSearchYes = () => {
    return {
        type: types.SHOW_SEARCH_ARTICLE_YES,
    };
};

export const showSearchNo = () => {
    return {
        type: types.SHOW_SEARCH_ARTICLE_NO,
    };
};