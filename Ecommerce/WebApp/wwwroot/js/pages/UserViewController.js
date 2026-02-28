//Clase Controladora de la vista User.cshtml

function UserViewController() {

    this.viewName = "Users";
    this.API_ControllerName = "User";

    this.InitView = function () {
        this.LoadTable();
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

    }

}

//Instancia y render del controlador
$(document).ready(function () {
    var vc = new UserViewController();
    vc.InitView();
})
