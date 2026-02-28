//Clase Controladora de la vista Product.cshtml

function ProductViewController() {

    this.viewName = "Products";
    this.API_ControllerName = "Product";

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
        colums[2] = { 'data': 'description', 'title': 'Descripción' };
        colums[3] = {
            'data': 'price',
            'title': 'Precio',
            'render': function (data, type, row) {
                // Formato de moneda en colones costarricenses
                return new Intl.NumberFormat('es-CR', { style: 'currency', currency: 'CRC' }).format(data);
            }
        };
        colums[4] = { 'data': 'quantity', 'title': 'Cantidad' };
        colums[5] = { 'data': 'category', 'title': 'Categoría' };
        colums[6] = {
            'data': 'created',
            'title': 'Registro',
            'render': function (data, type, row) {
                var date = new Date(data);
                return date.toLocaleString('es-CR', {
                    day: '2-digit', month: '2-digit', year: 'numeric',
                    hour: '2-digit', minute: '2-digit'
                });
            }
        };

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
