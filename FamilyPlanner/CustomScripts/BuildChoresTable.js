$(document).ready(function () {
    $.ajax({
        url: '/Chores/BuildChoresTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }
    });
});