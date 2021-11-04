/*O método filter() assim como map() recebe uma
função por argumento e executa essa função para
cada item do array.
Utilizamos baseados em uma condição em que
precisamos de um novo array apenas com alguns
itens do array original.
A função nesse cenário deve sempre retornar um
valor boleano, ou seja, true ou false.

Caso a função retorne false o filter irá ignorar o item
atual e irá analisar o próximo, se todos os itens
retornarem como false o filter retornará um array
vazio.*/

//utilizando arrow function.
const numerosAleatorios = [7,39,88,20]
const numerosMaioresQue37 = numerosAleatorios.filter((item) => item > 37) //if true
console.log(numerosMaioresQue37)

/*O método filter() cria um novo array com todos os
elementos que passaram no teste implementado pela
função fornecida.*/

function maiorQue37(value){
    return value > 37
}
var filtrado = [88,40,10,5,102,1].filter(maiorQue37);
console.log(filtrado)


//com function analisando se o número é par.
var numeros = [1,2,3,4,5,6,7,8,9,10];
function buscarNumerosPares (value){
    if (value % 2 == 0)
    return value;
}

var numerosPares = numeros.filter(buscarNumerosPares);
console.log(numerosPares);

/*No caso do Filter() a lista que retornará poderá ser
do mesmo tamanho ou menor dependendo do filtro.*/
//filter([🍿,🍔,🍳], isVegetarian) =>  [🍿,🍳]