var perfil = []
var inicializador = {
    controles: {
        //Variables

        //campos Formulario Usuarios
        frmUsuarios: $('#frmUsuario'),
        txtNombre: $('#txtNombre'),
        txtApellidoPat: $('#txtApellidoPat'),
        txtApellidoMat: $('#txtApellidoMat'),
        ddlPerfiles: $('#lstPerfiles'),
        txtDireccion: $('#txtDireccion'),
        txtCodigoPostal: $('#txtCodigoPostal'),
        TxtTelefono: $('#TxtTelefono'),
        TxtTelefonoOpcional: $('#TxtTelefonoOpcional'),
        tbUsuarios: $('#tbUsuarios'),
        btnGuardarUsuario: $('#btnGuardar'),
        btnCancelarUsuario: $('#btnCancelar'),

        btnEditarUsuario: $('#btnEditarUsuario'),
        btnEliminarUsuario: $('#btnEliminarUsuario')

    },
    inicializarEventos: function () {
        //Eventos Usuario
        if (inicializador.controles.ddlPerfiles.niceSelect !== undefined) {
            inicializador.controles.ddlPerfiles.niceSelect();
            $.ajax({
                type: 'POST',
                async: false,
                url: "/Admin/CargaPerfiles", // we are calling json method
                //dataType: 'json',
                success: function (result) {
                    var lstPerfiles = result.value;
                    var y = 0;
                    $(lstPerfiles).each(function () {
                        inicializador.controles.ddlPerfiles.append($("<option value='0'><---- Seleccione Perfil ----></option>").text(lstPerfiles[y].nombrePerfil).val(lstPerfiles[y].id));
                        y++;
                    });
                },
                error: function (ex) {

                }
            });
            inicializador.controles.ddlPerfiles.niceSelect('update');
        }
        inicializador.controles.btnGuardarUsuario.on("click", inicializador.registraUsuario);
        inicializador.controles.btnCancelarUsuario.on("click", inicializador.cancelarUsuario);
        inicializador.controles.tbUsuarios.bootstrapTable({
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

        ////Evento btnEditar Tablar Usuario
        inicializador.controles.tbUsuarios.on('click', '#btnEditarUsuario', function () {
            debugger;
            var $tr = $(this).closest('tr');
            var IdUsuario = $tr[0].cells[0].childNodes[1].textContent;
            $.ajax({
                type: 'POST',
                async: false,
                url: "/Admin/ObtieneUsuario", // we are calling json method
                //dataType: 'json',
                data: { idUsuario: IdUsuario },
                success: function (result) {
                    inicializador.controles.Nombre.val(nombrePerfil);
                    inicializador.controles.ApellidoPaterno.val();
                    inicializador.controles.ApellidoMaterno.val();
                    inicializador.controles.Direccion.val();
                    inicializador.controles.CodigoPostal.val();
                    inicializador.controles.Telefono1.val();
                    inicializador.controles.Telefono2.val();
                },
                error: function (ex) {

                }
            });

            
        });

        
    },
    registraUsuario: function () {
        usuarioVM = {};
        usuarioVM.Nombre = inicializador.controles.txtNombre.val();
        usuarioVM.ApellidoPaterno = inicializador.controles.txtApellidoPat.val();
        usuarioVM.ApellidoMaterno = inicializador.controles.txtApellidoMat.val();
        usuarioVM.Direccion = inicializador.controles.txtDireccion.val();
        usuarioVM.CodigoPostal = inicializador.controles.txtCodigoPostal.val();
        usuarioVM.Telefono1 = inicializador.controles.TxtTelefono.val();
        usuarioVM.Telefono2 = inicializador.controles.TxtTelefonoOpcional.val();
        usuarioVM.perfilId = inicializador.controles.ddlPerfiles[0].selectedOptions[0].value;

        $.ajax({
            type: 'POST',
            async: false,
            url: "/Admin/CreaUsuario", // we are calling json method
            //dataType: 'json',
            data: usuarioVM,
            success: function (result) {

            },
            error: function (ex) {

            }
        });
    },
    cancelarUsuario: function () {
        alert("btnCancelar Ejecucion Correcta!");
    },
    init: function () {
        inicializador.inicializarEventos();
    }
}

inicializador.init();