const formFinalizarPedido = document.getElementById('form_finalizarPedido')
const btn_finalizarPedido = document.getElementById('btn_finalizarPedido')

btn_finalizarPedido.addEventListener('click', (e) => {
    Swal.fire({
        icon: "success",
        title: "Pedido Cadastrado com sucesso!",
        showConfirmButton: true,
        confirmButtonText: "Início"
    }).then(result) {
        if (result.isConfirmed) {
            window.location.href = "/"
        }
    };
})