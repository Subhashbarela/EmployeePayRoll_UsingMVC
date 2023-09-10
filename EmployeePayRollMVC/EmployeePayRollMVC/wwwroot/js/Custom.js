$(document).ready(function () {
    ShowEmployeeData();
});

function ShowEmployeeData()
{ 
   
    $.ajax({
        url: '/Ajax/EmployeeList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.EmployeeId + '</td>';
                object += '<td>' + item.EmployeeName + '</td>';
                object += '<td>' + item.ProfileImage + '</td>';
                object += '<td>' + item.Department + '</td>';
                object += '<td>' + item.Gender + '</td>';
                object += '<td>' + item.Salary + '</td>';
                object += '<td>' + item.StartDate + '</td>';
                object += '<td>' + item.Notes + '</td>';
                object += '<td>' + <a href="#" class="btn btn-primary">Edit</a> || <a href="#" class="btn btn-danger">Delete</a> + '</td>';
                object += '</tr>';
            });
            $('#table_data').thml(object);
        },
        Error: function () {
            alert("Data Can't get");
        }
    });
}