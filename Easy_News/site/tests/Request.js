const axios = require('axios');
const https = require('https');

const agent = new https.Agent({
    rejectUnauthorized: false,
});

const client = axios.create({ //all axios can be used, shown in axios documentation
    responseType: 'json',
    withCredentials: true,
    httpsAgent: agent
});

async function getArticles() {
    const response = await client.get('https://localhost/api/Article');
    return response.data.length;
}

module.exports = getArticles;