$(document).ready(function () {
    $(".btn-delete").click(function (event) {
        $("#btn-delete").attr("href", "/Admin/DeleteCategory?id=" + $(this).attr("btn-data"));
    });
});