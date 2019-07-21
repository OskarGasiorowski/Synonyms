import React from "react";
import { connect } from "react-redux";
import { ThunkDispatch } from "redux-thunk";
import { Action } from "redux";
import { getSynonyms } from "../../../store/actions";
import { Synonym } from "../../../store/models/Synonyms";
import { TableComponent } from "../components/TableComponent";
import { BoxLoading } from "../components/BoxLoading";
import { RootState } from "../../../store";

interface IDispatch {
    get: () => void;
}

interface IMapState {
    synonyms: Synonym[],
    isPending: boolean;
}

class _Table extends React.Component<IDispatch & IMapState> {
    public componentWillMount(){
        this.props.get();
    }

    public render(){
        if (this.props.synonyms.length === 0){
            return (
                <div className="box">
                    <h2 className="has-text-centered has-text-grey">There is no synonyms :(</h2>
                </div>
            )
        }

        if (this.props.isPending){
            return <BoxLoading />
        }

        return (
            <TableComponent 
                synonyms={this.props.synonyms}
            />
        )
    }
}

const mapDispatchToProps = (dispatch: ThunkDispatch<{}, {}, Action>): IDispatch => ({
    get: () => dispatch(getSynonyms())
});

const mapStateToProps = ({main}: RootState): IMapState => ({
    synonyms: main.synonyms,
    isPending: main.synonymsPending
});

export const Table = connect(mapStateToProps, mapDispatchToProps)(_Table);