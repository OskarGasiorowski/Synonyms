import React from 'react';
import { Synonym } from '../../../store/models/Synonyms';

const termWidth = {
    width: '30%' as any
}

interface IProps {
    synonyms: Synonym[];
}

export const TableComponent: React.FC<IProps> = (props: IProps) => (
    <div className="box">
        <table className="table is-striped is-fullwidth">
            <thead>
                <tr>
                    <th style={termWidth}>Term</th>
                    <th>Synonyms</th>
                </tr>
            </thead>
            <tbody>
                {props.synonyms.map((syn, key) => (
                    <tr key={key}>
                        <td>{syn.term}</td>
                        <td>{syn.synonyms.join(', ')}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
)