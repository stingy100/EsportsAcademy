// JavaScript del lado del cliente: cierra automáticamente las alertas de éxito
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.alert-success').forEach(function (alerta) {
        setTimeout(function () {
            bootstrap.Alert.getOrCreateInstance(alerta).close();
        }, 4000);
    });
});
