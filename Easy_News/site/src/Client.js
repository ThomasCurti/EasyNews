// Require
const axios = require('axios');
const https = require('https');

// For Development api
const agent = new https.Agent({
    rejectUnauthorized: false,
});

// Create client
export const client = axios.create({
    responseType: 'json',
    withCredentials: false,
    httpsAgent: agent
});

export const getAllArticlesApiCall = "https://localhost:443/api/Article";
export const getArticleByIdApiCall = (id) => {
    return "https://localhost:443/api/Article/" + id
};