//Clase Controladora de la vista Product.cshtml

function ProductViewController() {

    this.viewName = "Products";
    this.API_ControllerName = "Product";

    this.InitView = function () {
        this.LoadTable();

        //Asociar eventos a los botones
        $('#btnCreate').click(function () {
            var vc = new ProductViewController();
            vc.Create();
        });

        $('#btnUpdate').click(function () {
            var vc = new ProductViewController();
            vc.Update();
        });

        $('#btnDelete').click(function () {
            var vc = new ProductViewController();
            vc.Delete();
        });
    }

    this.LoadTable = function () {
        var ca = new ControlActions();
        var endpoint = this.API_ControllerName + "/RetrieveAll";
        var urlService = ca.GetUrlApiService(endpoint);

        var colums = [];
        colums[0] = { 'data': 'id', 'title': 'Id' };
        colums[1] = { 'data': 'name', 'title': 'Nombre' };
        colums[2] = { 'data': 'description', 'title': 'Descripción' };
        colums[3] = {
            'data': 'price',
            'title': 'Precio',
            'render': function (data, type, row) {
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

        //Evento para mapear DTO seleccionado al formulario
        $('#tblProducts tbody').on('click', 'tr', function () {
            var row = $(this).closest('tr');
            var productDTO = $('#tblProducts').DataTable().row(row).data();

            $('#txtId').val(productDTO.id);
            $('#txtName').val(productDTO.name);
            $('#txtDescription').val(productDTO.description);
            $('#txtPrice').val(productDTO.price);
            $('#txtQuantity').val(productDTO.quantity);
            $('#txtCategory').val(productDTO.category);
        });
    }

    //Método de creación
    this.Create = function () {
        var productDTO = {};
        productDTO.id = 0;
        productDTO.created = new Date().toISOString();
        productDTO.updated = new Date().toISOString();

        productDTO.name = $('#txtName').val();
        productDTO.description = $('#txtDescription').val();
        productDTO.price = $('#txtPrice').val();
        productDTO.quantity = $('#txtQuantity').val();
        productDTO.category = $('#txtCategory').val();

        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Create";
        ca.PostToAPI(urlEndpoint, productDTO, function () {
            $('#tblProducts').DataTable().ajax.reload();
        });
    }

    //Método de actualización
    this.Update = function () {
        var productDTO = {};
        productDTO.id = $('#txtId').val();
        productDTO.updated = new Date().toISOString();
        productDTO.created = new Date().toISOString();

        productDTO.name = $('#txtName').val();
        productDTO.description = $('#txtDescription').val();
        productDTO.price = $('#txtPrice').val();
        productDTO.quantity = $('#txtQuantity').val();
        productDTO.category = $('#txtCategory').val();

        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Update";
        ca.PutToAPI(urlEndpoint, productDTO, function () {
            $('#tblProducts').DataTable().ajax.reload();
        });
    }

    //Método de eliminación
    this.Delete = function () {
        var productDTO = {};
        productDTO.id = $('#txtId').val();
        productDTO.name = $('#txtName').val();
        productDTO.description = $('#txtDescription').val();
        productDTO.price = $('#txtPrice').val();
        productDTO.quantity = $('#txtQuantity').val();
        productDTO.category = $('#txtCategory').val();

        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Delete";
        ca.DeleteToAPI(urlEndpoint, productDTO, function () {
            $('#tblProducts').DataTable().ajax.reload();
        });
    }
}

//Instancia y render del controlador
$(document).ready(function () {
    var vc = new ProductViewController();
    vc.InitView();
});
