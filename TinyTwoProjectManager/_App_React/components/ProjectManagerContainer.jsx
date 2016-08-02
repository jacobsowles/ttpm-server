import React, { Component } from 'react';
import {Container} from 'flux/utils';
import ProjectList from './ProjectList';
import ProjectManagerStore from '../stores/ProjectManagerStore';

class ProjectManagerContainer extends Component {

    render() {
        let projectList = this.props.children && React.cloneElement(this.props.children, {
            projects: this.state.projects
        });

        return projectList;
    }
}

ProjectManagerContainer.getStores = () => ([ProjectManagerStore]);
ProjectManagerContainer.calculateState = (prevState) => ({
    projects: ProjectManagerStore.getState()
});

export default Container.create(ProjectManagerContainer);