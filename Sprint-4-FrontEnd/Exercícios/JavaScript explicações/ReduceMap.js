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

const valorReal = produtos.map( p => p.preco * 6); //map
console.log(valorReal)
const somaReal = valorReal.reduce((a,b) => a + b,0)//reduce 

console.log(somaReal)

// analisar item por item e adicionar a soma nesse a 

const tudo = produtos.map(p => p.preco * 6).reduce((a,b) => a + b,0); //map com reduce(e arrow function)
console.log(tudo)