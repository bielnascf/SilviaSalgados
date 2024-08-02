const selectQuantidade = document.getElementById('quantidade');
const precoElement = document.getElementById('preco');
const typeElement = document.getElementById('type');

const typeProduct = typeElement.textContent;

if (typeProduct == 'Especial') {
    selectQuantidade.addEventListener('change', () => {
        const quantidade = selectQuantidade.value;
        let novoPreco;

        switch (parseInt(quantidade)) {
            case 25:
                novoPreco = 20
                break
            case 50:
                novoPreco = 35
                break
            case 75:
                novoPreco = 45
                break
            case 100:
                novoPreco = 60
                break
        }

        precoElement.textContent = novoPreco;
    })
}

if (typeProduct == 'Frito') {
    selectQuantidade.addEventListener('change', () => {
        const quantidade = selectQuantidade.value;
        let novoPreco;

        switch (parseInt(quantidade)) {
            case 25:
                novoPreco = 15
                break
            case 50:
                novoPreco = 25
                break
            case 75:
                novoPreco = 45
                break
            case 100:
                novoPreco = 60
                break
            default:
                novoPreco = 0
        }

        precoElement.textContent = novoPreco;
    })
}

if (typeProduct == 'Assado') {
    selectQuantidade.addEventListener('change', () => {
        const quantidade = selectQuantidade.value;
        let novoPreco;

        switch (parseInt(quantidade)) {
            case 25:
                novoPreco = 25               
                break
            case 50:
                novoPreco = 40              
                break
            case 75:
                novoPreco = 55              
                break
            case 100:
                novoPreco = 75
                break
            default:
                novoPreco = 0;
        }

        precoElement.textContent = novoPreco;
    })
}