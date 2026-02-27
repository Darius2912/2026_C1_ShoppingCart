

//Clase Controladora de la vista User.cshtml

//Definimos una clase JS usuando protoytpe

function UserViewController() {

    this.viewName = "Users"; 
    //Nombre del controlador que consumo en el API del backend
    this.API_ControllerName = "User"

    //metodo "Constructor"
    this.InitView = function () {
        this.LoadTable();
    }

    //Metodo para cargar la tabla de usuarios
    this.LoadTable = function () {

        var ca = new ControlActions();
        var endpoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endpoint);

        var colums = []
        colums[0] = { 'data': 'id', 'title': 'Id' };
        colums[1] = { 'data': 'name', 'title': 'Nombre' };
        colums[2] = { 'data': '_LastName', 'title': 'Apellidos' };
        colums[3] = { 'data': 'birthDate', 'title': 'Fecha de nacimiento' };
        colums[4] = { 'data': 'status', 'title': 'Estado' };
        colums[5] = { 'data': 'created', 'title': 'Registro' };

        //convertir la tabla plana y fe en una mas bonita y robusta
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