import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7228/api', // Your backend base URL
});

export default api;
