/*A função reduce funciona de uma forma mais
flexível, ela pode assumir o papel de um modificador
de array ou então de um agregador (que faz somas,
médias, etc).*/

//somatória
//array.reduce(acumulador, valoratual[], valor inicial)
var valores = [1.5,2,4,10];
var somatoria = valores.reduce(function(total,item){
    return total + item;
}, 0);
console.log(somatoria) //17,5

/*No exemplo acima de somatória temos:
[1.5, 2, 4, 10] – Como valores do array.
total – Como variável acumulativa da funcão de callback.
item – Como variável que armazena o valor atual.

Executando a função reduce acima passo a passo, teríamos algo desse tipo na sua
execução:
Passo 1 – total = 0 ; item = 1.5
Passo 2 – total = 1.5 ; item = 2
Passo 3 – total = 3.5 ; item = 4
Passo 4 – total = 7.5 ; item = 10

O resultado final que consta na variável somatoria é de 17.5
A cada passo o reduce interage com o array e constrói a variável total .*/

//Média
var media = valores.reduce( (total,item,indice,array) => {
    total += item;
    if (indice === array.lenght -1){
        return total / array.lenght;
    }
    return total
}, 0);
console.log(media);

