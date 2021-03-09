var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $(document).ready(function () {
       dataTable = $('#table_id').DataTable({
            dom: 'Bfrtip',
            buttons: [
                {
                    extend: 'csv',
                    exportOptions: {
                        columns: [0, 2, 4, 5, 6, 7]
                    }
                },
                {
                    extend: 'excel',
                    exportOptions: {
                        columns: [0, 2, 4, 5, 6, 7]
                    }
                },
                {
                    extend: 'pdf',
                    exportOptions: {
                        columns: [0, 2, 4, 5, 6, 7]
                    }
                }
            ],
            "filter": true,
            "orderMulti": false,
            "ajax": {
                "url": "Person/Get",
                "type": "get",
                "dataSrc": "result"
            },
            "columnDefs": [
                {
                    "targets": [1, 3],
                    "visible": false,
                },
                {
                    "targets": [1, 4, 8],
                    "orderable": false,
                }
            ],
            "columns": [
                {
                    "data": null,
                    "render": function (data, type, row, meta) {
                        return meta.row + meta.settings._iDisplayStart + 1;
                    }
                },
                { "data": 'nik' },
                {
                    "data": null,
                    "render": function (data, type, row) {
                        return row["firstName"] + ' ' + row["lastName"];
                    }
                },
                { "data": 'lastName' },
                {
                    "data": 'phone',
                    "render": function (data, type, row) {
                        var str = data;
                        var re = /^0/;
                        if (re.test(data)) {
                            str = str.replace(re, "+62 ")
                        }
                        return str;
                    }
                },
                {
                    "data": 'birthDate',
                    "render": function (data, type, row) {
                        return moment(data).format('DD MMMM YYYY');
                    }
                },
                { "data": 'salary' },
                { "data": 'email' },
                {
                    data: "id", render: function (data, type, row, meta) {
                        return "<button class='btn btn-success' style='margin-right:5px; onclick=Edit' id='edit'><i class='far fa-edit'></i> Edit</button>"
                            + "<button class='btn btn-danger' style='margin-right:5px; onclick=Delete' id='delete'><i class='far fa-trash-alt'></i> Delete</button>";
                    }
                }
            ]
        });
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
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}