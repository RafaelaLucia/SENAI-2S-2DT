/*O método map() pertence ao conjunto de funções
disponíveis no objeto array para facilitar a sua
manipulação.

Basicamente, ele faz a leitura de todos os elementos
do array, executa uma função callback para cada um e
devolve como retorno um novo array.*/

//map com arrow function.
const produtos = [
    {
        nome: "notebook",
        preco: 2100
    },
    {
        nome: "smartphone",
        preco: 400
    }
]

// exemplo de um map com arrow, multiplicando o preço por 6.
/*p = vai receber o produto como argumento.
=> arrow function
de cada item, pegamos o preço e multiplicamos por 6
*/
const precosEmReais = produtos.map(p => p.preco * 6)
// map recebe como parâmetro o que chamamos de função callback
// então, internamente, o map vai utilizar essa função para realizar a nossa regra de negócio.
console.log(precosEmReais)
console.log(produtos)

//map com function.

// mapeia e dobra cada item
var numbers = [1,5,9];
var listaDobrada = numbers.map(function(num){
    return num * 2;
})
console.log(numbers);
console.log(listaDobrada);

//utilizando uma regra para conversão de graus.

//traduz fahrenheit para celsius
var fahrenheit = [0,32,45,46,47,91,93,121];
var celsius = fahrenheit.map(function(item){
    return Math.round((item - 32)*5/9);
});
console.log(celsius)

/*Um map de um array sempre vai retornar outro array
de mesmo tamanho, ou seja, um array de 5
elementos que esta sendo mapeado resultará em outro
array de 5 elementos com a modificação passada pelo
argumento.*/

//map([🌽,🐮,🐔],cook) => [🍿,🍔,🍳]

