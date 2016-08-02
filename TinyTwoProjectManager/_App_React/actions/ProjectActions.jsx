import AppDispatcher from '../AppDispatcher';
import constants from '../Constants';
import ProjectAPI from '../api/ProjectAPI';
import {throttle} from '../utils';
import ProjectManagerStore from '../stores/ProjectManagerStore';

let ProjectActions = {
    fetchProjects() {
        AppDispatcher.dispatchAsync(ProjectAPI.fetchCards(), {
            request: constants.FETCH_PROJECTS,
            success: constants.FETCH_PROJECTS_SUCCESS,
            failure: constants.FETCH_PROJECTS_ERROR
        });
    },

    addProject(project) {
        AppDispatcher.dispatchAsync(ProjectAPI.addProject(project), {
            request: constants.CREATE_PROJECT,
            success: constants.CREATE_PROJECT_SUCCESS,
            failure: constants.CREATE_PROJECT_ERROR
        }, {project});
    },
};

export default ProjectActions;