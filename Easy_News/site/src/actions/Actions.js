export const getAllArticles = (payload) => {
    return {
        type: 'REQUEST_POSTS_ARTICLES',
        payload
    };
};

export const searchArticles = (payload) => dispatch => {
    dispatch({
        type: 'SEARCH_TEXT',
        payload: payload
    });
};
