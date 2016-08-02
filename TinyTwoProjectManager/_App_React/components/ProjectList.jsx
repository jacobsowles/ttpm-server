import React, { Component, PropTypes } from 'react';
import Project from './Project';

class ProjectList extends Component {
    render() {
        const header = 'PROJECTS';
        let projects = this.props.projects.map((project) => {
            return <li><Project key={project.id} {...project} /></li>
        });

        return (
            <div className="module">
                <h2>{header}</h2>
                <Link to='/addProject' className="float-button">+</Link>
                <ul id="projectList">
                    {projects}
                </ul>
            </div>
        );
    }
}

ProjectList.propTypes = {
    projects: PropTypes.arrayOf(PropTypes.object)
};

export default ProjectList