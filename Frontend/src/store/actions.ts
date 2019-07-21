import { Synonym } from "./models/Synonyms";
import axios from 'axios';
import { config } from '../config'
import { ThunkDispatch } from "redux-thunk";

export type Actions =
      { type: "GET_SYNONYMS_STARTED" }
    | { type: "GET_SYNONYMS_COMPLETED", synonyms: Synonym[] }
    | { type: "CREATE_SYNONYM_STARTED" }
    | { type: "CREATE_SYNONYM_COMPLETED" }

export const createSynonym = (synonym: Synonym, onSuccess: () => void) => {
    return async (dispatch: ThunkDispatch<{}, {}, Actions>): Promise<void> => {
        dispatch({ type: "CREATE_SYNONYM_STARTED"});
        await axios.post(`${config.api}/synonym`, synonym);
        dispatch({type: "CREATE_SYNONYM_COMPLETED"});
        onSuccess();
    }
}

export const getSynonyms = () => {
    return async (dispatch: ThunkDispatch<{}, {}, Actions>): Promise<void> => {
        dispatch({ type: "GET_SYNONYMS_STARTED"});
        var res = await axios.get<Synonym[]>(`${config.api}/synonym`);
        dispatch({type: "GET_SYNONYMS_COMPLETED", synonyms: res.data});
    }
}