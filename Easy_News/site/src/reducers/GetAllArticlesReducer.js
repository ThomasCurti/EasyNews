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
const initialState = [
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
        }
];

const GetAllArticlesReducer = (state = initialState, action) => {
    switch (action.type) {
        case 'REQUEST_POSTS_ARTICLES':
            return action.payload;
        default:
            return state;
    }
};

export default GetAllArticlesReducer;