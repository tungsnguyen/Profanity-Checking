import axios from 'axios';

const baseUrl = process.env.REACT_APP_API_URI;

const post = async (content) => {
    var response = await axios.post(`${baseUrl}/check`, content);

    return response.data;
};

const get = async () => {
    var response = await axios.get(`${baseUrl}/get`);

    return response.data;
};

export default { post, get };
