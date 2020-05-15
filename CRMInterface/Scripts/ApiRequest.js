
function getallStaff() {
    $('.staffTable').DataTable({
        ajax:{
            "url": '/Staff/GetAllStaff',
            "type": "GET",
            "dataType": "json",
            "dataSrc": ""
        },
        columns: [
            { "data": "sfirstName", "defaultContent": "<i>Not set</i>" },
            { "data": "slastName", "defaultContent": "<i>Not set</i>" },
            { "data": "sEmail", "defaultContent": "<i>Not set</i>" },
            { "data": "sDesignation", "defaultContent": "<i>Not set</i>" },
            {
                "data": "sDateofBirth", "defaultContent": "<i>Not set</i>", "render": function (data) {
                    var date = changeJsonDateFormat(data);
                    return date;
                }
            },
            { "data": "Gender", "defaultContent": "<i>Not set</i>" },
            {
                "data": "sid", "width": "100px", "render": function (data) {
                    return '<button style="margin-right:5px;" class="btn btn-info btn-sm" onclick="editStaff(' + data + ')" >Edit</button><button class="btn btn-danger btn-sm" onclick="deleteStaff(' + data +')" >Remove</button>';
                }
            }
        ]
    });
}

function editStaff(id) {
    window.location.href = '/Staff/AddEditStaff/' + id;
}

function deleteStaff(id) {
    alertify.confirm('Delete', 'Are You Sure to Delete this Staff ?',
        function () {
            $.ajax({
                url: "/Staff/DeleteStaff/" + id,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $('.staffTable').DataTable().ajax.reload();
                    var successMessage = 'Deleted Successfully';
                    if (successMessage != "") {
                        alertify.success(successMessage);
                    }
                },
            });
            //window.location.href = '/Customer/DeleteCustomer/' + id;
        }, null);
}

function getCustomers() {
    $('.customerTable').DataTable({
        ajax: {
            //"url": "http://localhost:61937/api/customer",
            "url": "/Customer/GetAllCustomer",
            "type": "GET",
            "dataType": "json",
            "dataSrc": ""
        },
        columns: [
            { "data": "FullName", "defaultContent": "<i>Not set</i>" },
            { "data": "Email", "defaultContent": "<i>Not set</i>" },
            { "data": "Contact", "defaultContent": "<i>Not set</i>" },
            { "data": "Gender", "defaultContent": "<i>Not set</i>" },
            { "data": "Staff", "defaultContent": "<i>Not set</i>" },
            {
                "data": "cdateofBirth", "defaultContent": "<i>Not set</i>", "render": function (data) {
                    var date = changeJsonDateFormat(data);
                    return date;
                }
            },
            {
                "data": "Id", "width": "100px", "render": function (data) {
                    return '<button style="margin-right:5px;" class="btn btn-info btn-sm" onclick="editCustomer(' + data + ')" >Edit</button><button class="btn btn-danger btn-sm" onclick="deleteCustomer(' + data + ')" >Remove</button>';
                }
            }
        ]
    });
}

function editCustomer(id) {
    window.location.href = '/Customer/AddEditCustomer/' + id;
}

function deleteCustomer(id) {
    alertify.confirm('Delete', 'Are You Sure to Delete this Record ?',
        function () {
            $.ajax({
                url: "/Customer/DeleteCustomer/" + id,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $('.customerTable').DataTable().ajax.reload();
                    var successMessage = 'Deleted Successfully';
                    if (successMessage != "") {
                        alertify.success(successMessage);
                    }
                },
            });
        //window.location.href = '/Customer/DeleteCustomer/' + id;
        }, null);
}

function getStaffById() {
    var stId = document.getElementById('stfId').value;
    $.ajax({
        type: 'GET',
        url: 'http://localhost:61937/api/staff?Id=' + stId,
        contentType: 'application/json;charset-utf-8',
        dataType: 'json',

        success: function (result) {
            
                var node = document.createElement("LI");
                var textnode = document.createTextNode("Id:" + result.Id + " Email: " + result.Email);
                node.appendChild(textnode);
                document.getElementById("stafflist").appendChild(node);
            

        }
    });
}

function RemoveStaff() {
    var stId = document.getElementById('stfId').value;
    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:61937/api/staff?Id=' + stId,
        contentType: 'application/json;charset-utf-8',
        dataType: 'json',

        success: function (result) {
            alert("Deleted Successfully");
        }
    });
}

function changeJsonDateFormat(jsonDate) {
    var dateString = jsonDate.substr(6);
    var currentTime = new Date(parseInt(dateString));
    var month = currentTime.getMonth() + 1;
    if (month < 10) {
        month = "0" + month;
    }
    var day = currentTime.getDate();
    if (day < 10) {
        day = "0" + day;
    }
    var year = currentTime.getFullYear();
    var date = month + "/" + day + "/" + year;
    return date;
}


function getallProducts() {
    $('.productTable').DataTable({
        ajax: {
            "url": '/Product/GetAllProduct',
            "type": "GET",
            "dataType": "json",
            "dataSrc": ""
        },
        columns: [
            { "data": "Name", "defaultContent": "<i>Not set</i>" },
            { "data": "Price", "defaultContent": "<i>Not set</i>" },
            { "data": "Details", "defaultContent": "<i>Not set</i>" },
            {
                "data": "Id", "width": "100px", "render": function (data) {
                    return '<button style="margin-right:5px;" class="btn btn-info btn-sm" onclick="editProduct(' + data + ')" >Edit</button><button class="btn btn-danger btn-sm" onclick="deleteProduct(' + data + ')" >Remove</button>';
                }
            }
        ]
    });
}

function editProduct(id) {
    window.location.href = '/Product/AddEditProduct/' + id;
}

function deleteProduct(id) {
    alertify.confirm('Delete', 'Are You Sure to Delete this Product ?',
        function () {
            $.ajax({
                url: "/Product/DeleteProduct/" + id,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $('.productTable').DataTable().ajax.reload();
                    var successMessage = 'Deleted Successfully';
                    if (successMessage != "") {
                        alertify.success(successMessage);
                    }
                },
            });
            //window.location.href = '/Customer/DeleteCustomer/' + id;
        }, null);
}
