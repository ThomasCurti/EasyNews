import * as types from './ActionsTypes'

export const getAllArticles = (payload) => {
    return {
        type: types.REQUEST_POSTS_ARTICLES,
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

export const searchArticles = (payload) => dispatch => {
    dispatch({
        type: types.SEARCH_TEXT,
        payload: payload
    });
};
