import { State } from "./state";
import { Actions } from "./actions";

const initState: State = {
    synonyms: [],
    synonymsPending: false
}

export const reducer = (state: State = initState, action: Actions): State => {
    switch (action.type) {
        case  "GET_SYNONYMS_STARTED":
            return { ...state, synonymsPending: true }
        case "GET_SYNONYMS_COMPLETED":
            return { synonyms: action.synonyms, synonymsPending: false }
        case "CREATE_SYNONYM_STARTED":
                return { ...state, synonymsPending: true }
        case "CREATE_SYNONYM_COMPLETED":
                return { ...state, synonymsPending: false }
        default: return state;
    }
}