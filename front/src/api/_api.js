import axios from 'axios';

let env  = process.env
console.log(env)
const api = axios.create({ 'baseURL': env.REACT_APP_BASE_URL })

api.interceptors.request.use(
    (config) => {
      const token = localStorage.getItem('token');
      if (token) {
        config.headers['Authorization'] = `Bearer ${token}`;
      }
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );

  api.interceptors.response.use(
    (response)=> {
      if(response.status === 401)
      {
        localStorage.removeItem('token')
      }
      return response
    }
  )

  export default api



