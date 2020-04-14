export const getAllArticles = (payload) => {
    return {
        type: 'REQUEST_POSTS_ARTICLES',
        payload
    };
};