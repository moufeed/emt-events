 


$(document).ready(function () {
    window.UsersTable = $('#UsersTable').DataTable({
        "serverSide": true,
        "lengthChange": false,
        drawCallback : function(settings, json) {
                $('.btn-viewgit').tooltip();
        },
        responsive: true,
        "language": {
            "emptyTable": "<div class='empty_table'> <i class='fa fa fa-exclamation-circle'></i><p>No data available in table</p></div>",
            "processing": "Loading..."
        },
        "searching": false,
        //"processing": true,
        "orderMulti": false,
        "ajax": {
            "url": "/Admin/Users/GetUsersAsync",
            "type": "POST",
            "datatype": "json",
            "data": function (data) { 
                data.usermodel = {
                    username: $('#Username').val(),
                    rolename: $('#UserRole').val(),
                    PageNumber: (data.start == 0) ? 1 : data.start / data.length,
                    PageSize: data.length 
                }
            }
        },
        /* "order": [
            [1, 'asc']
        ], */
        "ordering": false,
        "columnDefs": [ 
            {
                sortable: false,
                orderable: false,
                targets : [0,1,2,3,4,5,6],
            },
            {
                
                targets : [0,4,5,6],
                className :  "text-center"
            }

        ],
        "columns": [
            {
                data: null,
                width: "50px",
            },
            {
                "data": "userName"
            },
            {
                "data": "mobileNumber"
            },
            {
                "data": "email"
            },
            {
                data: "isBlocked",
                width: "75",
                render: function (data, type, row, meta) {
                    if (row.isBlocked) {
                        return '<i class="fa fa-times-circle-o c-red"></i>';
                    }
                    return '<i class="fa fa-check c-green"></i>';
                },
            },
            {
                data: "MobileNumberConfirmed",
                width: "75",
                render: function (data, type, row, meta) {
                    if (row.mobileNumberConfirmed) {
                        return '<i class="fa fa-check c-green"></i>';
                    }
                    return '<i class="fa fa-times c-red"></i>';
                }
            },
            {
                width: "75",
                render: function (data, type, row, meta) {
                    return '<a data-toggle="tooltip"' +
                        'data-placement="top"' +
                        'title="Details"' +
                        'href="/Users/Account/' + row.userName + '"' +
                        'class="btn btn-view"><i class="fa fa-eye "></i></a>';
                    /*'<a  href="/Users/Edit/' + row.userName +'" data-toggle="tooltip" data-placement="top" title="Edit"' +
                    'class="btn btn-edit"><i class="fa fa-edit "></i></a>' +
                    '<a data-toggle="tooltip"' +
                    'data-placement="top"' +
                    'data-type="user"' +
                    'data-id="' + row.id + '"' +
                    'data-url="/Users/Delete/' + row.userName + '"' +
                    'title="Remove"' +
                    'class="btn btn-remove" onClick="RemoveItem(UsersTable, this)"><i class="fa fa-times"></i></a>'*/
                }

            }

        ]
    });

    UsersTable.on('draw.dt', function () {
        var PageInfo = $('#UsersTable').DataTable().page.info();
        UsersTable.column(0, {
            search: 'applied',
            order: 'applied'
        }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1 + PageInfo.start;
        });
    }).draw();

    
    $("#searchBtn").on('click', function () {
        UsersTable.clear().draw();
    })
    
    $("#resetBtn").on('click', function () {
        $('#Username').val("");
        $('#UserRole').prop('selectedIndex', 0);
        UsersTable.clear().draw();
    })
    
   
})



