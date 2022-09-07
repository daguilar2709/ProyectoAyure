var inicializador = {
    controles: {
        frmLogin: $('#frmLogin'),
        TxtUsuario: $('#NombreUsuario'),
        TxtContrasena: $('#Contrase_a'),
        btnIniciaSesion: $('#btnIniciaSesion'),
    },
    inicializarEventos: function () {
        inicializador.controles.btnIniciaSesion.on("click", inicializador.iniciaSesion);
        $("#registroModal").modal("hide");
    },
    iniciaSesion: function () {
        usuarioSesion = {};

        usuarioSesion.NombreUsuario = inicializador.controles.TxtUsuario.val();
        usuarioSesion.Contraseña = inicializador.controles.TxtContrasena.val();

        $.ajax({
            type: 'POST',
            //async: false,
            url: '/Login/ValidaUsuario', // we are calling json method
            headers: { 'Access-Control-Allow-Origin': '*' },
            //dataType: 'json',
            data: { Usuario: usuarioSesion.NombreUsuario, Password: usuarioSesion.Contraseña },
            success: function (result) {
                var baseUrl = "Home/Index";
                location.href = baseUrl;
            },
            error: function (ex) {
            }
        });

    },
    init: function () {
        inicializador.inicializarEventos();
    }
};



inicializador.init();