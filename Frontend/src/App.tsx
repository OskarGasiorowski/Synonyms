import React from 'react';
import './App.css';
import { Form } from './modules/form/containers/Form';
import { Provider } from 'react-redux';
import store from './store';
import { Table } from './modules/table/containers/Table';

const space = {
    marginTop: '5%' as any,
    margin: '2vw'
}

const synonymsText = {
    fontFamily: 'Pacifico',
    fontSize: '500%'
}

const App: React.FC = () => {
    return (
        <Provider store={store}>
            <div className="has-background-info" id="main">
                <div className="columns is-centered">
                    <div style={space} className="column is-9-widescreen is-half-fullhd is-10-tablet is-9-desktop">
                        <h1 style={synonymsText} className="has-text-centered has-text-dark">Synonyms</h1>
                        <Form />
                        <Table />
                    </div>
                </div>
            </div>
        </Provider>
    );
}

export default App;
