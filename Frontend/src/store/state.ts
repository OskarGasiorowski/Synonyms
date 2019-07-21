import { Synonym } from './models/Synonyms';

export class State {
    public synonyms: Synonym[] = [];
    public synonymsPending: boolean = false;
}