$(document).ready(function () {
    $.ajax({
        url: '/ToDoLists/BuildToDoTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }
    });
});