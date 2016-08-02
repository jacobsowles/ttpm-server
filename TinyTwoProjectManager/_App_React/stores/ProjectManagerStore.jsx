import AppDispatcher from '../AppDispatcher';
import constants from '../Constants';
import {ReduceStore} from 'flux/utils';
import update from 'react-addons-update';
import 'babel-polyfill';

class ProjectManagerStore extends ReduceStore {

    getInitialState() {
        return [];
    }

    getProject(id) {
        return this._state.find((project) => project.id == id);
    }

    getProjectIndex(id) {
        return this._state.findIndex((project) => project.id == id);
    }

    reduce(state, action){
        switch (action.type) {
            case constants.CREATE_PROJECT:
                return update(this.getState(), {$push: [action.payload.project] })

            case constants.CREATE_PROJECT_SUCCESS:
                projectIndex = this.getProjectIndex(action.payload.project.id);
                return update(this.getState(), {
                  [projectIndex]: {
                      id: { $set: action.payload.response.id }
                  }
                });

            case constants.CREATE_PROJECT_ERROR:
                projectIndex = this.getProjectIndex(action.payload.project.id);
                return update(this.getState(), { $splice:[[projectIndex, 1]]});

            default:
                return state;
        }
    }
}

export default new ProjectManagerStore(AppDispatcher);