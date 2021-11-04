/*
const soma = function(a,b){
    return a + b;
}

// função arrow com return explícito
const soma = (a,b) => {
    return a + b;
}

// função arrow com return implícito
const soma = (a,b) => a + b;

/*
function imprimeTexto(texto){
    return texto
}
*/

const imprimeTexto = texto => texto
//função chamada imprimeTexto que recebe apenas um parametro e retorna esse parametro
console.log(imprimeTexto("teste arrow"));

// função arrow sem parametro
ola = () => 'olá'

// função arrow com parametro, que pode ser ignorado
ola = _ => 'olá' // _ não é ausência de parâmetro, é apenas ignorável ( _ é chamado de underscore)
