import 'whatwg-fetch';
import 'babel-polyfill';
import constants from '../Constants';

const API_HEADERS = {
    'Content-Type': 'application/json',
    Authorization: 'any-string-you-like'
}

let ProjectAPI = {
    fetchProjects() {
        return fetch(`${constants.API_URL}/projects`, {headers:API_HEADERS})
        .then((response) => response.json())
    },

    addProject(project) {
        return fetch(`${constants.API_URL}/projects`, {
            method: 'post',
            headers: API_HEADERS,
            body: JSON.stringify(project)
        })
        .then((response) => response.json())
    }
};

export default ProjectAPI;