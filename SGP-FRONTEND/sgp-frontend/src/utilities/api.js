import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7166/",
});

api.interceptors.response.use(
  (response) => {
    return response;
  },

  (error) => {
    console.log(error.response.data);
  }
);

export default api;
