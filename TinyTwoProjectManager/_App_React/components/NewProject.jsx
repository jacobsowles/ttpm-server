import React, {Component} from 'react';
import ProjectForm from './ProjectForm';
import DraftStore from '../stores/DraftStore';
import {Container} from 'flux/utils';
import ProjectActions from '../actions/ProjectActions';

class NewProject extends Component {

    handleSubmit(e){
        e.preventDefault();
        ProjectActions.addCard(this.state.draft);
        this.props.history.pushState(null, '/');
    }

    handleClose(e){
        this.props.history.pushState(null, '/');
    }

    componentDidMount(){
        setTimeout(() => ProjectActions.createDraft(), 0)
    }

    render(){
        return (
          <CardForm draftCard={this.state.draft}
    buttonLabel="Create Card"
    handleChange={this.handleChange.bind(this)}
        handleSubmit={this.handleSubmit.bind(this)}
        handleClose={this.handleClose.bind(this)} />
);
    }
}

NewCard.getStores = () => ([DraftStore]);
NewCard.calculateState = (prevState) => ({
    draft: DraftStore.getState()
});

export default Container.create(NewCard);