//let x = "";
//console.log(x)
//x = "oi"

// declara função e diz o que ela faz
function MostrarTexto(texto){
 console.log(texto)
}

// executa a função uma ou mais vezes
//MostrarTexto("oi");
//MostrarTexto("olá");

//segunda forma
// forma sem parâmetros

function soma(){
    //const resultado = 2 + 2;
    return 2 + 2;
}

console.log(soma());

// terceira forma

console.log(soma(MostrarTexto));
MostrarTexto(soma);
