var inicializador = {
    controles: {
        //campos Formulario Perfiles
        frmPerfiles: $('#frmPerfiles'),
        TxtIdPerfil: $('#TxtIdPerfil'),
        TxtPerfil: $('#TxtPerfil'),
        chkActivo: $('#chkActivo'),
        tbPerfiles: $('#tbPerfiles'),
        btnGuardarPerfil: $('#btnGuardarPerfil'),
        btnCancelarPerfil: $('#btnCancelarPerfil'),
        btnEliminarPerfil: $('#btnEliminarPerfil'),
        btnEditarPerfil: $('#btnEditarPerfil'),

    },
    inicializarEventos: function () {
        //Eventos Perfil
        inicializador.controles.btnGuardarPerfil.on("click", inicializador.registraPerfil);
        inicializador.controles.btnCancelarPerfil.on("click", inicializador.cancelaPerfil);
        inicializador.controles.tbPerfiles.bootstrapTable({
            locale: 'es-ES',
            formatLoadingMessage: function () {
                return '<div class="col-md-12 text-center" style="height:100%;">' +
                    '<span class="glyphicon glyphicon-loading" style="top:45%"></span>' +
                    '</div>';
            },
            formatNoMatches: function () {
                return 'No se encontraron resultados';
            },
            pageSize: 10
        })

        ////Evento btnEditar Tablar Perfil
        inicializador.controles.tbPerfiles.on('click', '#btnEditarPerfil', function () {
            var $tr = $(this).closest('tr');
            var idPerfil = $tr[0].cells[0].childNodes[1].textContent;
            var nombrePerfil = $tr[0].cells[1].childNodes[1].textContent;
            var Activo = $tr[0].cells[2].childNodes[1].checked;

            inicializador.controles.TxtIdPerfil.val(idPerfil);
            inicializador.controles.TxtPerfil.val(nombrePerfil);
            inicializador.controles.chkActivo[0].checked = Activo;
        });
        ////Evento btnEliminar Tablar Perfil
        inicializador.controles.tbPerfiles.on('click', '#btnEliminarPerfil', function () {
            var $tr = $(this).closest('tr');
            var idPerfil = parseInt($tr[0].cells[0].childNodes[1].textContent);
            var nombrePerfil = $tr[0].cells[1].childNodes[1].textContent;
            var confirmaBorrado = confirm("Desea eliminar el Perfil \'" + nombrePerfil + "\'?");

            if (confirmaBorrado) {
                inicializador.eliminaPerfil(idPerfil);
            }

        });
    },
    registraPerfil: function () {
        perfilVM = {};
        perfilVM.Id = inicializador.controles.TxtIdPerfil.val();

        if (perfilVM.Id != "") {
            perfilVM.NombrePerfil = inicializador.controles.TxtPerfil.val();
            perfilVM.Activo = inicializador.controles.chkActivo[0].checked;

            inicializador.editaPerfil(perfilVM);
            return;
        }

        perfilVM.NombrePerfil = inicializador.controles.TxtPerfil.val();
        perfilVM.Activo = inicializador.controles.chkActivo[0].checked;

        $.ajax({
            type: 'POST',
            async: false,
            url: "/Admin/RegistraPerfil", // we are calling json method
            //dataType: 'json',
            data: perfilVM,
            success: function (result) {

            },
            error: function (ex) {

            }
        });
    },
    editaPerfil: function (perfilVM) {
        $.ajax({
            type: 'POST',
            async: false,
            url: "/Admin/EditaPerfil/", // we are calling json method
            //dataType: 'json',
            data: perfilVM,
            success: function (result) {

            },
            error: function (ex) {

            }
        });
    },
    eliminaPerfil: function (idPerfil) {
        $.ajax({
            type: 'Delete',
            async: false,
            url: "/Admin/EliminaPerfil/", // we are calling json method
            //dataType: 'json',
            data: { idPerfil: idPerfil },
            success: function (result) {
                location.reload();
            },
            error: function (ex) {

            }
        });
    },
    cancelaPerfil: function () {
        inicializador.LimpiaPerfilForm();
    },
    LimpiaPerfilForm: function () {
        inicializador.controles.TxtIdPerfil.val('');
        inicializador.controles.TxtPerfil.val('');
        inicializador.controles.chkActivo[0].checked = false;
    },
    init: function () {
        inicializador.inicializarEventos();
    }
}

inicializador.init();