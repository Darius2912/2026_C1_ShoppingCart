//Clase Controladora de la vista Product.cshtml

//Definimos una clase JS usando prototype
function ProductViewController() {

    this.viewName = "Products";
    //Nombre del controlador que consumo en el API del backend
    this.API_ControllerName = "Product";

    //metodo "Constructor"
    this.InitView = function () {
        this.LoadTable();
    }

    //Metodo para cargar la tabla de productos
    this.LoadTable = function () {

        var ca = new ControlActions();
        var endpoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endpoint);

        var colums = []
        colums[0] = { 'data': 'id', 'title': 'Id' };
        colums[1] = { 'data': 'name', 'title': 'Nombre' };
        colums[2] = { 'data': 'description', 'title': 'Descripción' };
        colums[3] = { 'data': 'price', 'title': 'Precio' };
        colums[4] = { 'data': 'quantity', 'title': 'Cantidad' };
        colums[5] = { 'data': 'category', 'title': 'Categoría' };
        colums[6] = { 'data': 'created', 'title': 'Registro' };

        //convertir la tabla plana en una más robusta con DataTables
        $('#tblProducts').DataTable({
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
    var vc = new ProductViewController();
    vc.InitView();
})
