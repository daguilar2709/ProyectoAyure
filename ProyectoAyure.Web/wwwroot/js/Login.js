var inicializador = {
    controles: {
        frmLogin: $('#frmLogin'),
        TxtUsuario: $('#txtUsuario'),
        TxtContrasena: $('#txtContrasena'),
        btnIniciaSesion: $('#btnIniciaSesion'),
    },
    inicializarEventos: function () {
        inicializador.controles.btnIniciaSesion.on("click", inicializador.iniciaSesion);
    },
    iniciaSesion: function () {
        usuarioSesion = {};

        usuarioSesion.NombreUsuario = inicializador.controles.TxtUsuario.val();
        usuarioSesion.Contraseña = inicializador.controles.TxtContrasena.val();

        $.ajax({
            type: 'POST',
            async: false,
            url: "/Login/ValidaUsuario", // we are calling json method
            //dataType: 'json',
            data: usuarioSesion,
            success: function (result) {

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