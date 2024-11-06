export class Produto {
    id: number;
    nome: string;
    valor: number;
    setor: string;

    constructor(id: number, nome: string, valor: number, setor: string) {
        this.id = id;
        this.nome = nome;
        this.valor = valor;
        this.setor = setor;
    }
}
