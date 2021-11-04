
/*O método constructor é um tipo especial de método para
criar e iniciar um objeto criado pela classe. Só pode
existir um método especial com o nome "constructor"
dentro da classe.*/

class Retangulo {
    constructor(altura, largura){
        this.altura = altura;
        this.largura = largura;
    }
}

class Animal {
    constructor (nome){
        this.nome = nome;
    }

    falar(){
        console.log(this.nome + 'emite um barulho')
    }
}

/*A palavra-chave extends é usada em uma declaração de classe, ou em
uma expressão de classe para criar uma classe como filha de uma outra
classe*/
// no  c# usamos : para herdar da classe, no JS usamos extends
class Cachorro extends Animal {
    falar(){
        console.log(this.nome + ' latiu') // falar com sobrecarga, pois agora é "latiu"
    }
}

let cachorro = new Cachorro('Matt'); // classe pai quer que tenha um nome (por causa do construtor)
cachorro.falar(); // chamar o método
