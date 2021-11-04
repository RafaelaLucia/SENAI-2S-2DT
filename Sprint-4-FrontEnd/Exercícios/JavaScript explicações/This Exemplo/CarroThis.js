var Carro = new Object();
Carro.marca = "fiat" //propriedade
Carro.localizaMarca = function(){
    return this.marca
};
console.log(Carro.localizaMarca())

var Moto = new Object();
Moto.marca = "Honda" // propriedade
Moto.localizaMarca = function(){
    return this.marca
}
console.log(Moto.localizaMarca())

// o this é muito útil mas tem que se atentar onde é escrito
// dentro de uma função vai aguardar objeto
// dentro do proprio objeto ele vai assumir que tem que encontrar dentro do objeto que está dentro
// se estiver fora ele vai ser global
