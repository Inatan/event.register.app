export default class Participante{

    constructor(nome='', cpf='', email ='', nascimento = new Date() ,cidade){
        this.nome = nome;
        this.cpf = cpf;
        this.email=email;
        this.nascimento=nascimento;
        this.cidade=cidade;
    }
}