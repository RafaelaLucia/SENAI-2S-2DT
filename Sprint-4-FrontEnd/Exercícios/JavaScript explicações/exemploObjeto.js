var carro = new Object(); //criando um novo objeto carro

// criando as propriedades do objeto carro
carro.marca = "Fiat"; 
carro.modelo = "Uno";
carro.cor = "azul";

// criando os métodos do objeto carro
carro.ligar = false;
carro.Partida = function(){
    carro.ligar = true;
}

//chamando o objeto carro
console.log(carro);
carro.Partida();
console.log(carro);
