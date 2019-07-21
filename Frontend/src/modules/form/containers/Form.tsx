import React from "react";
import { FormComponent } from '../components/FormComponent'
import { Action } from "redux";
import { ThunkDispatch } from "redux-thunk";
import { Synonym } from "../../../store/models/Synonyms";
import { createSynonym, getSynonyms } from "../../../store/actions";
import { connect } from "react-redux";
import { RootState } from "../../../store";
const XRegExp = require('xregexp');

interface IState {
    term: string;
    synonyms: string;
    validationText: string | undefined;
}

interface IMapState {
    isPending: boolean;
}

interface IDispatch {
    save: (synonym: Synonym, onSuccess: () => void) => void;
    get: () => void;
}

export class _Form extends React.Component<IDispatch & IMapState, IState> {
    public render(){
        return (
            <FormComponent 
                {...this.state}
                onTermChanged={term => this.setState({term})}
                onSynonymsChange={synonyms => this.setState({synonyms})}
                onSave={this.onSave}
                isPending={this.props.isPending}
            />
        )
    }

    private onSave = (): void => {
        var validationResult = this.validate();
        this.setState({validationText: validationResult})
        if (!!validationResult) {
            return;
        }

        this.props.save({
            term: this.state.term,
            synonyms: this.state.synonyms.split(',').map(syn => syn.trim())
        }, this.props.get);
    }

    private validate = (): string | undefined => {
        if (!this.state.term || !this.state.synonyms){
            return 'Term and synonyms are required';
        }

        const regex = new XRegExp("^[\\s\\p{L}]*$");
        if (!regex.test(this.state.term)){
            return "Term is invalid";
        }

        const isSynonymsValid = (this.state.synonyms || '')
            .split(',')
            .map(syn => syn.trim())
            .every(syn => regex.test(syn));

        if (!isSynonymsValid){
            return "Synonyms are invalid";
        }

        return undefined;
    }
}

const mapDispatchToProps = (dispatch: ThunkDispatch<{}, {}, Action>): IDispatch => ({
    save: (synonym, onSuccess) => dispatch(createSynonym(synonym, onSuccess)),
    get: () => dispatch(getSynonyms())
});

const mapStateToProps = ({main}: RootState): IMapState => ({
    isPending: main.synonymsPending
});

export const Form = connect(mapStateToProps, mapDispatchToProps)(_Form);