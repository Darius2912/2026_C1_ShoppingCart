//Clase Controladora de la vista User.cshtml

function UserViewController() {

    this.viewName = "Users";
    this.API_ControllerName = "User";

    this.InitView = function () {
        this.LoadTable();
        //Asociar el evento de crear al boton 
        $('#btnCreate').click(function () {
            var vc = new UserViewController();
            vc.Create();
        })


        //Asociar el evento de actualizar al boton
        $('#btnUpdate').click(function () {
            var vc = new UserViewController();
            vc.updated();
        })

        //Asociar el evento de eliminar al boton
        $('#btnDelete').click(function () {
            var vc = new UserViewController();
            vc.delete();
        })
    }

    this.LoadTable = function () {

        var ca = new ControlActions();
        var endpoint = this.API_ControllerName + "/RetrieveAll";
        var urlService = ca.GetUrlApiService(endpoint);

        var colums = []
        colums[0] = { 'data': 'id', 'title': 'Id' };
        colums[1] = { 'data': 'name', 'title': 'Nombre' };
        colums[2] = { 'data': '_LastName', 'title': 'Apellidos' };
        colums[3] = {
            'data': 'birthDate',
            'title': 'Fecha de nacimiento',
            'render': function (data, type, row) {
                var date = new Date(data);
                // Solo fecha: dd/MM/yyyy
                return date.toLocaleDateString('es-CR', {
                    day: '2-digit', month: '2-digit', year: 'numeric'
                });
            }
        };
        colums[4] = { 'data': 'status', 'title': 'Estado' };
        colums[5] = {
            'data': 'created',
            'title': 'Registro',
            'render': function (data, type, row) {
                var date = new Date(data);
                // Fecha y hora: dd/MM/yyyy HH:mm
                return date.toLocaleString('es-CR', {
                    day: '2-digit', month: '2-digit', year: 'numeric',
                    hour: '2-digit', minute: '2-digit'
                });
            }
        };

        $('#tblUsers').DataTable({
            "ajax": {
                "url": urlService,
                dataSrc: ''
            },
            "columns": colums
        });

        //Asignar evento de mapeo del dto seleccionado con el form
        $('#tblUsers tbody').on('click', 'tr', function () {
            var row = $(this).closest('tr');

            //extraer el DTO al que se le dio click
            var userDTO = $('#tblUsers').DataTable().row(row).data();

            //Cargar el DTO en el form
            $('#txtId').val(userDTO.id);
            $('#txtName').val(userDTO.name);
            $('#txtLastName').val(userDTO._LastName);
            $('#txtEmail').val(userDTO.email);
            $('#txtStatus').val(userDTO.status);

            //formato de la fecha 
            var onlyDate = userDTO.birthDate.split('T');
            $('#txtBirthDate').val(onlyDate[0]);
        })

        }


    //metodo de creación 
    this.Create = function () {

        var userDTO = {};
        //Set con valores default
        userDTO.id = 0;
        userDTO.updated = "2026-01-01";
        userDTO.created = "2026-01-01";

        //valores que capturamos de pantalla
        userDTO.name = $('#txtName').val();
        userDTO._LastName = $('#txtLastName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.password = $('#txtPwd').val();

        //Enviar al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Create";
        //recargar la tabla 
        ca.PostToAPI(urlEndpoint, userDTO, function () {
            $('#tblUsers').DataTable().ajax.reload();
        })

    }

    this.updated = function () {

        var userDTO = {};
        //Set con valores default
        userDTO.id = 0;
        userDTO.updated = "2026-01-01";
        userDTO.created = "2026-01-01";


        userDTO.id = $('#txtId').val();
        userDTO.updated = "2026-01-01";
        userDTO.created = "2026-01-01";

        //valores que capturamos de pantalla
        userDTO.name = $('#txtName').val();
        userDTO._LastName = $('#txtLastName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.password = $('#txtPwd').val();

        //Enviar al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Update";

        //recargar la tabla 
        ca.PutToAPI(urlEndpoint, userDTO, function () {
            $('#tblUsers').DataTable().ajax.reload();
        })

    }

    this.delete = function () {

        var userDTO = {};
        //Set con valores default

        userDTO.updated = "2026-01-01";
        userDTO.created = "2026-01-01";

        //valores que capturamos de pantalla
        userDTO.id = $('#txtId').val();
        userDTO.name = $('#txtName').val();
        userDTO._LastName = $('#txtLastName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.password = $('#txtPwd').val();

        //Enviar al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Delete";

        //recargar la tabla 
        ca.DeleteToAPI(urlEndpoint, userDTO, function () {
            $('#tblUsers').DataTable().ajax.reload();
        })
    }

}
//Instancia y render del controlador
$(document).ready(function () {
    var vc = new UserViewController();
    vc.InitView();
})
