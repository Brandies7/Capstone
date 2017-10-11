$(document).ready(function () {
    $.ajax({
        url: '/ShoppingLists/BuildShoppingTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }
    });
});