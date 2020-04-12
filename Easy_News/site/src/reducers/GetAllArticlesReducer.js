import { GetAllArticles } from '../actions/Actions'

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

const initialState = {
    articles: []
};

export default async function GetAllArticlesReducer(state = initialState, action) {
    switch (action.type) {
        case GetAllArticles:
            const response = await client.get('https://localhost/api/Article');
            return {
                articles: response,
            };

        default:
            return state;
    }
}