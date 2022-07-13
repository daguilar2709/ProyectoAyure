var perfil = []
var inicializador = {
    controles: {
        //Variables

        //campos Formulario Usuarios
        frmUsuarios: $('#frmUsuario'),
        DatosBloque: $('#DatosBloque'),
        txtIdUsuario: $('#TxtIdUsuario'),
        txtNombre: $('#txtNombre'),

        EmpresaBloque: $('#EmpresaBloque'),
        txtIdEmpresa: $('#TxtIdEmpresa'),
        txtNombreEmpresa: $('#txtNombreEmpresa'),
        lblUsuario: $('#lblUsuario'),
        txtUsuario: $('#txtUsuario'),

        ApellidosBloque: $('#ApellidosBloque'),
        txtApellidoPat: $('#txtApellidoPat'),
        txtApellidoMat: $('#txtApellidoMat'),

        txtEmpresa: $('#txtEmpresa'),

        ddlPerfiles: $('#lstPerfiles'),
        txtDireccion: $('#txtDireccion'),
        txtCodigoPostal: $('#txtCodigoPostal'),
        txtEmail: $('#txtEmail'),
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
            inicializador.controles.EmpresaBloque[0].hidden = true;
            inicializador.controles.DatosBloque[0].hidden = false;
            inicializador.controles.ApellidosBloque[0].hidden = false;

            inicializador.controles.ddlPerfiles.change(function () {
                var perfilId = $.trim(inicializador.controles.ddlPerfiles[0].selectedOptions[0].value);
                if (perfilId == 3 || perfilId == 4) {
                    inicializador.controles.EmpresaBloque[0].hidden = false;
                    inicializador.controles.DatosBloque[0].hidden = true;
                    inicializador.controles.ApellidosBloque[0].hidden = true;
                } else {
                    inicializador.controles.EmpresaBloque[0].hidden = true;
                    inicializador.controles.DatosBloque[0].hidden = false;
                    inicializador.controles.ApellidosBloque[0].hidden = false;
                }
            });
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
            var $tr = $(this).closest('tr');
            var IdUsuario = $tr[0].cells[0].childNodes[1].textContent;
            var NombreCompleto = $tr[0].cells[1].childNodes[1].textContent;
            var Direccion = $tr[0].cells[2].childNodes[1].textContent;
            var Perfil = $tr[0].cells[3].childNodes[1].textContent;
            var CodigoPostal = $tr[0].cells[4].childNodes[1].textContent;
            var Telefono = $tr[0].cells[5].childNodes[1].textContent;
            var TelefonoOpcional = $tr[0].cells[6].childNodes[1].textContent;

            debugger;

            var nombres = NombreCompleto.split(' ');
            var Nombre = '', ApellidoPat = '', ApellidoMat = '';

            for (var i = 0; i < nombres.length; i++) {
                if (nombres.length == 3) {
                    if (nombres[i] != '') {
                        if (i == 0) {
                            Nombre += nombres[i];
                        }
                        else if (i == 1) {
                            ApellidoPat += nombres[i];
                        } else
                        {
                            ApellidoMat += nombres[i];
                        }
                    }
                }
                else if (nombres.length == 4)
                {
                    if (nombres[i] != '') {
                        if (i == 0 || i == 1) {
                            Nombre += nombres[i];
                        }
                        else if (i == 2)
                        {
                            ApellidoPat += nombres[i];
                        }
                        else
                        {
                            ApellidoMat += nombres[i];
                        }
                    }
                }
            }

            var perfiles = $('#lstPerfiles')[0], index = "";

            for (var j = 0; j < perfiles.length; j++) {
                if (Perfil == perfiles[j].innerHTML) {
                    index = perfiles[j].index
                }
            }

            inicializador.controles.txtIdUsuario.val(IdUsuario);
            inicializador.controles.txtNombre.val(Nombre);
            inicializador.controles.txtApellidoPat.val(ApellidoPat);
            inicializador.controles.txtApellidoMat.val(ApellidoMat);
            inicializador.controles.txtDireccion.val(Direccion);

            inicializador.controles.ddlPerfiles.niceSelect('destroy');
            $('#lstPerfiles option')[index].selected = true;
            inicializador.controles.ddlPerfiles.niceSelect();

            inicializador.controles.txtCodigoPostal.val(CodigoPostal);
            inicializador.controles.TxtTelefono.val(Telefono);
            inicializador.controles.TxtTelefonoOpcional.val(TelefonoOpcional);
        });

        ////Evento btnEliminar Tablar Usuario
        inicializador.controles.tbUsuarios.on('click', '#btnEliminarUsuario', function () {
            var $tr = $(this).closest('tr');
            var IdUsuario = parseInt($tr[0].cells[0].childNodes[1].textContent);
            var nombreCompleto = $tr[0].cells[1].childNodes[2].textContent;
            var confirmaBorrado = confirm("Desea eliminar al Usuario: \'" + nombreCompleto + "\'?");

            if (confirmaBorrado) {
                inicializador.eliminaUsuario(IdUsuario);
            }

        });
    },
    registraUsuario: function () {
        usuarioVM = {};
        usuarioVM.Id = inicializador.controles.txtIdUsuario.val();
        usuarioVM.perfilId = $.trim(inicializador.controles.ddlPerfiles[0].selectedOptions[0].value);

        if (usuarioVM.perfilId == "1" || usuarioVM.perfilId == "2") {
            usuarioVM.Nombre = $.trim(inicializador.controles.txtNombre.val());
            usuarioVM.ApellidoPaterno = $.trim(inicializador.controles.txtApellidoPat.val());
            usuarioVM.ApellidoMaterno = $.trim(inicializador.controles.txtApellidoMat.val());

            usuarioVM.Empresa = "";
            usuarioVM.Usuario = "";
        } else {
            usuarioVM.Nombre = "";
            usuarioVM.ApellidoPaterno = "";
            usuarioVM.ApellidoMaterno = "";

            usuarioVM.Empresa = $.trim(inicializador.controles.txtEmpresa.val());
            usuarioVM.Usuario = $.trim(inicializador.controles.txtUsuario.val());
        }
        
        usuarioVM.Direccion = $.trim(inicializador.controles.txtDireccion.val());
        usuarioVM.Email = $.trim(inicializador.controles.txtEmail.val());
        usuarioVM.CodigoPostal = $.trim(inicializador.controles.txtCodigoPostal.val());
        usuarioVM.Telefono1 = $.trim(inicializador.controles.TxtTelefono.val());
        usuarioVM.Telefono2 = $.trim(inicializador.controles.TxtTelefonoOpcional.val());
        
        if (usuarioVM.Id != "")
        {
            inicializador.editaUsuario(usuarioVM);
            return;
        }

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
    editaUsuario: function (usuarioVM) {
        $.ajax({
            type: 'POST',
            async: false,
            url: "/Admin/EditaUsuario", // we are calling json method
            //dataType: 'json',
            data: usuarioVM,
            success: function (result) {

            },
            error: function (ex) {

            }
        });
    },
    eliminaUsuario: function (IdUsuario) {
        $.ajax({
            type: 'Delete',
            async: false,
            url: "/Admin/EliminaUsuario/", // we are calling json method
            //dataType: 'json',
            data: { idUsuario: IdUsuario },
            success: function (result) {
                location.reload();
            },
            error: function (ex) {

            }
        });
    },
    cancelarUsuario: function () {
        inicializador.LimpiaUsuarioForm();
    },
    LimpiaUsuarioForm: function () {
        inicializador.controles.txtIdUsuario.val('');
        inicializador.controles.txtNombre.val('');
        inicializador.controles.txtApellidoPat.val('');
        inicializador.controles.txtApellidoMat.val('');
        inicializador.controles.txtIdEmpresa.val('');
        inicializador.controles.txtNombreEmpresa.val('');
        inicializador.controles.txtUsuario.val('');
        inicializador.controles.txtDireccion.val('');
        inicializador.controles.txtCodigoPostal.val('');
        inicializador.controles.TxtTelefono.val('');
        inicializador.controles.TxtTelefonoOpcional.val('');
        inicializador.controles.chkActivo[0].checked = false;
    },
    init: function () {
        inicializador.inicializarEventos();
    }
}

inicializador.init();