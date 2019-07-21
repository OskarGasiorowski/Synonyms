import React from "react";

interface IProps {
    term: string;
    synonyms: string;
    isPending: boolean;
    validationText: string | undefined;
    onTermChanged: (term: string) => void;
    onSynonymsChange: (synonyms: string) => void;
    onSave: () => void;
}

export const FormComponent: React.FC<IProps> = (props: IProps) => (
    <div className="box">
        <div className="field is-grouped">
            <p className="control">
                <input 
                    className="input" 
                    type="text" 
                    placeholder="Term"
                    value={props.term}
                    onChange={ev => props.onTermChanged(ev.target.value)} 
                />
            </p>
            <p className="control is-expanded">
                <input 
                    className="input" 
                    type="text" 
                    placeholder="Synonyms - comma separated" 
                    value={props.synonyms}
                    onChange={ev => props.onSynonymsChange(ev.target.value)}
                />
            </p>
            <p className="control">
                <button onClick={props.onSave} className={`button is-primary ${props.isPending ? 'is-loading' : ''}`}>
                    Add
                </button>
            </p>
        </div>
        <p className="help is-danger">{props.validationText}</p>
    </div>
);