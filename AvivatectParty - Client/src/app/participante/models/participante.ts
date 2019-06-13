export class Participante {
    id: string;
    nome: string;
    email: string;
    login: string;
    senha: string;
    melhorDiaHora: Date;
    localId: string;
    organizador: boolean;
}

export interface Local {
    id: string;
    nome: string;
}