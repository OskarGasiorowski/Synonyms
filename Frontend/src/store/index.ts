import { createStore, combineReducers, applyMiddleware } from "redux";
import { reducer } from './reducer'
import thunk from 'redux-thunk';
import {State} from './state'

export interface RootState {
    main: State
}

const rootReducer = combineReducers<RootState>({main: reducer})

export default createStore(rootReducer, applyMiddleware(thunk));