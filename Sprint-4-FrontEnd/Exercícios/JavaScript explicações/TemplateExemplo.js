/**
Template Strings são strings que permitem
expressões embutidas. Você pode utilizar
string multi-linhas e interpolação de string com
elas.

Basicamente é uma nova forma de criar strings e
tornar o seu código um pouco mais legível.
*/

const string1 = 'teste' //declarar uma string normalmente
const stringMultiLinha = 'linha 1 \n linha2' // declarando uma string com várias linhas
console.log(stringMultiLinha);
console.log(string1);

// declarando uma string multi-linha com template string
const stringMulti = `linha1
linha meio
linha 2`;
console.log(stringMulti); // utilizando crase

/* Não é mais necessário utilizar o \n, isso deixa o
código mais limpo. Outra coisa do Template String
é que podemos criar uma string interpolada, ou seja,
misturar uma expressão com a string que vai ser
avaliada e depois colocar ela entre pólos, ao invés
de concatenar. Fazemos isso apenas abrindo um

$ {expressão} */

const a = 10
const string = `Olá ${a + 1} !` //utilizando crase
console.log(string);
