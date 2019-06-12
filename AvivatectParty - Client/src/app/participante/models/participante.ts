export class Participante {
    id: string;
    nome: string;
    email: string;
    login: string;
    senha: string;
    melhoDiaHora: Date;
    localId: string;
    Organizador: boolean;
}

export interface Local {
    id: string;
    nome: string;
}