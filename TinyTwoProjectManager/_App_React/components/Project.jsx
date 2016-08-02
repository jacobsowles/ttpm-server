import React, { Component, PropTypes } from 'react';

class Project extends Component {
    render() {
        return (
            <div>{this.props.name}</div>
        );
    }
}

Project.propTypes = {
    id: PropTypes.number,
    name: PropTypes.string.isRequired
};

export default Project