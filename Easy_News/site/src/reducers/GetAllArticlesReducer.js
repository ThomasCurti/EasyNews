/*

// Require
const axios = require('axios');
const https = require('https');

// For Development api
const agent = new https.Agent({
    rejectUnauthorized: false,
});

// Create client
const client = axios.create({
    responseType: 'json',
    withCredentials: true,
    httpsAgent: agent
});
*/
import * as actionTypes from '../Actions/ActionsTypes'

const TOTAL_PER_PAGE = 5;

const initialState = {
    listArticles : [
        {
            id: 1,
            title : "Article 1",
            description : "Description de l'article 1",
            full_article : "Ceci est le texte complet de l'article 1.",
            source : "https://www.google.com/",
        },
        {
            id: 2,
            title : "Article 2",
            description : "Description de l'article 2",
            full_article : "Ceci est le texte complet de l'article 2.",
            source : "https://www.google.com/",
        },
        {
            id: 3,
            title : "Article 3",
            description : "Description de l'article 3",
            full_article : "Ceci est le texte complet de l'article 3.",
            source : "https://www.google.com/",
        },
        {
            id: 4,
            title : "Article 4",
            description : "Description de l'article 4",
            full_article : "Ceci est le texte complet de l'article 4.",
            source : "https://www.google.com/",
        },
        {
            id: 5,
            title : "Article 5",
            description : "Description de l'article 5",
            full_article : "Ceci est le texte complet de l'article 5.",
            source : "https://www.google.com/",
        }],
    page: 0,
    totalPages: 1,
    TOTAL_PER_PAGE: 5,
    searchText: '',
    searchTotalPages: 1,
    searchListArticles : [],
};

const GetAllArticlesReducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.REQUEST_POSTS_ARTICLES:
            const totalPagesTmp = Math.ceil(action.payload.length / TOTAL_PER_PAGE);
            const totalPages = totalPagesTmp ? totalPagesTmp : 1;
            return {
                ...state,
                listArticles: action.payload,
                page: 0,
                totalPages: totalPages
            };
        case actionTypes.PAGINATION_SET:
            return {
                ...state,
                page: action.payload
            };
        case actionTypes.PAGINATION_UP:
            return {
                ...state,
                page: state.page + 1
            };
        case actionTypes.PAGINATION_DOWN:
            return {
                ...state,
                page: state.page - 1
            };
        case actionTypes.PAGINATION_RESET:
            return {
                ...state,
                page: 0
            };
        case  actionTypes.SEARCH_TEXT:
            const searchTextLowerCase = action.payload.toLowerCase();
            const searchListArticles = state.listArticles.filter((item) => {
                const itemLowerCase = item.title.toLowerCase();
                return itemLowerCase.includes(searchTextLowerCase);
            });
            const searchTotalPagesTmp = Math.ceil(searchListArticles.length / TOTAL_PER_PAGE);
            const searchTotalPages = searchTotalPagesTmp ? searchTotalPagesTmp : 1;

            return {
                ...state,
                searchText: action.payload,
                searchListArticles: searchListArticles,
                searchTotalPages: searchTotalPages,
                page: 0,
            };
        case actionTypes.SEARCH_TEXT_CLEAR:
            return {
              ...state,
                searchText: ''
            };
        default:
            return state;
    }
};

export default GetAllArticlesReducer;