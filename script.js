function comprar(cafe) {
    fetch("/comprar", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ cafe: cafe })
    })
    .then(res => res.json())
    .then(data => {
        document.getElementById("mensaje").innerText = data.mensaje;
    })
    .catch(() => {
        document.getElementById("mensaje").innerText = "No se pudo conectar con el servidor.";
    });
}
