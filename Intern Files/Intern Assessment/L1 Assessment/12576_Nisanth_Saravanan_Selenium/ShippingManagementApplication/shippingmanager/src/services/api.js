//api.js
import axios from 'axios';

const API = axios.create({
    baseURL: 'http://localhost:5099/api', // Adjust if needed
});

export default API;
