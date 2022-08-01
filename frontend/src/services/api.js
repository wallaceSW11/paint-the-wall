import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5282/api/v1/",
    headers: { "Cache-Control": "no-cache" },
});

export default api;
