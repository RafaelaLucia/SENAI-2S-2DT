

// === igualdade na escrita

console.log(this)

// nesse caso o this representa o window que tem um objeto chamado document
console.log(this.document === window.document);
// confirmação que o this é o objeto global no caso do navegador = window
console.log(this === window) // true

this.a = 20;
console.log(window.a)

// 'use strict' é utilizado para não ter incostistência 

function thisNãoEstrito(){
    console.log(this) 
}

function thisEstrito(){
    'use strict' //representar algum objeto que tiver na função ou definido se não tiver objeto
    console.log(this) // this não existe objeto dentro da função 
}