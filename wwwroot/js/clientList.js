var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({

        "lengthMenu": [[5, 10, 25, -1], [5, 10, 25, "All"]],
        "pageLength": 5,
        "ajax": {
            "url": "/api/client",
            "type": "GET",
            "datatype": "json"
            
        },
        "columns": [
            { "data": "clientName", "width": "20%" },
            { "data": "clientAddress", "width":"20%" },
            { "data": "contactName", "width": "20%" },
            { "data": "contactPhone", "width": "20%" },
            //{ "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-left">
                          <a href="/ClientList/Edit?id=${data}" class='btn btn-success  text-white' style='cursor:pointer; width:40px;'>
                              <i class="fas fa-edit"></i>
                          </a>
                           &nbsp;
                            <a class='btn btn-danger text-white' style='cursor:pointer; width:40px;'
                             onclick=Delete('/api/client?id='+${data})>
                             <i class="far fa-trash-alt"></i>
                          </a>

                          &nbsp;
                            <a asp-controller="Projects" asp-action="Create" class='btn btn-primary text-white' style='cursor:pointer; width:84px;'>
                              <i class="fas fa-plus"></i>Project
                          </a>

                          </div>`;
                }, "width": "100%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success == true) {
                        toastr.success(data.message);
                        //toastr["success"](data.message);
                        toastr.options = {
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut",
                            "progressBar": true
                        }
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                        //toastr["error"](data.message);
                    }

                }
            });
        }
    });
}